using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Cimbalino.Toolkit.Extensions;
namespace HAC10.API
{
    public class API
    {
        public API()
        {
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("x2"); /* hex format */
            return sbinary;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static List<KeyValuePair<string, string>> QueryString(object data)
        {
            string publicKey = "bc91c0093b4cad7ff321e5ad36a6d309";
            string privateKey = "4ee37e56b17e48a504ff23e4b6fdb35f";
            Encoding encoding = Encoding.UTF8;

            //Encode data
            var json = JsonConvert.SerializeObject(data);
            string data_json = Base64Encode(json);
            //string data_json_encode = HttpUtility.UrlEncode(data_json);
            string data_json_encode = data_json.Replace("=", "%3D");


            //Encode signature
            string signature = "";

            var keyByte = privateKey.GetBytes();
            var stringBytes = encoding.GetBytes(data_json_encode);
            var md5Hash = stringBytes.ComputeHMACMD5Hash(keyByte);
            signature = ByteToString(md5Hash);

            List<KeyValuePair<string, string>> kv = new List<KeyValuePair<string, string>>();
            kv.Add(new KeyValuePair<string, string>("publicKey", publicKey));
            kv.Add(new KeyValuePair<string, string>("signature", signature));
            kv.Add(new KeyValuePair<string, string>("jsondata", data_json_encode));

            return kv;
        }

        public static async Task<T> CallAPI<T>(string function, object data)
        {
            // server to POST to
            var kv = QueryString(data);
            string queryData = "";
            for (var i = 0; i < kv.Count; i++)
            {
                if (i > 0)
                    queryData += "&";
                queryData += kv[i].Key + "=" + kv[i].Value;
            }

            // HTTP web request
            var request = (HttpWebRequest)WebRequest.Create("http://hopamchuan.com/api/" + function);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Method = "POST";
            request.Accept = "*/*";
            string postData = queryData;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.Headers[HttpRequestHeader.ContentLength] = byteArray.Length.ToString();


            using (var stream = await Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, null))
            {
                byte[] jsonAsBytes = Encoding.UTF8.GetBytes(queryData);
                await stream.WriteAsync(jsonAsBytes, 0, jsonAsBytes.Length);
            }

            string returnString = "";
            await Task
                .Factory
                .FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, "http://hopamchuan.com/api/" + function)
                .ContinueWith(t =>
                {
                    try
                    {
                        if (t.IsCompleted)
                        {
                            using (var stream = t.Result.GetResponseStream())
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    returnString = reader.ReadToEnd();
                                }
                            }
                        }
                        else if (t.IsFaulted)
                        {
                        }
                    }
                    catch (AggregateException ex)
                    {
                        if (ex.Message.IndexOf("NotFound") >= 0)
                        {
                            throw new Exception("Cannot connect to Hop Am Chuan API");
                        }
                        else
                        {
                            var messages = ex.Message + "\r\n";
                            messages += string.Join("\r\n", ex.InnerExceptions.Select(ee => ee.Message).ToArray());

                            throw new Exception(messages);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.IndexOf("NotFound") >= 0)
                        {
                            throw new Exception("Cannot connect to Hop Am Chuan API");
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                });

            try
            {
                var resultObj = JsonConvert.DeserializeObject<T>(returnString);
                return resultObj;
            }
            catch (Exception ex)
            {
                throw new Exception(returnString);
            }
        }

        public static async Task<T[]> CallAPIArray<T>(string function, object data)
        {
            // server to POST to
            var kv = QueryString(data);
            string queryData = "";
            for (var i = 0; i < kv.Count; i++)
            {
                if (i > 0)
                    queryData += "&";
                queryData += kv[i].Key + "=" + kv[i].Value;
            }

            // HTTP web request
            var request = (HttpWebRequest)WebRequest.Create("http://hopamchuan.com/api/" + function);
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Method = "POST";
            request.Accept = "*/*";
            string postData = queryData;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.Headers[HttpRequestHeader.ContentLength] = byteArray.Length.ToString();


            using (var stream = await Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, null))
            {
                byte[] jsonAsBytes = Encoding.UTF8.GetBytes(queryData);
                await stream.WriteAsync(jsonAsBytes, 0, jsonAsBytes.Length);
            }

            string returnString = "";
            await Task
                .Factory
                .FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, "http://hopamchuan.com/api/" + function)
                .ContinueWith(t =>
                {
                    try
                    {
                        if (t.IsCompleted)
                        {
                            using (var stream = t.Result.GetResponseStream())
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    returnString = reader.ReadToEnd();
                                }
                            }
                        }
                        //else if (t.IsFaulted)
                        //{
                        //}
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });

            try
            {
                List<T> objects = new List<T>();

                using (StringReader sr = new StringReader(returnString))
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.StartObject && reader.Depth == 1)
                        {
                            // Load each object from the stream and do something with it
                            JObject obj = JObject.Load(reader);
                            objects.Add(obj.ToObject<T>());
                        }
                    }
                }

                return objects.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(returnString + ";" + ex.Message);
            }
        }
    }
}
