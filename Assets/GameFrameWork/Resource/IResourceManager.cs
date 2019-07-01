using System;
using GameFramework.ObjectPool;
using GameFramework.Download;

namespace GameFramework.Resources
{
    /// <summary>
    /// 资源管理器接口
    /// </summary>
    public interface IResourceManager
    {
        /// <summary>
        /// 获取资源只读区路径
        /// </summary>
        /// <value></value>
        string ReadOnlyPath
        {
            get;
        }

        /// <summary>
        /// 获取资源读写区路径
        /// </summary>
        /// <value></value>
        string ReadWritePath
        {
            get;
        }

        /// <summary>
        /// 获取资源模式
        /// </summary>
        /// <value></value>
        ResourceMode ResourceMode
        {
            get;
        }

        /// <summary>
        /// 获取当前变体
        /// </summary>
        /// <value></value>
        string CurrentVariant
        {
            get;
        }

        /// <summary>
        /// 获取当前资源适用的游戏版本号
        /// </summary>
        /// <value></value>
        string ApplicableGameVersion
        {
            get;
        }

        /// <summary>
        /// 获取当前内部资源版本号
        /// </summary>
        /// <value></value>
        int InternalResourceVersion
        {
            get;
        }

        /// <summary>
        /// 获取已准备完毕资源数量
        /// </summary>
        /// <value></value>
        int AssetCount
        {
            get;
        }

        /// <summary>
        /// 获取已准备完毕资源数量
        /// </summary>
        /// <value></value>
        int ResourceCount
        {
            get;
        }

        /// <summary>
        /// 获取或设置资源更新下载地址
        /// </summary>
        /// <value></value>
        string UpdatePrefixUri
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置更新文件缓存大小
        /// </summary>
        /// <value></value>
        int UpdateFileCacheLength
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置每下载多少字节的资源，刷新一次下载资源列表
        /// </summary>
        /// <value></value>
        int GenerateReadWriteListLength
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置资源更新重试次数
        /// </summary>
        /// <value></value>
        int UpdateRetryCount
        {
            get;
            set;
        }

        /// <summary>
        /// 获取等待更新资源数量
        /// </summary>
        /// <value></value>
        int UpdateWaitingCount
        {
            get;
        }

        /// <summary>
        /// 获取更新失败资源数量
        /// </summary>
        /// <value></value>
        int UpdateFailureCount
        {
            get;
        }

        /// <summary>
        /// 获取正在更新资源数量
        /// </summary>
        /// <value></value>
        int UpdateingCount
        {
            get;
        }

        /// <summary>
        /// 获取加载资源代理总数量
        /// </summary>
        /// <value></value>
        int LoadTotalAgentCount
        {
            get;
        }

        /// <summary>
        /// 获取可用加载资源代理数量
        /// </summary>
        /// <value></value>
        int LoadFreeAgentCount
        {
            get;
        }

        /// <summary>
        /// 获取工作中加载资源代理数量
        /// </summary>
        /// <value></value>
        int LoadWorkingAgentCount
        {
            get;
        }

        /// <summary>
        /// 获取等待加载资源任务数量
        /// </summary>
        /// <value></value>
        int LoadWaitingTaskCount
        {
            get;
        }

        /// <summary>
        /// 获取或设置资源对象池自动释放可释放对象的间隔秒数
        /// </summary>
        /// <value></value>
        float AssetAutoReleaseInterval
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置资源对象池的容量
        /// </summary>
        /// <value></value>
        int AssetCapacity
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置资源对象池对象过期秒数
        /// </summary>
        /// <value></value>
        float AssetExpireTime
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置资源对象池的优先级
        /// </summary>
        /// <value></value>
        int AssetPriority
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置资源对象池自动释放可释放对象的间隔秒数
        /// </summary>
        /// <value></value>
        float ResourceAutoReleaseInterval
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置资源对象池的容量
        /// </summary>
        /// <value></value>
        int ResourceCapacity
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置资源对象池对象过期秒数
        /// </summary>
        /// <value></value>
        float ResourceExpireTime
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置资源对象池的优先级
        /// </summary>
        /// <value></value>
        int ResourcePriority
        {
            get;
            set;
        }

        /// <summary>
        /// 资源更新开始事件
        /// </summary>
        event EventHandler<ResourceUpdateStartEventArgs> ResourceUpdateStart;

        /// <summary>
        /// 资源更新改变事件
        /// </summary>
        event EventHandler<ResourceUpdateChangeEventArgs> ResourceUpdateChange;

        /// <summary>
        /// 资源更新成功事件
        /// </summary>
        event EventHandler<ResourceUpdateSuccessEventArgs> ResourceUpdateSuccess;

        /// <summary>
        /// 资源更新失败事件
        /// </summary>
        event EventHandler<ResourceUpdateFailureEventArgs> ResourceUpdateFailure;
    
        /// <summary>
        /// 设置资源只读区路径
        /// </summary>
        /// <param name="readOnlyPath"></param>
        void SetReadOnlyPath(string readOnlyPath);

        /// <summary>
        /// 设置资源读写区路径
        /// </summary>
        /// <param name="readWritePath"></param>
        void SetReadWritePath(string readWritePath);

        /// <summary>
        /// 这是资源模式
        /// </summary>
        /// <param name="resourceMode"></param>
        void SetResourceMode(ResourceMode resourceMode);

        /// <summary>
        /// 设置当前变体
        /// </summary>
        /// <param name="currentVariant"></param>
        void SetCurrentVariant(string currentVariant);

        /// <summary>
        /// 设置对象池管理器
        /// </summary>
        /// <param name="objectPoolManager"></param>
        void SetObjectPoolManager(IObjectPoolManager objectPoolManager);

        /// <summary>
        /// 设置下载管理器
        /// </summary>
        /// <param name="downloadManager"></param>
        void SetDownloadManager(IDownloadManager downloadManager);

        /// <summary>
        /// 设置解密资源回调函数
        /// </summary>
        /// <param name="decryptResourceCallback"></param>
        void SetDecryptResourceCallback(DecryptResourceCallback decryptResourceCallback);

        /// <summary>
        /// 设置资源辅助器
        /// </summary>
        /// <param name="resourceHelper"></param>
        void SetResourceHelper(IResourceHelper resourceHelper);

        /// <summary>
        /// 增加加载资源代理辅助器
        /// </summary>
        /// <param name="loadResourceAgentHelper"></param>
        void AddLoadResourceAgentHelper(ILoadResourceAgentHelper loadResourceAgentHelper);

        /// <summary>
        /// 使用单机模式并初始化资源
        /// </summary>
        /// <param name="initResourcesCompleteCallback"></param>
        void InitResources(InitResourcesCompleteCallback initResourcesCompleteCallback);

        /// <summary>
        /// 使用可更新模式并检查版本资源列表
        /// </summary>
        /// <param name="latesInternalResourceVersion"></param>
        /// <returns></returns>
        CheckVersionListResult CheckVersionList(int latesInternalResourceVersion);

        /// <summary>
        /// 使用可更新模式并更新版本资源列表
        /// </summary>
        /// <param name="versionListLength"></param>
        /// <param name="versionListHashCode"></param>
        /// <param name="versionListZipLength"></param>
        /// <param name="versionListZipHashCode"></param>
        /// <param name="updateVersionListCallbacks"></param>
        void UpdateVersionList(int versionListLength, int versionListHashCode, int versionListZipLength, int versionListZipHashCode, UpdateVersionListCallbacks updateVersionListCallbacks);

        /// <summary>
        /// 使用可更新模式并检查资源
        /// </summary>
        /// <param name="checkResourcesCompleteCallback"></param>
        void CheckResources(CheckResourcesCompleteCallback checkResourcesCompleteCallback);

        /// <summary>
        /// 使用可更新模式并更新资源
        /// </summary>
        /// <param name="updateResourcesCompleteCallback"></param>
        void UpdateResources(UpdateResourcesCompleteCallback updateResourcesCompleteCallback);

        /// <summary>
        /// 检查资源是否存在
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        bool HasAsset(string assetName);

        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="loadAssetCallbacks"></param>
        void LoadAsset(string assetName, LoadAssetCallbacks loadAssetCallbacks);

        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="assetType"></param>
        /// <param name="loadAssetCallbacks"></param>
        void LoadAsset(string assetName, Type assetType, LoadAssetCallbacks loadAssetCallbacks);

        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="priority"></param>
        /// <param name="loadAssetCallbacks"></param>
        void LoadAsset(string assetName, int priority, LoadAssetCallbacks loadAssetCallbacks);

        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="loadAssetCallbacks">加载资源回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        void LoadAsset(string assetName, LoadAssetCallbacks loadAssetCallbacks, object userData);

        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="assetType">要加载资源的类型。</param>
        /// <param name="priority">加载资源的优先级。</param>
        /// <param name="loadAssetCallbacks">加载资源回调函数集。</param>
        void LoadAsset(string assetName, Type assetType, int priority, LoadAssetCallbacks loadAssetCallbacks);

        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="assetType">要加载资源的类型。</param>
        /// <param name="loadAssetCallbacks">加载资源回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        void LoadAsset(string assetName, Type assetType, LoadAssetCallbacks loadAssetCallbacks, object userData);

        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="priority">加载资源的优先级。</param>
        /// <param name="loadAssetCallbacks">加载资源回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        void LoadAsset(string assetName, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData);

        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="assetType">要加载资源的类型。</param>
        /// <param name="priority">加载资源的优先级。</param>
        /// <param name="loadAssetCallbacks">加载资源回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        void LoadAsset(string assetName, Type assetType, int priority, LoadAssetCallbacks loadAssetCallbacks, object userData);

        /// <summary>
        /// 卸载资源
        /// </summary>
        /// <param name="asset"></param>
        void UnloadAsset(object asset);

         /// <summary>
        /// 异步加载场景。
        /// </summary>
        /// <param name="sceneAssetName">要加载场景资源的名称。</param>
        /// <param name="loadSceneCallbacks">加载场景回调函数集。</param>
        void LoadScene(string sceneAssetName, LoadSceneCallbacks loadSceneCallbacks);

        /// <summary>
        /// 异步加载场景。
        /// </summary>
        /// <param name="sceneAssetName">要加载场景资源的名称。</param>
        /// <param name="priority">加载场景资源的优先级。</param>
        /// <param name="loadSceneCallbacks">加载场景回调函数集。</param>
        void LoadScene(string sceneAssetName, int priority, LoadSceneCallbacks loadSceneCallbacks);

        /// <summary>
        /// 异步加载场景。
        /// </summary>
        /// <param name="sceneAssetName">要加载场景资源的名称。</param>
        /// <param name="loadSceneCallbacks">加载场景回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        void LoadScene(string sceneAssetName, LoadSceneCallbacks loadSceneCallbacks, object userData);

        /// <summary>
        /// 异步加载场景。
        /// </summary>
        /// <param name="sceneAssetName">要加载场景资源的名称。</param>
        /// <param name="priority">加载场景资源的优先级。</param>
        /// <param name="loadSceneCallbacks">加载场景回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        void LoadScene(string sceneAssetName, int priority, LoadSceneCallbacks loadSceneCallbacks, object userData);

        /// <summary>
        /// 异步卸载场景。
        /// </summary>
        /// <param name="sceneAssetName">要卸载场景资源的名称。</param>
        /// <param name="unloadSceneCallbacks">卸载场景回调函数集。</param>
        void UnloadScene(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks);

        /// <summary>
        /// 异步卸载场景。
        /// </summary>
        /// <param name="sceneAssetName">要卸载场景资源的名称。</param>
        /// <param name="unloadSceneCallbacks">卸载场景回调函数集。</param>
        /// <param name="userData">用户自定义数据。</param>
        void UnloadScene(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks, object userData);
    }
}