using MyStatz.Models;
using System;
using System.Reflection;


namespace MyStatz.Controllers.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string GetStringValue(this ActivityEnum value)
        {
            switch (value)
            {
                case ActivityEnum.NULL:
                    return " ";
                case ActivityEnum.Very_Low:
                    return "Very Low";
                case ActivityEnum.Low:
                    return "Low";
                case ActivityEnum.High:
                    return "High";
                case ActivityEnum.Very_High:
                    return "Very High";
                case ActivityEnum.Intense:
                    return "Intense";
                default:
                    return " ";

            }
        }

        public static string CovertToTime(this int totalSeconds) //since 01.01.1970
        {
            //var stttt = DateTime.FromOADate(timetick);
            var startDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(totalSeconds);
            var now = DateTime.Now;
            //var substractedTicks = DateTime.Now.Ticks - timetick;
            //TimeSpan ts =  TimeSpan.FromSeconds(secondsSinceLastUpdate);
            TimeSpan ts = now.Subtract(startDate);
            //var days = Convert.ToDecimal(ts.TotalDays);
            var hours = Convert.ToDecimal(ts.TotalHours);
            var days = hours / 24;
            var months = days / 30;
            if (hours < 25)
            {
                if(hours >= 2)
                {
                    return Math.Round(hours) + " hours ago";
                }
                else
                {
                    return Math.Round(hours) + " hour ago";
                }
                
            }
            else if(days < 31)
            {
                if(days >= 2)
                {
                    return Math.Round(days) + " days ago";
                }
                else
                {
                    return Math.Round(days) + " day ago";
                }
            }
            else
            {
                if(months >= 2) 
                {
                    return Math.Round(months) + " months ago";
                }
                else
                {
                    return Math.Round(months) + " month ago";
                }
            }
            //DateTime time = new DateTime(timetick);
            //return time.ToString();
        }



    
    }
}   

