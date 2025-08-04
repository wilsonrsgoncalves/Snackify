using System.Text.RegularExpressions;

namespace Snackify.Domain.ValueObjects;

public sealed class Telefone : IEquatable<Telefone>
{
    public string Numero { get; }

    public static Regex Regex => _regex;

    private static readonly Regex _regex = new(@"^\(?\d{2}\)?9\d{4}-?\d{4}$");

    public static Telefone Criar(string numero)
    {
        {
            return new Telefone(numero);
        }

    }
    private Telefone(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
            throw new ArgumentException("Telefone não pode ser vazio.");

        numero = numero.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

        if (!_regex.IsMatch(numero))
            throw new ArgumentException("Telefone inválido.");

        Numero = numero;
    }

    public override string ToString() =>
        $"({Numero.Substring(0, 2)}) {Numero.Substring(2, 5)}-{Numero.Substring(7)}";

    public override bool Equals(object obj) =>
        obj is Telefone telefone && Equals(telefone);

    public bool Equals(Telefone other) =>
        Numero == other.Numero;

    public override int GetHashCode() => Numero.GetHashCode();

    public static bool operator ==(Telefone a, Telefone b) => a.Equals(b);
    public static bool operator !=(Telefone a, Telefone b) => !a.Equals(b);
}
