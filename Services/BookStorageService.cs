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
                "�.� �������" => new string[] { "����� � ���", "���� ��������" },
                "�.� �����������" => new string[] { "������������ � ���������", "����" },
                _ => new string[] { "���� �� �������" },
            };
            var response = new LoadResponse();
            response.Books.AddRange(books);
            return Task.FromResult(response);
        }
    }
}