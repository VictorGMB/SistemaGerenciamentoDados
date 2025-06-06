namespace projeto_banco_de_dados
{
    partial class FrmVenda
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
            TxtIdVenda = new TextBox();
            TxtIdCliente = new TextBox();
            TxtIdProduto = new TextBox();
            TxtValor = new TextBox();
            TxtIdFuncionario = new TextBox();
            TxtData = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            BtnCadastrar = new Button();
            BtnExcluir = new Button();
            BtnAtualizar = new Button();
            LstVendas = new ListBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TxtIdVenda
            // 
            TxtIdVenda.Enabled = false;
            TxtIdVenda.Location = new Point(138, 10);
            TxtIdVenda.Name = "TxtIdVenda";
            TxtIdVenda.Size = new Size(302, 23);
            TxtIdVenda.TabIndex = 0;
            // 
            // TxtIdCliente
            // 
            TxtIdCliente.Location = new Point(138, 39);
            TxtIdCliente.Name = "TxtIdCliente";
            TxtIdCliente.Size = new Size(302, 23);
            TxtIdCliente.TabIndex = 1;
            // 
            // TxtIdProduto
            // 
            TxtIdProduto.Location = new Point(138, 68);
            TxtIdProduto.Name = "TxtIdProduto";
            TxtIdProduto.Size = new Size(302, 23);
            TxtIdProduto.TabIndex = 2;
            // 
            // TxtValor
            // 
            TxtValor.Location = new Point(138, 97);
            TxtValor.Name = "TxtValor";
            TxtValor.Size = new Size(302, 23);
            TxtValor.TabIndex = 3;
            // 
            // TxtIdFuncionario
            // 
            TxtIdFuncionario.Location = new Point(138, 130);
            TxtIdFuncionario.Name = "TxtIdFuncionario";
            TxtIdFuncionario.Size = new Size(302, 23);
            TxtIdFuncionario.TabIndex = 4;
            // 
            // TxtData
            // 
            TxtData.Location = new Point(138, 159);
            TxtData.Name = "TxtData";
            TxtData.Size = new Size(302, 23);
            TxtData.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 13);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 6;
            label1.Text = "ID Venda";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 42);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 7;
            label2.Text = "ID Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 71);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 8;
            label3.Text = "ID Produto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 100);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 9;
            label4.Text = "Valor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 133);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 10;
            label5.Text = "ID Funcionário";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 165);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 11;
            label6.Text = "Data";
            // 
            // BtnCadastrar
            // 
            BtnCadastrar.Location = new Point(407, 213);
            BtnCadastrar.Name = "BtnCadastrar";
            BtnCadastrar.Size = new Size(104, 22);
            BtnCadastrar.TabIndex = 2;
            BtnCadastrar.Text = "Cadastrar";
            BtnCadastrar.UseVisualStyleBackColor = true;
            BtnCadastrar.Click += BtnCadastrar_Click;
            // 
            // BtnExcluir
            // 
            BtnExcluir.Location = new Point(297, 213);
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new Size(104, 22);
            BtnExcluir.TabIndex = 1;
            BtnExcluir.Text = "Excluir";
            BtnExcluir.UseVisualStyleBackColor = true;
            BtnExcluir.Click += BtnExcluir_Click;
            // 
            // BtnAtualizar
            // 
            BtnAtualizar.Location = new Point(187, 213);
            BtnAtualizar.Name = "BtnAtualizar";
            BtnAtualizar.Size = new Size(104, 22);
            BtnAtualizar.TabIndex = 0;
            BtnAtualizar.Text = "Atualizar";
            BtnAtualizar.UseVisualStyleBackColor = true;
            BtnAtualizar.Click += BtnAtualizar_Click;
            // 
            // LstVendas
            // 
            LstVendas.ItemHeight = 15;
            LstVendas.Location = new Point(48, 250);
            LstVendas.Name = "LstVendas";
            LstVendas.Size = new Size(474, 364);
            LstVendas.TabIndex = 4;
            LstVendas.Click += LstVendas_Click;
            LstVendas.SelectedIndexChanged += LstVendas_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TxtIdVenda);
            panel1.Controls.Add(TxtIdCliente);
            panel1.Controls.Add(TxtIdProduto);
            panel1.Controls.Add(TxtValor);
            panel1.Controls.Add(TxtIdFuncionario);
            panel1.Controls.Add(TxtData);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(48, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 196);
            panel1.TabIndex = 3;
            // 
            // FrmVenda
            // 
            ClientSize = new Size(568, 655);
            Controls.Add(BtnAtualizar);
            Controls.Add(BtnExcluir);
            Controls.Add(BtnCadastrar);
            Controls.Add(panel1);
            Controls.Add(LstVendas);
            Name = "FrmVenda";
            Text = "Cadastro de Vendas";
            Load += FrmVenda_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TxtIdVenda;
        private TextBox TxtIdCliente;
        private TextBox TxtIdProduto;
        private TextBox TxtValor;
        private TextBox TxtIdFuncionario;
        private DateTimePicker TxtData;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button BtnCadastrar;
        private Button BtnExcluir;
        private Button BtnAtualizar;
        private ListBox LstVendas;
        private Panel panel1;
    }
}