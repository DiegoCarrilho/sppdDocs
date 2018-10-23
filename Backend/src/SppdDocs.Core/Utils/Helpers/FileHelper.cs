using System;
using System.Globalization;

namespace SppdDocs.Core.Utils.Helpers
{
    public static class FileHelper
    {
        public static string GetCleanFilePath(string path)
        {
            var uri = new UriBuilder(path);
            return Uri.UnescapeDataString(uri.Path).ToLower(CultureInfo.InvariantCulture);
        }
    }
}