namespace GameFramework.Resources
{
    /// <summary>
    /// 加载场景失败回调函数
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="stauts"></param>
    /// <param name="erroeMessage"></param>
    /// <param name="userData"></param>
    public delegate void LoadSceneFailureCallback(string sceneName, LoadResourcesStatus stauts, string erroeMessage, object userData);
}