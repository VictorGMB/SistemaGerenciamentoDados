namespace projeto_banco_de_dados
{
    partial class FrmFornecedor
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TxtFornecedor = new TextBox();
            TxtIdFornecedor = new TextBox();
            TxtCNPJ = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BtnCadastrar = new Button();
            BtnExcluir = new Button();
            BtnAtualizar = new Button();
            LstFornecedores = new ListBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TxtFornecedor
            // 
            TxtFornecedor.Location = new Point(138, 55);
            TxtFornecedor.Name = "TxtFornecedor";
            TxtFornecedor.Size = new Size(302, 23);
            TxtFornecedor.TabIndex = 0;
            // 
            // TxtIdFornecedor
            // 
            TxtIdFornecedor.Enabled = false;
            TxtIdFornecedor.Location = new Point(138, 29);
            TxtIdFornecedor.Name = "TxtIdFornecedor";
            TxtIdFornecedor.Size = new Size(302, 23);
            TxtIdFornecedor.TabIndex = 1;
            // 
            // TxtCNPJ
            // 
            TxtCNPJ.Location = new Point(138, 82);
            TxtCNPJ.Name = "TxtCNPJ";
            TxtCNPJ.Size = new Size(302, 23);
            TxtCNPJ.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 32);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 3;
            label1.Text = "ID Fornecedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 58);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 4;
            label2.Text = "Nome Fornecedor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 84);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 5;
            label3.Text = "CNPJ";
            // 
            // BtnCadastrar
            // 
            BtnCadastrar.Location = new Point(417, 132);
            BtnCadastrar.Name = "BtnCadastrar";
            BtnCadastrar.Size = new Size(104, 22);
            BtnCadastrar.TabIndex = 6;
            BtnCadastrar.Text = "Cadastrar";
            BtnCadastrar.UseVisualStyleBackColor = true;
            BtnCadastrar.Click += BtnCadastrar_Click;
            // 
            // BtnExcluir
            // 
            BtnExcluir.Location = new Point(308, 132);
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new Size(104, 22);
            BtnExcluir.TabIndex = 7;
            BtnExcluir.Text = "Excluir";
            BtnExcluir.UseVisualStyleBackColor = true;
            BtnExcluir.Click += BtnExcluir_Click;
            // 
            // BtnAtualizar
            // 
            BtnAtualizar.Location = new Point(199, 132);
            BtnAtualizar.Name = "BtnAtualizar";
            BtnAtualizar.Size = new Size(104, 22);
            BtnAtualizar.TabIndex = 8;
            BtnAtualizar.Text = "Atualizar";
            BtnAtualizar.UseVisualStyleBackColor = true;
            BtnAtualizar.Click += BtnAtualizar_Click;
            // 
            // LstFornecedores
            // 
            LstFornecedores.FormattingEnabled = true;
            LstFornecedores.ItemHeight = 15;
            LstFornecedores.Location = new Point(48, 175);
            LstFornecedores.Name = "LstFornecedores";
            LstFornecedores.Size = new Size(474, 364);
            LstFornecedores.TabIndex = 9;
            LstFornecedores.Click += LstFornecedores_Click;
            LstFornecedores.SelectedIndexChanged += LstFornecedores_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TxtIdFornecedor);
            panel1.Controls.Add(TxtFornecedor);
            panel1.Controls.Add(TxtCNPJ);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(48, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 113);
            panel1.TabIndex = 10;
            // 
            // FrmFornecedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 627);
            Controls.Add(BtnAtualizar);
            Controls.Add(BtnExcluir);
            Controls.Add(BtnCadastrar);
            Controls.Add(panel1);
            Controls.Add(LstFornecedores);
            Name = "FrmFornecedor";
            Text = "Cadastro de Fornecedores";
            Load += FrmFornecedor_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox TxtFornecedor;
        private System.Windows.Forms.TextBox TxtIdFornecedor;
        private System.Windows.Forms.TextBox TxtCNPJ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCadastrar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAtualizar;
        private System.Windows.Forms.ListBox LstFornecedores;
        private System.Windows.Forms.Panel panel1;
    }
}