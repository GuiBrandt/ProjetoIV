using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto4
{
    /// <summary>
    /// Formulário principal
    /// </summary>
    public partial class FormPrincipal : Form
    {
        /// <summary>
        /// Grafo de cidades
        /// </summary>
        Grafo<Cidade> grafo;

        /// <summary>
        /// Caminho entre cidades a ser destacado no desenho
        /// </summary>
        List<Cidade> caminho;

        /// <summary>
        /// Construtor
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manter cidades
        /// </summary>
        private void btnManterCidades_Click(object sender, EventArgs e)
        {
            new FormManterCidades().ShowDialog(this);
            LerGrafo();
        }

        /// <summary>
        /// Carrega o grafo dos arquivos
        /// </summary>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            LerGrafo();
        }

        /// <summary>
        /// Lê o grafo dos arquivos cidades.dat e arestas.dat
        /// </summary>
        private void LerGrafo()
        {
            grafo = new Grafo<Cidade>();

            using (var arq = new ArquivoRegistro<Cidade>("cidades.dat", System.IO.FileMode.OpenOrCreate))
            {
                Cidade cid;
                while ((cid = arq.LerUm()) != null)
                    grafo.AdicionarVertice(cid);
            }

            using (var arq = new ArquivoRegistro<Aresta<Cidade>>("arestas.dat", System.IO.FileMode.OpenOrCreate))
            {
                Aresta<Cidade> aresta;
                while ((aresta = arq.LerUm()) != null)
                    grafo.AdicionarAresta(aresta);
            }

            canvasGrafo.Invalidate();
        }

        /// <summary>
        /// Desenho da tela do grafo
        /// </summary>
        private void canvasGrafo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            List<Cidade> vertices = new List<Cidade>(grafo.Vertices);

            PointF centro = new PointF(g.ClipBounds.Width / 2, g.ClipBounds.Height / 2);
            double raio = Math.Min(g.ClipBounds.Width / 2, g.ClipBounds.Height / 2) - 10;

            List<PointF> posicoes = new List<PointF>();

            // Desenha os vértices na forma de um polígono regular
            SizeF tamanho = new SizeF(12, 12);

            for (int i = 0; i < vertices.Count; i++)
            {
                double angulo = Math.PI * 2 / vertices.Count * i;

                PointF pos = new PointF(
                    (float)(centro.X + Math.Cos(angulo) * raio),
                    (float)(centro.Y + Math.Sin(angulo) * raio)
                );

                posicoes.Add(pos);

                pos -= new SizeF(tamanho.Width / 2, tamanho.Height / 2);

                // Desenha a bolinha
                g.FillEllipse(Brushes.Blue, new RectangleF(pos, tamanho));

                // Escreve o nome da cidade
                pos += new SizeF(tamanho.Width, 0);
                TextRenderer.DrawText(g, vertices[i].ToString(), Font, Point.Round(pos), Color.Black, Color.White);
            }

            // Desenha as ligações entre os vértices
            foreach (Aresta<Cidade> aresta in grafo.Arestas)
            {
                PointF pA = posicoes[vertices.IndexOf(aresta.Origem)],
                       pB = posicoes[vertices.IndexOf(aresta.Destino)];

                // Desenha a seta
                using (Pen p = new Pen(Color.Red, (float)Math.Sqrt(aresta.Valor)))
                {
                    p.StartCap = LineCap.Round;
                    p.CustomEndCap = new AdjustableArrowCap(4 + p.Width, 4 + p.Width);
                    g.DrawLine(p, pA, pB);
                }

                // Escreve o peso
                SizeF sz = TextRenderer.MeasureText(aresta.Valor.ToString(), Font);
                PointF meio = new PointF((pA.X + pB.X - sz.Width) / 2, (pA.Y + pB.Y - sz.Height) / 2);
                TextRenderer.DrawText(g, aresta.Valor.ToString(), Font, Point.Round(meio), Color.Black, Color.White);
            }
        }

        /// <summary>
        /// Redesenha o grafo quando mover o splitter
        /// </summary>
        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            canvasGrafo.Invalidate();
        }
    }
}
