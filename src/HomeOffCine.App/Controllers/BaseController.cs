using HomeOffCine.Business.Interfaces;
using HomeOffCine.Business.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace HomeOffCine.App.Controllers;

public abstract class BaseController : Controller
{
    private readonly INotificator _notificator;

    protected Guid UserId { get; set; }
    protected string UserName { get; set; }

    protected BaseController(INotificator notificator,
                             IIdentityUser user)
    {
        _notificator = notificator;

        if (user.IsAuthenticated())
        {
            UserId = user.GetUserId();
            UserName = user.GetUserName();
        }
    }

    protected string BuscarNotificacao()
    {
        if (_notificator.TemNotificacao())
        {
            return _notificator.ObterNotificacoes().First().Message;
        }

        return string.Empty;
    }

    protected void AdicionarErroValidacao(string mensagem)
    {
        ModelState.AddModelError(string.Empty, mensagem);
    }

    protected bool OperacaoValida()
    {
        if (_notificator.TemNotificacao())
        {
            foreach (var mensagem in _notificator.ObterNotificacoes())
            {
                ModelState.AddModelError(string.Empty, mensagem.Message);
            }

            return false;
        }

        return true;
    }
}
