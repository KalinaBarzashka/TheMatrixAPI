namespace TheMatrixAPI.Services
{
    public interface IIPTokenMiddlewareService
    {
        public void AddRecordByIp(string ip, string date);

        public void AddRecordByTokenId(string tokenId, string date);

        public bool IsTokenValid(string tokenId);
    }
}
