using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

public class Produto
{
    public int IdProduto { get; set; }
    public string Nome { get; set; }
    public int IdFornecedor { get; set; }


    public bool Create()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "INSERT INTO produto (nome, idFornecedor) VALUES (@nome, @idFornecedor);";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@nome", Nome);
        cmd.Parameters.AddWithValue("@idFornecedor", IdFornecedor);

        bool executou = cmd.ExecuteNonQuery() > 0;
        IdProduto = (int)cmd.LastInsertedId;

        return executou;
    }

    public bool Delete()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "DELETE FROM produto WHERE idProduto = @idProduto;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idProduto", IdProduto);

        return cmd.ExecuteNonQuery() > 0;
    }

    public bool Update()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "UPDATE produto SET nome = @nome, idFornecedor = @idFornecedor WHERE idProduto = @idProduto;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@nome", Nome);
        cmd.Parameters.AddWithValue("@idFornecedor", IdFornecedor);
        cmd.Parameters.AddWithValue("@idProduto", IdProduto);

        return cmd.ExecuteNonQuery() > 0;
    }

    public bool IsProduto()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT COUNT(*) FROM produto WHERE nome = @nome;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@nome", Nome);

        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }


    public List<Produto> ReadAll()
    {
        List<Produto> listaProdutos = new List<Produto>();
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM produto ORDER BY nome;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Produto produto = new Produto();
            produto.IdProduto = reader.GetInt32("idProduto");
            produto.Nome = reader.GetString("nome");
            produto.IdFornecedor = reader.GetInt32("idFornecedor");
            listaProdutos.Add(produto);
        }
        reader.Close();

        return listaProdutos;
    }

    public static Produto ReadByID(int idProduto)
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM produto WHERE idProduto = @idProduto;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idProduto", idProduto);

        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Produto produto = new Produto();
            produto.IdProduto = reader.GetInt32("idProduto");
            produto.Nome = reader.GetString("nome");
            produto.IdFornecedor = reader.GetInt32("idFornecedor");
            reader.Close();
            return produto;
        }
        reader.Close();
        return null;
    }

    public override string ToString()
    {
        return $"{Nome} {IdFornecedor}";
    }
}