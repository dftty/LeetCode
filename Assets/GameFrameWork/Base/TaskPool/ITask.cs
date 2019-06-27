namespace GameFramework
{
    /// <summary>
    /// 任务接口
    /// </summary>
    internal interface ITask
    {
        /// <summary>
        /// 获取任务序列编号
        /// </summary>
        /// <value></value>
        int SerialId
        {
            get;
        }

        /// <summary>
        /// 获取任务的优先级
        /// </summary>
        /// <value></value>
        int Priority
        {
            get;
        }

        /// <summary>
        /// 获取任务是否完成
        /// </summary>
        /// <value></value>
        bool Done
        {
            get;
        }
    } 
}