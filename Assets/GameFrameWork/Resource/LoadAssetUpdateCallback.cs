namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源更新回调函数
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="progress"></param>
    /// <param name="userData"></param>
    public delegate void LoadAssetUpdateCallback(string assetName, float progress, object userData);
}