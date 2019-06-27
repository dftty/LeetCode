namespace GameFramework
{
    /// <summary>
    /// 开始处理任务的状态
    /// </summary>
    public enum StartTaskStatus
    {
        ///可以立刻处理完成此任务
        Done,
        // 可以继续处理此任务
        CanResume,
        // 不能继续处理此任务，需要等待其他任务执行完成
        HasToWait,
        // 不能继续处理此任务， 出现未知错误
        UnknownError,
    }
}