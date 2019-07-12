using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Safe2Pay
{
    public static class Utils
    {
        public static IDictionary<string, string> ToQueryString(this object obj)
        {
            if (obj == null) return null;
            if (!(obj is JToken token)) return ToQueryString(JObject.FromObject(obj));
            var content = new Dictionary<string, string>();
            if (token.HasValues)
            {
                foreach (var child in token.Children().ToList())
                {
                    var childContent = child.ToQueryString();
                    if (childContent != null)
                        content = content.Concat(childContent).ToDictionary(k => k.Key, v => v.Value);
                }
                return content;
            }

            var jValue = (JValue)token;
            if (jValue.Value == null) return null;
            var value = jValue.Type == JTokenType.Date
                ? jValue.ToString("o", CultureInfo.InvariantCulture)
                : jValue.ToString(CultureInfo.InvariantCulture);
            return new Dictionary<string, string> { { token.Path, value } };
        }

        public static string Compress(string input)
        {
            var encoded = Encoding.UTF8.GetBytes(input);
            var compressed = Compress(encoded);
            return Convert.ToBase64String(compressed);
        }

        private static byte[] Compress(byte[] input)
        {
            using (var result = new MemoryStream())
            {
                var lengthBytes = BitConverter.GetBytes(input.Length);
                result.Write(lengthBytes, 0, 4);

                using (var compressionStream = new GZipStream(result, CompressionMode.Compress))
                {
                    compressionStream.Write(input, 0, input.Length);
                    compressionStream.Flush();
                }
                return result.ToArray();
            }
        }

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore };

        public static string Serialize(object data) => JsonConvert.SerializeObject(data, Settings);

        public static T Deserialize<T>(string data) => JsonConvert.DeserializeObject<T>(data, Settings);
    }
}