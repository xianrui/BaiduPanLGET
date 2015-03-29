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
using System.Globalization;

namespace BaiduPanLGET.Core
{
    public class FileInfo
    {
        public string share_id;
        public string bdstoken;
        public string uk;
        public string bduss;
        public string fid_list;
        public string sign;
        public string filename;
        public string timestamp;

        public void match(string data)
        {
            //string pattern = "yunData\\.(\\w+\\s=\\s\"\\w+\");";
            string pattern = "yunData\\.(?<name>\\w+)\\s=\\s\"(?<value>.+?)\";";
            var d = new Dictionary<string, string>();
            foreach (Match match in Regex.Matches(data, pattern))
            {
                d.Add(match.Groups["name"].Value, match.Groups["value"].Value);
            }
            if(d.ContainsKey("SHARE_ID"))
            {
                share_id = d["SHARE_ID"];
            }
            if(d.ContainsKey("MYBDSTOKEN"))
            {
               bdstoken = d["MYBDSTOKEN"];
            }
            if(d.ContainsKey("MYUK"))
            {
                uk = d["MYUK"];
            }
            if(d.ContainsKey("MYBDUSS"))
            {
                bduss = d["MYBDUSS"];
            }
            if (d.ContainsKey("FS_ID"))
            {
                fid_list = d["FS_ID"];
            }
            if(d.ContainsKey("SIGN"))
            {
                sign = d["SIGN"];
            }
            if(d.ContainsKey("FILENAME"))
            {
                filename = Decode(d["FILENAME"]);
            }
            if(d.ContainsKey("TIMESTAMP"))
            {
                timestamp = d["TIMESTAMP"];
            }
        }
        static Regex reUnicode = new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.Compiled);
        public static string Decode(string s)
        {
            return reUnicode.Replace(s, m =>
            {
                short c;
                if (short.TryParse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c))
                {
                    return "" + (char)c;
                }
                return m.Value;
            });
        }
    }
}