using Gamma_News.Data.Migrations;

namespace Gamma_News.Models
{
    public class Subscription
    {
        //Subscription Information
        //· Id
        //· SubscriptionType
        //· Price
        //· Created
        //· Expires
        //· User
        //· PaymentComplete
        public int SubscriptionId { get; set; }
        public string SubscriptionType { get; set; } = string.Empty;
        public decimal SubscriptionPrice { get; set; }

        public string UserId { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime PaymentComplete { get; set; }
        public DateTime Expires { get; set; }

        //SubscriptionType 
        //· Id
        //· TypeName
        //· Description
        //· Price

        public int SubcriptionTypeId { get; set; }
        public string SubcriptionTypeName { get; set; } = string.Empty;
        public string SubscriptionTypeDescription { get; set; } = string.Empty;
        public decimal SubscriptionTypePrice { get; set; }

        //Navigation properties
        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
       
    }
}
