namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源失败回调函数
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="status"></param>
    /// <param name="errorMessage"></param>
    /// <param name="userData"></param>
    public delegate void LoadAssetFailureCallback(string assetName, LoadResourcesStatus status, string errorMessage, object userData);
}