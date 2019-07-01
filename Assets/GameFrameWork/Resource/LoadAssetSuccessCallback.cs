namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源成功回调函数
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="asset"></param>
    /// <param name="duration"></param>
    /// <param name="userData"></param>
    public delegate void LoadAssetSuccessCallback(string assetName, object asset, float duration, object userData);
}