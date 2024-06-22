using FluentAssertions;
using HomeOffCine.Tests.TesteAutomatizado.Config;
using Reqnroll;
using Reqnroll.BoDi;

namespace HomeOffCine.Tests.TesteAutomatizado.User;

[Binding]
[CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
public class AdicionarNovoUsuarioStep
{
    private readonly AdicionarNovoUsuarioTela _adicionarNovoUsuarioTela;
    private readonly AutomacaoWebTestsFixture _testsFixture;
    private readonly IObjectContainer _objectContainer;

    public AdicionarNovoUsuarioStep(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
        _testsFixture = _objectContainer.Resolve<AutomacaoWebTestsFixture>();
        _adicionarNovoUsuarioTela = new AdicionarNovoUsuarioTela(_testsFixture.BrowserHelper);
    }

    [When("Ele clicar em cadastrar")]
    public void WhenEleClicarEmCadastrar()
    {
        //Act
        _adicionarNovoUsuarioTela.NavegarParaUrl(_testsFixture.Configuration.RegisterUrl);

        //Assert
        _testsFixture.Configuration
            .RegisterUrl
            .Should()
            .Contain(_adicionarNovoUsuarioTela.ObterUrl());
    }

    [Then("O usuario será redirecionado para a tela com o formulario de cadastro")]
    public void ThenOUsuarioSeraRedirecionadoParaATelaComOFormularioDeCadastro()
    {
        //Assert
        _testsFixture.Configuration
            .RegisterUrl
            .Should()
            .Contain(_adicionarNovoUsuarioTela.ObterUrl());
    }

    [When("E Preencher os dados do formulario")]
    public void WhenEPreencherOsDadosDoFormulario(DataTable dataTable)
    {
        _testsFixture.GerarDadosUsuario();

        // Arrange
        var usuario = _testsFixture.Usuario;

        // Act
        _adicionarNovoUsuarioTela.PreencherFormularioRegistro(usuario);

        // Arrange
        _adicionarNovoUsuarioTela
            .ValidarPreenchimentoFormularioRegistro(usuario)
            .Should()
            .BeTrue();
    }

    [When("Clicar no botão cadastrar")]
    public void WhenClicarNoBotaoCadastrar()
    {
        _adicionarNovoUsuarioTela.ClicarNoBotaoRegistrar();
    }
}