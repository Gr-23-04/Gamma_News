using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Gamma_News.Models
{
    public class User : IdentityUser
    {
        [Key]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }

        public string? profile_image { get; set; }

        public bool IsPremium { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
       


        //Subscription Information
        //· Id
        //· SubscriptionType
        //· Price
        //· Created
        //· Expires
        //· User
        //· PaymentComplete
        //public int SubscriptionId { get; set; }
        //public string SubscriptionType { get; set; } = string.Empty;
        //public decimal SubscriptionPrice { get; set; }

        //public string UserId { get; set; } = string.Empty;
        //public DateTime Created { get; set; } = DateTime.Now;
        //public DateTime PaymentComplete { get; set; }
        //public DateTime Expires { get; set; }

        //SubscriptionType 
        //· Id
        //· TypeName
        //· Description
        //· Price

        //public int SubcriptionTypeId { get; set; }
        //public string SubcriptionTypeName { get; set; } = string.Empty;
        //public string SubscriptionTypeDescription { get; set; } = string.Empty;
        //public decimal SubscriptionTypePrice { get; set; }


    }
}
