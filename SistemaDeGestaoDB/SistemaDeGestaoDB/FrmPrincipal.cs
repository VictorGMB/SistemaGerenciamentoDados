using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace projeto_banco_de_dados
{
    public partial class FrmPrincipal : Form
    {
        //Armazena o usuario logado:
        private Usuario usuarioAtual;
        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            usuarioAtual = usuario;
            this.WindowState = FormWindowState.Maximized;

            lblUser.Text = $"Usuário: {usuarioAtual.User}";
        }

        private void menuItemFornecedor_Click(object sender, EventArgs e)
        {
            FrmFornecedor frmFornecedor = new FrmFornecedor();
            frmFornecedor.MdiParent = this;
            frmFornecedor.Show();
        }

        private void menuItemFuncionario_Click(object sender, EventArgs e)
        {
            FrmFuncionario frmFuncionario = new FrmFuncionario();
            frmFuncionario.MdiParent = this;
            frmFuncionario.Show();
        }

        private void menuItemCliente_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.MdiParent = this;
            frmCliente.Show();
        }

        private void menuItemProduto_Click(object sender, EventArgs e)
        {
            FrmProduto frmProduto = new FrmProduto();
            frmProduto.MdiParent = this;
            frmProduto.Show();
        }

        private void menuItemVenda_Click(object sender, EventArgs e)
        {
            FrmVenda frmVenda = new FrmVenda();
            frmVenda.MdiParent = this;
            frmVenda.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide(); 

            // Fecha o formulário principal após abrir o login
            frmLogin.FormClosed += (s, args) => this.Close();
        }
    }
}
