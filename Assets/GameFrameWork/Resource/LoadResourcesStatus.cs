namespace GameFramework.Resources
{
    /// <summary>
    /// 加载资源状态
    /// </summary>
    public enum LoadResourcesStatus
    {
        // 加载完成
        Ok = 0, 

        // 资源尚未准备完毕
        NotReady,

        // 资源不存在
        NotExist,

        // 依赖资源错误
        DependencyError,

        // 资源类型错误
        TypeError,

        // 加载资源错误
        AssetError,
    }
}