using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto4
{
    /// <summary>
    /// Formulário para manutenção das cidades e ligações
    /// </summary>
    public partial class FormManterCidades : Form
    {
        /// <summary>
        /// Raio dos nós da árvore
        /// </summary>
        const float TREE_NODE_RADIUS = 12;

        /// <summary>
        /// Ângulo (em graus) entre nós da árvore
        /// </summary>
        const float TREE_ANGLE_DEGREES = 75;

        /// <summary>
        /// Tamanho das arestas da árvore
        /// </summary>
        const float TREE_EDGE_LENGTH = 64;

        /// <summary>
        /// Variação do tamanho das arestas da árvore
        /// </summary>
        const float TREE_EDGE_VARIATION = 6;

        /// <summary>
        /// Árvore de cidades
        /// </summary>
        ArvoreBinaria<Cidade> cidades;

        /// <summary>
        /// Lista de arestas
        /// </summary>
        List<Aresta<Cidade>> arestas;

        /// <summary>
        /// Construtor
        /// </summary>
        public FormManterCidades()
        {
            InitializeComponent();

            LerCidades();
            LerArestas();

            AtualizarComboBoxes();
        }

        /// <summary>
        /// Lê o arquivo de cidades e monta uma árvore binária de busca com ele
        /// </summary>
        private void LerCidades()
        {
            cidades = new ArvoreBinaria<Cidade>();

            List<Cidade> vetor = new List<Cidade>();

            using (var arq = new ArquivoRegistro<Cidade>("cidades.dat", FileMode.OpenOrCreate))
            {
                Cidade cidade;
                while ((cidade = arq.LerUm()) != null)
                    vetor.Add(cidade);
            }

            Particionar(ref vetor, 0, vetor.Count - 1);
        }

        /// <summary>
        /// Particiona um vetor de cidades e monta a árvore
        /// </summary>
        /// <param name="vetor">Vetor de cidades</param>
        /// <param name="inicio">Posição inicial</param>
        /// <param name="fim">Posição final</param>
        private void Particionar(ref List<Cidade> vetor, int inicio, int fim)
        {
            if (inicio > fim)
                return;

            int meio = (inicio + fim) / 2;
            cidades.Adicionar(vetor[meio]);

            Particionar(ref vetor, inicio, meio - 1);
            Particionar(ref vetor, meio + 1, fim);
        }

        /// <summary>
        /// Lê o arquivo de arestas e monta uma lista com ele
        /// </summary>
        private void LerArestas()
        {
            arestas = new List<Aresta<Cidade>>();

            using (var arq = new ArquivoRegistro<Aresta<Cidade>>("arestas.dat", FileMode.OpenOrCreate))
            {
                Aresta<Cidade> aresta;
                while ((aresta = arq.LerUm()) != null)
                    arestas.Add(aresta);
            }
        }

        /// <summary>
        /// Insere uma cidade na árvore de cidades
        /// </summary>
        private void btnInserir_Click(object sender, EventArgs e)
        {
            Cidade cidade = new Cidade(txtNomeCidade.Text);

            if (cidades.Existe(cidade))
            {
                MessageBox.Show(this, "Já existe uma cidade com este nome", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cidades.Adicionar(cidade);

                Atualizar();
            }
        }

        /// <summary>
        /// Atualiza as informações do formulário
        /// </summary>
        private void Atualizar()
        {
            SalvarCidades();
            LerCidades();

            AtualizarComboBoxes();
            canvasArvore.Invalidate();
        }

        /// <summary>
        /// Atualiza os comboboxes do form com as cidades existentes
        /// </summary>
        private void AtualizarComboBoxes()
        {
            cbCidadeRemover.Items.Clear();
            cbOrigem.Items.Clear();
            cbDestino.Items.Clear();

            List<Cidade> listaCidades = new List<Cidade>();
            cidades.PercorrerEmOrdem((Cidade cidade) => listaCidades.Add(cidade));  // Foi mal

            if (listaCidades.Count == 0)
            {
                gbRemover.Enabled = gbLigacoes.Enabled = false;

                return;
            }

            gbRemover.Enabled = gbLigacoes.Enabled = true;

            cbCidadeRemover.Items.AddRange(listaCidades.ToArray());
            cbOrigem.Items.AddRange(listaCidades.ToArray());
            cbDestino.Items.AddRange(listaCidades.ToArray());

            cbCidadeRemover.SelectedIndex = cbOrigem.SelectedIndex = cbDestino.SelectedIndex = 0;
        }

        /// <summary>
        /// Botão de remover cidade
        /// </summary>
        private void btnRemover_Click(object sender, EventArgs e)
        {
            cidades.Remover((Cidade)cbCidadeRemover.SelectedItem);
            Atualizar();
        }

        /// <summary>
        /// Cria uma aresta entre duas cidades
        /// </summary>
        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (cbOrigem.SelectedItem == cbDestino.SelectedItem)
            {
                MessageBox.Show(this, "Não pode criar aresta de uma cidade para ela mesma", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Aresta<Cidade> nova = new Aresta<Cidade>((Cidade)cbOrigem.SelectedItem, (Cidade)cbDestino.SelectedItem, (int)numPeso.Value);

            // Procura por uma aresta que tenha a mesma origem e destino
            Aresta<Cidade> existente = arestas.Find(
                (Aresta<Cidade> a) => a.Destino.Equals(nova.Destino) && a.Origem.Equals(nova.Origem)  // Ai
            );

            // Se existir, sugere mudar o peso dela
            if (existente != null)
            {
                DialogResult r = MessageBox.Show(this, "Já existe uma aresta ligando estas cidade. Deseja mudar seu peso?", Text, MessageBoxButtons.YesNo);

                if (r == DialogResult.Yes)
                    arestas[arestas.IndexOf(existente)] = nova;

                return;
            }

            // Se não, cria a aresta
            arestas.Add(nova);
        }

        /// <summary>
        /// Desenha uma árvore binária recursivamente
        /// </summary>
        /// <param name="origin">Origem do desenho</param>
        /// <param name="raiz">Raíz da árvore a ser desenhada</param>
        /// <param name="g">Instância de Graphics para desenho</param>
        /// <param name="nivel">Nível da árvore sendo desenhado</param>
        private void DesenharArvore(PointF origin, NoArvore<Cidade> raiz, Graphics g, int nivel = 0)
        {
            if (raiz == null)
                return;

            // Cálculo do ângulo de abertura da árvore em radianos
            double rad = (TREE_ANGLE_DEGREES / Math.Pow(2, nivel)) * Math.PI / 180;

            float len = TREE_EDGE_LENGTH - TREE_EDGE_VARIATION * nivel;

            // Calcula a posição para os nós esquerdo e direito
            PointF left = new PointF(
                origin.X + (float)(Math.Cos(Math.PI / 2 + rad) * len),
                origin.Y + (float)(Math.Sin(Math.PI / 2 + rad) * len)
            );

            PointF right = new PointF(
                origin.X + (float)(Math.Cos(Math.PI / 2 - rad) * len),
                origin.Y + (float)(Math.Sin(Math.PI / 2 - rad) * len)
            );

            // Desenha as linhas para os nós filhos
            using (Pen outline = new Pen(Color.White, 5))
            {
                if (raiz.Esquerda != null)
                {
                    g.DrawLine(outline, origin, left);
                    g.DrawLine(Pens.Red, origin, left);
                }

                if (raiz.Direita != null)
                {
                    g.DrawLine(outline, origin, right);
                    g.DrawLine(Pens.Red, origin, right);
                }
            }

            // Desenha o círculo para a raíz
            float r = TREE_NODE_RADIUS;
            RectangleF rect = new RectangleF(origin.X - r / 2, origin.Y - r / 2, r, r);
            g.FillEllipse(Brushes.Blue, rect);

            using (Pen p = new Pen(Color.White, 2))
                g.DrawEllipse(p, rect);

            // Desenha o nome da cidade
            TextRenderer.DrawText(
                g,
                raiz.Info.ToString(),
                Font,
                new Point((int)origin.X, (int)origin.Y),
                Color.Black, Color.White
            );

            // Chama o procedimento para os nós filhos
            DesenharArvore(left, raiz.Esquerda, g, nivel + 1);
            DesenharArvore(right, raiz.Direita, g, nivel + 1);            
        }

        /// <summary>
        /// Desenho do canvas da árvore
        /// </summary>
        private void canvasArvore_Paint(object sender, PaintEventArgs e)
        {
            DesenharArvore(new PointF(canvasArvore.Width / 2, 10), cidades.Raiz, e.Graphics);
        }

        /// <summary>
        /// Fechamento do form. Salva os arquivos.
        /// </summary>
        private void FormManterCidades_FormClosed(object sender, FormClosedEventArgs e)
        {
            SalvarCidades();
            SalvarArestas();
        }

        /// <summary>
        /// Salva as arestas no arquivo de arestas
        /// </summary>
        private void SalvarArestas()
        {
            using (var arq = new ArquivoRegistro<Aresta<Cidade>>("arestas.dat", FileMode.Create))
                foreach (Aresta<Cidade> aresta in arestas)
                    arq.Escrever(aresta);
        }

        /// <summary>
        /// Salva as cidades no arquivo de cidades
        /// </summary>
        private void SalvarCidades()
        {
            using (ArquivoRegistro<Cidade> arq = new ArquivoRegistro<Cidade>("cidades.dat", FileMode.Create))
                cidades.PercorrerEmOrdem((Cidade cid) => arq.Escrever(cid));    // :/
        }

        /// <summary>
        /// Redesenha a árvore
        /// </summary>
        private void canvasArvore_MouseMove(object sender, MouseEventArgs e)
        {
            canvasArvore.Invalidate();
        }
    }
}
