using FluentAssertions;
using HomeOffCine.TestsAutomated.TesteAutomatizado.Config;
using Reqnroll;

namespace HomeOffCine.TestsAutomated.TesteAutomatizado.User
{
    [Binding]
    [CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
    public class Commom 
    {
        private readonly AutomacaoWebTestsFixture _testsFixture;
        private readonly AdicionarNovoUsuarioTela _adicionarNovoUsuarioTela;

        public Commom(AutomacaoWebTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
            _adicionarNovoUsuarioTela = new AdicionarNovoUsuarioTela(_testsFixture.BrowserHelper);
        }

        [Given("Que o usuario acessou o site")]
        public void GivenQueOUsuarioAcessouOSite()
        {
            //Act
            _testsFixture.AcessarSite();

            //Assert
            _testsFixture.Configuration
                .HomeUrl
                .Should()
                .Contain(_adicionarNovoUsuarioTela.ObterUrl());
        }

        [Then("O usuario será redirecionado para a Home")]
        public void ThenOUsuarioSeraRedirecionadoParaAHome()
        {
            //Assert
            _testsFixture.Configuration
                .HomeUrl
                .Should()
                .Contain(_adicionarNovoUsuarioTela.ObterUrl());
        }


        [Then("Uma saudação com seu e-mail será exibida no menu superior")]
        public void ThenUmaSaudacaoComSeuE_MailSeraExibidaNoMenuSuperior()
        {
            // Arrange
            var usuario = _testsFixture.Usuario;

            //Assert
            _adicionarNovoUsuarioTela
                .ValidarSaudacaoUsuarioLogado(usuario)
                .Should()
                .BeTrue();
        }
    }
}
