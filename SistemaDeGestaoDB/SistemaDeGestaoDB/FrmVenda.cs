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
    public partial class FrmVenda : Form
    {
        private Usuario usuarioAtual;

        private string tabela;

        private string atividade;
        public FrmVenda(Usuario usuario)
        {
            InitializeComponent();
            usuarioAtual = usuario;
            tabela = "venda";
            Venda venda = new Venda();
            LstVendas.DataSource = venda.ReadAll();
            DataManager.AtualizarVendas(LstVendas);
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
                    Venda venda = new Venda();
                    venda.IdCliente = int.Parse(this.TxtIdCliente.Text);
                    venda.IdProduto = int.Parse(this.TxtIdProduto.Text);
                    venda.Valor = float.Parse(this.TxtValor.Text);
                    venda.IdFuncionario = int.Parse(this.TxtIdFuncionario.Text);
                    venda.Data = TxtData.Value;

                    if (venda.Create())
                    {
                        LstVendas.DataSource = null; // Reseta a fonte de dados
                        LstVendas.DataSource = venda.ReadAll(); // Associa a lista de vendas
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
                    if (LstVendas.SelectedItem != null)
                    {
                        Venda vendaSelecionada = (Venda)LstVendas.SelectedItem;

                        DialogResult resultado = MessageBox.Show($"Tem certeza que deseja excluir a venda '{vendaSelecionada.IdVenda}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (resultado == DialogResult.Yes)
                        {
                            bool excluido = vendaSelecionada.Delete();

                            if (excluido)
                            {
                                LstVendas.DataSource = null;
                                Venda venda = new Venda();
                                LstVendas.DataSource = venda.ReadAll();
                                atividade = "DELETE";
                                InsertLog();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao excluir a venda.");
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
                    if (LstVendas.SelectedItem != null)
                    {
                        Venda vendaSelecionada = (Venda)LstVendas.SelectedItem;
                        vendaSelecionada.IdCliente = int.Parse(this.TxtIdCliente.Text);
                        vendaSelecionada.IdProduto = int.Parse(this.TxtIdProduto.Text);
                        vendaSelecionada.Valor = float.Parse(this.TxtValor.Text);
                        vendaSelecionada.IdFuncionario = int.Parse(this.TxtIdFuncionario.Text);
                        vendaSelecionada.Data = TxtData.Value;

                        if (vendaSelecionada.Update())
                        {
                            LstVendas.DataSource = null;
                            Venda venda = new Venda();
                            LstVendas.DataSource = venda.ReadAll();
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

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Venda venda = new Venda();
            LstVendas.DataSource = venda.ReadAll();
        }

        private void LstVendas_Click(object sender, EventArgs e)
        {
            Venda vendaSelecionada = (Venda)LstVendas.SelectedItem;

            this.TxtIdVenda.Text = vendaSelecionada.IdVenda.ToString();
            this.TxtIdCliente.Text = vendaSelecionada.IdCliente.ToString();
            this.TxtIdProduto.Text = vendaSelecionada.IdProduto.ToString();
            this.TxtValor.Text = vendaSelecionada.Valor.ToString();
            this.TxtIdFuncionario.Text = vendaSelecionada.IdFuncionario.ToString();
            this.TxtData.Value = vendaSelecionada.Data;
        }

        private void LstVendas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}