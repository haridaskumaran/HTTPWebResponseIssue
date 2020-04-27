using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTPWebResponseIssue
{
    public class MyWebJSONDownloader
    {
        public string GetJSONFromURL(string url)
        {
            string file = string.Empty;
            try
            {
                //*********get the json file using httpRequest ***********
                System.Uri uri = new System.Uri(url);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.CreateDefault(uri);
                httpWebRequest.Method = WebRequestMethods.Http.Get;
                httpWebRequest.Accept = "text/html; charset=utf-8";
                //httpWebRequest.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                //httpWebRequest.ContentType = "application/json; charset=utf-8";
                //httpWebRequest.CookieContainer = new CookieContainer();
                //WebRequest.DefaultWebProxy = null;
                httpWebRequest.Timeout = 30000;
                httpWebRequest.KeepAlive = true;
                httpWebRequest.AllowAutoRedirect = false;
                ServicePointManager.DefaultConnectionLimit = 500;

                using (var response = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        file = sr.ReadToEnd();
                    }
                    response.Close();
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.Message);
            }
            return file;
        }
    }
}
