using Microsoft.EntityFrameworkCore;

namespace INFINITE_QUIZ_API.Repository
{
    public class QUIZDBContext : DbContext
    {
        public QUIZDBContext(DbContextOptions<QUIZDBContext> options) : base(options)
        {
        }
    }

}
