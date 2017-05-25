using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Moq;
//using log4net;

namespace CoreTests
{
    [TestClass]
    public class UnitTest
    {

        //static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [TestMethod]
        public void Doit_RESPONSE_RECIEVED()
        {
            Processor processor = new Processor(new ServiceFactory());
            //log.Debug("Consuming Service.");
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            //log.Debug("Service response: " + result.Message);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Code != null);
        }

        [TestMethod]
        public void Doit_IF_RETURN_ZERO()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Returns(0);

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Returns(proxy.Object);

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Code != null);
        }

        [TestMethod]
        public void Doit_IF_NOT_PARAMS_RETURN_LESS_THAN_ZERO()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Returns(-1);

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Returns(proxy.Object);

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsTrue(double.Parse(result.Code) < 0);
        }


        [TestMethod]
        public void Doit_IF_200_IS_RETURNED()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Returns(200);

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Returns(proxy.Object);

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsTrue(result.Message == "Fair");
        }

        [TestMethod]
        public void Doit_IF_201_IS_RETURNED()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Returns(201);

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Returns(proxy.Object);

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsTrue((result.Overrall == Status.Success) && (result.Message == "Fair"));
        }

        [TestMethod]
        public void Doit_IF_202_IS_RETURNED()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Returns(202);

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Returns(proxy.Object);

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsTrue(result.Overrall == Status.Success);
            Assert.IsTrue(result.Message == "Acepted");
        }

        [TestMethod]
        public void Doit_IF_400_IS_RETURNED()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Returns(400);

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Returns(proxy.Object);

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsTrue(result.Overrall == Status.Fail);
            Assert.IsTrue(result.Message == "Error(Client)");
        }

        [TestMethod]
        public void Doit_IF_500_IS_RETURNED()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Returns(500);

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Returns(proxy.Object);

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsTrue(result.Overrall == Status.Fail);
            Assert.IsTrue(result.Message == "asdasd");
        }

        [TestMethod]
        public void Doit_IF_700_IS_RETURNED()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Returns(700);

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Returns(proxy.Object);

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsTrue(result.Overrall == Status.Unknown);
            Assert.IsTrue(result.Message == "Unknown");
        }


        [TestMethod]
        public void Doit_IF_WEB_EXCEPTION_IS_RETURNED()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Throws(new DivideByZeroException("Fallo"));

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Returns(proxy.Object);

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsTrue(result.Overrall == Status.Fail);
            Assert.IsTrue(result.Code == "0");
            Assert.IsTrue(result.Message == "Exception: Fallo");

        }


        [TestMethod]
        public void Doit_IF_CREATE_FUNCTION_RETURN_EXCEPTION()
        {
            Mock<CurrencyConvertorSoap> proxy = new Mock<CurrencyConvertorSoap>();
            proxy.Setup(p => p.ConversionRate(It.IsAny<www.webservicex.net.Currency>(), It.IsAny<www.webservicex.net.Currency>())).Returns(200);

            Mock<IServiceFactory> serviceFactory = new Mock<IServiceFactory>();
            serviceFactory.Setup(m => m.Create()).Throws(new Exception("Fallo"));

            Processor processor = new Processor(serviceFactory.Object);
            Result result = processor.Doit(www.webservicex.net.Currency.USD, www.webservicex.net.Currency.MXN);
            Assert.IsTrue(result.Overrall == Status.Fail);
            Assert.IsTrue(result.Code == "0");
            Assert.IsTrue(result.Message == "Fallo");

        }
    }
}
