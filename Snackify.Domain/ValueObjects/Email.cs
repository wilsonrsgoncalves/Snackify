using System.Text.RegularExpressions;

namespace Snackify.Domain.ValueObjects
{
    public sealed class Email
    {
        private const string Pattern =
            @"^[^\s@]+@[^\s@]+\.[^\s@]{2,}$"; // simples e eficiente para domínio

        public string Valor { get; }

        public static Email Criar(string endereco) =>
            new(endereco);

        private Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("Email não pode ser vazio.", nameof(endereco));

            endereco = endereco.Trim().ToLowerInvariant();

            if (!EhValido(endereco))
                throw new ArgumentException("Email inválido.", nameof(endereco));

            Valor = endereco;
        }

        private static bool EhValido(string email) =>
            Regex.IsMatch(email, Pattern, RegexOptions.IgnoreCase);

        public override bool Equals(object? obj) =>
            obj is Email other && Valor == other.Valor;

        public override int GetHashCode() => Valor.GetHashCode();

        public override string ToString() => Valor;

        public static implicit operator string(Email email) => email.Valor;
    }
}
