using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;


public class Fornecedor
{
    
    public int IdFornecedor { get; set; }

    
    public string Nome { get; set; }

    
    public string CNPJ { get; set; }

   
    public bool Create()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "INSERT INTO fornecedor (nome, CNPJ) VALUES (@nome, @CNPJ);";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@nome", Nome);
        cmd.Parameters.AddWithValue("@CNPJ", CNPJ);

        bool executou = cmd.ExecuteNonQuery() > 0;
        IdFornecedor = (int)cmd.LastInsertedId;

        return executou;
    }

    
    public bool Delete()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "DELETE FROM fornecedor WHERE idFornecedor = @idFornecedor;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idFornecedor", IdFornecedor);

        return cmd.ExecuteNonQuery() > 0;
    }

   
    public bool Update()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "UPDATE fornecedor SET nome = @nome, CNPJ = @CNPJ WHERE idFornecedor = @idFornecedor;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@nome", Nome);
        cmd.Parameters.AddWithValue("@CNPJ", CNPJ);
        cmd.Parameters.AddWithValue("@idFornecedor", IdFornecedor);

        return cmd.ExecuteNonQuery() > 0;
    }

    
    public bool IsFornecedor()
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT COUNT(*) FROM fornecedor WHERE CNPJ = @CNPJ;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@CNPJ", CNPJ);

        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    
    public List<Fornecedor> ReadAll()
    {
        List<Fornecedor> listaFornecedores = new List<Fornecedor>();
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM fornecedor ORDER BY nome;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.IdFornecedor = reader.GetInt32("idFornecedor");
            fornecedor.Nome = reader.GetString("nome");
            fornecedor.CNPJ = reader.GetString("CNPJ");
            listaFornecedores.Add(fornecedor);
        }
        reader.Close();

        return listaFornecedores;
    }

   
    public static Fornecedor ReadByID(int idFornecedor)
    {
        MySqlConnection conexao = Banco.GetConexao();
        string sql = "SELECT * FROM fornecedor WHERE idFornecedor = @idFornecedor;";
        MySqlCommand cmd = new MySqlCommand(sql, conexao);

        cmd.Parameters.AddWithValue("@idFornecedor", idFornecedor);

        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.IdFornecedor = reader.GetInt32("idFornecedor");
            fornecedor.Nome = reader.GetString("nome");
            fornecedor.CNPJ = reader.GetString("CNPJ");
            reader.Close();
            return fornecedor;
        }
        reader.Close();
        return null;
    }

    public override string ToString()
    {
        return $"{Nome} {CNPJ}";
    }
}
