using HomeOffCine.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeOffCine.App.Extensions;

public class SummaryViewComponent : ViewComponent
{
    private readonly INotificator _notification;

    public SummaryViewComponent(INotificator notificador)
    {
        _notification = notificador;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var notificacoes = await Task.FromResult(_notification.ObterNotificacoes());
        notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Message));

        return View();
    }
}
