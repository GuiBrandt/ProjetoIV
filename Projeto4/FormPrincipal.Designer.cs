namespace Projeto4
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnManterCidades = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.painelCaminhos = new System.Windows.Forms.Panel();
            this.lbCaminhos = new System.Windows.Forms.ListBox();
            this.btnEncontrarCaminhos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOrigem = new System.Windows.Forms.ComboBox();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.canvasGrafo = new System.Windows.Forms.PictureBox();
            this.rdRecursao = new System.Windows.Forms.RadioButton();
            this.rdBacktracking = new System.Windows.Forms.RadioButton();
            this.rdDijkstra = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.painelCaminhos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasGrafo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnManterCidades
            // 
            this.btnManterCidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManterCidades.Location = new System.Drawing.Point(687, 12);
            this.btnManterCidades.Name = "btnManterCidades";
            this.btnManterCidades.Size = new System.Drawing.Size(98, 23);
            this.btnManterCidades.TabIndex = 0;
            this.btnManterCidades.Text = "Manter Cidades";
            this.btnManterCidades.UseVisualStyleBackColor = true;
            this.btnManterCidades.Click += new System.EventHandler(this.btnManterCidades_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.painelCaminhos);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.canvasGrafo);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 556);
            this.panel1.TabIndex = 4;
            // 
            // painelCaminhos
            // 
            this.painelCaminhos.Controls.Add(this.lbCaminhos);
            this.painelCaminhos.Controls.Add(this.btnEncontrarCaminhos);
            this.painelCaminhos.Controls.Add(this.label1);
            this.painelCaminhos.Controls.Add(this.label2);
            this.painelCaminhos.Controls.Add(this.cbOrigem);
            this.painelCaminhos.Controls.Add(this.cbDestino);
            this.painelCaminhos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelCaminhos.Location = new System.Drawing.Point(581, 0);
            this.painelCaminhos.Name = "painelCaminhos";
            this.painelCaminhos.Size = new System.Drawing.Size(192, 556);
            this.painelCaminhos.TabIndex = 6;
            // 
            // lbCaminhos
            // 
            this.lbCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCaminhos.FormattingEnabled = true;
            this.lbCaminhos.Location = new System.Drawing.Point(10, 83);
            this.lbCaminhos.Name = "lbCaminhos";
            this.lbCaminhos.Size = new System.Drawing.Size(182, 459);
            this.lbCaminhos.TabIndex = 7;
            this.lbCaminhos.SelectedIndexChanged += new System.EventHandler(this.lbCaminhos_SelectedIndexChanged);
            // 
            // btnEncontrarCaminhos
            // 
            this.btnEncontrarCaminhos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncontrarCaminhos.Location = new System.Drawing.Point(76, 54);
            this.btnEncontrarCaminhos.Name = "btnEncontrarCaminhos";
            this.btnEncontrarCaminhos.Size = new System.Drawing.Size(116, 23);
            this.btnEncontrarCaminhos.TabIndex = 6;
            this.btnEncontrarCaminhos.Text = "Encontrar Caminhos";
            this.btnEncontrarCaminhos.UseVisualStyleBackColor = true;
            this.btnEncontrarCaminhos.Click += new System.EventHandler(this.btnEncontrarCaminhos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Origem:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destino:";
            // 
            // cbOrigem
            // 
            this.cbOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigem.FormattingEnabled = true;
            this.cbOrigem.Location = new System.Drawing.Point(56, 0);
            this.cbOrigem.Name = "cbOrigem";
            this.cbOrigem.Size = new System.Drawing.Size(136, 21);
            this.cbOrigem.TabIndex = 2;
            // 
            // cbDestino
            // 
            this.cbDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(56, 27);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(136, 21);
            this.cbDestino.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(578, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 556);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // canvasGrafo
            // 
            this.canvasGrafo.BackColor = System.Drawing.Color.White;
            this.canvasGrafo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvasGrafo.Dock = System.Windows.Forms.DockStyle.Left;
            this.canvasGrafo.Location = new System.Drawing.Point(0, 0);
            this.canvasGrafo.Name = "canvasGrafo";
            this.canvasGrafo.Size = new System.Drawing.Size(578, 556);
            this.canvasGrafo.TabIndex = 0;
            this.canvasGrafo.TabStop = false;
            this.canvasGrafo.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasGrafo_Paint);
            // 
            // rdRecursao
            // 
            this.rdRecursao.AutoSize = true;
            this.rdRecursao.Checked = true;
            this.rdRecursao.Location = new System.Drawing.Point(12, 15);
            this.rdRecursao.Name = "rdRecursao";
            this.rdRecursao.Size = new System.Drawing.Size(71, 17);
            this.rdRecursao.TabIndex = 5;
            this.rdRecursao.TabStop = true;
            this.rdRecursao.Text = "Recursão";
            this.rdRecursao.UseVisualStyleBackColor = true;
            this.rdRecursao.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rdBacktracking
            // 
            this.rdBacktracking.AutoSize = true;
            this.rdBacktracking.Location = new System.Drawing.Point(89, 15);
            this.rdBacktracking.Name = "rdBacktracking";
            this.rdBacktracking.Size = new System.Drawing.Size(88, 17);
            this.rdBacktracking.TabIndex = 6;
            this.rdBacktracking.Text = "Backtracking";
            this.rdBacktracking.UseVisualStyleBackColor = true;
            this.rdBacktracking.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rdDijkstra
            // 
            this.rdDijkstra.AutoSize = true;
            this.rdDijkstra.Location = new System.Drawing.Point(183, 15);
            this.rdDijkstra.Name = "rdDijkstra";
            this.rdDijkstra.Size = new System.Drawing.Size(60, 17);
            this.rdDijkstra.TabIndex = 7;
            this.rdDijkstra.Text = "Dijkstra";
            this.rdDijkstra.UseVisualStyleBackColor = true;
            this.rdDijkstra.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 609);
            this.Controls.Add(this.rdDijkstra);
            this.Controls.Add(this.rdBacktracking);
            this.Controls.Add(this.rdRecursao);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnManterCidades);
            this.Name = "FormPrincipal";
            this.Text = "Projeto 4";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResizeEnd += new System.EventHandler(this.FormPrincipal_ResizeEnd);
            this.Move += new System.EventHandler(this.FormPrincipal_Move);
            this.panel1.ResumeLayout(false);
            this.painelCaminhos.ResumeLayout(false);
            this.painelCaminhos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasGrafo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnManterCidades;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PictureBox canvasGrafo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.ComboBox cbOrigem;
        private System.Windows.Forms.RadioButton rdRecursao;
        private System.Windows.Forms.RadioButton rdBacktracking;
        private System.Windows.Forms.RadioButton rdDijkstra;
        private System.Windows.Forms.Panel painelCaminhos;
        private System.Windows.Forms.Button btnEncontrarCaminhos;
        private System.Windows.Forms.ListBox lbCaminhos;
    }
}

