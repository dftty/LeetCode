namespace GameFramework.Resources
{
    /// <summary>
    /// 资源更新改变事件
    /// </summary>
    public sealed class ResourceUpdateChangeEventArgs : GameFrameworkEventArgs
    {

        /// <summary>
        /// 初始化资源更新改变事件的新实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="downloadPath"></param>
        /// <param name="downloadUri"></param>
        /// <param name="currentLength"></param>
        /// <param name="zipLength"></param>
        public ResourceUpdateChangeEventArgs(string name, string downloadPath, string downloadUri, int currentLength, int zipLength)
        {
            Name = name;
            DownloadPath = downloadPath;
            DownloadUri = downloadUri;
            CurrentLength = currentLength;
            ZipLength = zipLength;
        }

        /// <summary>
        /// 资源名称
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
        public string DownloadUri
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
    }
}