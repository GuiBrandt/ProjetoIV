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
    /// Formulário principal
    /// </summary>
    public partial class FormPrincipal : Form
    {
        /// <summary>
        /// Grafo de cidades
        /// </summary>
        Grafo<Cidade> cidades;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnManterCidades_Click(object sender, EventArgs e)
        {
            new FormManterCidades().ShowDialog(this);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
