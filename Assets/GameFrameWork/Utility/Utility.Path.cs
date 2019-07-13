using System.IO;

namespace GameFramework
{
    public static partial class Utility
    {
        /// <summary>
        /// 路径相关的实用函数
        /// </summary>
        public static class Path
        {
            /// <summary>
            /// 获取规范路径
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public static string GetRegularPath(string path)
            {
                if(path == null)
                {
                    return null;
                }

                return path.Replace("\\", "/");
            }

            /// <summary>
            /// 获取连接后的路径
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public static string GetCombinePath(params string[] path)
            {
                if(path == null || path.Length < 1)
                {
                    return null;
                }

                string combinePath = path[0];
                for(int i = 1; i < path.Length; i++)
                {
                    combinePath = System.IO.Path.Combine(combinePath, path[i]);
                }

                return GetRegularPath(combinePath);
            }

            /// <summary>
            /// 获取远程格式的路径（带有file://或http://前缀）
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public static string GetRemotePath(params string[] path)
            {
                string combinePath = GetCombinePath(path);
                if(combinePath == null)
                {
                    return null;
                }

                return combinePath.Contains("://") ? combinePath : ("file:///" + combinePath).Replace("file:////", "file:///");
            }

            /// <summary>
            /// 获取带有后缀的资源名
            /// </summary>
            /// <param name="resourceName"></param>
            /// <returns></returns>
            public static string GetResourceNameWithSuffix(string resourceName)
            {
                if(string.IsNullOrEmpty(resourceName))
                {
                    throw new GameFrameworkException("Resource name is invalid.");
                }

                return Text.Format("{0}.dat", resourceName);
            }

            /// <summary>
            /// 获取带有CRC32 和后缀的资源名
            /// </summary>
            /// <param name="resourceName"></param>
            /// <param name="hashCode"></param>
            /// <returns></returns>
            public static string GetResourceNameWithCrc32AndSuffix(string resourceName, int hashCode)
            {
                if(string.IsNullOrEmpty(resourceName))
                {
                    throw new GameFrameworkException("Resource name is invalid.");
                }

                return Text.Format("{0}.{1:x8}.dat", resourceName, hashCode);
            }

            /// <summary>
            /// 移除空文件夹
            /// </summary>
            /// <param name="directoryName"></param>
            /// <returns></returns>
            public static bool RemoveEmptyDirectory(string directoryName)
            {
                if(string.IsNullOrEmpty(directoryName))
                {
                    throw new GameFrameworkException("Directory name is invalid.");
                }

                try
                {
                    if(!Directory.Exists(directoryName))
                    {
                        return false;
                    }

                    string[] subDirectoryNames = Directory.GetDirectories(directoryName, "*");
                    int subDirectoryCount = subDirectoryNames.Length;

                    foreach(string subDirectoryName in subDirectoryNames)
                    {
                        if(RemoveEmptyDirectory(subDirectoryName))
                        {
                            subDirectoryCount--;
                        }
                    }

                    if(subDirectoryCount > 0)
                    {
                        return false;
                    }

                    if(Directory.GetFiles(directoryName, "*").Length > 0)
                    {
                        return false;
                    }

                    Directory.Delete(directoryName);
                    return true;
                }catch
                {
                    return false;
                }
            }

        }
    }
}