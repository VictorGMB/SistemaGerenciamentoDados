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
    public partial class FrmFornecedor : Form
    {
        private Usuario usuarioAtual;

        private string tabela;

        private string atividade;
        public FrmFornecedor(Usuario usuario)
        {
            InitializeComponent();
            usuarioAtual = usuario;
            tabela = "fornecedor";
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
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.Nome = this.TxtFornecedor.Text;
                    fornecedor.CNPJ = this.TxtCNPJ.Text;

                    if (fornecedor.Create())
                    {
                        LstFornecedores.DataSource = null; // Reseta a fonte de dados
                        LstFornecedores.DataSource = fornecedor.ReadAll(); // Associa a lista de fornecedores
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
                    if (LstFornecedores.SelectedItem != null)
                    {
                        Fornecedor fornecedorSelecionado = (Fornecedor)LstFornecedores.SelectedItem;

                        DialogResult resultado = MessageBox.Show($"Tem certeza que deseja excluir '{fornecedorSelecionado.Nome}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (resultado == DialogResult.Yes)
                        {
                            bool excluido = fornecedorSelecionado.Delete();

                            if (excluido)
                            {
                                LstFornecedores.DataSource = null; // Reseta a fonte de dados
                                Fornecedor fornecedor = new Fornecedor();
                                LstFornecedores.DataSource = fornecedor.ReadAll(); // Associa a lista de fornecedores
                                atividade = "DELETE";
                                InsertLog();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao excluir o fornecedor.");
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
                    if (LstFornecedores.SelectedItem != null)
                    {
                        Fornecedor fornecedorSelecionado = (Fornecedor)LstFornecedores.SelectedItem;
                        fornecedorSelecionado.Nome = this.TxtFornecedor.Text;
                        fornecedorSelecionado.CNPJ = this.TxtCNPJ.Text;

                        if (fornecedorSelecionado.Update())
                        {
                            LstFornecedores.DataSource = null; // Reseta a fonte de dados
                            Fornecedor fornecedor = new Fornecedor();
                            LstFornecedores.DataSource = fornecedor.ReadAll(); // Associa a lista de fornecedores
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

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Fornecedor fornecedor = new Fornecedor();
            LstFornecedores.DataSource = fornecedor.ReadAll(); // Associa a lista de fornecedores
        }

        private void LstFornecedores_Click(object sender, EventArgs e)
        {
            // Obtém o item selecionado na lista e converte para um objeto da classe Fornecedor
            Fornecedor fornecedorSelecionado = (Fornecedor)LstFornecedores.SelectedItem;

            // Exibe os dados do fornecedor nos campos de texto
            this.TxtIdFornecedor.Text = fornecedorSelecionado.IdFornecedor.ToString();
            this.TxtFornecedor.Text = fornecedorSelecionado.Nome;
            this.TxtCNPJ.Text = fornecedorSelecionado.CNPJ;
        }

        private void LstFornecedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
