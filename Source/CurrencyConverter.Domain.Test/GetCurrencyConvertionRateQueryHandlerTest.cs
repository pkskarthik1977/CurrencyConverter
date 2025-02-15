using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.Abstracts.BaseTypes;
using CurrencyConverter.Abstracts.Configuration;
using CurrencyConverter.Abstracts.Model.Response;
using CurrencyConverter.Domain.CQRS;
using CurrencyConverter.Domain.Model;
using CurrencyConverter.Domain.QueryHandlers;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace CurrencyConverter.Domain.Test
{
    [TestFixture]
    [Category(TestCategory.Unit)]
    public sealed class GetCurrencyConvertionRateQueryHandlerTest
    {
        private ServiceResponse<ExchangeRateResponse> _rateServiceResponse;
        private ExchangeRateResponse rateResponse;
        private ExchangeRateDto rateDto;

        [SetUp]
        public void SetUp()
        {
            IDictionary<string, double> rares = new Dictionary<string, double>();
            rateResponse = new ExchangeRateResponse()
            {
                Amount = 1,
                Currency = "EUR",
                ReferenceDate = Convert.ToDateTime("2025-02-14T00:00:00"),
                Rates = new Dictionary<string, double>() { {"USD", 1.5761 },
                {"INR", 96.5761 }}
            };
            _rateServiceResponse = new ServiceResponse<ExchangeRateResponse>(rateResponse);
            rateDto = new ExchangeRateDto()
            {
                Amount = 1,
                Currency = "EUR",
                ReferenceDate = Convert.ToDateTime("2025-02-14T00:00:00"),
                Rates = new Dictionary<string, double>() { {"USD", 1.5761 },
                {"INR", 96.5761 }}
            };
        }

        [Test]
        public async Task Handle_Always_Calls_GetCurrencyConvertionRateAsync_Once()
        {
            // arrange
            var queryRequest = new GetCurrencyConvertionRateQuery(10, "EUR", "USD")
            {
                Context = new SessionContext(string.Empty)
            };
            var mockMapper = ObjectFactory.CreateMockMapper();
            var mockServiceManagerContext = ObjectFactory.CreateServiceManagerContext();

            Mock.Get(mockServiceManagerContext.FrankfurterService)
                .Setup(o => o.GetCurrencyConvertionRateAsync(
                    It.Is<ISessionContext>(ctxt => ReferenceEquals(ctxt, queryRequest.Context)),
                    It.IsAny<double>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(_rateServiceResponse);

            Mock.Get(mockMapper)
               .Setup(o => o.Map<ExchangeRateDto>(It.Is<ExchangeRateResponse>(o => ReferenceEquals(o, rateResponse))))
               .Returns(rateDto);

            var target = new GetCurrencyConvertionRateQueryHandler(mockMapper, mockServiceManagerContext);

            // act
            await target
                .Handle(queryRequest, CancellationToken.None)
                .ConfigureAwait(false);

            // assert
            Mock.Get(mockServiceManagerContext.FrankfurterService)
                .Verify(
                    o => o.GetCurrencyConvertionRateAsync(
                        It.Is<ISessionContext>(ctxt => ReferenceEquals(ctxt, queryRequest.Context)),
                        It.IsAny<double>(),
                        It.IsAny<string>(),
                        It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task Handle_Always_Calls_GetCurrencyConvertionRate_Entity_To_Dto_Mapper_Once()
        {
            // arrange
            var queryRequest = new GetCurrencyConvertionRateQuery(10, "EUR", "USD")
            {
                Context = new SessionContext(string.Empty)
            };
            var mockMapper = ObjectFactory.CreateMockMapper();
            var mockServiceManagerContext = ObjectFactory.CreateServiceManagerContext();

            Mock.Get(mockServiceManagerContext.FrankfurterService)
                .Setup(o => o.GetCurrencyConvertionRateAsync(
                    It.Is<ISessionContext>(ctxt => ReferenceEquals(ctxt, queryRequest.Context)),
                    It.IsAny<double>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(_rateServiceResponse);

            //Mock.Get(mockMapper)
            //   .Setup(o => o.Map<ExchangeRateDto>(It.Is<ExchangeRateResponse>(o => ReferenceEquals(o, rateResponse))))
            //   .Returns(rateDto);

            var target = new GetCurrencyConvertionRateQueryHandler(mockMapper, mockServiceManagerContext);

            // act
            await target
                .Handle(queryRequest, CancellationToken.None)
                .ConfigureAwait(false);

            // assert
            Mock.Get(mockMapper)
                .Verify(o => o.Map<ExchangeRateDto>(It.Is<ExchangeRateResponse>(o => ReferenceEquals(o, rateResponse))), Times.Once);
        }

        [Test]
        public async Task Handle_Always_GetCurrencyConvertionRate_Returns_HandlerResponse()
        {
            // arrange
            var queryRequest = new GetCurrencyConvertionRateQuery(10, "EUR", "USD")
            {
                Context = new SessionContext(string.Empty)
            };
            var mockMapper = ObjectFactory.CreateMockMapper();
            var mockServiceManagerContext = ObjectFactory.CreateServiceManagerContext();

            Mock.Get(mockServiceManagerContext.FrankfurterService)
                .Setup(o => o.GetCurrencyConvertionRateAsync(
                    It.Is<ISessionContext>(ctxt => ReferenceEquals(ctxt, queryRequest.Context)),
                    It.IsAny<double>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(_rateServiceResponse);

            Mock.Get(mockMapper)
               .Setup(o => o.Map<ExchangeRateDto>(It.Is<ExchangeRateResponse>(o => ReferenceEquals(o, rateResponse))))
               .Returns(rateDto);

            var target = new GetCurrencyConvertionRateQueryHandler(mockMapper, mockServiceManagerContext);

            // act
            var result = await target
                .Handle(queryRequest, CancellationToken.None)
                .ConfigureAwait(false);

            // assert
            ClassicAssert.IsTrue(result is HandlerResponse<ExchangeRateDto>);
            ClassicAssert.IsTrue(result.Success);
            ClassicAssert.AreEqual(string.Empty, result.Message);
        }
    }
}
