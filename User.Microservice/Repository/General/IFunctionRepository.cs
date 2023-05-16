using User.Microservice.Helpers;
using User.Microservice.Models.Menu;

namespace User.Microservice.Repository.General
{
    public interface IFunctionRepository
    {
        Task<List<ListOfMenus>> GetListOfMenus(string Role);
        Task<List<ListOfMenusAccess>> ListOfMenusAuthorized(string Role);
    }
}
