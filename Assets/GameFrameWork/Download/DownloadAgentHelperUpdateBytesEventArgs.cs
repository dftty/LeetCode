namespace GameFramework.Download
{
    /// <summary>
    /// 下载代理辅助器更新数据流事件
    /// </summary>
    public sealed class DownloadAgentHelperUpdateBytesEventArgs : GameFrameworkEventArgs
    {
        private readonly byte[] m_Bytes;

        public DownloadAgentHelperUpdateBytesEventArgs(byte[] bytes, int offset, int length)
        {
            if (bytes == null)
            {
                throw new GameFrameworkException("Bytes is invalid.");
            }

            if (offset < 0 || offset >= bytes.Length)
            {
                throw new GameFrameworkException("Offset is invalid.");
            }

            if (length <= 0 || offset + length > bytes.Length)
            {
                throw new GameFrameworkException("Length is invalid.");
            }

            m_Bytes = bytes;
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// 获取数据流的偏移
        /// </summary>
        /// <value></value>
        public int Offset
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据流的长度
        /// </summary>
        /// <value></value>
        public int Length
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载的数据流
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            return m_Bytes;
        }
    } 
}