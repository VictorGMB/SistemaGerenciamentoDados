using System;
using System.Collections.Generic;

namespace projeto_banco_de_dados
{
    public class Usuario
    {
        private string user;
        private string senha;
        private string tipo;

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        // Cria uma lista de usuários cadastrados:
        public static List<Usuario> usuariosCadastrados = new List<Usuario>();

        // Usuários cadastrados:
        public static void InicializarUsuarios()
        {
            Usuario admin = new Usuario();
            admin.User = "admin";
            admin.Senha = "1234";
            admin.Tipo = "CRUD";

            Usuario Daniel = new Usuario();
            Daniel.User = "Daniel";
            Daniel.Senha = "5678";
            Daniel.Tipo = "R";

            usuariosCadastrados.Add(admin);
            usuariosCadastrados.Add(Daniel);
        }
    }
}