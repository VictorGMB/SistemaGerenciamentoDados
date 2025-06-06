using System.Collections.Generic;

public static class DataManager
{
    public static List<string> Clientes = new List<string>();
    public static List<string> Fornecedores = new List<string>();
    public static List<string> Produtos = new List<string>();
    public static List<string> Funcionarios = new List<string>();
    public static List<string> Vendas = new List<string>();

    public static void AtualizarClientes(ListBox listBox)
    {
        Clientes.Clear();
        foreach (var item in listBox.Items)
            Clientes.Add(item.ToString());
    }

    public static void AtualizarFornecedores(ListBox listBox)
    {
        Fornecedores.Clear();
        foreach (var item in listBox.Items)
            Fornecedores.Add(item.ToString());
    }

    public static void AtualizarProdutos(ListBox listBox)
    {
        Produtos.Clear();
        foreach (var item in listBox.Items)
            Produtos.Add(item.ToString());
    }

    public static void AtualizarFuncionarios(ListBox listBox)
    {
        Funcionarios.Clear();
        foreach (var item in listBox.Items)
            Funcionarios.Add(item.ToString());
    }

    public static void AtualizarVendas(ListBox listBox)
    {
        Vendas.Clear();
        foreach (var item in listBox.Items)
            Vendas.Add(item.ToString());
    }
}
