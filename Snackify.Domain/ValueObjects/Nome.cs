namespace Snackify.Domain.ValueObjects;

public sealed class Nome
{
    public string Valor { get; }

    public static Nome Criar(string valor) => new Nome(valor);

    private Nome(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("Nome não pode ser vazio.");

        if (valor.Trim().Length < 3)
            throw new ArgumentException("Nome deve conter ao menos 3 caracteres.");

        Valor = valor.Trim();
    }

    public override string ToString() => Valor;

    public override bool Equals(object? obj) =>
        obj is Nome nome && Valor == nome.Valor;

    public override int GetHashCode() => Valor.GetHashCode();

    public static implicit operator string(Nome nome) => nome.Valor;
}
