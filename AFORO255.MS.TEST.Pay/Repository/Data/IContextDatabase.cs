using AFORO255.MS.TEST.Pay.Model;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Pay.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Operation> Operation { get; set; }
        int SaveChanges();
    }
}
