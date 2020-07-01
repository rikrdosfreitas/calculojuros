using System;
using AutoMapper;
using Juros.Application.Common.Mappings;
using Juros.Application.TaxaJuros.Commands;
using NUnit.Framework;

namespace Juros.Application.UnitTests.Common.Mappings
{
    [TestFixture()]
        public class MappingProfileTests
        {
            private readonly IConfigurationProvider _configuration;
            private readonly IMapper _mapper;

            public MappingProfileTests()
            {
                _configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });

                _mapper = _configuration.CreateMapper();
            }

            [Test]
            public void ShouldHaveValidConfiguration()
            {
                _configuration.AssertConfigurationIsValid();
            }

            [Test]
            [TestCase(typeof(Domain.Entity.TaxaJuros), typeof(TaxaJurosViewModel))]
            public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
            {
                var instance = Activator.CreateInstance(source, true);

                _mapper.Map(instance, source, destination);
            }
        }
    }