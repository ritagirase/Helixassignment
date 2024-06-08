using BookStore_Project.Db_BookStoreContext;
using BookStore_Project.Repositories;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore_Project.Model
{
    public class BookRepository : Repository<Book_Model>, IBookRepository
    {
        public BookRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
