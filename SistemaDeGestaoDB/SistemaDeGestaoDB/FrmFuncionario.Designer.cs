namespace projeto_banco_de_dados
{
    partial class FrmFuncionario
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
            TxtIdFuncionario = new TextBox();
            TxtCargo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BtnCadastrar = new Button();
            BtnExcluir = new Button();
            BtnAtualizar = new Button();
            LstFuncionarios = new ListBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();

            // TxtNome
            TxtNome.Location = new Point(138, 55);
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(302, 23);
            TxtNome.TabIndex = 0;

            // TxtIdFuncionario
            TxtIdFuncionario.Enabled = false;
            TxtIdFuncionario.Location = new Point(138, 29);
            TxtIdFuncionario.Name = "TxtIdFuncionario";
            TxtIdFuncionario.Size = new Size(302, 23);
            TxtIdFuncionario.TabIndex = 1;

            // TxtCargo
            TxtCargo.Location = new Point(138, 82);
            TxtCargo.Name = "TxtCargo";
            TxtCargo.Size = new Size(302, 23);
            TxtCargo.TabIndex = 2;

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(15, 32);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 3;
            label1.Text = "ID Funcionário";

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(15, 58);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 4;
            label2.Text = "Nome Funcionário";

            // label3
            label3.AutoSize = true;
            label3.Location = new Point(15, 84);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 5;
            label3.Text = "Cargo";

            // Botões
            BtnCadastrar.Location = new Point(417, 132);
            BtnCadastrar.Text = "Cadastrar";
            BtnCadastrar.Click += BtnCadastrar_Click;

            BtnExcluir.Location = new Point(308, 132);
            BtnExcluir.Text = "Excluir";
            BtnExcluir.Click += BtnExcluir_Click;

            BtnAtualizar.Location = new Point(199, 132);
            BtnAtualizar.Text = "Atualizar";
            BtnAtualizar.Click += BtnAtualizar_Click;

            // Lista
            LstFuncionarios.Location = new Point(48, 175);
            LstFuncionarios.Size = new Size(474, 364);
            LstFuncionarios.Click += LstFuncionarios_Click;
            LstFuncionarios.SelectedIndexChanged += LstFuncionarios_SelectedIndexChanged;

            // Painel
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TxtIdFuncionario);
            panel1.Controls.Add(TxtNome);
            panel1.Controls.Add(TxtCargo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(48, 11);
            panel1.Size = new Size(474, 113);

            // FrmFuncionario
            ClientSize = new Size(568, 627);
            Controls.Add(BtnAtualizar);
            Controls.Add(BtnExcluir);
            Controls.Add(BtnCadastrar);
            Controls.Add(panel1);
            Controls.Add(LstFuncionarios);
            Name = "FrmFuncionario";
            Text = "Cadastro de Funcionários";
            Load += FrmFuncionario_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TxtNome;
        private TextBox TxtIdFuncionario;
        private TextBox TxtCargo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button BtnCadastrar;
        private Button BtnExcluir;
        private Button BtnAtualizar;
        private ListBox LstFuncionarios;
        private Panel panel1;
    }
}