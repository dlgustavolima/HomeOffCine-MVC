using HomeOffCine.Tests.TesteAutomatizado.Config;

namespace HomeOffCine.Tests.TesteAutomatizado.User;

public abstract class BaseUserTela : PageObjectModel
{
    public BaseUserTela(SeleniumHelper helper) : base(helper) { }

    public bool ValidarSaudacaoUsuarioLogado(User usuario)
    {
        return Helper.ObterTextoElementoPorId("manage").Contains(usuario.Email);
    }
}
