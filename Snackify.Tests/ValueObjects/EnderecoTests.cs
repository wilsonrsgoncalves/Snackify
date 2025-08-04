using Snackify.Domain.ValueObjects;

namespace Snackify.Tests.ValueObjects;

public class EnderecoTests
{
    [Fact]
    public void Deve_Criar_Endereco_Com_Sucesso()
    {
        var endereco = Endereco.Criar(
            rua: "Rua das Flores",
            numero: "123",
            bairro: "Centro",            
            cidade: "São Paulo",
            estado: "SP",
            cep: "01001000"
        );

        Assert.Equal("Rua das Flores", endereco.Rua);
        Assert.Equal("123", endereco.Numero);
        Assert.Equal("Centro", endereco.Bairro);        
        Assert.Equal("São Paulo", endereco.Cidade);
        Assert.Equal("SP", endereco.Estado);
        Assert.Equal("01001000", endereco.Cep);
    }

    [Theory]
    [InlineData("", "123", "Centro", "São Paulo", "SP", "01001000")]
    [InlineData("Rua A", "", "Centro", "São Paulo", "SP", "01001000")]
    [InlineData("Rua A", "123", "", "São Paulo", "SP", "01001000")]
    [InlineData("Rua A", "123", "Centro", "São Paulo", "", "01001000")]
    [InlineData("Rua A", "123", "Centro","" , "SP", "01001000")]
    [InlineData("Rua A", "123", "Centro",  "São Paulo", "SP", "")]
    public void Nao_Deve_Criar_Endereco_Com_Campos_Vazios(
        string rua, string numero, string bairro, string estado, string cidade, string Cep)
    {
        Assert.Throws<ArgumentException>(() =>
            Endereco.Criar(rua, numero, bairro, estado, cidade, Cep));
    }

    [Fact]
    public void Enderecos_Iguais_Devem_Ser_Iguais()
    {
        var e1 = Endereco.Criar("Rua A", "10", "Bairro", "São Paulo", "SP", "12345678");
        var e2 = Endereco.Criar("Rua A", "10", "Bairro", "São Paulo", "SP", "12345678");

        Assert.Equal(e1, e2);
        Assert.True(e1.Equals(e2));
    }

    [Fact]
    public void ToString_Deve_Retornar_Endereco_Formatado()
    {
        var endereco = Endereco.Criar("Rua B", "45", "Centro", "Rio de Janeiro", "RJ", "20000000");

        string resultado = endereco.ToString();
    

        Assert.Equal("Rua B, 45 - Centro, Rio de Janeiro - RJ, CEP: 20000000", resultado);
    }
    [Theory]
    [InlineData("", "123", "Centro", "São Paulo", "SP", "01001000", "Rua inválida")]
    [InlineData("Rua das Flores", "", "Centro", "São Paulo", "SP", "01001000", "Número inválido")]
    [InlineData("Rua das Flores", "123", "", "São Paulo", "SP", "01001000", "Bairro inválido")]
    [InlineData("Rua das Flores", "123", "Centro", "", "SP", "01001000", "Cidade inválida")]
    [InlineData("Rua das Flores", "123", "Centro", "São Paulo", "", "01001000", "Estado inválido")]
    [InlineData("Rua das Flores", "123", "Centro", "São Paulo", "ABC", "01001000", "Estado inválido")]
    [InlineData("Rua das Flores", "123", "Centro", "São Paulo", "SP", "", "CEP inválido")]
    [InlineData("Rua das Flores", "123", "Centro", "São Paulo", "SP", "123", "CEP inválido")]
    public void Deve_Lancar_Excecao_Quando_Endereco_Tiver_Campo_Invalido(
           string rua,
           string numero,
           string bairro,
           string cidade,
           string estado,
           string cep,
           string mensagemEsperada)
    {
        // Act & Assert
        var excecao = Assert.Throws<ArgumentException>(() =>
            Endereco.Criar(rua, numero, bairro, cidade, estado, cep));

        Assert.Equal(mensagemEsperada, excecao.Message);
    }
}
