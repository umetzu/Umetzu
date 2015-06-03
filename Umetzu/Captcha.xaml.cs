using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Xml;
using System.Xml.Linq;

namespace Umetzu
{
    /// <summary>
    /// Interaction logic for Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        private string cookie = "";
        public string valor = "0";
        public string binCode = "";
        public string country = "";

        public Captcha()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            image1.Source = HttpGet();
            textBox1.Focus();
        }

        private void LoadProxy(WebRequest req)
        {
            try
            {
                var doc = XDocument.Load("CardLevels.xml");
                var proxy = doc.Descendants("PROXY").First().Value;

                 var proxyInfo = proxy.Split(':');

                if (proxyInfo.Length > 1)
                {
                    req.Proxy = new WebProxy(proxyInfo[0], int.Parse(proxyInfo[1]));
                }
            }
            catch (Exception)
            {
               MessageBox.Show("PROXY tag should appear, even empty"); 
            }         
        }

        public ImageSource HttpGet()
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create("https://www.bindb.com/captcha.php");

            LoadProxy(req);

            System.Net.WebResponse resp = req.GetResponse();
            cookie = resp.Headers["Set-cookie"].Substring(0, 42);

            var stream = resp.GetResponseStream();

            Byte[] buffer = new Byte[resp.ContentLength];
            stream.Read(buffer, 0, buffer.Length);

            BitmapImage bi = new BitmapImage();

            using (MemoryStream byteStream = new MemoryStream(buffer))
            {               
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = byteStream;
                bi.EndInit();

            }

            return bi;
        }

        public string HttpPost(string Parameters)
        {
            System.Net.HttpWebRequest req = (HttpWebRequest)System.Net.WebRequest.Create("https://www.bindb.com/bin-database.html");

            req.Accept = "text/html, application/xhtml+xml, */*";
            req.Referer = "https://www.bindb.com/bin-database.html";
            req.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            req.Headers.Add("Cookie", cookie);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            LoadProxy(req);

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }


        private void textBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ValidateCard(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void ValidateCard(KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;

                var page = HttpPost(string.Format("act=bin&bin={0}&captcha={1}&button=Search", binCode, textBox1.Text));

                HtmlDocument doc = null;

                try
                {
                    doc = new HtmlDocument { OptionFixNestedTags = true, OptionAutoCloseOnEnd = true };
                    doc.LoadHtml(page);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (doc != null)
                {
                    try
                    {
                        var type = doc.DocumentNode.SelectNodes("//td").FirstOrDefault(x => x.InnerText == "Card Type:").NextSibling.NextSibling.FirstChild.InnerText;
                        var level = doc.DocumentNode.SelectNodes("//td").FirstOrDefault(x => x.InnerText == "Card Level:").NextSibling.NextSibling.FirstChild.InnerText;
                        country = doc.DocumentNode.SelectNodes("//td").FirstOrDefault(x => x.InnerText == "Iso Country A2:").NextSibling.NextSibling.FirstChild.InnerText;
                        
                        Owner.Title = "Umetzu " + type + " | " + level + " | " + country;

                        valor = WriteTypeLevel(type, level);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            var tt = doc.DocumentNode.SelectNodes("//div").FirstOrDefault(x => x.Id == "myform_errorloc");
                            if (tt != null)
                            {
                                MessageBox.Show(tt.InnerText);
                            }
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex + @"\\\\\\\" + ex2);
                        }

                    }

                }

                this.Close();
            }
        }

        private string WriteTypeLevel(string type, string level)
        {            
            try
            {
                var doc = XDocument.Load("CardLevels.xml");

                type = string.IsNullOrEmpty(type) ? "ALL" : type.Trim();

                var node = doc.Descendants(type);

                if (node.Count() > 0)
                {
                    var defaultValue = node.Attributes("default").First().Value;

                    if (!string.IsNullOrEmpty(level))
                    {
                        var subNode = node.Descendants(level.Replace(@"/", "-").Trim()).FirstOrDefault();

                        if (subNode != null)
                        {
                            return subNode.Value;
                        }

                        MessageBox.Show("Update CardLevels.xml with " + type + " | " + level.Replace(@"/", "-"));
                    }

                    return defaultValue;
                }

                MessageBox.Show("Update CardLevels.xml with " + type + " | " + level.Replace(@"/", "-"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                     

            return "0";
        }
    }
}
