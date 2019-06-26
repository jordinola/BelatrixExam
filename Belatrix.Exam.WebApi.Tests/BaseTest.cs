using AutoMapper;
using Belatrix.Exam.WebApi.Profiles;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Belatrix.Exam.WebApi.Tests
{
    public class BaseTest
    {
        protected IMapper GetAutomapperConfig()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddMaps(new Assembly[] { typeof(AlbumProfile).GetTypeInfo().Assembly });
            });

            return config.CreateMapper();
        }
    }
}
