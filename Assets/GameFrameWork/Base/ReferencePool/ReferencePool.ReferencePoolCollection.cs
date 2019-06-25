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
                    
                }

                return null;
            }

        }
    }
}