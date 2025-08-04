using Snackify.Domain.ValueObjects;

namespace Snackify.Domain.Entities;

public class Cliente
{
    public Guid Id { get; private set; }
    public Nome Nome { get; private set; }
    public CPF Cpf { get; private set; }
    public Email Email { get; private set; }
    public Telefone Telefone { get; private set; }
    public Endereco Endereco { get; private set; }
    public Senha Senha { get; private set; }
    public DateTime CriadoEm { get; private set; }

    //private Cliente() { } 

    private Cliente(Guid id, Nome nome, CPF cpf, Email email, Telefone telefone, Endereco endereco, Senha senha)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        Senha = senha;
        CriadoEm = DateTime.UtcNow;
    }

    public static Cliente Criar(Nome nome, CPF cpf, Email email, Telefone telefone, Endereco endereco, Senha senha)
    {
        return new Cliente(Guid.NewGuid(), nome, cpf, email, telefone, endereco, senha);
    }

    public void AtualizarEndereco(Endereco novoEndereco)
    {
        Endereco = novoEndereco;
    }

    public bool Autenticar(string senha)
    {
        return Senha.Verificar(senha);
    }
}
