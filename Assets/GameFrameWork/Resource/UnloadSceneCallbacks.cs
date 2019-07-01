namespace GameFramework.Resources
{
    public sealed class UnloadSceneCallbacks
    {
        private readonly UnloadSceneSuccessCallback m_UnloadSceneSuccessCallback;

        private readonly UnloadSceneFailureCallback m_UnloadSceneFailureCallback;

        public UnloadSceneCallbacks(UnloadSceneSuccessCallback unloadSceneSuccessCallback) 
            : this(unloadSceneSuccessCallback, null)
        {

        }

        /// <summary>
        /// 初始化卸载场景回调函数集的新实例
        /// </summary>
        /// <param name="unloadSceneSuccessCallback"></param>
        /// <param name="unloadSceneFailureCallback"></param>
        public UnloadSceneCallbacks(UnloadSceneSuccessCallback unloadSceneSuccessCallback, UnloadSceneFailureCallback unloadSceneFailureCallback)
        {
            if(unloadSceneSuccessCallback == null)
            {
                throw new GameFrameworkException("Unload scene success callback is invalid.");
            }

            m_UnloadSceneFailureCallback = unloadSceneFailureCallback;
            m_UnloadSceneSuccessCallback = unloadSceneSuccessCallback;
        }

        /// <summary>
        /// 获取卸载场景成功回调函数
        /// </summary>
        /// <value></value>
        public UnloadSceneSuccessCallback UnloadSceneSuccessCallback
        {
            get
            {
                return m_UnloadSceneSuccessCallback;
            }
        }

        /// <summary>
        /// 获取卸载场景失败回调函数
        /// </summary>
        /// <value></value>
        public UnloadSceneFailureCallback UnloadSceneFailureCallback
        {
            get
            {
                return m_UnloadSceneFailureCallback;
            }
        }
    }
}