using Snackify.Domain.ValueObjects;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

namespace Snackify.Tests.ValueObjects;

public class EmailTests
{
    [Theory]
    [InlineData("usuario@dominio.com")]
    [InlineData("USER@DOMAIN.COM")]
    public void Deve_Criar_Email_Valido(string endereco)
    {
        var email = Email.Criar(endereco);

        Assert.Equal(endereco.Trim().ToLowerInvariant(), email.Valor);
    }

    [Theory]
    [InlineData("")]
    [InlineData("usuario@")]
    [InlineData("@dominio.com")]
    [InlineData("email_invalido")]
    public void Nao_Deve_Criar_Email_Invalido(string endereco)
    {
        Assert.Throws<ArgumentException>(() => Email.Criar(endereco));
    }

    [Fact]
    public void Emails_Iguais_Devem_Ser_Iguais()
    {
        var email1 = Email.Criar("usuario@dominio.com");
        var email2 = Email.Criar("USUARIO@DOMINIO.COM");

        Assert.Equal(email1, email2);
        Assert.True(email1.Equals(email2));
    }

    [Fact]
    public void Deve_Converter_Email_Implicitamente_Para_String()
    {
        var email = Email.Criar("usuario@dominio.com");

        string valor = email;

        Assert.Equal("usuario@dominio.com", valor);
    }

    [Fact]
    public void ToString_Deve_Retornar_Endereco_Email()
    {
        var email = Email.Criar("usuario@dominio.com");

        Assert.Equal("usuario@dominio.com", email.ToString());
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Email_For_Vazio()
    {
        // Arrange
        var emailInvalido = "";

        // Act & Assert
        var excecao = Assert.Throws<ArgumentException>(() => Email.Criar(emailInvalido));
        Assert.Equal("Email não pode ser vazio. (Parameter 'endereco')", excecao.Message);
    }

    [Theory]
    [InlineData("email-invalido")]
    [InlineData("email@")]
    [InlineData("email@com")]
    [InlineData("email.com")]
    public void Deve_Lancar_Excecao_Quando_Email_Tiver_Formato_Invalido(string emailInvalido)
    {
        // Act & Assert
        var excecao = Assert.Throws<ArgumentException>(() => Email.Criar(emailInvalido));
        Assert.Equal("Email inválido. (Parameter 'endereco')", excecao.Message);
    }
}
