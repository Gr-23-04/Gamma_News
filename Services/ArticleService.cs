
using Gamma_News.Data;
using Gamma_News.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Gamma_News.Services
{
    public class ArticleService : IArticleService
    {
        public readonly ApplicationDbContext _db; 
        public ArticleService(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext; 
        }

        public void CreateArticle(Article newArticle)
        {
            _db.Articles.Add(newArticle);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Article>> SearchArticlesAsync(string searchTerm) 
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) 
            {
                return await _db.Articles.ToListAsync();
            }

            return await _db.Articles
                             .Where(a=>a.Headline.Contains(searchTerm) || a.Content.Contains(searchTerm)).ToListAsync();
		}                    
        
        
        
    }
}
