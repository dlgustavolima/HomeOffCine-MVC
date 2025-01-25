using HomeOffCine.TestsAutomated.TesteAutomatizado.Config;

namespace HomeOffCine.TestsAutomated.TesteAutomatizado.User;

public class LoginTela : BaseUserTela
{
    public LoginTela(SeleniumHelper helper) : base(helper) { }

    public void ClicarEmLogin() 
    {
        Helper.ClicarBotaoPorId("login");
    }

    public void ClicarParaLogar()
    {
        Helper.ClicarBotaoPorId("login-submit");
    }

    public void PreencherFormularioLogin(User usuario) 
    {
        Helper.PreencherTextBoxPorId("Input_Email", usuario.Email);
        Helper.PreencherTextBoxPorId("Input_Password", usuario.Password);
    }

    public bool ValidarPreenchimentoFormularioRegistro(User usuario)
    {
        if (Helper.ObterValorTextBoxPorId("Input_Email") != usuario.Email) return false;
        if (Helper.ObterValorTextBoxPorId("Input_Password") != usuario.Password) return false;

        return true;
    }
}