using ContractTracker.Repository.Context;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace FileExporter.Factory
{

    public class UowFactory
    {
        private readonly string _connectionString;
        public UowFactory(string conString)
        {
            _connectionString = conString;
        }
        public IUnitOfWork BuildUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<TrackerDbContext>().UseSqlServer(_connectionString);
            var uow = new UnitOfWork(options);
            return uow;
        }
    }

}
