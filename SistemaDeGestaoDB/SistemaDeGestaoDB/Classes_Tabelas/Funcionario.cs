using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

public class Funcionario
{
    public int IdFuncionario { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }

    /// <summary>
    /// Insere um novo funcionário no banco de dados.
    /// </summary>
    public bool Create()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "INSERT INTO funcionario (nome, cargo) VALUES (@nome, @cargo);";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@nome", Nome);
        cmd.Parameters.AddWithValue("@cargo", Cargo);

        bool executou = cmd.ExecuteNonQuery() > 0;
        IdFuncionario = (int)cmd.LastInsertedId;
        return executou;
    }

    /// <summary>
    /// Exclui um funcionário no banco de dados.
    /// </summary>
    public bool Delete()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "DELETE FROM funcionario WHERE idFuncionario = @idFuncionario;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idFuncionario", IdFuncionario);

        return cmd.ExecuteNonQuery() > 0;
    }

    /// <summary>
    /// Atualiza os dados de um funcionário no banco.
    /// </summary>
    public bool Update()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "UPDATE funcionario SET nome = @nome, cargo = @cargo WHERE idFuncionario = @idFuncionario;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@nome", Nome);
        cmd.Parameters.AddWithValue("@cargo", Cargo);
        cmd.Parameters.AddWithValue("@idFuncionario", IdFuncionario);

        return cmd.ExecuteNonQuery() > 0;
    }

    /// <summary>
    /// Retorna todos os funcionários cadastrados.
    /// </summary>
    public List<Funcionario> ReadAll()
    {
        List<Funcionario> listaFuncionarios = new List<Funcionario>();
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM funcionario ORDER BY nome;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Funcionario funcionario = new Funcionario();
            funcionario.IdFuncionario = reader.GetInt32("idFuncionario");
            funcionario.Nome = reader.GetString("nome");
            funcionario.Cargo = reader.GetString("cargo");
            listaFuncionarios.Add(funcionario);
        }
        reader.Close();
        return listaFuncionarios;
    }

    /// <summary>
    /// Retorna um funcionário com base no ID.
    /// </summary>
    public static Funcionario ReadByID(int idFuncionario)
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM funcionario WHERE idFuncionario = @idFuncionario;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);
        cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);
        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Funcionario funcionario = new Funcionario();
            funcionario.IdFuncionario = reader.GetInt32("idFuncionario");
            funcionario.Nome = reader.GetString("nome");
            funcionario.Cargo = reader.GetString("cargo");
            reader.Close();
            return funcionario;
        }
        reader.Close();
        return null;
    }
    public override string ToString()
    {
        return $"{Nome} {Cargo}";
    }
}