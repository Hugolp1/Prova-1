using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Victor.Models;
using static Victor.Models.Folha;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/", () => "Folhas de pagamento de funcionários");

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDbContext ctx) =>{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
}
);

app.MapGet("/api/funcionario/listar", ([FromServices] AppDbContext ctx) => {
    if(ctx.Funcionarios.Any()){
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound("Não existem funcionários nessa tabela");
});

app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDbContext ctx) =>{
    ctx.Folhas.Add(folha);
    ctx.SaveChanges();
    var folhafunc = new Folha();
    folhafunc.SalarioBruto = folhafunc.Quantidade * folhafunc.Valor;
    if(folhafunc.SalarioBruto <= 1903.93m){
        folhafunc.ImpostoIRRF = 0;
    } else if (folhafunc.SalarioBruto >=1903.99m && folhafunc.SalarioBruto <= 2826.65m){
        folhafunc.ImpostoIRRF = (folhafunc.SalarioBruto * 0.075m) - 142.80m;
    } else if (folhafunc.SalarioBruto >=2826.66m && folhafunc.SalarioBruto <= 3751.05m){
        folhafunc.ImpostoIRRF = (folhafunc.SalarioBruto * 0.15m) - 354.80m;
    } else if (folhafunc.SalarioBruto >=3751.06m && folhafunc.SalarioBruto <= 4664.68m){
        folhafunc.ImpostoIRRF = (folhafunc.SalarioBruto * 0.225m) - 636.13m;
    } else if (folhafunc.SalarioBruto > 4664.68m){
        folhafunc.ImpostoIRRF = (folhafunc.SalarioBruto * 0.275m) - 869.36m;
    }    
    ctx.SaveChanges();
    return Results.Created("", folha);
});

app.MapGet("/api/folha/listar", ([FromServices] AppDbContext ctx ) => {
    if(ctx.Folhas.Any()){
        return Results.Ok(ctx.Folhas.ToList());
    }
    return Results.NotFound("Não existe nenhuma folha nessa tabela");
});

app.Run();