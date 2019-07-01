namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源代理辅助器异步加载资源进度事件
    /// </summary>
    public sealed class LoadResourceAgentHelperUpdateEventArgs : GameFrameworkEventArgs
    {
        public LoadResourceAgentHelperUpdateEventArgs(LoadResourceProgress type, float progress)
        {
            Type = type;
            Progress = progress;
        }

        public LoadResourceProgress Type
        {
            get;
            private set;
        }

        public float Progress
        {
            get;
            private set;
        }
    }
}