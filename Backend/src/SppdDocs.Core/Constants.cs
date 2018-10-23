namespace SppdDocs.Core
{
    /// <summary>
    ///     Application constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        ///     Contains constant paths
        /// </summary>
        public struct Config
        {
            /// <summary>
            ///     Relative path to the folder containing configurations
            /// </summary>
            public const string APP_CONFIG_FOLDER = "AppConfig";

            /// <summary>
            ///     The log4net configuration file name
            /// </summary>
            // ReSharper disable once InconsistentNaming
            public const string LOG4NET_CONFIG_FILE_NAME = "log4net.config";
        }

        public struct Application
        {
            public const string SHORT_NAME = "Sppd";
        }
    }
}