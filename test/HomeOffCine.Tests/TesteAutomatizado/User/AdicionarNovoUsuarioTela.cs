using HomeOffCine.Tests.TesteAutomatizado.Config;

namespace HomeOffCine.Tests.TesteAutomatizado.User;

public class AdicionarNovoUsuarioTela : BaseUserTela
{
    public AdicionarNovoUsuarioTela(SeleniumHelper helper) : base(helper)
    {
    }

    public void ClicarNoLinkRegistrar()
    {
        Helper.ClicarLinkPorTexto("Register");
    }

    public void PreencherFormularioRegistro(User usuario)
    {
        Helper.PreencherTextBoxPorId("Input_Email", usuario.Email);
        Helper.PreencherTextBoxPorId("Input_Password", usuario.Password);
        Helper.PreencherTextBoxPorId("Input_ConfirmPassword", usuario.Password);
    }

    public bool ValidarPreenchimentoFormularioRegistro(User usuario)
    {
        if (Helper.ObterValorTextBoxPorId("Input_Email") != usuario.Email) return false;
        if (Helper.ObterValorTextBoxPorId("Input_Password") != usuario.Password) return false;
        if (Helper.ObterValorTextBoxPorId("Input_ConfirmPassword") != usuario.Password) return false;

        return true;
    }

    public void ClicarNoBotaoRegistrar()
    {
        Helper.ClicarBotaoPorId("registerSubmit");
    }
}