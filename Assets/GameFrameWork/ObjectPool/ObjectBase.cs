using System;

namespace GameFramework.ObjectPool
{
    /// <summary>
    /// 对象基类
    /// </summary>
    public abstract class ObjectBase
    {
        private readonly string m_Name;
        private readonly object m_Target;
        private bool m_Locked;
        private int m_Priority;
        private DateTime m_LastUseTime;

        /// <summary>
        /// 初始化对象的新实例
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public ObjectBase(object target) : this(null, target, false, 0)
        {

        }

        /// <summary>
        /// 初始化对象的新实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public ObjectBase(string name, object target) : this(name, target, false, 0)
        {

        }

        /// <summary>
        /// 初始化对象的新实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        public ObjectBase(string name, object target, int priority) : this(name, target, false, priority)
        {

        }

        /// <summary>
        /// 初始化对象的新实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
        public ObjectBase(string name, object target, bool locked) : this(name, target, locked, 0)
        {

        }

        /// <summary>
        /// 初始化对象的新实例
        /// </summary>
        /// <param name="name"></param>
        /// <param name="target"></param>
        /// <param name="locked"></param>
        /// <param name="priority"></param>
        public ObjectBase(string name, object target, bool locked, int priority)
        {
            if(target == null)
            {
                throw new GameFrameworkException(Utility.Text.Format("Target '{0}' is invalid.", name));
            }

            m_Name = name ?? string.Empty;
            m_Target = target;
            m_Locked = locked;
            m_Priority = priority;
            m_LastUseTime = DateTime.Now;
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
        /// 获取对象
        /// </summary>
        /// <value></value>
        public object Target
        {
            get
            {
                return m_Target;
            }
        }

        /// <summary>
        /// 获取或设置对象是否被加锁
        /// </summary>
        /// <value></value>
        public bool Locked
        {
            get
            {
                return m_Locked;
            }
            set{
                m_Locked = value;
            }
        }

        /// <summary>
        /// 获取或设置对象的优先级
        /// </summary>
        /// <value></value>
        public int Priority
        {
            get
            {
                return m_Priority;
            }
            set
            {
                m_Priority = value;
            }
        }

        /// <summary>
        /// 获取自定义释放检查标记
        /// </summary>
        /// <value></value>
        public virtual bool CustomCanReleaseFlag
        {
            get 
            {
                return true;
            }
        }

        /// <summary>
        /// 获取对象上次使用时间
        /// </summary>
        /// <value></value>
        public DateTime LastUesTime
        {
            get
            {
                return m_LastUseTime;
            }
            set{
                m_LastUseTime = value;
            }
        }

        /// <summary>
        /// 获取对象时的事件
        /// </summary>
        protected internal virtual void OnSpawn()
        {

        }

        /// <summary>
        /// 回收对象时的事件
        /// </summary>
        protected internal virtual void OnUnspawn()
        {

        }

        /// <summary>
        /// 释放对象
        /// </summary>
        /// <param name="isShutdown"></param>
        protected internal abstract void Release(bool isShutdown);


    }
}