namespace TheMatrixAPI.Models.DbModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RequestFromIP
    {
        public int Id { get; set; }

        [Required]
        public string IP { get; set; }

        public DateTime Date { get; set; }

        [Range(0, 10, ErrorMessage = "You have reached your maximum limit of requests per day!")]
        public int RequestsCount { get; set; }
    }
}
