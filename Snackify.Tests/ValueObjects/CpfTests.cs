using Snackify.Domain.ValueObjects;

namespace Snackify.Tests.ValueObjects;

public class CpfTests
{
    [Theory]
    [InlineData("123.456.789-09")]
    [InlineData("12345678909")]
    public void Deve_Criar_CPF_Valido(string valor)
    {
        var cpf = CPF.Criar(valor);

        Assert.Equal("12345678909", cpf.Numero);
    }

    [Theory]
    [InlineData("")]
    [InlineData("111.111.111-11")]
    [InlineData("00000000000")]
    [InlineData("123456789")]
    [InlineData("abc")]
    public void Nao_Deve_Criar_CPF_Invalido(string valor)
    {
        Assert.Throws<ArgumentException>(() => CPF.Criar(valor));
    }

    [Fact]
    public void CPF_Implicit_Conversion_Para_String()
    {
        var cpf = CPF.Criar("12345678909");

        string valor = cpf;

        Assert.Equal("12345678909", valor);
    }

    [Fact]
    public void CPF_ToString_Deve_Formatar_Corretamente()
    {
        var cpf = CPF.Criar("12345678909");

        Assert.Equal("123.456.789-09", cpf.ToString());
    }

    [Fact]
    public void CPFs_Iguais_Devem_Ser_Considerados_Iguais()
    {
        var cpf1 = CPF.Criar("12345678909");
        var cpf2 = CPF.Criar("123.456.789-09");

        Assert.Equal(cpf1, cpf2);
        Assert.True(cpf1.Equals(cpf2));
    }

     [Fact]
        public void Deve_Lancar_Excecao_Quando_CPF_For_Vazio()
        {
            // Arrange
            var cpfInvalido = "";

            // Act & Assert
            var excecao = Assert.Throws<ArgumentException>(() => CPF.Criar(cpfInvalido));
            Assert.Equal("CPF não pode ser vazio. (Parameter 'numero')", excecao.Message);        
        }

        [Fact]
        public void Deve_Lancar_Excecao_Quando_CPF_For_Invalido()
        {
            // Arrange
            var cpfInvalido = "12345678900"; // inválido

            // Act & Assert
            var excecao = Assert.Throws<ArgumentException>(() => CPF.Criar(cpfInvalido));
            Assert.Equal("CPF inválido. (Parameter 'numero')", excecao.Message);
    }
}
