using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inoa_test
{
    public static class Constants
    {
        public static class ConsoleMessages
        {
            public const string buttonForExit = "\nPressione qualquer botão para sair.";

            public const string advisedBuy = "O preço da ação é de R${0}\nÉ aconselhado a compra.\nEnviando o email nesse momento...";

            public const string advisedSell = "O preço da ação é de R${0}\nÉ aconselhado a venda.\nEnviando o email nesse momento...";

            public const string infoMessage = "Nome da ação : {0} \nPreço de venda: {1} \nPreço de compra: {2}";

            public const string errorCall = "Erro\n";

            public const string sleepMessage = "Indo dormir por 15 minutos.";

            public const string wakeUpMessage = "Acordado. Indo realizar a chamada.";

            public const string oneTimeWarningMessage = "Atenção! Opção de aviso apenas uma vez ativada!";

            public const string endingexecution = "Encerrando a execução do programa.";
        }

        public static class ExceptionMessages
        {
            public const string stockNotFound = "Ação não encontrada. O nome da ação digitado está correto?";

            public const string buyParse = "Chamada com formatação errada do preço de compra! Por favor, insira um número no seguinte formato: 22.59";

            public const string sellParse = "Chamada com formatação errada do preço de venda! Por favor, insira um número no seguinte formato: 22.67";

            public const string wrongArgsCount = "Chamada com número errado de argumentos! Chamadas devem ser feitas como a seguinte: inoa-test.exe PETR4 22.67 22.59";

            public const string underZeroValues = "Preço de venda ou compra abaixo de zero! Por favor, coloque valores plausíveis";

            public const string sellUnderOrEqualBuy = "Preço de vende menor ou igual ao de compra! Por favor, coloque valores plausíveis";
        }

        public static class HttpClientConstants
        {
            public const string yfUri = "https://yfapi.net/";

            public const string apiHeader = "X-API-KEY";

            public const string apiKey = "aYk9EANGN6avPxAqMlQWy8m3tNa4zXPc8xWtuWPL";

            public const string acceptHeader = "accept";

            public const string acceptValue = "application/json";

            public const string requestUri = "v6/finance/quote?region=BR&lang=pt&symbols={0}.SA";

            public const string buyMail = "<h1>Compra</h1>\r\n<body>\r\n    Aconselhamos a compra do ativo {0}, que ultrapassou o valor de R${1} estimado, estando atualmente com valor R${2}<br>\r\n    Email enviado da aplicação criada por Mateus Olaso.\r\n</body>";

            public const string buyMailSubject = "Compra";

            public const string sellMail = "<h1>Venda</h1>\r\n<body>\r\n    Aconselhamos a venda do ativo {0}, que ultrapassou o valor de R${1} estimado, estando atualmente com valor R${2}<br>\r\n    Email enviado da aplicação criada por Mateus Olaso.\r\n</body>";

            public const string sellMailSubject = "Venda";
        }

        public static class FileConstants
        {
            public const string configurationJson = "config.json";
        }
    }
}
