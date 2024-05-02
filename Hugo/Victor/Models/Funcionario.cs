namespace Victor.Models;

public class Funcionario
{
    public Funcionario(){
        FuncionarioId = Guid.NewGuid().ToString();
    }

    public Funcionario(string nome, string cpf){
        FuncionarioId = Guid.NewGuid().ToString();
        Nome = nome;
        CPF = cpf;
    }

    public string FuncionarioId { get; set;}
    public string? Nome { get; set;}
    public string? CPF { get; set;}  
}
