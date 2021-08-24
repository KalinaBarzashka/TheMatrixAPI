namespace TheMatrixAPI.Services
{
    using System;
    using System.Globalization;
    using System.Linq;
    using TheMatrixAPI.Data;
    using TheMatrixAPI.Models.DbModels;

    public class IPTokenMiddlewareService : IIPTokenMiddlewareService
    {
        private readonly ApplicationDbContext dbContext;

        public IPTokenMiddlewareService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddRecordByIp(string ip, string date)
        {
            var dbDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var dbRecord = this.dbContext.RequestsFromIP.Where(x => x.IP == ip && x.Date == dbDate).FirstOrDefault();

            if(dbRecord == null)
            {
                var newRecord = new RequestFromIP
                {
                    IP = ip,
                    Date = dbDate,
                    RequestsCount = 0
                };

                this.dbContext.RequestsFromIP.Add(newRecord);
            }
            else
            {
                if (dbRecord.RequestsCount >= 10)
                {
                    throw new Exception("You have reached your maximum limit of requests per day!");
                }

                dbRecord.RequestsCount++;
            }

            this.dbContext.SaveChanges();
        }

        public void AddRecordByTokenId(string tokenId, string date)
        {
            var dbDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var dbRecord = this.dbContext.RequestsFromTokenId.Where(x => x.TokenId == tokenId && x.Date.Year == dbDate.Year && x.Date.Month == dbDate.Month).FirstOrDefault();

            if (dbRecord == null)
            {
                var newRecord = new RequestFromTokenId
                {
                    TokenId = tokenId,
                    Date = dbDate,
                    RequestsCount = 0
                };

                this.dbContext.RequestsFromTokenId.Add(newRecord);
            }
            else
            {
                if (dbRecord.RequestsCount >= 1000)
                {
                    throw new Exception("You have reached your maximum limit of requests per day!");
                }

                dbRecord.RequestsCount++;
            }

            this.dbContext.SaveChanges();
        }

        public bool IsTokenValid(string tokenId)
        {
            return this.dbContext.ApplicationUsers.Any(x => x.TokenId == tokenId);
        }
    }
}
