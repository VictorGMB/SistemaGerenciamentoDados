namespace projeto_banco_de_dados
{
    partial class FrmProduto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            TxtProduto = new TextBox();
            TxtIdProduto = new TextBox();
            TxtIdFornecedor = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BtnCadastrar = new Button();
            BtnExcluir = new Button();
            BtnAtualizar = new Button();
            LstProdutos = new ListBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();

            TxtProduto.Location = new Point(138, 55);
            TxtProduto.Name = "TxtProduto";
            TxtProduto.Size = new Size(302, 23);
            TxtProduto.TabIndex = 0;

            TxtIdProduto.Enabled = false;
            TxtIdProduto.Location = new Point(138, 29);
            TxtIdProduto.Name = "TxtIdProduto";
            TxtIdProduto.Size = new Size(302, 23);
            TxtIdProduto.TabIndex = 1;

            TxtIdFornecedor.Location = new Point(138, 82);
            TxtIdFornecedor.Name = "TxtIdFornecedor";
            TxtIdFornecedor.Size = new Size(302, 23);
            TxtIdFornecedor.TabIndex = 2;

            label1.AutoSize = true;
            label1.Location = new Point(15, 32);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.Text = "ID Produto";

            label2.AutoSize = true;
            label2.Location = new Point(15, 58);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.Text = "Nome Produto";

            label3.AutoSize = true;
            label3.Location = new Point(15, 84);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.Text = "ID Fornecedor";

            BtnCadastrar.Location = new Point(417, 132);
            BtnCadastrar.Name = "BtnCadastrar";
            BtnCadastrar.Size = new Size(104, 22);
            BtnCadastrar.Text = "Cadastrar";
            BtnCadastrar.UseVisualStyleBackColor = true;
            BtnCadastrar.Click += BtnCadastrar_Click;

            BtnExcluir.Location = new Point(308, 132);
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new Size(104, 22);
            BtnExcluir.Text = "Excluir";
            BtnExcluir.UseVisualStyleBackColor = true;
            BtnExcluir.Click += BtnExcluir_Click;

            BtnAtualizar.Location = new Point(199, 132);
            BtnAtualizar.Name = "BtnAtualizar";
            BtnAtualizar.Size = new Size(104, 22);
            BtnAtualizar.Text = "Atualizar";
            BtnAtualizar.UseVisualStyleBackColor = true;
            BtnAtualizar.Click += BtnAtualizar_Click;

            LstProdutos.FormattingEnabled = true;
            LstProdutos.ItemHeight = 15;
            LstProdutos.Location = new Point(48, 175);
            LstProdutos.Name = "LstProdutos";
            LstProdutos.Size = new Size(474, 364);
            LstProdutos.Click += LstProdutos_Click;
            LstProdutos.SelectedIndexChanged += LstProdutos_SelectedIndexChanged;

            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TxtIdProduto);
            panel1.Controls.Add(TxtProduto);
            panel1.Controls.Add(TxtIdFornecedor);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(48, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 113);

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 627);
            Controls.Add(BtnAtualizar);
            Controls.Add(BtnExcluir);
            Controls.Add(BtnCadastrar);
            Controls.Add(panel1);
            Controls.Add(LstProdutos);
            Name = "FrmProduto";
            Text = "Cadastro de Produtos";
            Load += FrmProduto_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TxtProduto;
        private TextBox TxtIdProduto;
        private TextBox TxtIdFornecedor;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button BtnCadastrar;
        private Button BtnExcluir;
        private Button BtnAtualizar;
        private ListBox LstProdutos;
        private Panel panel1;
    }
}