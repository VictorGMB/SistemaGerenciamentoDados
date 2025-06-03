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
        public FrmFornecedor()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = this.TxtFornecedor.Text;
            fornecedor.CNPJ = this.TxtCNPJ.Text;

            if (fornecedor.Create())
            {
                LstFornecedores.DataSource = null; // Reseta a fonte de dados
                LstFornecedores.DataSource = fornecedor.ReadAll(); // Associa a lista de fornecedores
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se algum item foi selecionado na lista
            if (LstFornecedores.SelectedItem != null)
            {
                // Obtém o fornecedor selecionado
                Fornecedor fornecedorSelecionado = (Fornecedor)LstFornecedores.SelectedItem;

                // Confirmação do usuário antes de excluir
                DialogResult resultado = MessageBox.Show($"Tem certeza que deseja excluir '{fornecedorSelecionado.Nome}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    // Executa a exclusão do banco
                    bool excluido = fornecedorSelecionado.Delete();

                    if (excluido)
                    {
                        LstFornecedores.DataSource = null; // Reseta a fonte de dados
                        Fornecedor fornecedor = new Fornecedor();
                        LstFornecedores.DataSource = fornecedor.ReadAll(); // Associa a lista de fornecedores
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o fornecedor.");
                    }
                }
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            // Verifica se algum item foi selecionado na lista
            if (LstFornecedores.SelectedItem != null)
            {
                // Obtém o fornecedor selecionado
                Fornecedor fornecedorSelecionado = (Fornecedor)LstFornecedores.SelectedItem;
                fornecedorSelecionado.Nome = this.TxtFornecedor.Text;
                fornecedorSelecionado.CNPJ = this.TxtCNPJ.Text;

                if (fornecedorSelecionado.Update())
                {
                    LstFornecedores.DataSource = null; // Reseta a fonte de dados

                    Fornecedor fornecedor = new Fornecedor();
                    LstFornecedores.DataSource = fornecedor.ReadAll(); // Associa a lista de fornecedores
                }
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
