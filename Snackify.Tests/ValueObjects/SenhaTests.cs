using Snackify.Domain.ValueObjects;

namespace Snackify.Tests.ValueObjects;

public class SenhaTests
{
    [Fact]
    public void Deve_Criar_Senha_Valida()
    {
        var senha = Senha.Criar("SenhaForte123!");

        Assert.NotNull(senha);
        Assert.True(senha.Verificar("SenhaForte123!"));
    }

    [Theory]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("abc")]
    public void Nao_Deve_Criar_Senha_Invalida(string valor)
    {
        Assert.Throws<ArgumentException>(() => Senha.Criar(valor));
    }

    [Fact]
    public void Senhas_Iguais_Sao_Iguais()
    {
        var s1 = Senha.Criar("SenhaForte123!");
        var s2 = Senha.Criar("SenhaForte123!");

        Assert.Equal(s1, s2);
        Assert.True(s1.Equals(s2));
    }

    [Fact]
    public void Deve_Verificar_Senha_Correta()
    {
        var senha = Senha.Criar("Senha123");

        Assert.True(senha.Verificar("Senha123"));
    }

    [Fact]
    public void Nao_Deve_Verificar_Senha_Incorreta()
    {
        var senha = Senha.Criar("Senha123");

        Assert.False(senha.Verificar("senhaerrada"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    // [InlineData("Jo")] <- remova essa linha se nomes curtos forem válidos
    public void Deve_Lancar_Excecao_Quando_Nome_For_Invalido(string nomeInvalido)
    {
        var excecao = Assert.Throws<ArgumentException>(() =>
            Nome.Criar(nomeInvalido));

        Assert.Contains("Nome", excecao.Message);
    }
}
