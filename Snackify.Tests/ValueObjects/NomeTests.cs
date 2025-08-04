using Snackify.Domain.ValueObjects;

namespace Snackify.Tests.ValueObjects;
public class NomeTests
{
    [Fact]
    public void Deve_Criar_Nome_Valido()
    {
        var nome = Nome.Criar("Wilson Gonçalves");

        Assert.Equal("Wilson Gonçalves", nome.Valor);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(data: null)]
    public void Nao_Deve_Criar_Nome_Invalido(string? valor)
    {
        Assert.Throws<ArgumentException>(() => Nome.Criar(valor!));
    }

    [Fact]
    public void Nomes_Iguais_Sao_Iguais()
    {
        var n1 = Nome.Criar("Wilson Gonçalves");
        var n2 = Nome.Criar("Wilson Gonçalves");

        Assert.Equal(n1, n2);
        Assert.True(n1.Equals(n2));
    }

    [Fact]
    public void ToString_Deve_Retornar_Valor()
    {
        var nome = Nome.Criar("Wilson Gonçalves");

        Assert.Equal("Wilson Gonçalves", nome.ToString());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("A")]
    [InlineData("Jo")]
    public void Deve_Lancar_Excecao_Quando_Nome_For_Invalido(string nomeInvalido)
    {
        // Act & Assert
        var excecao = Assert.Throws<ArgumentException>(() =>
            Nome.Criar(nomeInvalido));

        Assert.Contains("Nome", excecao.Message);
    }
}
