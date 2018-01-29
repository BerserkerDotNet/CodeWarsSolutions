using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Base64Encoder
{
    public class Base64Encoder
    {
        public static class Base64Utils
        {
            static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
            public static string GetRandomString(int i)
            {
                Random random = new Random(i);
                var length = random.Next(1, alphabet.Length - 1);
                return new string(Enumerable.Repeat(alphabet, length).Select(s => s[random.Next(s.Length)]).ToArray());

            }

            public static string ToBase64(string s)
            {
                var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
                var bytes = Encoding.ASCII.GetBytes(s);
                var sb = new StringBuilder();

                for (int i = 0; i < bytes.Length; i += 3)
                {
                    var c = (bytes[i] & 0xFC) >> 2;
                    sb.Append(alphabet[c]);
                    c = (bytes[i] & 0x03) << 4;
                    if (i + 1 < bytes.Length)
                    {
                        c |= (bytes[i + 1] & 0xF0) >> 4;
                        sb.Append(alphabet[c]);
                        c = (bytes[i + 1] & 0x0F) << 2;
                        if (i + 2 < bytes.Length)
                        {
                            c |= (bytes[i + 2] & 0xC0) >> 6;
                            sb.Append(alphabet[c]);
                            c = bytes[i + 2] & 0x3F;
                            sb.Append(alphabet[c]);
                        }
                        else
                        {
                            sb.Append(alphabet[c]);
                            sb.Append("=");
                        }
                    }
                    else
                    {
                        sb.Append(alphabet[c]);
                        sb.Append("==");
                    }
                }

                return sb.ToString();
            }

            public static string FromBase64(string s)
            {
                var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
                var result = new List<byte>();

                for (var i = 0; i < s.Length; i += 4)
                {
                    var c1 = alphabet.IndexOf(s[i]) << 2;
                    c1 |= (alphabet.IndexOf(s[i + 1]) & 0x30) >> 4;
                    result.Add(Convert.ToByte(c1));
                    if (s[i + 2] != '=')
                    {
                        var c2 = (alphabet.IndexOf(s[i + 1]) & 0x0F) << 4;
                        c2 |= (alphabet.IndexOf(s[i + 2]) & 0x03C) >> 2;
                        result.Add(Convert.ToByte(c2));
                    }

                    if (s[i + 3] != '=')
                    {
                        var c3 = (alphabet.IndexOf(s[i + 2]) & 0x03) << 6;
                        c3 |= alphabet.IndexOf(s[i + 3]);
                        result.Add(Convert.ToByte(c3));
                    }
                }

                return Encoding.UTF8.GetString(result.ToArray());
            }
        }
    }
}