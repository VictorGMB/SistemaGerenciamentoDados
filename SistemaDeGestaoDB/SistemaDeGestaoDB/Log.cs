using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_banco_de_dados
{
    public class Log
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Tabela { get; set; }
        public string Atividade { get; set; }
        public DateTime Data { get; set; }

        public List<Log> ReadAll()
        {
            List<Log> listaLogs = new List<Log>();
            MySqlConnection conexao = Banco.GetConexao();
            string sql = "SELECT * FROM log ORDER BY data DESC;";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Log log = new Log();
                log.Id = reader.GetInt32("id");
                log.Usuario = reader.GetString("usuario");
                log.Tabela = reader.GetString("tabela");
                log.Atividade = reader.GetString("atividade");
                log.Data = reader.GetDateTime("data");
                listaLogs.Add(log);
            }
            reader.Close();

            return listaLogs;
        }

        public override string ToString()
        {
            return $"{Id} {Usuario} {Tabela} {Atividade} {Data.ToShortDateString()}";
        }
    }
}
