using System;
using System.Runtime.Serialization;

namespace GameFramework
{
    /// <summary>
    /// 游戏框架异常类
    /// </summary>
    public class GameFrameworkException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GameFrameworkException() : base()
        {

        }

        public GameFrameworkException(string message) : base(message)
        {
            
        }

        public GameFrameworkException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public GameFrameworkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }


    }
}