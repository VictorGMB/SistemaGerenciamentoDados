using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Diagnostics;

namespace projeto_banco_de_dados
{
    public partial class FrmPrincipal : Form
    {
        //Armazena o usuario logado:
        private Usuario usuarioAtual;

        private string tabela;

        private string atividade;
        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            usuarioAtual = usuario;
            this.WindowState = FormWindowState.Maximized;

            lblUser.Text = $"Usuário: {usuarioAtual.User}";
        }

        public bool InsertLog()
        {
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "INSERT INTO log (usuario, tabela, atividade) VALUES (@usuario, @tabela, @atividade);";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@usuario", usuarioAtual.User);
            cmd.Parameters.AddWithValue("@tabela", tabela);
            cmd.Parameters.AddWithValue("@atividade", atividade);

            bool executou = cmd.ExecuteNonQuery() > 0;

            return executou;
        }

        private void menuItemFornecedor_Click(object sender, EventArgs e)
        {
            FrmFornecedor frmFornecedor = new FrmFornecedor(usuarioAtual);
            frmFornecedor.MdiParent = this;
            frmFornecedor.Show();
            tabela = "fornecedor";
            atividade = "READ";
            InsertLog();
        }

        private void menuItemFuncionario_Click(object sender, EventArgs e)
        {
            FrmFuncionario frmFuncionario = new FrmFuncionario(usuarioAtual);
            frmFuncionario.MdiParent = this;
            frmFuncionario.Show();
            tabela = "funcionario";
            atividade = "READ";
            InsertLog();
        }

        private void menuItemCliente_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente(usuarioAtual);
            frmCliente.MdiParent = this;
            frmCliente.Show();
            tabela = "cliente";
            atividade = "READ";
            InsertLog();
        }

        private void menuItemProduto_Click(object sender, EventArgs e)
        {
            FrmProduto frmProduto = new FrmProduto(usuarioAtual);
            frmProduto.MdiParent = this;
            frmProduto.Show();
            tabela = "produto";
            atividade = "READ";
            InsertLog();
        }

        private void menuItemVenda_Click(object sender, EventArgs e)
        {
            FrmVenda frmVenda = new FrmVenda(usuarioAtual);
            frmVenda.MdiParent = this;
            frmVenda.Show();
            tabela = "venda";
            atividade = "READ";
            InsertLog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();

            // Fecha o formulário principal após abrir o login
            frmLogin.FormClosed += (s, args) => this.Close();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLog frmLog = new FrmLog();
            frmLog.MdiParent = this;
            frmLog.Show();
        }

        public void ExportarTodosPDF()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) =>
            {
                Font fonte = new Font("Arial", 12);
                float x = 50, y = 50;

                e.Graphics.DrawString("Relatório de Dados", fonte, Brushes.Black, x, y);
                y += 30;

                e.Graphics.DrawString("------------------------------------------------------------------------", fonte, Brushes.Black, x, y);
                y += 30;

                e.Graphics.DrawString("Tabela Clientes", fonte, Brushes.Black, x, y);
                y += 30;

                foreach (var item in DataManager.Clientes)
                {
                    e.Graphics.DrawString(item, fonte, Brushes.Black, x, y);
                    y += 20;
                }

                e.Graphics.DrawString("------------------------------------------------------------------------", fonte, Brushes.Black, x, y);
                y += 30;

                e.Graphics.DrawString("Tabela Fornecedores", fonte, Brushes.Black, x, y);
                y += 30;

                foreach (var item in DataManager.Fornecedores)
                {
                    e.Graphics.DrawString(item, fonte, Brushes.Black, x, y);
                    y += 20;
                }

                e.Graphics.DrawString("------------------------------------------------------------------------", fonte, Brushes.Black, x, y);
                y += 30;

                e.Graphics.DrawString("Tabela Produtos", fonte, Brushes.Black, x, y);
                y += 30;

                foreach (var item in DataManager.Produtos)
                {
                    e.Graphics.DrawString(item, fonte, Brushes.Black, x, y);
                    y += 20;
                }

                e.Graphics.DrawString("------------------------------------------------------------------------", fonte, Brushes.Black, x, y);
                y += 30;

                e.Graphics.DrawString("Tabela Funcionarios", fonte, Brushes.Black, x, y);
                y += 30;

                foreach (var item in DataManager.Funcionarios)
                {
                    e.Graphics.DrawString(item, fonte, Brushes.Black, x, y);
                    y += 20;
                }

                e.Graphics.DrawString("------------------------------------------------------------------------", fonte, Brushes.Black, x, y);
                y += 30;

                e.Graphics.DrawString("Tabela Vendas", fonte, Brushes.Black, x, y);
                y += 30;

                foreach (var item in DataManager.Vendas)
                {
                    e.Graphics.DrawString(item, fonte, Brushes.Black, x, y);
                    y += 20;
                }
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;
            printDialog.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }
        private void exportarPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFornecedor frmFornecedor = new FrmFornecedor(usuarioAtual);
            frmFornecedor.MdiParent = this;
            frmFornecedor.Hide();

            FrmFuncionario frmFuncionario = new FrmFuncionario(usuarioAtual);
            frmFuncionario.MdiParent = this;
            frmFuncionario.Hide();

            FrmProduto frmProduto = new FrmProduto(usuarioAtual);
            frmProduto.MdiParent = this;
            frmProduto.Hide();

            FrmVenda frmVenda = new FrmVenda(usuarioAtual);
            frmVenda.MdiParent = this;
            frmVenda.Hide();

            FrmCliente frmCliente = new FrmCliente(usuarioAtual);
            frmCliente.MdiParent = this;
            frmCliente.Hide();

            ExportarTodosPDF();

            frmFornecedor.Close();
            frmFuncionario.Close();
            frmProduto.Close();
            frmVenda.Close();
            frmCliente.Close();
        }

        private void criarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Banco.CriarBackup();
        }
    }
}
