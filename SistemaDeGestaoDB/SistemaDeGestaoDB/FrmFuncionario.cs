using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_banco_de_dados
{
    public partial class FrmFuncionario : Form
    {
        private Usuario usuarioAtual;

        private string tabela;

        private string atividade;
        public FrmFuncionario(Usuario usuario)
        {
            InitializeComponent();
            usuarioAtual = usuario;
            tabela = "funcionario";
            LstFuncionarios.DataSource = null; // Reseta a fonte de dados
            Funcionario funcionario = new Funcionario();
            LstFuncionarios.DataSource = funcionario.ReadAll();
            DataManager.AtualizarFuncionarios(LstFuncionarios);
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
                    Funcionario funcionario = new Funcionario();
                    funcionario.Nome = this.TxtNome.Text;
                    funcionario.Cargo = this.TxtCargo.Text;

                    if (funcionario.Create())
                    {
                        LstFuncionarios.DataSource = null; // Reseta a fonte de dados
                        LstFuncionarios.DataSource = funcionario.ReadAll(); // Associa a lista de funcionários
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
                    if (LstFuncionarios.SelectedItem != null)
                    {
                        Funcionario funcionarioSelecionado = (Funcionario)LstFuncionarios.SelectedItem;

                        DialogResult resultado = MessageBox.Show($"Tem certeza que deseja excluir '{funcionarioSelecionado.Nome}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (resultado == DialogResult.Yes)
                        {
                            bool excluido = funcionarioSelecionado.Delete();

                            if (excluido)
                            {
                                LstFuncionarios.DataSource = null; // Reseta a fonte de dados
                                Funcionario funcionario = new Funcionario();
                                LstFuncionarios.DataSource = funcionario.ReadAll(); // Associa a lista de funcionários
                                atividade = "DELETE";
                                InsertLog();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao excluir o funcionário.");
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
                    if (LstFuncionarios.SelectedItem != null)
                    {
                        Funcionario funcionarioSelecionado = (Funcionario)LstFuncionarios.SelectedItem;
                        funcionarioSelecionado.Nome = this.TxtNome.Text;
                        funcionarioSelecionado.Cargo = this.TxtCargo.Text;

                        if (funcionarioSelecionado.Update())
                        {
                            LstFuncionarios.DataSource = null; // Reseta a fonte de dados
                            Funcionario funcionario = new Funcionario();
                            LstFuncionarios.DataSource = funcionario.ReadAll(); // Associa a lista de funcionários
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

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Funcionario funcionario = new Funcionario();
            LstFuncionarios.DataSource = funcionario.ReadAll(); // Associa a lista de funcionários
        }

        private void LstFuncionarios_Click(object sender, EventArgs e)
        {
            Funcionario funcionarioSelecionado = (Funcionario)LstFuncionarios.SelectedItem;

            this.TxtIdFuncionario.Text = funcionarioSelecionado.IdFuncionario.ToString();
            this.TxtNome.Text = funcionarioSelecionado.Nome;
            this.TxtCargo.Text = funcionarioSelecionado.Cargo;
        }

        private void LstFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}