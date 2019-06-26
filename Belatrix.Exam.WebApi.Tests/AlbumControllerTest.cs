using Belatrix.Exam.WebApi.Controllers;
using Belatrix.Exam.WebApi.Models;
using Belatrix.Exam.WebApi.Repository.PostgreSql;
using Belatrix.Exam.WebApi.Tests.Builder.Data;
using FluentAssertions;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Belatrix.Exam.WebApi.Tests
{
    public class AlbumControllerTest : BaseTest
    {
        private readonly ChinookDbContextBuilder _builder;
        public AlbumControllerTest()
        {
            _builder = new ChinookDbContextBuilder();
        }

        [Fact]
        public async Task AlbumController_GetAlbums_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .AddTenAlbum()
                .Build();

            var repository = new Repository<Album>(db);
            var controller = new AlbumController(repository, GetAutomapperConfig());

            var response = (await controller.GetAlbums())
                .Result as OkObjectResult;

            var values = response.Value as List<Album>;

            values.Count.Should().Be(10);
        }

        [Fact]
        public async Task AlbumController_CreateAlbum_Ok()
        {
            var db = _builder
                .ConfigureInMemory()
                .Build();

            var repository = new Repository<Models.Album>(db);
            var controller = new AlbumController(repository, GetAutomapperConfig());

            var newAlbum = A.New<Models.Album>();

            var response = (await controller.PostAlbum(newAlbum))
                .Result as OkObjectResult;

            var value = Convert.ToInt32(response.Value);

            value.Should().Be(newAlbum.AlbumId);
        }
    }
}
