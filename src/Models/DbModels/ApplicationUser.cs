namespace TheMatrixAPI.Models.DbModels
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.TokenId = Guid.NewGuid().ToString();
            //this.Roles = new HashSet<IdentityUserRole<string>>();
            //this.Claims = new HashSet<IdentityUserClaim<string>>();
            //this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [MaxLength(40)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        //[MaxLength(10)]
        //public string EGN { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string TokenId { get; set; }

        //public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        //public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
