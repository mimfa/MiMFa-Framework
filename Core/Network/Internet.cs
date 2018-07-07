using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace MiMFa_Framework.Network
{
    public static class MiMFa_Internet
    {
        public static Uri CreateUri(string url)
        {
            string ss = url.ToLower();
            if (ss.StartsWith("http://") || ss.StartsWith("https://"))
                return new Uri(url);
            if (url.Contains("\\")) return new Uri(url);
            return new Uri("http://" + url);
        }

        /// <summary>
        /// This method will check a url to see that it does not return server or protocol errors
        /// </summary>
        /// <param name="url">The path to check</param>
        /// <returns></returns>
        public static bool IsWellURL(string url) => Uri.IsWellFormedUriString(url, UriKind.Absolute);
        public static string GetBaseWebURL(string url)
        {
            string[] sa = url.Split('/');
            url = sa.First();
            int len = Math.Min(sa.Length, 3);
            for (int i = 1; i < len; i++)
                url += "/" + sa[i];
            return url;
        }
        public static bool ValidateURL(string url)
        {
            if (!IsWellURL(url)) return false;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 5000; //set the timeout to 5 seconds to keep the user from waiting too long for the page to load
                request.Method = "HEAD"; //Get only the header information -- no need to download any content
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                int statusCode = (int)response.StatusCode;
                if (statusCode >= 100 && statusCode < 400) //Good requests
                    return true;
                else if (statusCode >= 500 && statusCode <= 510) //Server Errors
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public static void Download(string url, string fileAddress)
        {
            try
            {
                WebClient myWebClient = new WebClient();
                myWebClient.DownloadFile(url, fileAddress);
            }
            catch { }
        }
        public static bool DownloadOrSave(string urlOrText,string fileAddress,string ifTextFormat = ".txt")
        {
            if (Uri.IsWellFormedUriString(urlOrText, UriKind.Absolute))
                try
                {
                    WebClient myWebClient = new WebClient();
                    myWebClient.DownloadFile(urlOrText, fileAddress);
                    return true;
                }
                catch(Exception ex) { }
            Service.MiMFa_IOService.StringToFile(fileAddress + ifTextFormat, urlOrText );
            return false;
        }
        public static string GetHTML(string url,out bool success)
        {
            int i = 0;
            success = false;
            string html = "";
            while (!success && i++ < 2)
                try
                {
                    HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                    request.Timeout = 10000; //set the timeout to 5 seconds to keep the user from waiting too long for the page to load
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    int statusCode = (int)response.StatusCode;
                    if (statusCode >= 100 && statusCode < 400) //Good requests
                    {
                        success = true;
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        html = reader.ReadToEnd();
                    }
                    else if (statusCode >= 500 && statusCode <= 510) //Server Errors
                        success = false;
                }
                catch { }
            return html;
        }
        public static void GetHTML(string url, Func<string, object> successFunc, Func<string, object> errorFunc)
        {
            System.Windows.Forms.WebBrowser wb = new System.Windows.Forms.WebBrowser();
            Timer timer = new Timer();
            timer.Interval = 1000;
            int i = 0;
            string html = "";
            timer.Tick += (o, a) =>
            {
                html = wb.DocumentText;
                if (html.ToLower().Contains("</html>"))
                {
                    successFunc(html);
                    timer.Enabled = false;
                }
                else if (i++ > 100)
                {
                    errorFunc(html);
                    timer.Enabled = false;
                }
            };

            wb.Navigated += (s, e) => timer.Enabled = true;
            wb.Navigate(url);
        }
        public static string Json(string url, IEnumerable<KeyValuePair<string, string>> namevaluecollection, string method = "Get")
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ReadWriteTimeout = 100000;
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = method;
            foreach (var item in namevaluecollection)
                httpWebRequest.Headers.Add(item.Key, item.Value);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }

    }
}
