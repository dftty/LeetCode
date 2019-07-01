namespace GameFramework.Resources
{
    /// <summary>
    /// 使用可更新模式并检查资源完成的回调函数
    /// </summary>
    /// <param name="needUpdateResources"></param>
    /// <param name="removedCount"></param>
    /// <param name="updateCount"></param>
    /// <param name="updateTotalLength"></param>
    /// <param name="updateToZipLength"></param>
    public delegate void CheckResourcesCompleteCallback(bool needUpdateResources, int removedCount, int updateCount, long updateTotalLength ,long updateToZipLength);
}