using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository.PostgreSql;
using GenFu;

namespace Belatrix.Exam.WebApi.Tests.Builder.Data
{
    public partial class ChinookDbContextBuilder
    {
        public ChinookDbContextBuilder AddTenAlbum()
        {
            AddAlbum(_context, 10);
            return this;
        }

        private void AddAlbum(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
    }
}
