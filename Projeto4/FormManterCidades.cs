using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        /// Árvore de cidades
        /// </summary>
        ArvoreBinaria<Cidade> cidades;

        /// <summary>
        /// Lista de arestas
        /// </summary>
        List<Aresta> arestas;

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

            using (ArquivoCidades arq = new ArquivoCidades("cidades.dat"))
            {
                Cidade cidade;
                while ((cidade = arq.LerUm()) != null)
                    cidades.Adicionar(cidade);
            }
        }

        /// <summary>
        /// Lê o arquivo de arestas e monta uma lista com ele
        /// </summary>
        private void LerArestas()
        {
            arestas = new List<Aresta>();

            using (ArquivoArestas arq = new ArquivoArestas("arestas.dat"))
            {
                Aresta aresta;
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

                AtualizarComboBoxes();
            }
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
            cidades.PercorrerEmOrdem((Cidade cidade) => listaCidades.Add(cidade));                

            cbCidadeRemover.Items.AddRange(listaCidades.ToArray());
            cbOrigem.Items.AddRange(listaCidades.ToArray());
            cbDestino.Items.AddRange(listaCidades.ToArray());
        }
    }
}
