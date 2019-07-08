namespace GameFramework.Download
{
    public sealed class DownloadAgenthelperUpdateLengthEventArgs : GameFrameworkEventArgs
    {
        public DownloadAgenthelperUpdateLengthEventArgs(int deltaLength)
        {
            if (deltaLength <= 0)
            {
                throw new GameFrameworkException("Delta length is invalid.");
            }

            DeltaLength = deltaLength;
            
        }

        /// <summary>
        /// 获取下载的增量数据大小
        /// </summary>
        /// <value></value>
        public int DeltaLength
        {
            get;
            private set;
        }
    }
}