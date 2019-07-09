namespace GameFramework.Download
{
    internal sealed partial class DownloadManager : GameFrameWorkModule, IDownloadManager
    {
        private sealed partial class DownloadCounter
        {
            private sealed class DownloadCounterNode : IReference
            {
                private int m_DownloadedLength;
                private float m_ElapseSeconds;

                public DownloadCounterNode()
                {
                    m_DownloadedLength = 0;
                    m_ElapseSeconds = 0;
                }

                public int DownloadedLength
                {
                    get
                    {
                        return m_DownloadedLength;
                    }
                    set
                    {
                        m_DownloadedLength = value;
                    }
                }

                public float ElapseSeconds
                {
                    get
                    {
                        return m_ElapseSeconds;
                    }
                }

                public void Update(float elapseSeconds, float realElapseSeconds)
                {
                    m_ElapseSeconds += elapseSeconds;
                }

                public void Clear()
                {
                    m_DownloadedLength = 0;
                    m_ElapseSeconds = 0;
                }
            }
        }
    }
}