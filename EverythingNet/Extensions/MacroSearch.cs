﻿using EverythingNet.Interfaces;

namespace EverythingNet.Extensions
{
    public static class MacroSearch
    {
        public static IEverything Audio(this IEverything everything, string search = null)
        {
            return Macro(everything, "audio:", search);
        }

        public static IEverything Zip(this IEverything everything, string search = null)
        {
            return Macro(everything, "zip:", search);
        }

        public static IEverything Video(this IEverything everything, string search = null)
        {
            return Macro(everything, "video:", search);
        }

        public static IEverything Picture(this IEverything everything, string search = null)
        {
            return Macro(everything, "pic:", search);
        }

        public static IEverything Exe(this IEverything everything, string search = null)
        {
            return Macro(everything, "exe:", search);
        }

        public static IEverything Document(this IEverything everything, string search = null)
        {
            return Macro(everything, "doc:", search);
        }

        private static IEverything Macro(IEverything everything, string tag, string search)
        {
            everything.SearchText += tag + LogicSearch.QuoteIfNeeded(search);

            return everything;
        }
    }
}
