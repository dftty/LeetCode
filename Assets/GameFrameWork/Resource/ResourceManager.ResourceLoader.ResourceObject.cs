using GameFramework.ObjectPool;
using System.Collections.Generic;

namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        private sealed partial class ResourceLoader
        {
            private sealed class ResourceObject : ObjectBase
            {
                private readonly List<object> m_DependencyResources;
                private readonly IResourceHelper m_ResourceHelper;
                private readonly ResourceLoader m_ResourceLoader;

                public ResourceObject(string name, object target, IResourceHelper resourceHelper, ResourceLoader resourceLoader)
                : base(name, target)
                {
                    if (resourceHelper == null)
                    {
                        throw new GameFrameworkException("Resource helper is invalid.");
                    }

                    if (resourceLoader == null)
                    {
                        throw new GameFrameworkException("Resource loader is invalid.");
                    }

                    m_DependencyResources = new List<object>();
                    m_ResourceHelper = resourceHelper;
                    m_ResourceLoader = resourceLoader;
                }

                public override bool CustomCanReleaseFlag
                {
                    get
                    {
                        int targetReferenceCount = 0;
                        //m_ResourceLoader.
                        return base.CustomCanReleaseFlag && targetReferenceCount <= 0;
                    }
                }

                protected internal override void Release(bool isShutdown)
                {
                    
                }
            }
        }
    }
}