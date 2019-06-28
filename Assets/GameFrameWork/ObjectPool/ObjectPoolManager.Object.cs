using System;

namespace GameFramework.ObjectPool
{
    internal sealed partial class ObjectPoolManager
    {
        /// <summary>
        /// 内部对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private sealed class Object<T> where T : ObjectBase
        {
            private readonly T m_Object;
            private int m_SpawnCount;

            public Object(T obj, bool spawned)
            {
                if(obj == null)
                {
                    throw new GameFrameworkException("Object is invalic.");
                }

                m_Object = obj;
                m_SpawnCount = spawned ? 1 : 0;
                if(spawned)
                {
                    m_Object.OnSpawn();
                }
            }

            /// <summary>
            /// 获取对象名称
            /// </summary>
            /// <value></value>
            public string Name
            {
                get
                {
                    return m_Object.Name;
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
                    return m_Object.Locked;
                }
                set
                {
                    m_Object.Locked = value;
                }
            }

            /// <summary>
            /// 获取对象优先级
            /// </summary>
            /// <value></value>
            public int Priority
            {
                get
                {
                    return m_Object.Priority;
                }
                internal set
                {
                    m_Object.Priority = value;
                }
            }

            /// <summary>
            /// 获取自定义释放检查标记
            /// </summary>
            /// <value></value>
            public bool CustomCanReleaseFlag
            {
                get
                {
                    return m_Object.CustomCanReleaseFlag;
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
                    return m_Object.LastUesTime;
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

            /// <summary>
            /// 查看对象
            /// </summary>
            /// <returns></returns>
            public T Peek()
            {
                return m_Object;
            }

            /// <summary>
            /// 获取对象
            /// </summary>
            /// <returns></returns>
            public T Spawn()
            {
                m_SpawnCount++;
                m_Object.LastUesTime = DateTime.Now;
                m_Object.OnSpawn();
                return m_Object;
            }

            /// <summary>
            /// 回收对象
            /// </summary>
            public void Unspawn()
            {
                m_Object.OnUnspawn();
                m_Object.LastUesTime = DateTime.Now;
                m_SpawnCount--;
                if(m_SpawnCount < 0)
                {
                    throw new GameFrameworkException("Spawn count is less than 0.");
                }
            }

            /// <summary>
            /// 释放对象
            /// </summary>
            /// <param name="isShutdown"></param>
            public void Release(bool isShutdown)
            {
                m_Object.Release(isShutdown);
            }
        }
    }
}