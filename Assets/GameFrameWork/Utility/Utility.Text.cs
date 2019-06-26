using System;
using System.Text;

namespace GameFramework
{
    public static partial class Utility
    {
        /// <summary>
        /// 字符相关实用函数
        /// </summary>
        public static class Text
        {
            [ThreadStatic]
            private static StringBuilder s_CachedStringBuilder = new StringBuilder(1024);

            /// <summary>
            /// 获取格式化字符串
            /// </summary>
            /// <param name="format"></param>
            /// <param name="arg0"></param>
            /// <returns></returns>
            public static string Format(string format, object arg0)
            {
                if(format == null)
                {
                    throw new GameFrameworkException("Format is invalid");
                }

                s_CachedStringBuilder.Length = 0;
                s_CachedStringBuilder.AppendFormat(format, arg0);
                return s_CachedStringBuilder.ToString();
            }

            /// <summary>
            /// 获取格式化字符串
            /// </summary>
            /// <param name="format"></param>
            /// <param name="arg0"></param>
            /// <param name="arg1"></param>
            /// <returns></returns>
            public static string Format(string format, object arg0, object arg1)
            {
                if(format == null)
                {
                    throw new GameFrameworkException("Format is invalid");
                }

                s_CachedStringBuilder.Length = 0;
                s_CachedStringBuilder.AppendFormat(format, arg0, arg1);
                return s_CachedStringBuilder.ToString();
            }

            /// <summary>
            /// 获取格式化字符串
            /// </summary>
            /// <param name="format"></param>
            /// <param name="arg0"></param>
            /// <param name="arg1"></param>
            /// <param name="arg2"></param>
            /// <returns></returns>
            public static string Format(string format, object arg0, object arg1, object arg2)
            {
                if(format == null)
                {
                    throw new GameFrameworkException("Format is invalid");
                }

                s_CachedStringBuilder.Length = 0;
                s_CachedStringBuilder.AppendFormat(format, arg0, arg1, arg2);
                return s_CachedStringBuilder.ToString();
            }

            /// <summary>
            /// 获取格式化字符串
            /// </summary>
            /// <param name="format"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            public static string Format(string format, params object[] args)
            {
                if(format == null)
                {
                    throw new GameFrameworkException("Format is invalid");
                }

                s_CachedStringBuilder.Length = 0;
                s_CachedStringBuilder.AppendFormat(format, args);
                return s_CachedStringBuilder.ToString();
            }

            /// <summary>
            /// 根据类型和名称过去完整名称
            /// </summary>
            /// <param name="name"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public static string GetFullName<T>(string name)
            {
                return GetFullName(typeof(T), name);
            }

            /// <summary>
            /// 根据类型和名称过去完整名称
            /// </summary>
            /// <param name="type"></param>
            /// <param name="name"></param>
            /// <returns></returns>
            public static string GetFullName(Type type, string name)
            {
                if(type == null)
                {
                    throw new GameFrameworkException("Type is invalid.");
                }

                string typeName = type.FullName;
                return string.IsNullOrEmpty(name) ? typeName : Format("{0}.{1}", typeName, name);
            }

        }
    }
}