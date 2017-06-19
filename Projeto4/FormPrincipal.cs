using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
        List<Aresta<Cidade>> caminho = new List<Aresta<Cidade>>();

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

            AtualizarComboBoxes();
            lbCaminhos.Items.Clear();
            caminho.Clear();
        }

        /// <summary>
        /// Atualiza os comboboxes do form com as cidades existentes
        /// </summary>
        private void AtualizarComboBoxes()
        {
            cbOrigem.Items.Clear();
            cbDestino.Items.Clear();

            Cidade[] cidades = grafo.Vertices;

            if (cidades.Length == 0)
            {
                painelCaminhos.Enabled = false;
                return;
            }

            painelCaminhos.Enabled = true;
            
            cbOrigem.Items.AddRange(cidades);
            cbDestino.Items.AddRange(cidades);

            cbOrigem.SelectedIndex = cbDestino.SelectedIndex = 0;
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
            double raio = Math.Min(g.ClipBounds.Width / 2, g.ClipBounds.Height / 2) - 32;

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
                using (Pen p = new Pen(Color.LightGray, (float)Math.Sqrt(aresta.Valor) + (caminho.Contains(aresta) ? 1 : 0)))
                {
                    p.StartCap = LineCap.Round;
                    p.CustomEndCap = new AdjustableArrowCap(4 + p.Width / 2, 4 + p.Width / 2);
                    g.DrawLine(p, pA, pB);
                }

                // Escreve o peso
                SizeF sz = TextRenderer.MeasureText(aresta.Valor.ToString(), Font);
                PointF meio = new PointF((pA.X + pB.X - sz.Width) / 2, (pA.Y + pB.Y - sz.Height) / 2);
                TextRenderer.DrawText(g, aresta.Valor.ToString(), Font, Point.Round(meio), Color.Black, Color.White);
            }

            // Desenha as o caminho destacado
            foreach (Aresta<Cidade> aresta in caminho)
            {
                PointF pA = posicoes[vertices.IndexOf(aresta.Origem)],
                       pB = posicoes[vertices.IndexOf(aresta.Destino)];

                // Desenha a seta
                using (Pen p = new Pen(Color.Red, (float)Math.Sqrt(aresta.Valor) + (caminho.Contains(aresta) ? 1 : 0)))
                {
                    p.StartCap = LineCap.Round;
                    p.CustomEndCap = new AdjustableArrowCap(4 + p.Width / 2, 4 + p.Width / 2);
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

        /// <summary>
        /// Redesenha o grafo quando redimensionar a janela
        /// </summary>
        private void FormPrincipal_ResizeEnd(object sender, EventArgs e)
        {
            canvasGrafo.Invalidate();
        }

        /// <summary>
        /// Redesenha o grafo quando mover a janela
        /// </summary>
        private void FormPrincipal_Move(object sender, EventArgs e)
        {
            canvasGrafo.Invalidate();
        }

        /// <summary>
        /// Procura todos os caminhos entre as cidades 1 e 2 com recursão
        /// </summary>
        /// <param name="origem">Cidade de origem</param>
        /// <param name="destino">Cidade de destino</param>
        /// <param name="percorridos">Lista de cidades percorridas</param>
        /// <returns>Uma lista com o nome das cidades percorridas para se ir de cid1
        /// a cid2 ou null caso não haja caminho entre as duas cidades</returns>
        private Cidade[][] ProcurarCaminhosRecursivo(Cidade origem, Cidade destino, Cidade[] percorridos)
        {
            List<Cidade[]> caminhos = new List<Cidade[]>();

            List<Cidade> percorrido = new List<Cidade>(percorridos);
            Aresta<Cidade>[] saidas = grafo.Saidas(origem);
            percorrido.Add(origem);

            foreach (Aresta<Cidade> aresta in saidas)
            {
                if (aresta.Destino.Equals(destino))
                {
                    caminhos.Add(new Cidade[] { origem, destino });
                }
                else if (!percorrido.Contains(aresta.Destino))
                {
                    Cidade[][] proximos = ProcurarCaminhosRecursivo(aresta.Destino, destino, percorrido.ToArray());

                    if (proximos != null)
                        foreach (Cidade[] proximo in proximos)
                        {
                            List<Cidade> caminho = new List<Cidade>();
                            caminho.Add(origem);
                            caminho.AddRange(proximo);
                            caminhos.Add(caminho.ToArray());
                        }
                }
            }

            return caminhos.Count == 0 ? null : caminhos.ToArray();
        }

        /// <summary>
        /// Procura um caminho entre duas cidades com backtracking
        /// </summary>
        /// <param name="origem">Cidade de origem</param>
        /// <param name="destino">Cidade de destino</param>
        /// <returns>Uma lista das cidades percorridas</returns>
        private Stack<Cidade> ProcurarCaminhoBacktracking(Cidade origem, Cidade destino)
        {
            List<Cidade> passouCidade = new List<Cidade>();
            bool achou = false;
            bool terminou = false;//não tem mais caminhos para procurar
            Stack<Cidade> pilhaCidades = new Stack<Cidade>();
            Cidade cidadeAtual = origem;

            while (!achou && !terminou)
            {
                if (new List<Aresta<Cidade>>(grafo.Saidas(cidadeAtual)).Exists((Aresta<Cidade> a) => a.Destino.Equals(destino)))
                {
                    achou = true;
                    pilhaCidades.Push(cidadeAtual);
                    pilhaCidades.Push(destino);
                }

                else
                {
                    passouCidade.Add(cidadeAtual);
                    bool achouCidadeNova = false;
                    foreach (Aresta<Cidade> saidas in grafo.Saidas(cidadeAtual))
                        if (!passouCidade.Contains(saidas.Destino))
                        {
                            pilhaCidades.Push(cidadeAtual);
                            achouCidadeNova = true;
                            cidadeAtual = saidas.Destino;
                            break;
                        }

                    if (!achouCidadeNova)
                        if (pilhaCidades.Count == 0)
                            terminou = true;
                        else
                            cidadeAtual = pilhaCidades.Pop();
                }
            }
            return pilhaCidades;
        }

        /// <summary>
        /// Procura um caminho entre dois nós com dijkstra
        /// </summary>
        /// <param name="origem">Índice do nó de origem</param>
        /// <param name="destino">Índice do nó de destino</param>
        /// <returns>Uma lista com os índices dos nós no caminho</returns>
        List<int> Dijkstra(int origem, int destino)
        {
            var n = grafo.Vertices.Length;

            var distancias = new int[n];
            for (int i = 0; i < n; i++)
            {
                distancias[i] = int.MaxValue;
            }

            distancias[origem] = 0;

            var visitado = new bool[n];
            var anterior = new int?[n];

            while (true)
            {
                var minimaDistancia = int.MaxValue;
                var verticeMinimo = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!visitado[i] && minimaDistancia > distancias[i])
                    {
                        minimaDistancia = distancias[i];
                        verticeMinimo = i;
                    }
                }

                if (minimaDistancia == int.MaxValue)
                {
                    break;
                }

                visitado[verticeMinimo] = true;

                for (int i = 0; i < n; i++)
                {
                    Aresta<Cidade> a = grafo.ArestaEntre(grafo.Vertices[verticeMinimo], grafo.Vertices[i]);
                    int v = a == null ? 0 : a.Valor;

                    if (v > 0)
                    {
                        var menorParaOMinimo = distancias[verticeMinimo];
                        var distanciaParaOProximo = v;

                        var total = menorParaOMinimo + distanciaParaOProximo;

                        if (total < distancias[i])
                        {
                            distancias[i] = total;
                            anterior[i] = verticeMinimo;
                        }
                    }
                }
            }

            if (distancias[destino] == int.MaxValue)
            {
                return null;
            }

            var caminho = new LinkedList<int>();
            int? atual = destino;
            while (atual != null)
            {
                caminho.AddFirst(atual.Value);
                atual = anterior[atual.Value];
            }

            return caminho.ToList();
        }

        /// <summary>
        /// Procura um caminho entre duas cidades com dijkstra
        /// </summary>
        /// <param name="origem">Cidade de origem</param>
        /// <param name="destino">Cidade de destino</param>
        /// <returns>Uma lista das cidades percorridas</returns>
        private string ProcurarCaminhoDijkstra(Cidade origem, Cidade destino)
        {
            List<Cidade> listaVertices = new List<Cidade>(grafo.Vertices);
            List<int> caminho = Dijkstra(listaVertices.IndexOf(origem), listaVertices.IndexOf(destino));

            if (caminho == null)
                return null;

            string resultado = "" + grafo.Vertices[caminho[0]];

            for (int i = 1; i < caminho.Count; i++)
                resultado += "," + grafo.Vertices[caminho[i]];

            return resultado;
        }
        /// <summary>
        /// Encontrar caminhos
        /// </summary>
        private void btnEncontrarCaminhos_Click(object sender, EventArgs e)
        {
            lbCaminhos.Items.Clear();
            caminho.Clear();
            canvasGrafo.Invalidate();

            // Recursão
            if (rdRecursao.Checked)
            {
                if (cbOrigem.SelectedItem == cbDestino.SelectedItem)
                {
                    MessageBox.Show(this, "Selecione um destino diferente", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
                Cidade[][] caminhos = ProcurarCaminhosRecursivo(
                    (Cidade) cbOrigem.SelectedItem,
                    (Cidade) cbDestino.SelectedItem,
                    new Cidade[] { }
                );

                if (caminhos == null)
                    MessageBox.Show(this, "Não há caminhos entre essas cidades", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    foreach (Cidade[] caminho in caminhos)
                    {
                        string c = "" + caminho[0];
                        for (var i = 1; i < caminho.Length; i++)
                            c += "," + caminho[i];

                        lbCaminhos.Items.Add(c);
                    }
            }
            
            // Backtracking
            else if (rdBacktracking.Checked)
            {
                if (cbOrigem.SelectedItem == cbDestino.SelectedItem)
                {
                    MessageBox.Show(this, "Selecione um destino diferente", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Stack<Cidade> caminhoInvertido = ProcurarCaminhoBacktracking(
                                                 (Cidade)cbOrigem.SelectedItem,
                                                 (Cidade)cbDestino.SelectedItem);

                if (caminhoInvertido.Count == 0)
                    MessageBox.Show(this, "Não há caminhos entre essas cidades", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    Stack<Cidade> caminho = new Stack<Cidade>();

                    while (caminhoInvertido.Count != 0)
                        caminho.Push(caminhoInvertido.Pop());

                    string StringCaminho = "" + caminho.Pop();
                    while (caminho.Count != 0)
                        StringCaminho += "," + caminho.Pop().ToString();

                    lbCaminhos.Items.Add(StringCaminho);
                }
            }

            // Dijkstra
            else if (rdDijkstra.Checked)
            {
                if (cbOrigem.SelectedItem == cbDestino.SelectedItem)
                {
                    MessageBox.Show(this, "Selecione um destino diferente", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string caminho = ProcurarCaminhoDijkstra((Cidade)cbOrigem.SelectedItem, (Cidade)cbDestino.SelectedItem);

                if (caminho == null)
                    MessageBox.Show(this, "Não há caminhos entre essas cidades", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    lbCaminhos.Items.Add(caminho);
            }
        }

        /// <summary>
        /// Caminho selecionado
        /// </summary>
        private void lbCaminhos_SelectedIndexChanged(object sender, EventArgs e)
        {
            caminho.Clear();

            if (lbCaminhos.SelectedItem != null)
            {
                string[] c = lbCaminhos.SelectedItem.ToString().Split(',');
                for (int i = 0; i < c.Length - 1; i++)
                {
                    Cidade c1 = new Cidade(c[i]), c2 = new Cidade(c[i + 1]);
                    Aresta<Cidade> aresta = grafo.ArestaEntre(c1, c2);
                    caminho.Add(aresta);
                }
            }

            canvasGrafo.Invalidate();
        }

        /// <summary>
        /// Botão de método de procura selecionado
        /// </summary>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            lbCaminhos.Items.Clear();
            caminho.Clear();

            canvasGrafo.Invalidate();
        }
    }
}
