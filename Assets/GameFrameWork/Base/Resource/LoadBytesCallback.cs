namespace GameFramework.Resources
{
    /// <summary>
    /// 读取数据流回调函数
    /// </summary>
    /// <param name="fileUrl"></param>
    /// <param name="bytes"></param>
    /// <param name="errorMessage"></param>
    public delegate void LoadBytesCallback(string fileUrl, byte[] bytes, string errorMessage);
}