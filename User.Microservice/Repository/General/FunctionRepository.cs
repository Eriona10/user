
using User.Microservice.Models.Menu;
using Microsoft.EntityFrameworkCore;

using User.Microservice.Helpers;
using User.Microservice.Data.Entieties;

namespace User.Microservice.Repository.General
{
    public class FunctionRepository : IFunctionRepository
    {

        private PetTrackerContext _db;

        public FunctionRepository(PetTrackerContext db)
        {
            _db = db;
        }
        public async Task<List<ListOfMenus>> GetListOfMenus(string Role)
        {
            return await _db.Set<ListOfMenus>().FromSqlInterpolated(sql: $"SELECT * FROM ListOfMenus({Role})").ToListAsync();
        }

        public async Task<List<ListOfMenusAccess>> ListOfMenusAuthorized(string Role)
        {
            return await _db.Set<ListOfMenusAccess>().FromSqlInterpolated(sql: $"SELECT *FROM ListOfMenusAccess({Role})").ToListAsync();
        }

    }
}
