
using Gamma_News.Data;
using Gamma_News.Models.ViewModels;

namespace Gamma_News.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _db; 
        public ArticleService(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext; 
        }

        public void CreateArticle(Article newArticle)
        {
            _db.Articles.Add(newArticle);
            _db.SaveChanges();
        }
    }
}
