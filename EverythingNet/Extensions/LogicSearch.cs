﻿using EverythingNet.Interfaces;

namespace EverythingNet.Extensions
{
    public static class LogicSearch
    {
        public static IEverything Is(this IEverything everything, string value)
        {
            everything.SearchText += QuoteIfNeeded(value);

            return everything;
        }

        public static IEverything Is(this IEverything everything, object value)
        {
            everything.SearchText += QuoteIfNeeded(value.ToString());

            return everything;
        }

        public static IEverything GreaterThan(this IEverything everything, int value)
        {
            everything.SearchText += $">{value}";

            return everything;
        }

        public static IEverything GreaterOrEqualThan(this IEverything everything, int value)
        {
            everything.SearchText += $">={value}";

            return everything;
        }

        public static IEverything LessThan(this IEverything everything, int value)
        {
            everything.SearchText += $"<{value}";

            return everything;
        }

        public static IEverything LessOrEqualThan(this IEverything everything, int value)
        {
            everything.SearchText += $"<={value}";

            return everything;
        }

        public static IEverything Or(this IEverything everything)
        {
            everything.SearchText += "|";

            return everything;
        }

        public static IEverything And(this IEverything everything)
        {
            everything.SearchText += " ";

            return everything;
        }

        public static IEverything Not(this IEverything everything)
        {
            everything.SearchText += "!";

            return everything;
        }

        public static IEverything Between(this IEverything everything, int min, int max, string unit = "")
        {
            everything.SearchText += $"{min}{unit}-{max}{unit}";

            return everything;
        }

        public static IEverything Between(this IEverything everything, int min, int max, Enum unit)
        {
            string u = unit.ToString().ToLower();

            everything.SearchText += $"{min}{u}-{max}{u}";

            return everything;
        }

        public static string QuoteIfNeeded(string text)
        {
            if (text == null)
            {
                return string.Empty;
            }

            if (text.Contains(" ") && text.First() != '\"' && text.Last() != '\"')
            {
                return $"\"{text}\"";
            }

            return text;
        }
    }
}
