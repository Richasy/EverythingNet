﻿using EverythingNet.Interfaces;

namespace EverythingNet.Extensions
{
    public static class SizeSearch
    {
        public enum SizeStandard
        {
            Empty,
            Unknown,
            Tiny,
            Small,
            Medium,
            Large,
            Huge,
            Gigantic,
        }

        public enum SizeUnit
        {
            Kb,
            Mb,
            Gb,
        }

        public static IEverything Size(this IEverything everything)
        {
            return Size(everything, "size:");
        }

        public static IEverything Size(this IEverything everything, int size)
        {
            return Size(everything, $"size:{size}");
        }

        public static IEverything Kb(this IEverything everything)
        {
            return everything.Unit(SizeUnit.Kb);
        }

        public static IEverything Mb(this IEverything everything)
        {
            return everything.Unit(SizeUnit.Mb);
        }

        public static IEverything Gb(this IEverything everything)
        {
            return everything.Unit(SizeUnit.Gb);
        }

        public static IEverything Unit(this IEverything everything, SizeUnit unit)
        {
            return Size(everything, unit.ToString().ToLower());
        }

        public static IEverything Standard(this IEverything everything, SizeStandard size)
        {
            return Size(everything, size.ToString().ToLower());
        }

        private static IEverything Size(IEverything everything, string text)
        {
            everything.SearchText += text;

            return everything;
        }
    }
}
