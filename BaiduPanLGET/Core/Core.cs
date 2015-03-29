using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace BaiduPanLGET.Core
{
    public class PAN
    {
        string url; //Define url.
        string user_agent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.60 Safari/537.36"; //Define User Agent
        CookieContainer cookie = new CookieContainer(); //Cookie container.
        public bool parse_result = true; //If url not pan.baidu.com or yun.baidu.com, return false.
        string data_returned; //Returned Request Data.
        string sekey; //Secret Key
        public bool failed = false;
        string shareid; //for passwd
        string uk; //for passwd
        string request_url; // for post.
        string original_url; //for passwd
        string js; //returned js.
        bool gotpass = false;
        string post;
        public void MakeRequest(string data, string method, bool passwd = false, bool requrl = false, string requesturl = "")
        {
            if(failed == true)
            {
                MessageBox.Show("Error");
                return;
            }
            try
            {
                if (method == "get")
                {
                    var request = (HttpWebRequest)WebRequest.Create(url); //Make Request
                    request.AllowAutoRedirect = true; 
                    ((HttpWebRequest)request).UserAgent = user_agent; //Define user-agent.
                    ((HttpWebRequest)request).CookieContainer = cookie;
                    request.KeepAlive = true;
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        for (int i = 0; i < response.Cookies.Count; i++)
                        {
                            Cookie http_cookie = response.Cookies[i];
                            cookie.Add(new Uri("http://pan.baidu.com"), new Cookie(http_cookie.Name, http_cookie.Value)); //Add response cookie.
                        }
                        Stream responseStream = response.GetResponseStream();
                        StreamReader responseReader = new StreamReader(responseStream);
                        data_returned = responseReader.ReadToEnd();
                        url = response.ResponseUri.ToString();
                    }
                }
                else
                {
                    
                    if(passwd == true)
                    {
                        int epoch = (int)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds;
                        request_url = "http://pan.baidu.com/share/verify/?shareid="+shareid+"&uk="+uk+"&t="+epoch;
                    }
                    else
                    {
                        request_url = url;
                    }
                    if(requrl == true)
                    {
                        request_url = requesturl;
                    }
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(request_url);
                    ((HttpWebRequest)request).UserAgent = user_agent;
                    ((HttpWebRequest)request).Headers.Set("X-Requested-With", "XMLHttpRequest");
                    ((HttpWebRequest)request).ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    ((HttpWebRequest)request).Method = "POST";
                    ((HttpWebRequest)request).CookieContainer = cookie;
                    byte[] databyteArray = Encoding.UTF8.GetBytes(data);
                    request.ContentLength = databyteArray.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(databyteArray, 0, databyteArray.Length); //Write Post DATA
                    dataStream.Close();
                    using(var response = (HttpWebResponse)request.GetResponse())
                    {
                        for (int i = 0; i < response.Cookies.Count; i++)
                        {
                            Cookie http_cookie = response.Cookies[i];
                            cookie.Add(new Uri("http://pan.baidu.com"), new Cookie(http_cookie.Name, http_cookie.Value));
                            if (http_cookie.Name == "BDCLND")
                            {
                                sekey = http_cookie.Value;
                            }
                        }
                        Stream dataStream2 = response.GetResponseStream();
                        StreamReader dataReader = new StreamReader(dataStream2);
                        data_returned = dataReader.ReadToEnd();
                        url = response.ResponseUri.ToString();
                        dataReader.Close();
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void parse_url(string url)
        {
            try
            {
                var uri = new Uri(url);
                string host = uri.Host.ToString();
                if (host != "pan.baidu.com" && host != "yun.baidu.com")
                {
                    DialogResult result = MessageBox.Show("Url must be pan.baidu.com or yun.baidu.com", "Url Invalid.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        parse_result = false;
                        return;
                    }
                }
                else
                {
                    parse_result = true;
                    this.url = uri.ToString();
                    original_url = uri.ToString();
                }

            }
            catch (UriFormatException)
            {
                url = "http://" + url;
                var uri = new Uri(url);
                string host = uri.Host.ToString();
                if (host != "pan.baidu.com" && host != "yun.baidu.com")
                {
                    DialogResult result = MessageBox.Show("Url must be pan.baidu.com or yun.baidu.com", "Url Invalid.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.OK)
                    {
                        parse_result = false;
                        return;
                    }
                }
                else
                {
                    parse_result = true;
                    this.url = uri.ToString();
                    original_url = uri.ToString();
                }

            }

        }
        public void get_js(string secret = "")
        {
            if(url.Contains("init"))
            {
                verify_passwd();
            }
            url = original_url;
            if(failed == false)
            {
                if (gotpass == true)
                {
                    MakeRequest("", "get");
                }
            }
            Regex re = new Regex("<script\\stype=\"text/javascript\">!function\\(\\)([^<]+)</script>");
            Match ma = re.Match(data_returned);
            if (ma.Success)
            {
                js = ma.Groups[0].Value;
                failed = false;
            }
            else
            {
                MessageBox.Show("Match js failed!");
                failed = true;
            }
        }
        public void verify_passwd()
        {
            Regex re = new Regex("init\\?shareid=(?<shareid>.\\d+)&uk=(?<uk>.\\d+)");
            Match ma = re.Match(url);
            if (ma.Success)
            {
                MessageBox.Show("Password required!");
                shareid = ma.Groups["shareid"].Value;
                uk = ma.Groups["uk"].Value;
                string password = Prompt.ShowDialog("Password : ", "Please input your sharing password.");
                MakeRequest("pwd=" + password + "&vcode=", "post", true);
                JToken token = JObject.Parse(data_returned);
                int errno = (int)token.SelectToken("errno");
                if(errno == -9){
                    MessageBox.Show("Password Wrong");
                    failed = true;
                    return;
                }
                if(errno == -63)
                {
                    MessageBox.Show("Unknown Error!");
                    failed = true;
                    return;
                }
                if(errno != 0)
                {
                    MessageBox.Show("Unknown Error!");
                    failed = true;
                    return;
                }
                gotpass = true;
            }
            else
            {
                MessageBox.Show("Match url failed");
                failed = true;
            }

        }
        public void get_dllink()
        {
            MakeRequest("", "get");
            get_js();
            FileInfo fileinfo = new FileInfo();
            fileinfo.match(js);
            string share_id = fileinfo.share_id;
            string bdstoken = fileinfo.bdstoken;
            string myuk = fileinfo.uk;
            string bduss = fileinfo.bduss;
            string fid_list = fileinfo.fid_list;
            string sign = fileinfo.sign;
            string filename = fileinfo.filename;
            string timestamp = fileinfo.timestamp;
            if (gotpass != true)
            {
                post = "encrypt=0&product=share&uk=" + myuk + "&primaryid=" + share_id + "&fid_list=%5B" + fid_list + "%5D";
            }
            else
            {
                post = "encrypt=0&product=share&uk=" + myuk + "&primaryid=" + share_id + "&fid_list=%5B" + fid_list + "%5D&extra=%7B%22sekey%22%3A%22" + sekey + "%22%7D";
            }
            MakeRequest(post, "post", false, true, "http://pan.baidu.com/api/sharedownload?sign="+sign+"&timestamp="+timestamp+"&bdstoken="+bdstoken+"&channel=chunlei&clienttype=0&web=1&app_id=250528");
            JToken token = JObject.Parse(data_returned);
            int errno = (int)token.SelectToken("errno");
            if(errno == 0)
            {
                var des = (MyClass)Newtonsoft.Json.JsonConvert.DeserializeObject(data_returned, typeof(MyClass));
                Main.dlink = des.list[0].dlink.ToString();
                Main.md5 = des.list[0].md5.ToString();
                Main.filename = fileinfo.filename;
                return;
            }
            if(errno == -20)
            {
                MessageBox.Show("Captcha Required.");
                url = "http://pan.baidu.com/api/getcaptcha?prod=share&bdstoken=&channel=chunlei&clienttype=0&web=1&app_id=250528";
                MakeRequest("","get");
                JToken token2 = JObject.Parse(data_returned);
                string vcode_str = (string)token2.SelectToken("vcode_str");
                string vcode_img = (string)token2.SelectToken("vcode_img");
                string vcode_img2 = vcode_img.Replace("\\", "");
                WebRequest req = WebRequest.Create(vcode_img2);
                Stream stream = req.GetResponse().GetResponseStream();
                Image img = Image.FromStream(stream);
                Main.captcha = img;
                string vcode = Prompt.ShowCaptcha();
                if (gotpass != true)
                {
                    post = "encrypt=0&product=share&uk=" + myuk + "&primaryid=" + share_id + "&fid_list=%5B" + fid_list + "%5D&vcode_str=" + vcode_str + "&vcode_input=" + vcode;
                }
                else
                {
                    post = "encrypt=0&product=share&uk=" + myuk + "&primaryid=" + share_id + "&fid_list=%5B" + fid_list + "%5D&extra=%7B%22sekey%22%3A%22" + sekey + "%22%7D&vcode_str=" + vcode_str + "&vcode_input=" + vcode;
                }
                MakeRequest(post, "post", false, true, "http://pan.baidu.com/api/sharedownload?sign=" + sign + "&timestamp=" + timestamp + "&bdstoken=" + bdstoken + "&channel=chunlei&clienttype=0&web=1&app_id=250528");
                JToken token3 = JObject.Parse(data_returned);
                int errno2 = (int)token3.SelectToken("errno");
                if(errno2 == -20)
                {
                    MessageBox.Show("Captcha Wrong! Please Try Again!");
                    return;
                }
                var des = (MyClass)Newtonsoft.Json.JsonConvert.DeserializeObject(data_returned, typeof(MyClass));
                Main.dlink = des.list[0].dlink.ToString();
                Main.md5 = des.list[0].md5.ToString();
                Main.filename = fileinfo.filename;
                return;
            }
        }
        public class MyClass
        {
            public List<info> list { get; set; }
        }

        public class info
        {
            public string dlink { get; set; }
            public string md5 { get; set; }
        }
    }
}