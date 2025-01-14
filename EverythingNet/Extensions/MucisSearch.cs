﻿using EverythingNet.Interfaces;

namespace EverythingNet.Extensions
{
    public static class MucisSearch
    {
        public static IEverything Album(this IEverything everything, string album = null)
        {
            return Search(everything, "album:", album);
        }

        public static IEverything Artist(this IEverything everything, string artist = null)
        {
            return Search(everything, "artist:", artist);
        }

        public static IEverything Genre(this IEverything everything, string genre = null)
        {
            return Search(everything, "genre:", genre);
        }

        public static IEverything Title(this IEverything everything, string title = null)
        {
            return Search(everything, "title:", title);
        }

        public static IEverything Track(this IEverything everything, int track = -1)
        {
            return Search(everything, "track:", track >= 0 ? $"{track}" : String.Empty);
        }

        public static IEverything Comment(this IEverything everything, string comment = null)
        {
            return Search(everything, "comment:", comment);
        }

        private static IEverything Search(IEverything everything, string tag, string search)
        {
            everything.SearchText += tag + LogicSearch.QuoteIfNeeded(search);

            return everything;
        }
    }
}
