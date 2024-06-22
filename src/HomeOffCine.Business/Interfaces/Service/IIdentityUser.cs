namespace HomeOffCine.Business.Interfaces.Service;

public interface IIdentityUser
{
    string GetUserName();

    Guid GetUserId();

    bool IsAuthenticated();

    bool IsInRole(string role);
}
