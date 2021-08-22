namespace TheMatrixAPI.Services
{ 
    using System.Linq;
    using TheMatrixAPI.Data;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string GetFirstAndLastNameOfUser(string userId)
        {
            var userFirstLastName = this.dbContext.ApplicationUsers.Where(x => x.Id == userId).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();

            return userFirstLastName;
        }

        public string GetUserIdByEGN(string EGN)
        {
            return this.dbContext.ApplicationUsers
                .Where(x => x.EGN == EGN)
                .Select(x => x.Id)
                .FirstOrDefault();
        }
    }
}
