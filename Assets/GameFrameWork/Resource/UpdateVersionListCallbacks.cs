namespace GameFramework.Resources
{
    public sealed class UpdateVersionListCallbacks
    {
        private readonly UpdateVersionListSuccessCallback m_UpdateVersionListSuccessCallback;
        private readonly UpdateVersionListFailureCallback m_UpdateVersionListFailureCallback;

        public UpdateVersionListCallbacks(UpdateVersionListSuccessCallback updateVersionListSuccessCallback)
        : this(updateVersionListSuccessCallback, null)
        {

        }

        public UpdateVersionListCallbacks(UpdateVersionListSuccessCallback updateVersionListSuccessCallback, UpdateVersionListFailureCallback updateVersionListFailureCallback)
        {
            if(updateVersionListSuccessCallback == null)
            {
                throw new GameFrameworkException("Update version list succes callback is invalid.");
            }

            m_UpdateVersionListSuccessCallback = updateVersionListSuccessCallback;
            m_UpdateVersionListFailureCallback = updateVersionListFailureCallback;
        }

        /// <summary>
        /// 获取版本资源列表更新成功回调函数
        /// </summary>
        /// <value></value>
        public UpdateVersionListSuccessCallback UpdateVersionListSuccessCallbacks
        {
            get
            {
                return m_UpdateVersionListSuccessCallback;
            }
        }

        public UpdateVersionListFailureCallback UpdateVersionListFailureCallback
        {
            get
            {
                return m_UpdateVersionListFailureCallback;
            }
        }

    }
}