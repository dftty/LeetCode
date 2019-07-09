using System;
using System.Collections.Generic;

namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        private sealed partial class ResourceLoader
        {
            private sealed partial class LoadResourceAgent// : ITaskAgent<LoadResourceTaskBase>
            {
                private static readonly HashSet<string> s_LoadingAssetNames = new HashSet<string>();
                private static readonly HashSet<string> s_LoadingResourceNames = new HashSet<string>();

                private readonly ILoadResourceAgentHelper m_Helper;
                private readonly IResourceHelper m_ResourceHelper;
                private readonly ResourceLoader m_ResourceLoader;
                private readonly string m_ReadOnlyPath;
                private readonly string m_ReadWritePath;
                private readonly DecryptResourceCallback m_DecryptResourceCallback;
                private LoadResourceTaskBase m_Task;

                /// <summary>
                /// 初始化加载资源代理的新实例。
                /// </summary>
                /// <param name="loadResourceAgentHelper">加载资源代理辅助器。</param>
                /// <param name="resourceHelper">资源辅助器。</param>
                /// <param name="resourceLoader">加载资源器。</param>
                /// <param name="readOnlyPath">资源只读区路径。</param>
                /// <param name="readWritePath">资源读写区路径。</param>
                /// <param name="decryptResourceCallback">解密资源回调函数。</param>
                public LoadResourceAgent(ILoadResourceAgentHelper loadResourceAgentHelper, IResourceHelper resourceHelper, ResourceLoader resourceLoader, string readOnlyPath, string readWritePath, DecryptResourceCallback decryptResourceCallback)
                {
                    if (loadResourceAgentHelper == null)
                    {
                        throw new GameFrameworkException("Load resource agent helper is invalid.");
                    }

                    if (resourceHelper == null)
                    {
                        throw new GameFrameworkException("Resource helper is invalid.");
                    }

                    if (resourceLoader == null)
                    {
                        throw new GameFrameworkException("Resource loader is invalid.");
                    }

                    if (decryptResourceCallback == null)
                    {
                        throw new GameFrameworkException("Decrypt resource callback is invalid.");
                    }

                    m_Helper = loadResourceAgentHelper;
                    m_ResourceHelper = resourceHelper;
                    m_ResourceLoader = resourceLoader;
                    m_ReadOnlyPath = readOnlyPath;
                    m_ReadWritePath = readWritePath;
                    m_DecryptResourceCallback = decryptResourceCallback;
                    m_Task = null;
                }

                public ILoadResourceAgentHelper Helper
                {
                    get
                    {
                        return m_Helper;
                    }
                }

                /// <summary>
                /// 获取加载资源任务
                /// </summary>
                /// <value></value>
                public LoadResourceTaskBase Task
                {
                    get
                    {
                        return m_Task;
                    }
                }

                private void OnError(LoadResourcesStatus status, string errorMessage)
                {
                    m_Helper.Reset();
                    m_Task.OnLoadAssetFailure(this, status, errorMessage);
                    s_LoadingAssetNames.Remove(m_Task.AssetName);
                    s_LoadingResourceNames.Remove(m_Task.ResourceInfo.ResourceName.Name);
                    m_Task.Done = true;
                }

                private void OnLoadResourceAgentHelperLoadComplete(object sender, LoadResourceAgentHelperLoadCompleteEventArgs e)
                {
                    AssetObject assetObject = null;
                }

                private void OnLoadResourceAgentHelperError(object sender, LoadResourceAgentHelperErrorEventArgs e)
                {
                    OnError(e.Status, e.errorMessage);
                }
            }
        }
    }
}