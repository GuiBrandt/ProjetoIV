﻿namespace Projeto4
{
    partial class FormManterCidades
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeCidade = new System.Windows.Forms.TextBox();
            this.gbInserir = new System.Windows.Forms.GroupBox();
            this.btnInserir = new System.Windows.Forms.Button();
            this.gbRemover = new System.Windows.Forms.GroupBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.cbCidadeRemover = new System.Windows.Forms.ComboBox();
            this.gbLigacoes = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numPeso = new System.Windows.Forms.NumericUpDown();
            this.btnCriar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.cbOrigem = new System.Windows.Forms.ComboBox();
            this.canvasArvore = new System.Windows.Forms.PictureBox();
            this.gbInserir.SuspendLayout();
            this.gbRemover.SuspendLayout();
            this.gbLigacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasArvore)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // txtNomeCidade
            // 
            this.txtNomeCidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeCidade.Location = new System.Drawing.Point(50, 16);
            this.txtNomeCidade.Name = "txtNomeCidade";
            this.txtNomeCidade.Size = new System.Drawing.Size(290, 20);
            this.txtNomeCidade.TabIndex = 1;
            // 
            // gbInserir
            // 
            this.gbInserir.Controls.Add(this.btnInserir);
            this.gbInserir.Controls.Add(this.label1);
            this.gbInserir.Controls.Add(this.txtNomeCidade);
            this.gbInserir.Location = new System.Drawing.Point(12, 12);
            this.gbInserir.Name = "gbInserir";
            this.gbInserir.Size = new System.Drawing.Size(346, 77);
            this.gbInserir.TabIndex = 2;
            this.gbInserir.TabStop = false;
            this.gbInserir.Text = "Inserir Cidade";
            // 
            // btnInserir
            // 
            this.btnInserir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserir.Location = new System.Drawing.Point(265, 42);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 2;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // gbRemover
            // 
            this.gbRemover.Controls.Add(this.btnRemover);
            this.gbRemover.Controls.Add(this.cbCidadeRemover);
            this.gbRemover.Location = new System.Drawing.Point(12, 95);
            this.gbRemover.Name = "gbRemover";
            this.gbRemover.Size = new System.Drawing.Size(346, 50);
            this.gbRemover.TabIndex = 3;
            this.gbRemover.TabStop = false;
            this.gbRemover.Text = "Remover Cidade";
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemover.Location = new System.Drawing.Point(265, 17);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 1;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // cbCidadeRemover
            // 
            this.cbCidadeRemover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCidadeRemover.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCidadeRemover.FormattingEnabled = true;
            this.cbCidadeRemover.Location = new System.Drawing.Point(9, 19);
            this.cbCidadeRemover.Name = "cbCidadeRemover";
            this.cbCidadeRemover.Size = new System.Drawing.Size(250, 21);
            this.cbCidadeRemover.TabIndex = 0;
            // 
            // gbLigacoes
            // 
            this.gbLigacoes.Controls.Add(this.label4);
            this.gbLigacoes.Controls.Add(this.numPeso);
            this.gbLigacoes.Controls.Add(this.btnCriar);
            this.gbLigacoes.Controls.Add(this.label3);
            this.gbLigacoes.Controls.Add(this.label2);
            this.gbLigacoes.Controls.Add(this.cbDestino);
            this.gbLigacoes.Controls.Add(this.cbOrigem);
            this.gbLigacoes.Location = new System.Drawing.Point(12, 151);
            this.gbLigacoes.Name = "gbLigacoes";
            this.gbLigacoes.Size = new System.Drawing.Size(346, 127);
            this.gbLigacoes.TabIndex = 4;
            this.gbLigacoes.TabStop = false;
            this.gbLigacoes.Text = "Ligações";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Peso:";
            // 
            // numPeso
            // 
            this.numPeso.Location = new System.Drawing.Point(58, 72);
            this.numPeso.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPeso.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPeso.Name = "numPeso";
            this.numPeso.Size = new System.Drawing.Size(72, 20);
            this.numPeso.TabIndex = 7;
            this.numPeso.ThousandsSeparator = true;
            this.numPeso.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(265, 98);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(75, 23);
            this.btnCriar.TabIndex = 6;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Destino:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Origem:";
            // 
            // cbDestino
            // 
            this.cbDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(58, 46);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(282, 21);
            this.cbDestino.TabIndex = 3;
            // 
            // cbOrigem
            // 
            this.cbOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigem.FormattingEnabled = true;
            this.cbOrigem.Location = new System.Drawing.Point(58, 19);
            this.cbOrigem.Name = "cbOrigem";
            this.cbOrigem.Size = new System.Drawing.Size(282, 21);
            this.cbOrigem.TabIndex = 2;
            // 
            // canvasArvore
            // 
            this.canvasArvore.BackColor = System.Drawing.Color.White;
            this.canvasArvore.Location = new System.Drawing.Point(364, 12);
            this.canvasArvore.Name = "canvasArvore";
            this.canvasArvore.Size = new System.Drawing.Size(359, 266);
            this.canvasArvore.TabIndex = 5;
            this.canvasArvore.TabStop = false;
            this.canvasArvore.Paint += new System.Windows.Forms.PaintEventHandler(this.canvasArvore_Paint);
            this.canvasArvore.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvasArvore_MouseMove);
            // 
            // FormManterCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 288);
            this.Controls.Add(this.canvasArvore);
            this.Controls.Add(this.gbLigacoes);
            this.Controls.Add(this.gbRemover);
            this.Controls.Add(this.gbInserir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormManterCidades";
            this.Text = "Manter Cidades";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormManterCidades_FormClosed);
            this.gbInserir.ResumeLayout(false);
            this.gbInserir.PerformLayout();
            this.gbRemover.ResumeLayout(false);
            this.gbLigacoes.ResumeLayout(false);
            this.gbLigacoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasArvore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeCidade;
        private System.Windows.Forms.GroupBox gbInserir;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.GroupBox gbRemover;
        private System.Windows.Forms.ComboBox cbCidadeRemover;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.GroupBox gbLigacoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.ComboBox cbOrigem;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPeso;
        private System.Windows.Forms.PictureBox canvasArvore;
    }
}