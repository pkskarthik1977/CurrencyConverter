using AutoMapper;
using CurrencyConverter.Abstracts.Configuration;
using CurrencyConverter.Abstracts.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace CurrencyConverter.Domain.Test
{
    public static class ObjectFactory
    {
        public static IMapper CreateMockMapper()
        {
            var mapper = new Mock<IMapper>();

            return mapper.Object;
        }

        public static ISessionContext CreateContext()
        {
            var mockContext = new Mock<ISessionContext>();

            return mockContext.Object;
        }

        public static IMemoryCache CreateMemoryCache()
        {
            var mockMemoryCache = new Mock<IMemoryCache>();

            return mockMemoryCache.Object;
        }

        public static IServiceManagerContext CreateServiceManagerContext()
        {
            var mockServiceManagerContext = new Mock<IServiceManagerContext>();

            var frankfurterService = CreateFrankfurterService();
                mockServiceManagerContext
                    .Setup(o => o.FrankfurterService)
                    .Returns(frankfurterService);

            return mockServiceManagerContext.Object;
        }

        public static IFrankfurterService CreateFrankfurterService()
        {
            var frankfurterService = new Mock<IFrankfurterService>();

            return frankfurterService.Object;        
        }
    }
}
