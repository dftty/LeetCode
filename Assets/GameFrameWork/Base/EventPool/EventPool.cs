using System;
using System.Collections.Generic;

namespace GameFramework
{
    /// <summary>
    /// 事件池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed partial class EventPool<T> where T : BaseEventArgs
    {
        private readonly Dictionary<int, LinkedList<EventHandler<T>>> m_EventHandlers;
        private readonly Queue<Event> m_Events;
        private readonly EventPoolMode m_EventPoolMode;
        private EventHandler<T> m_DefaultHandler;

        /// <summary>
        /// 初始化事件池的新实例
        /// </summary>
        /// <param name="mode"></param>
        public EventPool(EventPoolMode mode)
        {
            m_EventHandlers = new Dictionary<int, LinkedList<EventHandler<T>>>();
            m_Events = new Queue<Event>();
            m_EventPoolMode = mode;
            m_DefaultHandler = null;
        }

        /// <summary>
        /// 获取事件处理函数的数量
        /// </summary>
        /// <value></value>
        public int EventHandlerCount
        {
            get
            {
                return m_EventHandlers.Count;
            }
        }

        /// <summary>
        /// 获取事件数量
        /// </summary>
        /// <value></value>
        public int EventCount
        {
            get
            {
                return m_Events.Count;
            }
        }

        /// <summary>
        /// 事件池轮询
        /// </summary>
        /// <param name="elapseSeconds"></param>
        /// <param name="realElapseSeconds"></param>
        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            lock(m_Events)
            {
                while(m_Events.Count > 0)
                {
                    Event e = m_Events.Dequeue();
                    HandleEvent(e.Sender, e.EventArgs);
                }
            }
        }

        /// <summary>
        /// 关闭并清理事件池
        /// </summary>
        public void ShutDown()
        {
            Clear();
            m_EventHandlers.Clear();
            m_DefaultHandler = null;
        }

        /// <summary>
        /// 清理事件
        /// </summary>
        public void Clear()
        {
            lock(m_Events)
            {
                m_Events.Clear();
            }
        }

        /// <summary>
        /// 获取事件处理函数的数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Count(int id)
        {
            LinkedList<EventHandler<T>> handlers = null;
            if(m_EventHandlers.TryGetValue(id, out handlers)){
                return handlers.Count;
            }

            return 0;
        }



        /// <summary>
        /// 检查是否存在事件处理函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public bool Check(int id, EventHandler<T> handler)
        {
            if(handler == null)
            {
                throw new GameFrameworkException("Event handler is invalic.");
            }

            LinkedList<EventHandler<T>> handlers = null;
            if(!m_EventHandlers.TryGetValue(id, out handlers))
            {
                return false;
            }

            return handlers.Contains(handler);
        }

        /// <summary>
        /// 订阅事件处理函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="handler"></param>
        public void Subscribe(int id, EventHandler<T> handler)
        {
            if(handler == null)
            {
                throw new GameFrameworkException("Event handler is invalid.");
            }

            LinkedList<EventHandler<T>> handlers = null;
            if(m_EventHandlers.TryGetValue(id, out handlers))
            {
                handlers = new LinkedList<EventHandler<T>>();
                handlers.AddLast(handler);
                m_EventHandlers.Add(id, handlers);
            }else if((m_EventPoolMode & EventPoolMode.AllowMultiHandler) == 0)
            {
                throw new GameFrameworkException(Utility.Text.Format("Event '{0}' not allow multi handler.", id.ToString()));
            }else if((m_EventPoolMode & EventPoolMode.AllowDuplicateHandler) == 0 && Check(id, handler))
            {
                throw new GameFrameworkException(Utility.Text.Format("Event '{0}' not allow duplicate handler.", id.ToString()));
            }else
            {
                handlers.AddLast(handler);
            }
        }

        /// <summary>
        /// 取消订阅事件处理函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="handler"></param>
        public void Unsubscribe(int id, EventHandler<T> handler)
        {
            if(handler == null)
            {
                throw new GameFrameworkException("Event handler is invalid.");
            }

            LinkedList<EventHandler<T>> handlers = null;
            if(m_EventHandlers.TryGetValue(id, out handlers))
            {
                throw new GameFrameworkException(Utility.Text.Format("Event '{0}' not exists any handler.", id.ToString()));
            }

            if(handlers.Remove(handler))
            {
                throw new GameFrameworkException(Utility.Text.Format("Event '{0}' not exists specified handler.", id.ToString()));
            }
        }

        /// <summary>
        /// 设置默认事件处理函数
        /// </summary>
        /// <param name="handler"></param>
        public void SetDefaultHandler(EventHandler<T> handler)
        {
            m_DefaultHandler = handler;
        }

        /// <summary>
        ///  抛出事件，这个操作是线程安全的，即使不在主线程中抛出，也可保证在主线程中回调事件处理函数，但事件会在抛出后的下一帧分发。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Fire(object sender ,T e)
        {
            Event eventNode = new Event(sender, e);
            lock(m_Events)
            {
                m_Events.Enqueue(eventNode);
            }
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FireNow(object sender, T e)
        {
            HandleEvent(sender, e);
        }


        /// <summary>
        /// 处理事件结点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleEvent(object sender, T e)
        {
            int eventId = e.Id;
            bool noHandlerException = false;
            LinkedList<EventHandler<T>> handlers = null;
            if(m_EventHandlers.TryGetValue(eventId, out handlers) && handlers.Count > 0)
            {
                LinkedListNode<EventHandler<T>> current = handlers.First;
                while(current != null)
                {
                    LinkedListNode<EventHandler<T>> next = current.Next;
                    current.Value(sender, e);
                    current = next;    
                }
            }else if (m_DefaultHandler != null)
            {
                m_DefaultHandler(sender, e);
            }else if((m_EventPoolMode & EventPoolMode.AllowNoHandler) == 0)
            {
                noHandlerException = true;
            }

            ReferencePool.Release((IReference)e);

            if(noHandlerException)
            {
                throw new GameFrameworkException(Utility.Text.Format("Event '{0}' not allow no handler", eventId.ToString()));
            }
        }
    }
}