using Snackify.Domain.ValueObjects;
using Xunit;

namespace Snackify.Tests.ValueObjects;

public class MoneyTests
{
    [Fact]
    public void Deve_Criar_Valor_Valido()
    {
        var money = Money.Criar(15.50m);
        Assert.Equal(15.50m, money.Valor);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Para_Valor_Negativo()
    {
        Assert.Throws<ArgumentException>(() => Money.Criar(-1m));
    }

    [Fact]
    public void Deve_Somar_Valores()
    {
        var m1 = Money.Criar(10);
        var m2 = Money.Criar(20);

        var total = m1 + m2;

        Assert.Equal(30m, total.Valor);
    }

    [Fact]
    public void Deve_Subtrair_Valores()
    {
        var m1 = Money.Criar(50);
        var m2 = Money.Criar(20);

        var result = m1 - m2;

        Assert.Equal(30m, result.Valor);
    }
}
