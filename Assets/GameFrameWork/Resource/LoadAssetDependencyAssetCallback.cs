namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源时加载依赖资源回调函数
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="dependencyAssetName"></param>
    /// <param name="loadedCount"></param>
    /// <param name="totalCount"></param>
    /// <param name="userData"></param>
    public delegate void LoadAssetDependencyAssetCallback(string assetName, string dependencyAssetName, int loadedCount, int totalCount, object userData);
}