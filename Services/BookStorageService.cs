using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
    public class BookStorageService : BookStorage.BookStorageBase
    {
        private readonly ILogger<BookStorageService> _logger;
        public BookStorageService(ILogger<BookStorageService> logger)
        {
            _logger = logger;
        }

        public override Task<LoadResponse> LoadAllBooks(LoadRequest request, ServerCallContext context)
        {
            var books = request.Author switch
            {
                "Л.Н Толстой" => new string[] { "Война и мир", "Анна Каренина" },
                "Ф.М Достоевский" => new string[] { "Преступление и наказание", "Бесы" },
                _ => new string[] { "Книг не найдено" },
            };
            var response = new LoadResponse();
            response.Books.AddRange(books);
            return Task.FromResult(response);
        }
    }
}