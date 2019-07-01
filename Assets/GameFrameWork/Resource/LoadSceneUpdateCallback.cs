namespace GameFramework.Resources
{
    /// <summary>
    /// 加载场景更新回调函数
    /// </summary>
    /// <param name="sceneAssetName"></param>
    /// <param name="progress"></param>
    /// <param name="userData"></param>
    public delegate void LoadSceneUpdateCallback(string sceneAssetName, float progress, object userData);
}