namespace BookStoreManagementSystem.Controllers
{
    public class BooksController : ApiController
    {
        [Authorize]
        public class EmployeesController : ApiController
        {
            public IEnumerable<Book> Get()
            {
                using (BookDBEntities entities = new BookDBEntities())
                {
                    return entities.Books.ToList();
                }
            }
        }
    }
}
