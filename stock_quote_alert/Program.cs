using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace inoa_test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var t = new StockPriceController();

            await t.Action(args);

        }
    }

}
