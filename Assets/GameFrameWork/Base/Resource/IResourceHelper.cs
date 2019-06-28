namespace GameFramework.Resources
{
    /// <summary>
    /// 资源辅助器接口
    /// </summary>
    public interface IResourceHelper
    {
        /// <summary>
        /// 直接从指定文件路径读取数据流
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="loadGBytesCallback"></param>
        void LoadBytees(string fileUri, LoadBytesCallback loadGBytesCallback);

        /// <summary>
        /// 卸载场景
        /// </summary>
        /// <param name="sceneAssetName"></param>
        /// <param name="unloadSceneCallbacks"></param>
        /// <param name="userData"></param>
        void UnloadScene(string sceneAssetName, UnloadSceneCallbacks unloadSceneCallbacks, object userData);

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="objectToRelease"></param>
        void Release(object objectToRelease);
    }
}