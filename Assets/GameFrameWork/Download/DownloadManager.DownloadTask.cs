namespace GameFramework.Download
{
    internal sealed partial class DownloadManager : GameFrameWorkModule, IDownloadManager
    {
        private sealed class DownloadTask : ITask
        {
            private static int s_Serial = 0;

            private readonly int m_SerialId;
            private readonly int m_Priority;
            private bool m_Down;
            private DownloadTaskStatus m_Status;
            private readonly string m_DownloadPath;
            private readonly string m_DownloadUri;
            private readonly int m_FlushSize;
            private readonly float m_Timeout;
            private readonly object m_UserData;

            /// <summary>
            /// 初始化下载任务的新实例
            /// </summary>
            /// <param name="downloadPath"></param>
            /// <param name="downloadUri"></param>
            /// <param name="priority"></param>
            /// <param name="flushSize"></param>
            /// <param name="timeout"></param>
            /// <param name="userData"></param>
            public DownloadTask(string downloadPath, string downloadUri, int priority, int flushSize, float timeout, object userData)
            {
                m_SerialId = s_Serial++;
                m_Priority = priority;
                m_Down = false;
                m_Status = DownloadTaskStatus.Todo;
                m_DownloadPath = downloadPath;
                m_DownloadUri = downloadUri;
                m_FlushSize = flushSize;
                m_Timeout = timeout;
                m_UserData = userData;
            }

            /// <summary>
            /// 获取下载任务的序列编号
            /// </summary>
            /// <value></value>
            public int SerialId
            {
                get
                {
                    return m_SerialId;
                }
            }

            /// <summary>
            /// 获取下载任务的优先级
            /// </summary>
            /// <value></value>
            public int Priority
            {
                get
                {
                    return m_Priority;
                }
            }

            /// <summary>
            /// 获取或设置任务是否完成
            /// </summary>
            /// <value></value>
            public bool Done
            {
                get
                {
                    return m_Down;
                }
                set
                {
                    m_Down = value;
                }
            }

            /// <summary>
            /// 获取或设置下载任务的状态
            /// </summary>
            /// <value></value>
            public DownloadTaskStatus Status
            {
                get
                {
                    return m_Status;
                }
                set
                {
                    m_Status = value;
                }
            }

            /// <summary>
            /// 获取下载后存放路径
            /// </summary>
            /// <value></value>
            public string DownloadPath
            {
                get
                {
                    return m_DownloadPath;
                }
            }

            /// <summary>
            /// 获取原始下载地址
            /// </summary>
            /// <value></value>
            public string DownloadUri
            {
                get
                {
                    return m_DownloadUri;
                }
            }

            /// <summary>
            /// 获取将缓冲区写入磁盘的临界大小
            /// </summary>
            /// <value></value>
            public int FlushSize
            {
                get
                {
                    return m_FlushSize;
                }
            }

            /// <summary>
            /// 获取下载超时时长，以秒为单位
            /// </summary>
            /// <value></value>
            public float Timeout
            {
                get
                {
                    return m_Timeout;
                }
            }

            /// <summary>
            /// 获取用户自定义数据
            /// </summary>
            /// <value></value>
            public object UserData
            {
                get
                {
                    return m_UserData;
                }
            }
        }

    }
}