using System;

namespace GameFramework.ObjectPool
{
    /// <summary>
    /// 对象池接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectPool<T> where T : ObjectBase
    {
        /// <summary>
        /// 获取对象池名称
        /// </summary>
        /// <value></value>
        string Name
        {
            get;
        }

        /// <summary>
        /// 获取对象池完整名称
        /// </summary>
        /// <value></value>
        string FullName
        {
            get;
        }

        /// <summary>
        /// 获取对象池对象类型
        /// </summary>
        /// <value></value>
        Type ObjectType
        {
            get;
        }

        /// <summary>
        /// 获取对象池中对象的数量
        /// </summary>
        /// <value></value>
        int Count
        {
            get;
        }

        /// <summary>
        /// 获取对象池中能被释放的对象的数量
        /// </summary>
        /// <value></value>
        int CanReleaseCount
        {
            get;
        }

        /// <summary>
        /// 获取是否允许对象被多次获取
        /// </summary>
        /// <value></value>
        bool AllowMultiSpawn
        {
            get;
        }

        /// <summary>
        /// 获取或设置对象池自动释放可释放对象的间隔秒数
        /// </summary>
        /// <value></value>
        float AutoReleaseInterval
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置对象池的容量
        /// </summary>
        /// <value></value>
        int Capacity
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置对象池对象过期秒数
        /// </summary>
        /// <value></value>
        float ExpireTime
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置对象池的优先级
        /// </summary>
        /// <value></value>
        int Priority
        {
            get;
            set;
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="spawned"></param>
        void Register(T obj, bool spawned);

        /// <summary>
        /// 检查对象
        /// </summary>
        /// <returns></returns>
        bool CanSpawn();

        /// <summary>
        /// 检查对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool CanSpawn(string name);

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <returns></returns>
        T Spawn();

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T Spawn(string name);

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="obj"></param>
        void Unspawn(T obj);

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="target"></param>
        void Unspawn(object target);

        /// <summary>
        /// 设置对象是否被加锁
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="locked"></param>
        void SetLocked(T obj, bool locked);

        /// <summary>
        /// 设置对象是否被加锁
        /// </summary>
        /// <param name="target"></param>
        /// <param name="locked"></param>
        void SetLocked(object target, bool locked);

        /// <summary>
        /// 设置对象的优先级
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="priority"></param>
        void SetPriority(T obj, int priority);

        /// <summary>
        /// 设置对象的优先级
        /// </summary>
        /// <param name="target"></param>
        /// <param name="priority"></param>
        void SetPriority(object target, int priority);

        /// <summary>
        /// 释放对象池中的可释放对象
        /// </summary>
        void Release();

        /// <summary>
        /// 释放对象池中的可释放对象
        /// </summary>
        /// <param name="toReleaseCount"></param>
        void Release(int toReleaseCount);

        /// <summary>
        /// 释放对象池中的可释放对象
        /// </summary>
        /// <param name="releaseObjectFilterCallback"></param>
        void Release(ReleaseObjectFilterCallback<T> releaseObjectFilterCallback);

        /// <summary>
        /// 释放对象池中的可释放对象
        /// </summary>
        /// <param name="toReleaseCount"></param>
        /// <param name="releaseObjectFilterCallback"></param>
        void Release(int toReleaseCount, ReleaseObjectFilterCallback<T> releaseObjectFilterCallback);

        /// <summary>
        /// 释放对象池中的所有未使用对象
        /// </summary>
        void ReleaseAllUnused();

    }
}