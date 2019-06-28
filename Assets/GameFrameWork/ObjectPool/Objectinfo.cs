using System;

namespace GameFramework.ObjectPool
{
    /// <summary>
    /// 对象信息
    /// </summary>
    public struct ObjectInfo
    {
        private readonly string m_Name;
        private readonly bool m_Locked;
        private readonly bool m_CustomCanReleaseFlag;
        private readonly int m_Priority;
        private readonly DateTime m_LastUseTime;
        private readonly int m_SpawnCount;

        /// <summary>
        /// 初始化对象信息的新实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="locked"></param>
        /// <param name="customCanReleaseFlag"></param>
        /// <param name="priority"></param>
        /// <param name="lastUseTime"></param>
        /// <param name="spawnCount"></param>
        public ObjectInfo(string name, bool locked, bool customCanReleaseFlag, int priority, DateTime lastUseTime, int spawnCount)
        {
            m_Name = name;
            m_Locked = locked;
            m_CustomCanReleaseFlag = customCanReleaseFlag;
            m_Priority = priority;
            m_LastUseTime = lastUseTime;
            m_SpawnCount = spawnCount;
        }

        /// <summary>
        /// 获取对象名称
        /// </summary>
        /// <value></value>
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        /// <summary>
        /// 获取对象是否被加锁
        /// </summary>
        /// <value></value>
        public bool Locked
        {
            get
            {
                return m_Locked;
            }
        }

        /// <summary>
        /// 获取对象自定义释放检查标记
        /// </summary>
        /// <value></value>
        public bool CustomCanReleaseFlag
        {
            get
            {
                return m_CustomCanReleaseFlag;
            }
        }

        /// <summary>
        /// 获取对象的优先级
        /// </summary>
        /// <value></value>
        public int Priority
        {
            get
            {
                return m_Priority;
            }
        }

        /// <summary>
        /// 获取对象上次使用时间
        /// </summary>
        /// <value></value>
        public DateTime LastUseTime
        {
            get
            {
                return m_LastUseTime;
            }
        }

        /// <summary>
        /// 获取对象是否正在使用 
        /// </summary>
        /// <value></value>
        public bool IsInUse
        {
            get
            {
                return m_SpawnCount > 0;
            }
        }

        /// <summary>
        /// 获取对象的获取计数
        /// </summary>
        /// <value></value>
        public int SpawnCount
        {
            get
            {
                return m_SpawnCount;
            }
        }
    }
}