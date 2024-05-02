namespace Victor.Models;
public class Folha
{   
    public Folha (){
        FolhaId = Guid.NewGuid().ToString();
    }
    public Folha (int valor, int quantidade, int mes, int ano){
        FolhaId = Guid.NewGuid().ToString();
        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
        SalarioBruto = SalarioBruto;
        ImpostoIRRF = ImpostoIRRF; 
        ImpostoINSS = ImpostoINSS;
        ImpostoFGTS = ImpostoFGTS;
        SalarioLiquido = SalarioLiquido;
    }

    public string FolhaId { get; set; }
    public int Valor { get; set;}
    public int Quantidade { get; set;}
    public int Ano { get; set;}
    public int Mes { get; set;}
    public decimal SalarioBruto { get; set;}
    public decimal ImpostoIRRF { get; set;}
    public decimal ImpostoINSS { get; set;}
    public decimal ImpostoFGTS { get; set;}
    public decimal SalarioLiquido { get; set;}

}
