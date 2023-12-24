using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace inoa_test
{
    class StockPriceController
    {
        private MailHelper mailHelper;

        private Configuration configuration;

        public StockPriceController()
        {
            configuration = ConfigurationReader();
            mailHelper = new MailHelper(configuration.smtpHost, configuration.port, configuration.userName, configuration.password, configuration.destinyEmails);
        }

        private Configuration ConfigurationReader()
        {
            var path = Directory.GetCurrentDirectory();
            var pathFinal = Path.Combine(path, Constants.FileConstants.configurationJson);
            string[] c = Directory.GetFiles(path);
            using (StreamReader sr = new StreamReader(pathFinal))
            {
                var file = sr.ReadToEnd();
                var json = JsonConvert.DeserializeObject<Configuration>(file);
                return json;
            }
        }

        public async Task Action(string[] args)
        {
            string stockName;

            float sellPrice;

            float buyPrice;

            if (args.Count() != 3)
            {
                Console.WriteLine(Constants.ExceptionMessages.wrongArgsCount +
                    Constants.ConsoleMessages.buttonForExit);
                Console.ReadLine();
                return;
            }
            if(!float.TryParse(args[1], out sellPrice)) 
            {
                Console.WriteLine(Constants.ExceptionMessages.sellParse +
                    Constants.ConsoleMessages.buttonForExit);
                Console.ReadLine();
                return;

            }
            if (!float.TryParse(args[2], out buyPrice))
            {
                Console.WriteLine(Constants.ExceptionMessages.buyParse +
                    Constants.ConsoleMessages.buttonForExit);
                Console.ReadLine();
                return;
            }

            if (sellPrice <= 0 || buyPrice < 0)
            {
                Console.WriteLine(Constants.ExceptionMessages.underZeroValues +
                    Constants.ConsoleMessages.buttonForExit);
                Console.ReadLine();
                return;
            }

            if (buyPrice >= sellPrice) 
            {
                Console.WriteLine(Constants.ExceptionMessages.sellUnderOrEqualBuy +
                    Constants.ConsoleMessages.buttonForExit);
                Console.ReadLine();
                return;

            }

            if (configuration.oneTimeWarning) Console.WriteLine(Constants.ConsoleMessages.oneTimeWarningMessage);

            stockName = args[0].ToUpper();

            Console.WriteLine(Constants.ConsoleMessages.infoMessage, stockName, sellPrice, buyPrice);

            await CallStockApi(stockName, sellPrice, buyPrice);
        }

        private async Task CallStockApi(string stockName, float sellPrice, float buyPrice) 
        {
            var httpClient = new HttpClient();

            var uri = new Uri(Constants.HttpClientConstants.yfUri);

            httpClient.BaseAddress = uri;

            httpClient.DefaultRequestHeaders.Add(Constants.HttpClientConstants.apiHeader, Constants.HttpClientConstants.apiKey);

            httpClient.DefaultRequestHeaders.Add(Constants.HttpClientConstants.acceptHeader, Constants.HttpClientConstants.acceptValue);

            while (true)
            {
                try
                {
                    var httpResponseMessage = await httpClient.GetAsync(string.Format(Constants.HttpClientConstants.requestUri, stockName));

                    httpResponseMessage.EnsureSuccessStatusCode();

                    var httpResponseMessageBody = await httpResponseMessage.Content.ReadAsStringAsync();

                    dynamic jsonObject = JObject.Parse(httpResponseMessageBody);


                    if (Enumerable.Count(jsonObject.quoteResponse.result) == 0)
                    {
                        throw new Exception(Constants.ExceptionMessages.stockNotFound);
                    }

                    var regularMarketPrice = jsonObject.quoteResponse.result[0].regularMarketPrice;

                    if (regularMarketPrice < buyPrice)
                    {
                        Console.WriteLine(Constants.ConsoleMessages.advisedBuy, regularMarketPrice);
                        mailHelper.SendMail(Constants.HttpClientConstants.buyMailSubject, string.Format(Constants.HttpClientConstants.buyMail, stockName, buyPrice, regularMarketPrice));
                    }

                    if (regularMarketPrice > sellPrice)
                    {
                        Console.WriteLine(Constants.ConsoleMessages.advisedSell, regularMarketPrice);
                        mailHelper.SendMail(Constants.HttpClientConstants.sellMailSubject, string.Format(Constants.HttpClientConstants.sellMail, stockName, sellPrice, regularMarketPrice));
                    }



                }
                catch (Exception e)
                {
                    Console.WriteLine(Constants.ConsoleMessages.errorCall +
                        $"{e.Message}\n");

                }

                if (configuration.oneTimeWarning) 
                {
                    Console.WriteLine(Constants.ConsoleMessages.endingexecution + Constants.ConsoleMessages.buttonForExit);
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine(Constants.ConsoleMessages.sleepMessage);

                Sleep15Minutes();
            }
        }

        private void Sleep15Minutes() 
        {
            TimeSpan interval = TimeSpan.FromMinutes(15);
            Thread.Sleep(interval);
            Console.WriteLine(Constants.ConsoleMessages.wakeUpMessage);
        }
    }
}
