namespace GameFramework.Resources
{
    /// <summary>
    /// 加载场景时加载依赖资源回调函数
    /// </summary>
    /// <param name="sceneAssetName"></param>
    /// <param name="dependencyAssetName"></param>
    /// <param name="loadedCount"></param>
    /// <param name="totalCount"></param>
    /// <param name="userData"></param>
    public delegate void LoadSceneDependencyAssetCallback(string sceneAssetName, string dependencyAssetName, int loadedCount, int totalCount, object userData);
}