using System.Security.Cryptography;
using System.Text;

namespace Snackify.Domain.ValueObjects;

public sealed class Senha : IEquatable<Senha>
{
    public string Hash { get; }

    private Senha(string hash)
    {
        Hash = hash;
    }

    public static Senha Criar(string senhaClara)
    {
        if (string.IsNullOrWhiteSpace(senhaClara) || senhaClara.Length < 6)
            throw new ArgumentException("Senha deve conter pelo menos 6 caracteres");

        var hash = GerarHash(senhaClara);
        return new Senha(hash);
    }

    private static string GerarHash(string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hashBytes);
    }

    public bool Verificar(string senhaClara)
    {
        var hashInput = GerarHash(senhaClara);
        return Hash == hashInput;
    }

    public bool Equals(Senha other) => Hash == other?.Hash;

    public override bool Equals(object obj) => obj is Senha other && Equals(other);
    public override int GetHashCode() => Hash.GetHashCode();

    public static bool operator ==(Senha a, Senha b) => a.Equals(b);
    public static bool operator !=(Senha a, Senha b) => !a.Equals(b);
}
