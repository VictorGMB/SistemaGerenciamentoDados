namespace projeto_banco_de_dados
{
    partial class FrmCliente
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
            TxtNome = new TextBox();
            TxtIdCliente = new TextBox();
            TxtEmail = new TextBox();
            TxtCPF = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            BtnCadastrar = new Button();
            BtnExcluir = new Button();
            BtnAtualizar = new Button();
            LstClientes = new ListBox();
            panel1 = new Panel();
            label5 = new Label();
            TxtImport = new TextBox();
            BtnImport = new Button();
            dgvCliente = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCliente).BeginInit();
            SuspendLayout();
            // 
            // TxtNome
            // 
            TxtNome.Location = new Point(138, 45);
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(302, 23);
            TxtNome.TabIndex = 0;
            // 
            // TxtIdCliente
            // 
            TxtIdCliente.Enabled = false;
            TxtIdCliente.Location = new Point(138, 16);
            TxtIdCliente.Name = "TxtIdCliente";
            TxtIdCliente.Size = new Size(302, 23);
            TxtIdCliente.TabIndex = 1;
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(138, 74);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(302, 23);
            TxtEmail.TabIndex = 2;
            // 
            // TxtCPF
            // 
            TxtCPF.Location = new Point(138, 103);
            TxtCPF.Name = "TxtCPF";
            TxtCPF.Size = new Size(302, 23);
            TxtCPF.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 4;
            label1.Text = "ID Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 48);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 5;
            label2.Text = "Nome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 77);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 106);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 7;
            label4.Text = "CPF";
            // 
            // BtnCadastrar
            // 
            BtnCadastrar.Location = new Point(414, 161);
            BtnCadastrar.Name = "BtnCadastrar";
            BtnCadastrar.Size = new Size(75, 23);
            BtnCadastrar.TabIndex = 2;
            BtnCadastrar.Text = "Cadastrar";
            BtnCadastrar.Click += BtnCadastrar_Click;
            // 
            // BtnExcluir
            // 
            BtnExcluir.Location = new Point(309, 161);
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new Size(75, 23);
            BtnExcluir.TabIndex = 1;
            BtnExcluir.Text = "Excluir";
            BtnExcluir.Click += BtnExcluir_Click;
            // 
            // BtnAtualizar
            // 
            BtnAtualizar.Location = new Point(205, 161);
            BtnAtualizar.Name = "BtnAtualizar";
            BtnAtualizar.Size = new Size(75, 23);
            BtnAtualizar.TabIndex = 0;
            BtnAtualizar.Text = "Atualizar";
            BtnAtualizar.Click += BtnAtualizar_Click;
            // 
            // LstClientes
            // 
            LstClientes.FormattingEnabled = true;
            LstClientes.ItemHeight = 15;
            LstClientes.Location = new Point(48, 190);
            LstClientes.Name = "LstClientes";
            LstClientes.Size = new Size(474, 364);
            LstClientes.TabIndex = 9;
            LstClientes.Click += LstClientes_Click;
            LstClientes.SelectedIndexChanged += LstClientes_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TxtIdCliente);
            panel1.Controls.Add(TxtNome);
            panel1.Controls.Add(TxtEmail);
            panel1.Controls.Add(TxtCPF);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(48, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 136);
            panel1.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(590, 28);
            label5.Name = "label5";
            label5.Size = new Size(123, 15);
            label5.TabIndex = 10;
            label5.Text = "Importar arquivo CSV:";
            // 
            // TxtImport
            // 
            TxtImport.Location = new Point(590, 57);
            TxtImport.Name = "TxtImport";
            TxtImport.Size = new Size(318, 23);
            TxtImport.TabIndex = 11;
            // 
            // BtnImport
            // 
            BtnImport.Location = new Point(590, 89);
            BtnImport.Name = "BtnImport";
            BtnImport.Size = new Size(75, 23);
            BtnImport.TabIndex = 12;
            BtnImport.Text = "Importar";
            BtnImport.UseVisualStyleBackColor = true;
            BtnImport.Click += btnImport_Click;
            // 
            // dgvCliente
            // 
            dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCliente.Location = new Point(579, 190);
            dgvCliente.Name = "dgvCliente";
            dgvCliente.Size = new Size(506, 364);
            dgvCliente.TabIndex = 13;
            // 
            // FrmCliente
            // 
            ClientSize = new Size(1097, 627);
            Controls.Add(dgvCliente);
            Controls.Add(BtnImport);
            Controls.Add(TxtImport);
            Controls.Add(label5);
            Controls.Add(BtnAtualizar);
            Controls.Add(BtnExcluir);
            Controls.Add(BtnCadastrar);
            Controls.Add(panel1);
            Controls.Add(LstClientes);
            Name = "FrmCliente";
            Text = "Cadastro de Clientes";
            Load += FrmCliente_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCliente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtNome;
        private TextBox TxtIdCliente;
        private TextBox TxtEmail;
        private TextBox TxtCPF;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox LstClientes;
        private Button BtnCadastrar;
        private Button BtnExcluir;
        private Button BtnAtualizar;
        private Panel panel1;
        private Label label5;
        private TextBox TxtImport;
        private Button BtnImport;
        private DataGridView dgvCliente;
    }
}