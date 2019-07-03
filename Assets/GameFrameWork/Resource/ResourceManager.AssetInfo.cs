namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        /// <summary>
        /// 资源信息
        /// </summary>
        private struct AssetInfo
        {
            private readonly string m_AssetName;
            private readonly ResourceName m_ResourceName;
            private readonly string[] m_DependencyAssetNames;

            /// <summary>
            /// 初始化资源信息的新实例
            /// </summary>
            /// <param name="assetName"></param>
            /// <param name="resourceName"></param>
            /// <param name="dependencyAssetNames"></param>
            public AssetInfo(string assetName, ResourceName resourceName, string[] dependencyAssetNames)
            {
                m_AssetName = assetName;
                m_ResourceName = resourceName;
                m_DependencyAssetNames = dependencyAssetNames;
            }

            /// <summary>
            /// 获取资源名称
            /// </summary>
            /// <value></value>
            public string AssetName
            {
                get
                {
                    return m_AssetName;
                }
            }

            /// <summary>
            /// 获取所在资源名称
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
            /// 获取依赖资源名称
            /// </summary>
            /// <returns></returns>
            public string[] GetDependencyAssetNames()
            {
                return m_DependencyAssetNames;
            }
        }
    }
}