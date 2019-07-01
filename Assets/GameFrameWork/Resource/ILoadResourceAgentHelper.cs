using System;

namespace GameFramework.Resources
{
    /// <summary>
    /// 资源代理辅助器接口
    /// </summary>
    public interface ILoadResourceAgentHelper
    {
        /// <summary>
        /// 加载资源代理辅助器异步加载资源更新事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperUpdateEventArgs> LoadResourceAgentHelperUpdate;

        /// <summary>
        /// 加载资源代理辅助器异步读取资源文件完成事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperReadFileCompleteEventArgs> LoadResourceAgentHelperReadFileComplete;

        /// <summary>
        /// 加载资源代理辅助器异步读取资源二进制流完成事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperReadBytesCompleteEventArgs> LoadResourceAgentHelperReadBytesComplete;

        /// <summary>
        /// 加载资源代理辅助器异步加载资源完成事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperLoadCompleteEventArgs> LoadResourceAgentHelperLoadComplete;

        /// <summary>
        /// 加载资源代理辅助器错误事件
        /// </summary>
        event EventHandler<LoadResourceAgentHelperErrorEventArgs> LoadResourceAgentHelperError;

        /// <summary>
        /// 通过加载资源代理辅助器开始异步读取资源文件
        /// </summary>
        /// <param name="fullPath"></param>
        void ReadFile(string fullPath);

        /// <summary>
        /// 通过加载资源代理辅助区开始异步读取资源二进制流
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="loadType"></param>
        void ReadBytes(string fullPath, int loadType);

        /// <summary>
        /// 通过加载资源代理辅助器开始异步将资源二进制流转换为加载对象
        /// </summary>
        /// <param name="bytes"></param>
        void ParseBytes(byte[] bytes);

        /// <summary>
        /// 通过加载资源代理辅助器开始异步加载资源
        /// </summary>
        /// <param name="resources"></param>
        /// <param name="assetName"></param>
        /// <param name="assetType"></param>
        /// <param name="isScene"></param>
        void LoadAsset(object resources, string assetName, Type assetType, bool isScene);

        /// <summary>
        /// 重置加载资源代理辅助器
        /// </summary>
        void Reset();

    }
}