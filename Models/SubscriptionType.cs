using System.ComponentModel.DataAnnotations;

namespace Gamma_News.Models
{
    public class SubscriptionType
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
    }
}