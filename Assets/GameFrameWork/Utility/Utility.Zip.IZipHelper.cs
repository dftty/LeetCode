using System.IO;

namespace GameFramework
{
    public static partial class Utility
    {
        public static partial class Zip
        {
            /// <summary>
            /// 压缩解压缩辅助器接口
            /// </summary>
            public interface IZipHelper
            {
                /// <summary>
                /// 压缩数据
                /// </summary>
                /// <param name="bytes"></param>
                /// <param name="offset"></param>
                /// <param name="length"></param>
                /// <param name="compressedStream"></param>
                /// <returns></returns>
                bool Compress(byte[] bytes, int offset, int length, Stream compressedStream);

                /// <summary>
                /// 解压缩数据
                /// </summary>
                /// <param name="bytes"></param>
                /// <param name="offset"></param>
                /// <param name="length"></param>
                /// <param name="decompressedStream0"></param>
                /// <returns></returns>
                bool Decompress(byte[] bytes, int offset, int length, Stream decompressedStream0);
            }
        }
    }
}