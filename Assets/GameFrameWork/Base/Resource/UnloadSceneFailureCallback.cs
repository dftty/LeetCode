namespace GameFramework.Resources
{
    /// <summary>
    /// 卸载场景失败回调函数
    /// </summary>
    /// <param name="sceneAssetName"></param>
    /// <param name="userData"></param>
    public delegate void UnloadSceneFailureCallback(string sceneAssetName, object userData);
}