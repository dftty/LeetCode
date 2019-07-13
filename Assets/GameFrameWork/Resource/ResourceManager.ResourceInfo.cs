namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        /// <summary>
        /// 资源信息
        /// </summary>
        private struct ResourceInfo
        {
            private readonly ResourceName m_ResourceName;
            private readonly LoadType m_LoadType;
            private readonly int m_Length;
            private readonly int m_HashCode;
            private readonly bool m_StorageInReadOnly;

            /// <summary>
            /// 初始化资源信息新实例
            /// </summary>
            /// <param name="resourceName"></param>
            /// <param name="loadType"></param>
            /// <param name="length"></param>
            /// <param name="hashCode"></param>
            /// <param name="storageInReadOnly"></param>
            public ResourceInfo(ResourceName resourceName, LoadType loadType, int length, int hashCode, bool storageInReadOnly)
            {   
                m_ResourceName = resourceName;
                m_LoadType = loadType;
                m_Length = length;
                m_HashCode = hashCode;
                m_StorageInReadOnly = storageInReadOnly;
            }

            /// <summary>
            /// 获取资源名称
            /// </summary>
            /// <value></value>
            public ResourceName ResourceName
            {
                get
                {
                    return m_ResourceName;
                }
            }

            /// <summary>
            /// 获取资源加载方式
            /// </summary>
            /// <value></value>
            public LoadType LoadType
            {
                get
                {
                    return m_LoadType;
                }
            }

            /// <summary>
            /// 获取资源大小
            /// </summary>
            /// <value></value>
            public int Length
            {
                get
                {
                    return m_Length;
                }
            }

            /// <summary>
            /// 获取资源哈希值
            /// </summary>
            /// <value></value>
            public int HashCode
            {
                get
                {
                    return m_HashCode;
                }
            }

            /// <summary>
            /// 获取资源是否在只读区
            /// </summary>
            /// <value></value>
            public bool storageInReadOnly
            {
                get
                {
                    return m_StorageInReadOnly;
                }
            }
        }
    }
}