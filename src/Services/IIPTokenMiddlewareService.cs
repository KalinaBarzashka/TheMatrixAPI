namespace TheMatrixAPI.Services
{
    using System;

    public interface IIPTokenMiddlewareService
    {
        public void AddRecordByIp(string ip, string date);
    }
}
