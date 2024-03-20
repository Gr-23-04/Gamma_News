using Gamma_News.Models.ViewModels;

namespace Gamma_News.Services
{

    public interface IArticleService
    {
        void CreateArticle(Article newArticle);


        Task<IEnumerable<Article>> SearchArticlesAsync(string searchTerm);
    }



}
