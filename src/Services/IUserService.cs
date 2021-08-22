namespace TheMatrixAPI.Services
{
    public interface IUserService
    {
        public string GetFirstAndLastNameOfUser(string userId);

        public string GetUserIdByEGN(string EGN);
    }
}
