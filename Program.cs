using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPWebResponseIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWebJSONDownloader myDownloader = new MyWebJSONDownloader();

            String url = @"https://www.nseindia.com/api/market-data-pre-open?key=ALL";

            string jsonResult = myDownloader.GetJSONFromURL(url);

            url = @"https://www.nseindia.com/api/equity-stock?index=fu_nifty50";

            string jsonResult2 = myDownloader.GetJSONFromURL(url);

            url = @"https://www.nseindia.com/api/liveEquity-derivatives?index=nifty_bank_fut";

            string jsonResult3 = myDownloader.GetJSONFromURL(url);
        }
    }
}
