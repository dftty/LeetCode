namespace GameFramework.Download
{
    /// <summary>
    /// 下载失败事件
    /// </summary>
    public sealed class DownloadFailureEventArgs : GameFrameworkEventArgs
    {

        /// <summary>
        /// 初始化下载失败事件的新实例
        /// </summary>
        /// <param name="serialId"></param>
        /// <param name="downloadPath"></param>
        /// <param name="downloadUri"></param>
        /// <param name="errorMessage"></param>
        /// <param name="userData"></param>
        public DownloadFailureEventArgs(int serialId, string downloadPath, string downloadUri, string errorMessage, object userData)
        {
            SerialId = serialId;
            DownloadPath = downloadPath;
            DownloadUri = downloadUri;
            ErrorMessage = errorMessage;
            UserData = userData;
        }

        /// <summary>
        /// 虎丘现在任务的序列编号
        /// </summary>
        /// <value></value>
        public int SerialId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载后存放路径
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
        /// 获取错误信息
        /// </summary>
        /// <value></value>
        public string ErrorMessage
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取用户自定义数据
        /// </summary>
        /// <value></value>
        public object UserData
        {
            get;
            private set;
        }
    }
}