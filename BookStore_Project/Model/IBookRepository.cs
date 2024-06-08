using BookStore_Project.Repositories;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore_Project.Model
{
    public interface IBookRepository : IRepository<Book_Model>
    {
    }
}
