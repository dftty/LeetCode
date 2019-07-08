using System;

namespace GameFramework.Download
{
    /// <summary>
    /// 下载管理接口
    /// </summary>
    public interface IDownloadManager
    {
        /// <summary>
        /// 获取下载代理总数量
        /// </summary>
        /// <value></value>
        int TotalAgentCount
        {
            get;
        }

        /// <summary>
        /// 获取可用下载代理数量。
        /// </summary>
        int FreeAgentCount
        {
            get;
        }

        /// <summary>
        /// 获取工作中下载代理数量
        /// </summary>
        /// <value></value>
        int WorkingAgentCount
        {
            get;
        }

        /// <summary>
        /// 获取等待下载任务数量
        /// </summary>
        /// <value></value>
        int WaitingTaskCount
        {
            get;
        }

        /// <summary>
        /// 获取或设置将缓冲区写入磁盘的临界大小
        /// </summary>
        /// <value></value>
        int FlushSize
        {
            get;
        }

        /// <summary>
        /// 获取或设置下载超时时长，以秒为单位
        /// </summary>
        /// <value></value>
        float Timeout
        {
            get;
            set;
        }

        /// <summary>
        /// 获取当前下载速度
        /// </summary>
        /// <value></value>
        float CurrentSpeed
        {
            get;
        }

        /// <summary>
        /// 下载开始事件
        /// </summary>
        event EventHandler<DownloadStartEventArgs> DownloadStart;

        /// <summary>
        /// 下载更新事件
        /// </summary>
        event EventHandler<DownloadUpdateEventArgs> DownloadUpdate;

        /// <summary>
        /// 下载成功事件
        /// </summary>
        event EventHandler<DownloadSuccessEventArgs> DownloadSuccess;

        /// <summary>
        /// 下载失败事件
        /// </summary>
        event EventHandler<DownloadFailureEventArgs> DownloadFailure;

        /// <summary>
        /// 增加下载代理辅助器
        /// </summary>
        /// <param name="downloadAgentHelper"></param>
        void AddDownloadAgentHelper(IDownloadAgentHelper downloadAgentHelper);

        /// <summary>
        /// 增加下载任务
        /// </summary>
        /// <param name="downloadPath"></param>
        /// <param name="downloadUri"></param>
        int AddDownload(string downloadPath, string downloadUri);

        /// <summary>
        /// 增加下载任务
        /// </summary>
        /// <param name="downloadPath"></param>
        /// <param name="downloadUri"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        int AddDownload(string downloadPath, string downloadUri, int priority);

        /// <summary>
        /// 增加下载任务。
        /// </summary>
        /// <param name="downloadPath">下载后存放路径。</param>
        /// <param name="downloadUri">原始下载地址。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>新增下载任务的序列编号。</returns>
        int AddDownload(string downloadPath, string downloadUri, object userData);

        /// <summary>
        /// 增加下载任务
        /// </summary>
        /// <param name="downloadPath"></param>
        /// <param name="downloadUri"></param>
        /// <param name="priority"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        int AddDownload(string downloadPath, string downloadUri, int priority, object userData);

        /// <summary>
        /// 移除下载任务
        /// </summary>
        /// <param name="serialId"></param>
        /// <returns></returns>
        bool RemoveDownload(int serialId);

        /// <summary>
        /// 移除所有下载任务
        /// </summary>
        void RemoveAllDownload();
    }
}