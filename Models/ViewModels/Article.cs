using System.ComponentModel.DataAnnotations.Schema;

namespace Gamma_News.Models.ViewModels
{
    public class Article
    {
        //articles information
        public int Id { get; set; }
        public string Headline { get; set; } = string.Empty;
         
        public string Content { get; set; }= string.Empty;

        public DateTime CreatedDate { get; set; }

        public string FileName { get; set; }
       




    }
}
