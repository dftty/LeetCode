namespace GameFramework.Download
{
    /// <summary>
    /// 下载代理辅助器完成事件
    /// </summary>
    public sealed class DownloadAgentHelperCompleteEventArgs : GameFrameworkEventArgs
    {
        public DownloadAgentHelperCompleteEventArgs(int length)
        {
            if(length <= 0)
            {
                throw new GameFrameworkException("Length is invalid.");
            }
            Length = length;
        }

        /// <summary>
        /// 获取下载的数据大小
        /// </summary>
        /// <value></value>
        public int Length
        {
            get;
            private set;
        }
    }
}