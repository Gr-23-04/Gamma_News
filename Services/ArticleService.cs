
using Azure.Storage.Blobs;
using Gamma_News.Data;
using Gamma_News.Models.ViewModels;

namespace Gamma_News.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _db; 
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;
        public ArticleService(ApplicationDbContext applicationDbContext,IConfiguration configuration)
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
    }
}
