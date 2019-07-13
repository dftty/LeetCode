namespace GameFramework.Download
{
    internal sealed partial class DownloadManager : GameFrameWorkModule, IDownloadManager
    {
        /// <summary>
        /// 下载任务的状态
        /// </summary>
        private enum DownloadTaskStatus
        {
            // 准备下载
            Todo,
            // 下载中
            Doing,
            // 下载完成
            Done,
            // 下载错误
            Error
        }
    }
}