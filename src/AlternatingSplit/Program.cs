using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
       // Console.WriteLine($"Encrypted: {Encrypt("This kata is very interesting!", 1)}");
        Console.WriteLine($"Encrypted: {Encrypt("This is a test!", 1)}");
        Console.ReadLine();
    }

    public static string Encrypt(string s, int n)
    {
        if (string.IsNullOrEmpty(s) || n <= 0)
        {
            return s;
        }

        for (int i = 1; i <= n; i++)
        {
            var sb = new StringBuilder(s.Length);
            EncryptInternal(sb, s, 0);
            s = sb.ToString();
        }

        return s;
    }

    public static string Decrypt(string s, int n)
    {
        if (string.IsNullOrEmpty(s) || n <= 0)
        {
            return s;
        }

        for (int i = 1; i <= n; i++)
        {
            var sb = new StringBuilder(s.Length);
            DecryptInternal(sb, s, 0);
            s = sb.ToString();
        }

        return s;
    }

    private static void EncryptInternal(StringBuilder sb, string s, int index)
    {
        if (index == s.Length)
        {
            sb.Append(s[0]);
            return;
        }
        else if (index == s.Length)
        {
            sb.Append(s[0]);
            return;
        }
        else if (index % 2 != 0)
        {
            sb.Append(s[index]);
        }

        EncryptInternal(sb, s, index - 1);

        if (index % 2 == 0)
        {
            sb.Append(s[index]);
        }

        //if (index + 1 <= s.Length)
        //{
        //    EncryptInternal(sb, s, index + 1);

        //    if (index % 2 == 0)
        //    {
        //        sb.Append(s[s.Length - (index - 1)]);
        //    }
        //}
        //else
        //{
        //    sb.Append(s[0]);
        //}
    }

    private static void DecryptInternal(StringBuilder sb, string s, int index)
    {
        var half = (s.Length / 2);
        if (half + index < s.Length)
        {
            sb.Append(s[(s.Length / 2) + index]);
            if (index != half)
            {
                sb.Append(s[index]);
            }
            DecryptInternal(sb, s, index + 1);
        }
    }
}