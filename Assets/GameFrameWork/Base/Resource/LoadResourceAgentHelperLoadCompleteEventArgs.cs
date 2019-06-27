namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源代理辅助器异步加载资源完成事件
    /// </summary>
    public sealed class LoadResourceAgentHelperLoadCompleteEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="asset"></param>
        public LoadResourceAgentHelperLoadCompleteEventArgs(object asset)
        {
            Asset = asset;
        }

        /// <summary>
        /// 获取加载的资源
        /// </summary>
        /// <value></value>
        public object Asset
        {
            get;
            private set;
        }
    }

}