using GameFramework.ObjectPool;
using System;
using System.Collections.Generic;

namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        private sealed partial class ResourceLoader
        {
            private readonly ResourceManager m_ResourceManager;
            private readonly TaskPool<LoadResourceTaskBase> m_TaskPool;
            private readonly Dictionary<object, int> m_AssetDependencyCount;
            private readonly Dictionary<object, int> m_ResourceDependencyCount;
            private readonly Dictionary<object, object> m_AssetToResourceMap;
            private readonly Dictionary<string, object> m_SceneToAssetMap;
            private IObjectPool<AssetObject> m_AssetPool;
            private IObjectPool<ResourceObject> m_ResourcePool;
        }
    }
}