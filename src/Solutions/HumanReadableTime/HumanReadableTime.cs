using System;

namespace Solutions.HumanReadableTime
{
    public class HumanReadableTime
    {
        public static string FormatTime(int timeInSeconds)
        {
            const int maxTime = 359999;
            const int secondsInHour = 3600;
            const int secondsInMinute = 60;
            if (timeInSeconds < 0 || timeInSeconds > maxTime)
            {
                throw new ArgumentOutOfRangeException(nameof(timeInSeconds));
            }

            var hours = timeInSeconds / secondsInHour;
            var minutes = (timeInSeconds % secondsInHour) / secondsInMinute;
            var seconds = timeInSeconds % secondsInMinute;

            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
    }
}