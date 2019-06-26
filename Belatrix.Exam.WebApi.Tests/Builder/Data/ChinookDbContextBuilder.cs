using Belatrix.Exam.WebApi.Repository.PostgreSql;
using Microsoft.EntityFrameworkCore;
using System;

namespace Belatrix.Exam.WebApi.Tests.Builder.Data
{
    public partial class ChinookDbContextBuilder : IDisposable
    {
        private ChinookDbContext _context;
        public ChinookDbContextBuilder ConfigureInMemory()
        {
            var options = new DbContextOptionsBuilder<ChinookDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            _context = new ChinookDbContext(options);
            return this;
        }

        public ChinookDbContext Build()
        {
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
