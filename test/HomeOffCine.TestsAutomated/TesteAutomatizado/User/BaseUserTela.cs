using HomeOffCine.TestsAutomated.TesteAutomatizado.Config;

namespace HomeOffCine.TestsAutomated.TesteAutomatizado.User;

public abstract class BaseUserTela : PageObjectModel
{
    public BaseUserTela(SeleniumHelper helper) : base(helper) { }

    public bool ValidarSaudacaoUsuarioLogado(User usuario)
    {
        return Helper.ObterTextoElementoPorId("manage").Contains(usuario.Email);
    }
}
