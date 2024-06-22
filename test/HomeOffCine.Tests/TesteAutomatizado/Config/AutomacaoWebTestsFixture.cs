using Bogus;
using Reqnroll;

namespace HomeOffCine.Tests.TesteAutomatizado.Config;

[CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
public class AutomacaoWebFixtureCollection : ICollectionFixture<AutomacaoWebTestsFixture> { }

public class AutomacaoWebTestsFixture
{
    public SeleniumHelper BrowserHelper;
    public readonly ConfigurationHelper Configuration;

    public User.User Usuario;

    public AutomacaoWebTestsFixture()
    {
        Usuario = new User.User();
        Configuration = new ConfigurationHelper();
        BrowserHelper = new SeleniumHelper("Chrome", Configuration, false);
    }

    public void GerarDadosUsuario()
    {
        var faker = new Faker("pt_BR");
        Usuario.Email = faker.Internet.Email().ToLower();
        Usuario.Password = faker.Internet.Password(8, false, "", "@1Ab_");
    }

    public void AcessarSite()
    {
        BrowserHelper.IrParaUrl(BrowserHelper.Configuration.DomainUrl);
    }

    public bool ValidarMensagemDeErroFormulario(string mensagem)
    {
        return BrowserHelper.ObterTextoElementoPorClasseCss("text-danger")
            .Contains(mensagem);
    }
}
