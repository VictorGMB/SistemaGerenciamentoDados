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
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comando inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
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
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o produto.");
                    }
                }
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comando inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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