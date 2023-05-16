//using Gateway.WebApi.Data.Entieties;
//using Microsoft.EntityFrameworkCore;

//namespace Gateway.WebApi.Repository.User
//{
//    public class UserRepository : IUserRepository
//    {
//        public PetTrackerContext _context;

//        public UserRepository(PetTrackerContext context)
//        {
//            _context = context;
//        }
//        public Task CreateUser(AspNetUsers user)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteUser(AspNetUsers user)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IEnumerable<AspNetUsers>> GetAllUser()
//        {
//            var users = await _context.AspNetUsers.ToListAsync();

//            return users;
//        }

//        public Task<AspNetUsers> GetUserById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task SaveChanges()
//        {
//            await _context.SaveChangesAsync();
//        }
//    }
//}
