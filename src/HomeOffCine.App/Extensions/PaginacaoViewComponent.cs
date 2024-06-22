using HomeOffCine.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeOffCine.App.Extensions;

public class PaginacaoViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(IPagedList modeloPaginado)
    {
        return View(modeloPaginado);
    }
}
