using Snackify.Domain.ValueObjects;

namespace Snackify.Tests.ValueObjects;

public class TelefoneTests
{
    [Theory]
    //[InlineData("+5511987654321")]
    [InlineData("11987654321")]
    [InlineData("(11)98765-4321")]
    public void Deve_Criar_Telefone_Valido(string numero)
    {
        var telefone = Telefone.Criar(numero);

        Assert.Equal("11987654321", telefone.Numero);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc123")]
    [InlineData("12345")]
    public void Nao_Deve_Criar_Telefone_Invalido(string numero)
    {
        Assert.Throws<ArgumentException>(() => Telefone.Criar(numero));
    }

    [Fact]
    public void Telefones_Iguais_Devem_Ser_Iguais()
    {
        var t1 = Telefone.Criar("(11)98765-4321");
        var t2 = Telefone.Criar("11987654321");

        Assert.Equal(t1, t2);
        Assert.True(t1.Equals(t2));
    }


    [Fact]
    public void Deve_Lancar_Excecao_Quando_Telefone_For_Vazio()
    {
        // Arrange
        var telefoneInvalido = "";

        // Act & Assert
        var excecao = Assert.Throws<ArgumentException>(() => Telefone.Criar(telefoneInvalido));
        Assert.Equal("Telefone não pode ser vazio.", excecao.Message);
    }

    [Theory(DisplayName = "Deve lançar exceção quando telefone for inválido")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("123")]
    [InlineData("abcdefghij")]
    [InlineData("119876543")]       // Menos dígitos
    [InlineData("119876543210")]    // Mais dígitos
    [InlineData("(11)98765-432")]   // Menos dígitos no final
    [InlineData("119765432")]       // Sem nono dígito obrigatório (depois do DDD)
    public void Deve_Lancar_Excecao_Quando_Telefone_For_Invalido(string telefoneInvalido)
    {
        // Act & Assert
        var excecao = Assert.Throws<ArgumentException>(() =>
            Telefone.Criar(telefoneInvalido));

        Assert.Contains("Telefone", excecao.Message);
    }
}
