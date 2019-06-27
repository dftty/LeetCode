namespace GameFramework
{
    internal interface ITaskAgent<T> where T : ITask
    {
        /// <summary>
        /// 获取任务
        /// </summary>
        /// <value></value>
        T Task
        {
            get;
        }

        /// <summary>
        /// 初始化任务代理
        /// </summary>
        void Initialize();

        /// <summary>
        /// 任务代理轮询
        /// </summary>
        /// <param name="elapseSeconds"></param>
        /// <param name="readElapseSeconds"></param>
        void Update(float elapseSeconds, float readElapseSeconds);
    
        /// <summary>
        /// 关闭并清理任务代理
        /// </summary>
        void Shutdown();

        /// <summary>
        /// 开始处理任务
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        StartTaskStatus Start(T task);

        /// <summary>
        /// 停止正在处理的任务并重置任务代理
        /// </summary>
        void Reset();
    }
}