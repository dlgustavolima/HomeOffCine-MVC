using FluentAssertions;
using HomeOffCine.TestsAutomated.TesteAutomatizado.Config;
using Reqnroll;
using Reqnroll.BoDi;

namespace HomeOffCine.TestsAutomated.TesteAutomatizado.User;

[Binding]
[CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
public class LoginStep
{
    private readonly LoginTela _loginTela;
    private readonly AutomacaoWebTestsFixture _testsFixture;
    private readonly IObjectContainer _objectContainer;

    public LoginStep(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
        _testsFixture = _objectContainer.Resolve<AutomacaoWebTestsFixture>();
        _loginTela = new LoginTela(_testsFixture.BrowserHelper);
    }

    [When("Ele clicar em login")]
    public void WhenEleClicarEmLogin()
    {
        _loginTela.ClicarEmLogin();
    }

    [Then("O usuario será redirecionado para a tela de login")]
    public void ThenOUsuarioSeraRedirecionadoParaATelaDeLogin()
    {
        //assert
        _testsFixture.Configuration
            .LoginUrl
            .Should()
            .Contain(_loginTela.ObterUrl());
    }

    [When("O usuario preencher o formulario")]
    public void WhenOUsuarioPreencherOFormulario(DataTable dataTable)
    {
        // Arrange
        var usuario = new User 
        {
            Email = "teste@teste.com.br",
            Password = "Teste@123"
        };

        _testsFixture.Usuario = usuario;

        // Act
        _loginTela.PreencherFormularioLogin(usuario);

        // Arrange
        _loginTela
            .ValidarPreenchimentoFormularioRegistro(usuario)
            .Should()
            .BeTrue();
    }

    [When("Ele clicar em logar")]
    public void WhenEleClicarEmLogar()
    {
        _loginTela.ClicarParaLogar();
    }
}