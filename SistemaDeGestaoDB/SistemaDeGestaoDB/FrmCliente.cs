using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_banco_de_dados
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = this.TxtNome.Text;
            cliente.Email = this.TxtEmail.Text;
            cliente.CPF = this.TxtCPF.Text;

            if (cliente.Create())
            {
                LstClientes.DataSource = null; // Reseta a fonte de dados
                LstClientes.DataSource = cliente.ReadAll(); // Atualiza a lista de clientes
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
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
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o cliente.");
                    }
                }
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
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
                }
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