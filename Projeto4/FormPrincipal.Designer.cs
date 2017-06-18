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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.cbOrigem = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.canvasGrafo = new System.Windows.Forms.PictureBox();
            this.rdRecursao = new System.Windows.Forms.RadioButton();
            this.rdBacktracking = new System.Windows.Forms.RadioButton();
            this.rdDijkstra = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvasGrafo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnManterCidades
            // 
            this.btnManterCidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManterCidades.Location = new System.Drawing.Point(490, 12);
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.canvasGrafo);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 396);
            this.panel1.TabIndex = 4;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Origem:";
            // 
            // cbDestino
            // 
            this.cbDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(56, 27);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(146, 21);
            this.cbDestino.TabIndex = 3;
            // 
            // cbOrigem
            // 
            this.cbOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigem.FormattingEnabled = true;
            this.cbOrigem.Location = new System.Drawing.Point(56, 0);
            this.cbOrigem.Name = "cbOrigem";
            this.cbOrigem.Size = new System.Drawing.Size(146, 21);
            this.cbOrigem.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(371, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 396);
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
            this.canvasGrafo.Size = new System.Drawing.Size(371, 396);
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
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbOrigem);
            this.panel2.Controls.Add(this.cbDestino);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(374, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 396);
            this.panel2.TabIndex = 6;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 449);
            this.Controls.Add(this.rdDijkstra);
            this.Controls.Add(this.rdBacktracking);
            this.Controls.Add(this.rdRecursao);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnManterCidades);
            this.Name = "FormPrincipal";
            this.Text = "Projeto 4";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvasGrafo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Panel panel2;
    }
}

