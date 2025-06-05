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
    public partial class FrmProduto : Form
    {
        private Usuario usuarioAtual;

        private string tabela;

        private string atividade;
        public FrmProduto(Usuario usuario)
        {
            InitializeComponent();
            usuarioAtual = usuario;
            tabela = "produto";
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
                    Produto produto = new Produto();
                    produto.Nome = this.TxtProduto.Text;
                    produto.IdFornecedor = int.Parse(this.TxtIdFornecedor.Text);

                    if (produto.Create())
                    {
                        LstProdutos.DataSource = null; // Reseta a fonte de dados
                        LstProdutos.DataSource = produto.ReadAll(); // Associa a lista de produtos
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
                    if (LstProdutos.SelectedItem != null)
                    {
                        Produto produtoSelecionado = (Produto)LstProdutos.SelectedItem;

                        DialogResult resultado = MessageBox.Show($"Tem certeza que deseja excluir '{produtoSelecionado.Nome}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (resultado == DialogResult.Yes)
                        {
                            bool excluido = produtoSelecionado.Delete();

                            if (excluido)
                            {
                                LstProdutos.DataSource = null;
                                Produto produto = new Produto();
                                LstProdutos.DataSource = produto.ReadAll();
                                atividade = "DELETE";
                                InsertLog();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao excluir o produto.");
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
                    if (LstProdutos.SelectedItem != null)
                    {
                        Produto produtoSelecionado = (Produto)LstProdutos.SelectedItem;
                        produtoSelecionado.Nome = this.TxtProduto.Text;
                        produtoSelecionado.IdFornecedor = int.Parse(this.TxtIdFornecedor.Text);

                        if (produtoSelecionado.Update())
                        {
                            LstProdutos.DataSource = null;
                            Produto produto = new Produto();
                            LstProdutos.DataSource = produto.ReadAll();
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

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Produto produto = new Produto();
            LstProdutos.DataSource = produto.ReadAll();
        }

        private void LstProdutos_Click(object sender, EventArgs e)
        {
            Produto produtoSelecionado = (Produto)LstProdutos.SelectedItem;

            this.TxtIdProduto.Text = produtoSelecionado.IdProduto.ToString();
            this.TxtProduto.Text = produtoSelecionado.Nome;
            this.TxtIdFornecedor.Text = produtoSelecionado.IdFornecedor.ToString();
        }

        private void LstProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}