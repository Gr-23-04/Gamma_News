
using Azure;
using Azure.Storage.Blobs;
using Gamma_News.Data;
using Gamma_News.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;


namespace Gamma_News.Services
{
    public class ArticleService : IArticleService
    {


        private readonly ApplicationDbContext _db;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;
        public ArticleService(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _db = applicationDbContext;
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration["AzureWebJobsStorage"]);
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
