using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

public class Venda
{
    public int IdVenda { get; set; }
    public int IdCliente { get; set; }
    public int IdProduto { get; set; }
    public float Valor { get; set; }
    public int IdFuncionario { get; set; }
    public DateTime Data { get; set; }

    public bool Create()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "INSERT INTO venda (idCliente, idProduto, valor, idFuncionario, data) VALUES (@idCliente, @idProduto, @valor, @idFuncionario, @data);";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idCliente", IdCliente);
        cmd.Parameters.AddWithValue("@idProduto", IdProduto);
        cmd.Parameters.AddWithValue("@valor", Valor);
        cmd.Parameters.AddWithValue("@idFuncionario", IdFuncionario);
        cmd.Parameters.AddWithValue("@data", Data);

        bool executou = cmd.ExecuteNonQuery() > 0;
        IdVenda = (int)cmd.LastInsertedId;

        return executou;
    }

    public bool Delete()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "DELETE FROM venda WHERE idVenda = @idVenda;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idVenda", IdVenda);

        return cmd.ExecuteNonQuery() > 0;
    }

    public bool Update()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "UPDATE venda SET idCliente = @idCliente, idProduto = @idProduto, valor = @valor, idFuncionario = @idFuncionario, data = @data WHERE idVenda = @idVenda;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idCliente", IdCliente);
        cmd.Parameters.AddWithValue("@idProduto", IdProduto);
        cmd.Parameters.AddWithValue("@valor", Valor);
        cmd.Parameters.AddWithValue("@idFuncionario", IdFuncionario);
        cmd.Parameters.AddWithValue("@data", Data);
        cmd.Parameters.AddWithValue("@idVenda", IdVenda);

        return cmd.ExecuteNonQuery() > 0;
    }

    public bool IsVenda()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT COUNT(*) FROM venda WHERE idVenda = @idVenda;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idVenda", IdVenda);

        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    public List<Venda> ReadAll()
    {
        List<Venda> listaVendas = new List<Venda>();
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM venda ORDER BY data DESC;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Venda venda = new Venda();
            venda.IdVenda = reader.GetInt32("idVenda");
            venda.IdCliente = reader.GetInt32("idCliente");
            venda.IdProduto = reader.GetInt32("idProduto");
            venda.Valor = reader.GetFloat("valor");
            venda.IdFuncionario = reader.GetInt32("idFuncionario");
            venda.Data = reader.GetDateTime("data");
            listaVendas.Add(venda);
        }
        reader.Close();

        return listaVendas;
    }

    public static Venda ReadByID(int idVenda)
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM venda WHERE idVenda = @idVenda;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idVenda", idVenda);

        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Venda venda = new Venda();
            venda.IdVenda = reader.GetInt32("idVenda");
            venda.IdCliente = reader.GetInt32("idCliente");
            venda.IdProduto = reader.GetInt32("idProduto");
            venda.Valor = reader.GetFloat("valor");
            venda.IdFuncionario = reader.GetInt32("idFuncionario");
            venda.Data = reader.GetDateTime("data");
            reader.Close();
            return venda;
        }
        reader.Close();
        return null;
    }

    public override string ToString()
    {
        return $"{IdVenda} {IdCliente} {IdProduto} {Valor} {IdFuncionario} {Data.ToShortDateString()}";
    }
}