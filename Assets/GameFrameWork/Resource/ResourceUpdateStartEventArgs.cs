namespace GameFramework.Resources
{
    /// <summary>
    /// 资源更新开始事件
    /// </summary>
    public sealed class ResourceUpdateStartEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化资源更新开始事件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="downloadPath"></param>
        /// <param name="downloadUrl"></param>
        /// <param name="currentLength"></param>
        /// <param name="zipLength"></param>
        /// <param name="retryCount"></param>
        public ResourceUpdateStartEventArgs(string name, string downloadPath, string downloadUrl, int currentLength, int zipLength, int retryCount)
        {
            Name = name;
            DownloadPath = downloadPath;
            DownloadUrl = downloadUrl;
            CurrentLength = currentLength;
            ZipLength = zipLength;
            RetryCount = retryCount;
        }

        /// <summary>
        /// 获取资源名称
        /// </summary>
        /// <value></value>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取资源下载后存放路径
        /// </summary>
        /// <value></value>
        public string DownloadPath
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载地址
        /// </summary>
        /// <value></value>
        public string DownloadUrl
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取当前下载大小
        /// </summary>
        /// <value></value>
        public int CurrentLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取压缩包大小
        /// </summary>
        /// <value></value>
        public int ZipLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取已重试下载次数
        /// </summary>
        /// <value></value>
        public int RetryCount
        {
            get;
            private set;
        }
    }
}