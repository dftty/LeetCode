namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件
    /// </summary>
    public sealed class LoadResourceAgentHelperParseBytesCompleteEventArgs : GameFrameworkEventArgs
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="resource"></param>
        public LoadResourceAgentHelperParseBytesCompleteEventArgs(object resource)
        {
            Resource = resource;
        }

        /// <summary>
        /// 获取加载对象
        /// </summary>
        /// <value></value>
        public object Resource
        {
            get;
            private set;
        }
    }
}