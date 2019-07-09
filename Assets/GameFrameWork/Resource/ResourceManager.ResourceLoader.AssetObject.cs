using GameFramework.ObjectPool;

namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        private sealed partial class ResourceLoader
        {
            private sealed class AssetObject : ObjectBase
            {
                private readonly object[] m_DependencyAssets;
                private readonly object m_Resource;
                private readonly IResourceHelper m_ResourceHelper;
                private readonly ResourceLoader m_ResourceLoader;

                public AssetObject(string name, object target, object[] dependencyAssets, object resource, IResourceHelper resourceHelper, ResourceLoader resourceLoader)
                    : base(name, target)
                {
                    if (dependencyAssets == null)
                    {
                        throw new GameFrameworkException("Dependency assets is invalid.");
                    }

                    if (resource == null)
                    {
                        throw new GameFrameworkException("Resource is invalid.");
                    }

                    if (resourceHelper == null)
                    {
                        throw new GameFrameworkException("Resource helper is invalid.");
                    }

                    if (resourceLoader == null)
                    {
                        throw new GameFrameworkException("Resource loader is invalid.");
                    }

                    m_DependencyAssets = dependencyAssets;
                    m_Resource = resource;
                    m_ResourceHelper = resourceHelper;
                    m_ResourceLoader = resourceLoader;

                    foreach(object dependencyAsset in m_DependencyAssets)
                    {
                        int referenceCount = 0;
                        if(m_ResourceLoader.m_AssetDependencyCount.TryGetValue(dependencyAsset, out referenceCount))
                        {
                            m_ResourceLoader.m_AssetDependencyCount[dependencyAsset] = referenceCount + 1;
                        }else{
                            m_ResourceLoader.m_AssetDependencyCount.Add(dependencyAsset, 1);
                        }
                    }
                }

                public override bool CustomCanReleaseFlag
                {
                    get
                    {
                        int targetReferenceCount = 0;
                        m_ResourceLoader.m_AssetDependencyCount.TryGetValue(Target, out targetReferenceCount);
                        return base.CustomCanReleaseFlag && targetReferenceCount <= 0;
                    }
                }

                protected internal override void OnUnspawn()
                {
                    base.OnUnspawn();
                    foreach(object dependencyAsset in m_DependencyAssets)
                    {
                        m_ResourceLoader.m_AssetPool.Unspawn(dependencyAsset);
                    }
                }

                protected internal override void Release(bool isShutdown)
                {
                    
                }

            }
        }
    }
}