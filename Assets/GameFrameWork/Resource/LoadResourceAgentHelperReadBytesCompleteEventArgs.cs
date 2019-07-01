namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源代理辅助器异步读取资源二进制流完成事件
    /// </summary>
    public sealed class LoadResourceAgentHelperReadBytesCompleteEventArgs : GameFrameworkEventArgs
    {
        private readonly byte[] m_Bytes;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="loadType"></param>
        public LoadResourceAgentHelperReadBytesCompleteEventArgs(byte[] bytes, int loadType)
        {

        }

        /// <summary>
        /// 获取资源的加载方式
        /// </summary>
        /// <value></value>
        public int loadType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取资源的二进制流
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            return m_Bytes;
        }
    }
}