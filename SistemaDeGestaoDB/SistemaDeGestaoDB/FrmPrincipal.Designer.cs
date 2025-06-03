namespace projeto_banco_de_dados
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            menuItemArquivo = new ToolStripMenuItem();
            menuItemTabelas = new ToolStripMenuItem();
            menuItemVenda = new ToolStripMenuItem();
            menuItemCliente = new ToolStripMenuItem();
            menuItemFuncionario = new ToolStripMenuItem();
            menuItemProduto = new ToolStripMenuItem();
            menuItemFornecedor = new ToolStripMenuItem();
            lblUser = new Label();
            sairToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuItemArquivo, menuItemTabelas });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(961, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuItemArquivo
            // 
            menuItemArquivo.DropDownItems.AddRange(new ToolStripItem[] { sairToolStripMenuItem });
            menuItemArquivo.Name = "menuItemArquivo";
            menuItemArquivo.Size = new Size(61, 20);
            menuItemArquivo.Text = "Arquivo";
            // 
            // menuItemTabelas
            // 
            menuItemTabelas.DropDownItems.AddRange(new ToolStripItem[] { menuItemVenda, menuItemCliente, menuItemFuncionario, menuItemProduto, menuItemFornecedor });
            menuItemTabelas.Name = "menuItemTabelas";
            menuItemTabelas.Size = new Size(58, 20);
            menuItemTabelas.Text = "Tabelas";
            // 
            // menuItemVenda
            // 
            menuItemVenda.Name = "menuItemVenda";
            menuItemVenda.Size = new Size(137, 22);
            menuItemVenda.Text = "Venda";
            menuItemVenda.Click += menuItemVenda_Click;
            // 
            // menuItemCliente
            // 
            menuItemCliente.Name = "menuItemCliente";
            menuItemCliente.Size = new Size(137, 22);
            menuItemCliente.Text = "Cliente";
            menuItemCliente.Click += menuItemCliente_Click;
            // 
            // menuItemFuncionario
            // 
            menuItemFuncionario.Name = "menuItemFuncionario";
            menuItemFuncionario.Size = new Size(137, 22);
            menuItemFuncionario.Text = "Funcionário";
            menuItemFuncionario.Click += menuItemFuncionario_Click;
            // 
            // menuItemProduto
            // 
            menuItemProduto.Name = "menuItemProduto";
            menuItemProduto.Size = new Size(137, 22);
            menuItemProduto.Text = "Produto";
            menuItemProduto.Click += menuItemProduto_Click;
            // 
            // menuItemFornecedor
            // 
            menuItemFornecedor.Name = "menuItemFornecedor";
            menuItemFornecedor.Size = new Size(137, 22);
            menuItemFornecedor.Text = "Fornecedor";
            menuItemFornecedor.Click += menuItemFornecedor_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(0, 680);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 15);
            lblUser.TabIndex = 2;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(180, 22);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // FrmPrincipal
            // 
            ClientSize = new Size(961, 600);
            Controls.Add(lblUser);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            Text = "Sistema - Principal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemArquivo;
        private System.Windows.Forms.ToolStripMenuItem menuItemTabelas;
        private System.Windows.Forms.ToolStripMenuItem menuItemVenda;
        private System.Windows.Forms.ToolStripMenuItem menuItemCliente;
        private System.Windows.Forms.ToolStripMenuItem menuItemFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuItemProduto;
        private System.Windows.Forms.ToolStripMenuItem menuItemFornecedor;
        private Label lblUser;
        private ToolStripMenuItem sairToolStripMenuItem;
    }
}
