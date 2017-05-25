using System;

namespace Core
{
    public class Processor
    {
        private IServiceFactory _serviceFactory;

        public Processor(IServiceFactory serviceFactory)
        {
            this._serviceFactory = serviceFactory;
        }

        public Result Doit(www.webservicex.net.Currency fromCurrency, www.webservicex.net.Currency toCurrency)
        {
            Result result;
            CurrencyConvertorSoap serviceClient;
            try
            {
                Log4net.Log.Info("Getting Proxy Class from Web Service");
                serviceClient = this._serviceFactory.Create();
                Log4net.Log.Info("Proxy Class Instance Obtained");
                Codes codeList = new Codes();
                try
                {
                    Log4net.Log.Info("Requesting response with parameters => FromCurrency: " + fromCurrency.ToString() + " ToCurrency: " + toCurrency.ToString());
                    var serviceResponse = serviceClient.ConversionRate(fromCurrency, toCurrency).ToString();
                    result = codeList.GetCode(serviceResponse);
                    Log4net.Log.Info("Service Response => " + result.Overrall.ToString() + " Code:" + result.Code + " Message:" + result.Message);
                }
                catch (Exception e)
                {
                    result = new Result() { Overrall = Status.Fail, Code = "0", Message = "Exception: " + e.Message };
                    Log4net.Log.Error("Exception returned by service => " + e.Message);
                }
            }
            catch (Exception ex)
            {
                result = new Result() { Overrall = Status.Fail, Code = "0", Message = ex.Message };
                Log4net.Log.Error("Something went worng: " + ex.Message);
            }

            return result;
        }
    }
}
