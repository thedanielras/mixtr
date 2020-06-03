using System;
using System.Text.RegularExpressions;

namespace Mixtr.Utils
{
    public static class YoutubeUrlValidator
    {
        private static Regex VideoIdRegexRule = new Regex(@"watch\?v=[\d\D]{11}");
        private  static  Regex ShortenedVideoIdRegexRule = new Regex(@"youtu\.be\/[\d\D]{11}");
        private static Regex PlaylistIdRegexRule = new Regex(@"PL[\d\D]{32}");

        public static bool CheckIfValid(string input)
        {
            return PlaylistIdRegexRule.Match(input).Success
                   || VideoIdRegexRule.Match(input).Success
                   || ShortenedVideoIdRegexRule.Match(input).Success;
        }

        public static string GetId(string input)
        {
            var playlistIdMatcher = PlaylistIdRegexRule.Match(input);
            var videoIdMatcher = VideoIdRegexRule.Match(input);
            var shortVideoIdMatcher = ShortenedVideoIdRegexRule.Match(input);

            if (playlistIdMatcher.Success)
            {
                return playlistIdMatcher.Value;
            }

            if (videoIdMatcher.Success)
            {
                return videoIdMatcher.Value.Split('=')[1];
            }

            if (shortVideoIdMatcher.Success)
            {
                return shortVideoIdMatcher.Value.Split('/')[1];
            }

            return null;
        }
    }
}