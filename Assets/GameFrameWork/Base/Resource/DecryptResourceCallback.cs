namespace GameFramework.Resources
{
    /// <summary>
    /// 解密资源回调函数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="variant"></param>
    /// <param name="loadType"></param>
    /// <param name="length"></param>
    /// <param name="hashCode"></param>
    /// <param name="storageInReadOnly"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public delegate byte[] DecryptResourceCallback(string name, string variant, int loadType, int length, int hashCode, bool storageInReadOnly, byte[] bytes);
}