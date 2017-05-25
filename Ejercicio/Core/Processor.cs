
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Processor
    {
        IServiceFactory _serviceFactory;

        public Processor(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
        public Result Doit(www.webservicex.net.Currency FromCurrency, www.webservicex.net.Currency ToCurrency)
        {
            Result result;
            CurrencyConvertorSoap serviceClient;
            try
            {
                log4net.log.Info("Getting Proxy Class from Web Service");
                serviceClient = _serviceFactory.Create();
                log4net.log.Info("Proxy Class Instance Obtained");
                Codes codeList = new Codes();
                try
                {
                    log4net.log.Info("Requesting response with parameters => FromCurrency: " + FromCurrency.ToString() + " ToCurrency: " + ToCurrency.ToString());
                    var serviceResponse = serviceClient.ConversionRate(FromCurrency, ToCurrency).ToString();
                    result = codeList.GetCode(serviceResponse);
                    log4net.log.Info("Service Response => " + result.Overrall.ToString() + " Code:" + result.Code + " Message:" + result.Message);
                }
                catch (Exception e)
                {
                    result = new Result() { Overrall = Status.Fail, Code = "0", Message = "Exception: " + e.Message };
                    log4net.log.Error("Exception returned by service => " + e.Message);
                }
            }
            catch (Exception ex)
            {
                result = new Result() { Overrall = Status.Fail, Code = "0", Message = ex.Message };
                log4net.log.Error("Something went worng: " + ex.Message);
            }

            return result;
        }
    }
}
