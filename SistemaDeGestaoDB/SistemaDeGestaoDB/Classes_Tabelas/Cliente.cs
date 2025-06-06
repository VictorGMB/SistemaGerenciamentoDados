using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

public class Cliente
{
    public int IdCliente { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }

    /// <summary>
    /// Insere um novo cliente no banco de dados.
    /// </summary>
    public bool Create()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "INSERT INTO cliente (nome, email, CPF) VALUES (@nome, @email, @CPF);";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@nome", Nome);
        cmd.Parameters.AddWithValue("@email", Email);
        cmd.Parameters.AddWithValue("@CPF", CPF);

        bool executou = cmd.ExecuteNonQuery() > 0;
        IdCliente = (int)cmd.LastInsertedId;

        return executou;
    }

    /// <summary>
    /// Exclui um cliente do banco de dados.
    /// </summary>
    public bool Delete()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "DELETE FROM cliente WHERE idCliente = @idCliente;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idCliente", IdCliente);

        return cmd.ExecuteNonQuery() > 0;
    }

    /// <summary>
    /// Atualiza os dados de um cliente no banco.
    /// </summary>
    public bool Update()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "UPDATE cliente SET nome = @nome, email = @email, CPF = @CPF WHERE idCliente = @idCliente;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@nome", Nome);
        cmd.Parameters.AddWithValue("@email", Email);
        cmd.Parameters.AddWithValue("@CPF", CPF);
        cmd.Parameters.AddWithValue("@idCliente", IdCliente);

        return cmd.ExecuteNonQuery() > 0;
    }

    /// <summary>
    /// Verifica se um cliente com o CPF já existe no banco.
    /// </summary>
    public bool IsCliente()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT COUNT(*) FROM cliente WHERE CPF = @CPF;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@CPF", CPF);

        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    /// <summary>
    /// Retorna todos os clientes cadastrados.
    /// </summary>
    public List<Cliente> ReadAll()
    {
        List<Cliente> listaClientes = new List<Cliente>();
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM cliente ORDER BY nome;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = reader.GetInt32("idCliente");
            cliente.Nome = reader.GetString("nome");
            cliente.Email = reader.GetString("email");
            cliente.CPF = reader.GetString("CPF");
            listaClientes.Add(cliente);
        }
        reader.Close();

        return listaClientes;
    }

    /// <summary>
    /// Retorna um cliente com base no ID.
    /// </summary>
    public static Cliente ReadByID(int idCliente)
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM cliente WHERE idCliente = @idCliente;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idCliente", idCliente);

        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = reader.GetInt32("idCliente");
            cliente.Nome = reader.GetString("nome");
            cliente.Email = reader.GetString("email");
            cliente.CPF = reader.GetString("CPF");
            reader.Close();
            return cliente;
        }
        reader.Close();
        return null;
    }

    /// <summary>
    /// Representação textual do objeto Cliente.
    /// </summary>
    public override string ToString()
    {
        return $"{Nome} {Email} {CPF}";
    }
}