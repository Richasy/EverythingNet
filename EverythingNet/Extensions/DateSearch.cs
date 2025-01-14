﻿using EverythingNet.Interfaces;

namespace EverythingNet.Extensions
{
    public static class DateSearch
    {
        public enum Dates
        {
            Year, Month, Week,
        }

        public enum Months
        {
            January, February, March, April, May, June, July, August, September, October, November, December,
        }

        public enum Days
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday,
        }

        public enum Times
        {
            Hours, Minutes, Seconds,
        }


        public static IEverything DateCreated(this IEverything everything)
        {
            return Date(everything, "dc:");
        }

        public static IEverything DateCreated(this IEverything everything, DateTime date)
        {
            return Date(everything, $"dc:{date.ToShortDateString()}");
        }

        public static IEverything DateAccess(this IEverything everything)
        {
            return Date(everything, "da:");
        }

        public static IEverything DateAccess(this IEverything everything, DateTime date)
        {
            return Date(everything, $"da:{date.ToShortDateString()}");
        }

        public static IEverything DateModified(this IEverything everything)
        {
            return Date(everything, "dm:");
        }

        public static IEverything DateModified(this IEverything everything, DateTime date)
        {
            return Date(everything, $"dm:{date.ToShortDateString()}");
        }

        public static IEverything DateRun(this IEverything everything)
        {
            return Date(everything, "dr:");
        }

        public static IEverything Today(this IEverything everything)
        {
            return Date(everything, "today");
        }

        public static IEverything Yesterday(this IEverything everything)
        {
            return Date(everything, "yesterday");
        }

        public static IEverything This(this IEverything everything, Dates date)
        {
            return Date(everything, $"this{date.ToString().ToLower()}");
        }

        public static IEverything This(this IEverything everything, Times times)
        {
            return Date(everything, $"this{times.ToString().ToLower()}");
        }

        public static IEverything Last(this IEverything everything, Dates date, int num = 0)
        {
            return Date(everything, "last", date, num, "s");
        }

        public static IEverything Last(this IEverything everything, Times times, int num = 0)
        {
            return Date(everything, "last", times, num, String.Empty);
        }

        public static IEverything Next(this IEverything everything, Dates date, int num = 0)
        {
            return Date(everything, "next", date, num, "s");
        }

        public static IEverything Next(this IEverything everything, Times times, int num = 0)
        {
            return Date(everything, "next", times, num, string.Empty);
        }

        private static IEverything Date(IEverything everything, string date)
        {
            everything.SearchText += date;

            return everything;
        }

        private static IEverything Date(IEverything everything, string tag, Enum date, int num, string plural)
        {
            string dateString = date.ToString().ToLower();

            return Date(everything, num > 0 ? $"{tag}{num}{dateString}{plural}" : $"{tag}{dateString}");
        }
    }
}
