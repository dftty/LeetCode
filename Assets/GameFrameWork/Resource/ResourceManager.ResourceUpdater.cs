using GameFramework.Download;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager 
    {
        private sealed partial class ResourceUpdater
        {
            private readonly ResourceManager m_ResourceManager;
            private readonly List<UpdateInfo> m_UpdateWaitingInfo;
            private readonly List<UpdateInfo> m_UpdateFailureInfo;
            private IDownloadManager m_DownloadManager;
            private bool m_CheckResourcesComplete;
            private bool m_UpdateAllowed;
            private int m_GenerateReadWriteListLength;
            private int m_CurrentGenerateReadWriteListLength;
            private int m_RetryCount;
            private int m_UpdatingCount;

            public GameFrameworkAction<ResourceName, string, string, int, int, int > ResourceUpdateStart;
            public GameFrameworkAction<ResourceName, string, string, int, int> ResourceUpdateChanged;
            public GameFrameworkAction<ResourceName, string, string, int, int> ResourceUpdateSuccess;
            public GameFrameworkAction<ResourceName, string, int, int , string> ResourceUpdateFailure;
            public GameFrameworkAction<bool> ResourceUpdateAllComplete;

            /// <summary>
            /// 初始化资源更新器的新实例
            /// </summary>
            /// <param name="resourceManager"></param>
            public ResourceUpdater(ResourceManager resourceManager)
            {
                m_ResourceManager = resourceManager;
                m_UpdateWaitingInfo = new List<UpdateInfo>();
                m_UpdateFailureInfo = new List<UpdateInfo>();
                m_DownloadManager = null;
                m_CheckResourcesComplete = false;
                m_UpdateAllowed = false;
                m_GenerateReadWriteListLength = 0;
                m_CurrentGenerateReadWriteListLength = 0;
                m_RetryCount = 3;
                m_UpdatingCount = 0;

                ResourceUpdateStart = null;
                ResourceUpdateChanged = null;
                ResourceUpdateSuccess = null;
                ResourceUpdateFailure = null;
                ResourceUpdateAllComplete = null;
            }

            /// <summary>
            /// 获取或设置每下载多少字节的资源刷新一次资源列表
            /// </summary>
            /// <value></value>
            public int GenerateReadWriteListLength
            {
                get
                {
                    return m_GenerateReadWriteListLength;
                }
                set
                {
                    m_GenerateReadWriteListLength = value;
                }
            }

            /// <summary>
            /// 获取或设置资源更新重试次数
            /// </summary>
            /// <value></value>
            public int RetryCount
            {
                get
                {
                    return m_RetryCount;
                }
                set
                {
                    m_RetryCount = value;
                }
            }

            /// <summary>
            /// 获取等待更新资源数量
            /// </summary>
            /// <value></value>
            public int UpdateWaitingCount
            {
                get
                {
                    return m_UpdateWaitingInfo.Count;
                }
            }

            /// <summary>
            /// 获取更新失败资源数量
            /// </summary>
            /// <value></value>
            public int UpdateFailureCount
            {
                get
                {
                    return m_UpdateFailureInfo.Count;
                }
            }

            /// <summary>
            /// 获取正在更新资源数量
            /// </summary>
            /// <value></value>
            public int UpdatingCount
            {
                get
                {
                    return m_UpdatingCount;
                }
            }

            public void Update(float elapseSeconds, float readElapseSeconds)
            {
                if(m_UpdateAllowed)
                {
                    if(m_UpdateWaitingInfo.Count > 0)
                    {
                        if(m_DownloadManager.FreeAgentCount > 0)
                        {
                            UpdateInfo updateInfo = m_UpdateWaitingInfo[0];
                            m_UpdateWaitingInfo.RemoveAt(0);
                            m_DownloadManager.AddDownload(updateInfo.ResourcePath, Utility.Path.GetRemotePath(m_ResourceManager.m_UpdatePrefixUri, Utility.Path.GetResourceNameWithCrc32AndSuffix(updateInfo.ResourceName.FullName, updateInfo.HashCode)), updateInfo);
                            m_UpdatingCount++;
                        }
                    }else if(m_UpdatingCount <= 0)
                    {
                        m_UpdateAllowed = false;
                        Utility.Path.RemoveEmptyDirectory(m_ResourceManager.m_ReadWritePath);
                        if(ResourceUpdateAllComplete != null)
                        {
                            ResourceUpdateAllComplete(UpdateFailureCount <= 0);
                        }
                    }
                }
            }

            public void Shutdown()
            {
                if(m_DownloadManager != null)
                {
                    //m_DownloadManager
                }
            }
        }
    }
}