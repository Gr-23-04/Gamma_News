
using Azure;
using Azure.Storage.Blobs;
using Gamma_News.Data;
using Gamma_News.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gamma_News.Services
{
    public class ArticleService : IArticleService
    {


        private readonly ApplicationDbContext _db;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;
        private readonly IArticleService _articleService;

        public ArticleService(ApplicationDbContext applicationDbContext,IConfiguration configuration)

        {
            _db = applicationDbContext;
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration["AzureWebJobsStorage"]);
        }


        
        public List<Category> GetAllCategories()
        {
            var categories = _db.Categories.ToList();
            return categories;


        }

        public void AddCategories()
        {
            List<Category> categories = new List<Category>();
            Category category = new Category()
            {
               Name = "World"
        };
            categories.Add(category);
            //category.Name = "Entertainment";
            //category.Name = "Sport";
            //category.Name = "Politics";
            //category.Name = "Sweden";
            //category.Name = "World";


            _db.AddRange(categories);
            
            
            
            
            
            _db.SaveChanges();

        }
        public Article Article()
        {

            Article newArticle = new();

            newArticle.Categories.Add(new SelectListItem { Text = "Local", Value = "1" });
            newArticle.Categories.Add(new SelectListItem { Text = "Enterainment", Value = "2" });
            newArticle.Categories.Add(new SelectListItem { Text = "Sport", Value = "3" });
            newArticle.Categories.Add(new SelectListItem { Text = "Politics", Value = "4" });
            newArticle.Categories.Add(new SelectListItem { Text = "Sweden", Value = "5" });
            newArticle.Categories.Add(new SelectListItem { Text = "World", Value = "6" });

            return newArticle;
        }



        public void CreateArticle(Article newArticle)
        {
            _db.Articles.Add(newArticle);
            _db.SaveChanges();
        }


        public async Task<string> UploadImage(IFormFile file)
        {
            BlobContainerClient containerClient = _blobServiceClient
                .GetBlobContainerClient("newssitespictures");
            BlobClient blobClient = containerClient.GetBlobClient(file.FileName);
            await using (var stream = file.OpenReadStream())
            {
                blobClient.Upload(stream);

            }
            return blobClient.Uri.AbsoluteUri;
        }



        public async Task<IEnumerable<Article>> SearchArticlesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _db.Articles.ToListAsync();
            }

            return await _db.Articles
                             .Where(a => a.Headline.Contains(searchTerm) || a.Content.Contains(searchTerm)).ToListAsync();
        }


        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            //var json = await .Content.ReadAsStringAsync();
            //var Article_jason= JsonConvert.DeserializeObject<Article>(json);
            return await _db.Articles.ToListAsync();
        }

    }
}
