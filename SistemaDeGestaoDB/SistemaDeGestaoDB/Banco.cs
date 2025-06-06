using System;
using System.Data;
using MySql.Data.MySqlClient;

public class Banco
{
    // Propriedades estáticas para armazenar informações de conexão
    private static readonly string HOST = "127.0.0.1";
    private static readonly string USER = "root";
    private static readonly string PWD = "12345";
    private static readonly string DB = "banco_vendas";
    private static readonly int PORT = 3306;
    private static MySqlConnection CONEXAO = null;

    // Método privado para estabelecer uma conexão com o banco de dados
    private static void Conectar()
    {
        if (CONEXAO == null)
        {
            try
            {
                string connectionString = $"Server={Banco.HOST};Port={Banco.PORT};Database={Banco.DB};User={Banco.USER};Password={Banco.PWD};";
                CONEXAO = new MySqlConnection(connectionString);
                CONEXAO.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao conectar no banco: " + ex.Message);
                throw;
            }
        }
    }
    // Método público para obter a conexão com o banco de dados
    public static MySqlConnection GetConexao()
    {
        if (CONEXAO == null || CONEXAO.State == ConnectionState.Closed)
        {
            Conectar();
        }
        return CONEXAO;
    }

    public static void CriarBackup()
    {
        try
        {
            string command = $"mysqldump -h {Banco.HOST} -u {Banco.USER} -p{Banco.PWD} --databases {Banco.DB} > C:\\Users\\danie\\Downloads\\backup.sql";

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + command);
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = psi;
            process.Start();
            process.WaitForExit();

            MessageBox.Show("Backup realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao realizar backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void Restaurar()
    {
        try
        {
            string backupFile = "C:\\Users\\danie\\Downloads\\backup.sql";

            string command = $"mysql --user={Banco.USER} --password=sua_senha --host=seu_servidor seu_banco < \"{backupFile}\"";

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + command);
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = psi;
            process.Start();
            process.WaitForExit();

            MessageBox.Show("Restauração realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao restaurar backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
