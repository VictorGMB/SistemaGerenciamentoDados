using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                        dgvCliente.DataSource = ObterDataTableCliente(); // Atualiza o DataGridView
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
                    if (dgvCliente.CurrentRow != null && dgvCliente.CurrentRow.Index >= 0)
                    {
                        int idCliente = Convert.ToInt32(dgvCliente.CurrentRow.Cells["idCliente"].Value);
                        Cliente clienteSelecionado = Cliente.ReadByID(idCliente);

                        if (clienteSelecionado != null)
                        {
                            DialogResult resultado = MessageBox.Show(
                                $"Tem certeza que deseja excluir '{clienteSelecionado.Nome}'?",
                                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (resultado == DialogResult.Yes)
                            {
                                bool excluido = clienteSelecionado.Delete();

                                if (excluido)
                                {
                                    dgvCliente.DataSource = ObterDataTableCliente(); // Atualiza o DataGridView
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
                    if (dgvCliente.CurrentRow != null && dgvCliente.CurrentRow.Index >= 0)
                    {
                        int idCliente = Convert.ToInt32(dgvCliente.CurrentRow.Cells["idCliente"].Value);
                        Cliente clienteSelecionado = Cliente.ReadByID(idCliente);

                        if (clienteSelecionado != null)
                        {
                            clienteSelecionado.Nome = this.TxtNome.Text;
                            clienteSelecionado.Email = this.TxtEmail.Text;
                            clienteSelecionado.CPF = this.TxtCPF.Text;

                            if (clienteSelecionado.Update())
                            {
                                dgvCliente.DataSource = ObterDataTableCliente(); // Atualiza o DataGridView
                                atividade = "UPDATE";
                                InsertLog();
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

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            dgvCliente.DataSource = ObterDataTableCliente();
        }

        private DataTable ObterDataTableCliente()
        {
            DataTable dt = new DataTable();
            using (var conexao = Banco.GetConexao())
            {
                string sql = "SELECT idCliente, nome, email, CPF FROM cliente ORDER BY nome;";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conexao))
                using (var da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private void dgvCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCliente.CurrentRow != null && dgvCliente.CurrentRow.Index >= 0)
            {
                this.TxtIdCliente.Text = dgvCliente.CurrentRow.Cells["idCliente"].Value?.ToString();
                this.TxtNome.Text = dgvCliente.CurrentRow.Cells["nome"].Value?.ToString();
                this.TxtEmail.Text = dgvCliente.CurrentRow.Cells["email"].Value?.ToString();
                this.TxtCPF.Text = dgvCliente.CurrentRow.Cells["CPF"].Value?.ToString();
            }
        }
    }
}