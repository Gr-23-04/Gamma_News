using Gamma_News.Models.ViewModels;

namespace Gamma_News.Services
{
	
	public interface IArticleService
    {
        void CreateArticle(Article newArticle);

        Task<string> UploadImage(IFormFile file);
        void AddCategories();

        List<Category> GetAllCategories();









        Task<IEnumerable<Article>> SearchArticlesAsync(string searchTerm);


     Task<IEnumerable<Article>> GetAllArticles();

    }
   

      
}
