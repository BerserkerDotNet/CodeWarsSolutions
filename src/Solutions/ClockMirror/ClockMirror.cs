using Solutions.Infrastructure;
using System;

namespace Solutions.ClockMirror
{
    public class ClockMirror : ISolution
    {
        public string DisplayName => "Clock mirror";

        public void Execute(IHost host)
        {
            var time = host.Read<string>("Enter time (HH:mm):");
            var result = WhatIsTheTime(time);
            host.Show($"Result: {result}");
        }

        public string WhatIsTheTime(string timeInMirror)
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
}