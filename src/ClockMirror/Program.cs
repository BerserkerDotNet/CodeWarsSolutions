using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Result: {WhatIsTheTime("06:35")}");
        Console.WriteLine($"Result: {WhatIsTheTime("12:01")}");
        Console.WriteLine($"Result: {WhatIsTheTime("11:58")}");
        Console.WriteLine($"Result: {WhatIsTheTime("12:00")}");
        Console.WriteLine($"Result: {WhatIsTheTime("10:00")}");
        Console.ReadLine();
    }

    public static string WhatIsTheTime(string timeInMirror)
    {
        const int minutesInHour = 60;
        const int TwelveHours = 720;
        var timeComponents = timeInMirror.Split(':');
        var minutes = int.Parse(timeComponents[0]) * minutesInHour + int.Parse(timeComponents[1]);
        if (minutes > TwelveHours)
        {
            minutes = minutes - TwelveHours;
        }
        var difference = minutes > TwelveHours ? minutes : Math.Abs(TwelveHours - minutes);
        if (difference < 60)
        {
            difference += TwelveHours;
        }
        return string.Format("{0:D2}:{1:D2}", difference / 60, difference % 60);
    }
}