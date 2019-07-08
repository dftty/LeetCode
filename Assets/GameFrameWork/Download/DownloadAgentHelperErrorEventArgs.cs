namespace GameFramework.Download
{
    /// <summary>
    /// 下载代理辅助器错误事件
    /// </summary>
    public sealed class DownloadAgentHelperErroeEventArgs : GameFrameworkEventArgs
    {
        public DownloadAgentHelperErroeEventArgs(string erroeMessage)
        {
            ErrorMessage = erroeMessage;
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
    }
}