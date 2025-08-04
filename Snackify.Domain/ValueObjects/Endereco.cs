namespace Snackify.Domain.ValueObjects;

public sealed class Endereco : IEquatable<Endereco>
{
    public string Rua { get; }
    public string Numero { get; }
    public string Bairro { get; }
    public string Cidade { get; }
    public string Estado { get; }
    public string Cep { get; }

    public static Endereco Criar(string rua, string numero, string bairro, string cidade, string estado, string cep)
    {
        return new Endereco(rua, numero, bairro, cidade, estado, cep);
    }

    private Endereco(string rua, string numero, string bairro, string cidade, string estado, string cep)
    {
        if (string.IsNullOrWhiteSpace(rua)) throw new ArgumentException("Rua inválida");
        if (string.IsNullOrWhiteSpace(numero)) throw new ArgumentException("Número inválido");
        if (string.IsNullOrWhiteSpace(bairro)) throw new ArgumentException("Bairro inválido");
        if (string.IsNullOrWhiteSpace(cidade)) throw new ArgumentException("Cidade inválida");
        if (string.IsNullOrWhiteSpace(estado) || estado.Length != 2) throw new ArgumentException("Estado inválido");
        if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8) throw new ArgumentException("CEP inválido");

        Rua = rua.Trim();
        Numero = numero.Trim();
        Bairro = bairro.Trim();
        Cidade = cidade.Trim();
        Estado = estado.Trim().ToUpper();
        Cep = cep.Trim();
    }

    public override string ToString() =>
        $"{Rua}, {Numero} - {Bairro}, {Cidade} - {Estado}, CEP: {Cep}";

    public override bool Equals(object obj) =>
        obj is not null &&
        obj is Endereco endereco && Equals(endereco);

    public bool Equals(Endereco? other) =>
        other is not null &&
        Rua == other.Rua &&
        Numero == other.Numero &&
        Bairro == other.Bairro &&
        Cidade == other.Cidade &&
        Estado == other.Estado &&
        Cep == other.Cep;

    public override int GetHashCode() =>
        HashCode.Combine(Rua, Numero, Bairro, Cidade, Estado, Cep);

    public static bool operator ==(Endereco a, Endereco b) => a.Equals(b);
    public static bool operator !=(Endereco a, Endereco b) => !a.Equals(b);
}
