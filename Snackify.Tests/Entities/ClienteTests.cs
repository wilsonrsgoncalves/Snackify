using Snackify.Domain.Entities;
using Snackify.Domain.ValueObjects;
using Snackify.Tests.Builders;

namespace Snackify.Tests.Entities;

public class ClienteTests
{
    [Fact]
    public void Deve_Criar_Cliente_Com_Sucesso()
    {
        var cliente = new ClienteBuilder().Build();

        Assert.NotEqual(Guid.Empty, cliente.Id);
        Assert.Equal("Wilson Gonçalves", cliente.Nome.Valor);
        Assert.Equal("12345678909", cliente.Cpf.Numero);
        Assert.Equal("wilson@email.com", cliente.Email.Valor);
        Assert.True(cliente.Autenticar("senha123"));
    }

    [Fact]
    public void Deve_Atualizar_Endereco()
    {
        var cliente = new ClienteBuilder().Build();

        var novoEndereco = Endereco.Criar("Nova Rua", "456", "Bairro Novo",  "São Paulo", "SP", "11111111");

        cliente.AtualizarEndereco(novoEndereco);

        Assert.Equal("Nova Rua", cliente.Endereco.Rua);
        Assert.Equal("456", cliente.Endereco.Numero);
        Assert.Equal("Bairro Novo", cliente.Endereco.Bairro);
    }
}
