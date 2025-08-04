using System.Text.RegularExpressions;

namespace Snackify.Domain.ValueObjects
{
    public sealed class CPF
    {
        private const int TamanhoCPF = 11;
        public string Numero { get; }

        public static CPF Criar(string numero) => new(numero);

        private CPF(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("CPF não pode ser vazio.", nameof(numero));

            var apenasNumeros = RemoverNaoNumericos(numero);

            if (!EhValido(apenasNumeros))
                throw new ArgumentException("CPF inválido.", nameof(numero));

            Numero = apenasNumeros;
        }

        private static string RemoverNaoNumericos(string valor) =>
            Regex.Replace(valor, "[^0-9]", "");

        private static bool EhValido(string cpf)
        {
            if (cpf.Length != TamanhoCPF || cpf.Distinct().Count() == 1)
                return false;

            var cpfSemDigitos = cpf[..9];
            var primeiroDigito = CalcularDigitoVerificador(cpfSemDigitos, new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 });
            var segundoDigito = CalcularDigitoVerificador(cpfSemDigitos + primeiroDigito, new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 });

            return cpf.EndsWith($"{primeiroDigito}{segundoDigito}");
        }

        private static int CalcularDigitoVerificador(string cpfParcial, int[] multiplicadores)
        {
            var soma = cpfParcial
                .Select((caractere, indice) => int.Parse(caractere.ToString()) * multiplicadores[indice])
                .Sum();

            var resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        public override bool Equals(object? obj) =>
            obj is CPF other && Numero == other.Numero;

        public override int GetHashCode() => Numero.GetHashCode();

        public override string ToString() =>
            Convert.ToUInt64(Numero).ToString(@"000\.000\.000\-00");

        public static implicit operator string(CPF cpf) => cpf.Numero;
    }
}
