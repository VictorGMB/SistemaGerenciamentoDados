using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_banco_de_dados
{
    public partial class FrmCliente : Form
    {
        private Usuario usuarioAtual;

        private string tabela;

        private string atividade;
        public FrmCliente(Usuario usuario)
        {
            InitializeComponent();
            usuarioAtual = usuario;
            tabela = "cliente";
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

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (usuarioAtual.Tipo.Contains("C"))
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.Nome = this.TxtNome.Text;
                    cliente.Email = this.TxtEmail.Text;
                    cliente.CPF = this.TxtCPF.Text;

                    if (cliente.Create())
                    {
                        LstClientes.DataSource = null; // Reseta a fonte de dados
                        LstClientes.DataSource = cliente.ReadAll(); // Atualiza a lista de clientes
                        atividade = "CREATE";
                        InsertLog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Comando inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Permissão negada.",
                    "Acesso Restrito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (usuarioAtual.Tipo.Contains("D"))
            {
                try
                {
                    if (LstClientes.SelectedItem != null)
                    {
                        Cliente clienteSelecionado = (Cliente)LstClientes.SelectedItem;

                        DialogResult resultado = MessageBox.Show($"Tem certeza que deseja excluir '{clienteSelecionado.Nome}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (resultado == DialogResult.Yes)
                        {
                            bool excluido = clienteSelecionado.Delete();

                            if (excluido)
                            {
                                LstClientes.DataSource = null; // Reseta a fonte de dados
                                Cliente cliente = new Cliente();
                                LstClientes.DataSource = cliente.ReadAll();
                                atividade = "DELETE";
                                InsertLog();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao excluir o cliente.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Comando inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Permissão negada.",
                    "Acesso Restrito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (usuarioAtual.Tipo.Contains("U"))
            {
                try
                {
                    if (LstClientes.SelectedItem != null)
                    {
                        Cliente clienteSelecionado = (Cliente)LstClientes.SelectedItem;
                        clienteSelecionado.Nome = this.TxtNome.Text;
                        clienteSelecionado.Email = this.TxtEmail.Text;
                        clienteSelecionado.CPF = this.TxtCPF.Text;

                        if (clienteSelecionado.Update())
                        {
                            LstClientes.DataSource = null; // Reseta a fonte de dados
                            Cliente cliente = new Cliente();
                            LstClientes.DataSource = cliente.ReadAll();
                            atividade = "UPDATE";
                            InsertLog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Comando inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Permissão negada.",
                    "Acesso Restrito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Cliente cliente = new Cliente();
            LstClientes.DataSource = cliente.ReadAll(); ;
        }

        private void LstClientes_Click(object sender, EventArgs e)
        {
            if (LstClientes.SelectedItem != null)
            {
                Cliente clienteSelecionado = (Cliente)LstClientes.SelectedItem;

                this.TxtIdCliente.Text = clienteSelecionado.IdCliente.ToString();
                this.TxtNome.Text = clienteSelecionado.Nome;
                this.TxtEmail.Text = clienteSelecionado.Email;
                this.TxtCPF.Text = clienteSelecionado.CPF;
            }
        }
        private void LstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}