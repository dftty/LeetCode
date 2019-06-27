namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源代理辅助器异步将资源文件转换为加载对象完成事件
    /// </summary>
    public sealed class LoadResourceAgentHelperReadFileCompleteEventArgs : GameFrameworkEventArgs
    {
        public LoadResourceAgentHelperReadFileCompleteEventArgs(object resource)
        {
            Resource = resource;
        }

        public object Resource
        {
            get;
            private set;
        }
    }
}