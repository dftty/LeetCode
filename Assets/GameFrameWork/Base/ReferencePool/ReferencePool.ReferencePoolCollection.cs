using System;
using System.Collections.Generic;

namespace GameFramework
{
    public static partial class ReferencePool
    {
        private sealed class ReferencePoolCollection
        {
            private readonly Queue<IReference> m_Reference;
            private readonly Type m_ReferenceType;
            private int m_UsingReferenceCount;
            private int m_AcquireReferenceCount;
            private int m_ReleaseReferenceCount;
            private int m_AddReferenceCount;
            private int m_RemoveReferenceCount;

            public ReferencePoolCollection(Type referenceType)
            {
                m_Reference = new Queue<IReference>();
                m_ReferenceType = referenceType;
                m_UsingReferenceCount = 0;
                m_AcquireReferenceCount = 0;
                m_ReleaseReferenceCount = 0;
                m_AddReferenceCount = 0;
                m_RemoveReferenceCount = 0;
            }

            public Type ReferenceType
            {
                get
                {
                    return m_ReferenceType;
                }
            }

            public int UnusedReferenceType
            {
                get
                {
                    return m_Reference.Count;
                }
            }

            public int UsingReferenceCount
            {
                get
                {
                    return m_UsingReferenceCount;    
                }
            }

            public int AcquireReferenceCount
            {
                get
                {
                    return m_AcquireReferenceCount;
                }
            }

            public int ReleaseReferenceCount
            {
                get
                {
                    return m_ReleaseReferenceCount;
                }
            }

            public int AddReferenceCount
            {
                get
                {
                    return m_AddReferenceCount;
                }
            }

            public int RemoveReferenceCount
            {
                get
                {
                    return m_RemoveReferenceCount;
                }
            }

            public T Acquire<T>() where T : class, IReference, new()
            {
                if(typeof(T) != m_ReferenceType)
                {
                    throw new GameFrameworkException("Type is invalid");
                }

                m_UsingReferenceCount++;
                m_AcquireReferenceCount++;

                lock(m_Reference)
                {
                    if(m_Reference.Count > 0)
                    {
                        return (T)m_Reference.Dequeue();
                    }
                }

                m_AddReferenceCount++;
                return new T();
            }

            public IReference Acquire()
            {
                m_UsingReferenceCount++;
                m_AcquireReferenceCount++;
                lock(m_Reference)
                {
                    if(m_Reference.Count > 0)
                    {
                        return m_Reference.Dequeue();
                    }
                }

                m_AddReferenceCount++;
                return (IReference)Activator.CreateInstance(m_ReferenceType);
            }

            public void Release(IReference reference)
            {
                reference.Clear();
                lock(m_Reference)
                {
                    if(m_Reference.Contains(reference))
                    {
                        throw new GameFrameworkException("The reference has been released.");
                    }

                    m_Reference.Enqueue(reference);
                }

                m_ReleaseReferenceCount++;
                m_UsingReferenceCount--;
            }

            public void Add(int count)
            {
                lock(m_Reference)
                {
                    while(count-- > 0){
                        m_Reference.Enqueue((IReference)Activator.CreateInstance(m_ReferenceType));
                    }
                }
            }

            public void Remove(int count)
            {
                lock(m_Reference)
                {
                    if(count > m_Reference.Count)
                    {
                        count = m_Reference.Count;
                    }

                    m_RemoveReferenceCount += count;
                    while(count-- > 0)
                    {
                        m_Reference.Dequeue();
                    }
                }
            }

            public void RemoveAll()
            {
                lock(m_Reference)
                {
                    m_RemoveReferenceCount += m_Reference.Count;
                    m_Reference.Clear();
                }
            }

        }
    }
}