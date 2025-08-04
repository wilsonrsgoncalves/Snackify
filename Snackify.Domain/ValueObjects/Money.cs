namespace Snackify.Domain.ValueObjects;

public readonly struct Money : IEquatable<Money>
{
    public decimal Valor { get; }

    public static Money Criar(decimal valor)
    {
        if (valor < 0)
            throw new ArgumentException("Valor monetário não pode ser negativo", nameof(valor));
        return new Money(valor);
    }

    private Money(decimal valor)
    {
        if (valor < 0)
            throw new ArgumentException("Valor monetário não pode ser negativo");

        Valor = Math.Round(valor, 2);
    }

    public override string ToString() => Valor.ToString("C");

    public Money Somar(Money outro) => new(Valor + outro.Valor);
    public Money Subtrair(Money outro) => new(Valor - outro.Valor);

    public bool Equals(Money other) => Valor == other.Valor;

    public override bool Equals(object? obj) => obj is Money other && Equals(other); 
    public override int GetHashCode() => Valor.GetHashCode();

    public static bool operator ==(Money a, Money b) => a.Equals(b);
    public static bool operator !=(Money a, Money b) => !a.Equals(b);
    public static Money operator +(Money a, Money b) => a.Somar(b);
    public static Money operator -(Money a, Money b) => a.Subtrair(b);
}
