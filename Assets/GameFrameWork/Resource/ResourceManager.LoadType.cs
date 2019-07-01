namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        /// <summary>
        /// 资源加载方式类型
        /// </summary>
        private enum LoadType
        {
            // 从文件加载
            LoadFromFile = 0,
            // 从内存加载
            LoadFromMemory,
            // 从内存快速解密加载
            LoadFromMemoryAndQuickDecrype,
            // 从内存解密加载
            LoadFromMemoryAndDecript,
        }
    }
}