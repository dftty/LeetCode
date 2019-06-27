namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源进度类型
    /// </summary>
    public enum LoadResourceProgress
    {
        // 读取资源包
        ReadResource,

        // 加载资源包
        LoadResource,

        // 加载资源
        LoadAsset,

        // 加载场景
        LoadScene,
    }
}