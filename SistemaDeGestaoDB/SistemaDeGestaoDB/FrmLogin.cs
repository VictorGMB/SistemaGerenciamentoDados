using System;
using System.Windows.Forms;

namespace projeto_banco_de_dados
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            Usuario.InicializarUsuarios(); // Inicializa usuários pré-cadastrados
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuario usuarioLogado = ValidarUsuario(txtUsuario.Text, txtSenha.Text);

            if (usuarioLogado != null) // Se o usuário foi encontrado
            {
                MessageBox.Show($"Bem-vindo, {usuarioLogado.User}!", "Login realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Abre o formulário principal
                FrmPrincipal principalForm = new FrmPrincipal(usuarioLogado);
                principalForm.Show();

                // Fecha o formulário de login quando FrmPrincipal for fechado
                principalForm.FormClosed += (s, args) => this.Close();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para validar usuário no login:
        private Usuario ValidarUsuario(string usuario, string senha)
        {
            foreach (Usuario user in Usuario.usuariosCadastrados)
            {
                if (user.User == usuario && user.Senha == senha)
                {
                    return user;
                }
            }
            return null; // Retorna nulo se não encontrar
        }
    }
}
