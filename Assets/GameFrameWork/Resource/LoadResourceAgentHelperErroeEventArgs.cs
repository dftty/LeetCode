namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源代理辅助器错误事件
    /// </summary>
    public sealed class LoadResourceAgentHelperErrorEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化加载资源代理辅助器错误事件的新实例
        /// </summary>
        /// <param name="status"></param>
        /// <param name="errorMessage"></param>
        public LoadResourceAgentHelperErrorEventArgs(LoadResourcesStatus status, string errorMessage)
        {
            Status = status;
        }

        /// <summary>
        /// 获取加载资源状态
        /// </summary>
        /// <value></value>
        public LoadResourcesStatus Status
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <value></value>
        public string errorMessage
        {
            get;
            private set;
        }
    }
}