using Snackify.Domain.Entities;
using Snackify.Domain.ValueObjects;

namespace Snackify.Tests.Builders;

public class ClienteBuilder
{
    private Nome _nome = Nome.Criar("Wilson Gonçalves");
    private CPF _cpf = CPF.Criar("12345678909");
    private Email _email = Email.Criar("wilson@email.com");
    private Telefone _telefone = Telefone.Criar("11999999999");
    private Endereco _endereco = Endereco.Criar("Rua das Flores", "123", "Centro",  "São Paulo", "SP", "01001000");
    private Senha _senha = Senha.Criar("senha123");

    public ClienteBuilder ComNome(string nome)
    {
        _nome = Nome.Criar(nome);
        return this;
    }

    public ClienteBuilder ComCPF(string cpf)
    {
        _cpf = CPF.Criar(cpf);
        return this;
    }

    public ClienteBuilder ComEmail(string email)
    {
        _email = Email.Criar(email);
        return this;
    }

    public ClienteBuilder ComTelefone(string telefone)
    {
        _telefone = Telefone.Criar(telefone);
        return this;
    }

    public ClienteBuilder ComEndereco(Endereco endereco)
    {
        _endereco = endereco;
        return this;
    }

    public ClienteBuilder ComSenha(string senha)
    {
        _senha = Senha.Criar(senha);
        return this;
    }

    public Cliente Build()
    {
        return Cliente.Criar(_nome, _cpf, _email, _telefone, _endereco, _senha);
    }
}
