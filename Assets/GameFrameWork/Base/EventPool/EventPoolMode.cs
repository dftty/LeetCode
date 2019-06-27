using System;

namespace GameFramework
{
    [Flags]
    internal enum EventPoolMode
    {
        // 默认事件池模式，即必须存在有且只有一个事件处理函数
        Default = 0,

        // 允许不存在事件处理函数
        AllowNoHandler = 1,

        // 允许存在多个事件处理函数
        AllowMultiHandler = 2,

        // 允许存在重复的事件处理函数
        AllowDuplicateHandler = 4,
    }
}