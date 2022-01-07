using Microsoft.EntityFrameworkCore;

namespace TBILLSWebBlazorServerApp.Entities
{
    public class TBILLSWebDbContext: DbContext
    {
        public TBILLSWebDbContext()
        {
        }
        public TBILLSWebDbContext(DbContextOptions<TBILLSWebDbContext> options) :
         base(options)
        { }
    }
}
