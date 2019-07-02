using System;

namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        private struct ResourceName : IComparable, IComparable<ResourceName>, IEquatable<ResourceName>
        {
            private readonly string m_Name;
            private readonly string m_Variant;

            /// <summary>
            /// 初始化资源名称的新实例
            /// </summary>
            /// <param name="name"></param>
            /// <param name="variant"></param>
            public ResourceName(string name, string variant)
            {
                if(string.IsNullOrEmpty(name))
                {
                    throw new GameFrameworkException("Resource name is invalid.");
                }

                m_Name = name;
                m_Variant = variant;
            }

            /// <summary>
            /// 获取资源名称
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
            /// 获取变体名称
            /// </summary>
            /// <value></value>
            public string Variant
            {
                get
                {
                    return m_Variant;
                }
            }

            /// <summary>
            /// 获取是否变体
            /// </summary>
            /// <value></value>
            public bool IsVariant
            {
                get
                {
                    return m_Variant != null;
                }
            }

            public string FullName
            {
                get
                {
                    return IsVariant ? Utility.Text.Format("{0}.{1}", m_Name, m_Variant) : m_Name;
                }
            }

            public override string ToString()
            {
                return FullName;
            }

            public override int GetHashCode()
            {
                if(m_Variant == null)
                {
                    return m_Name.GetHashCode();
                }

                return (m_Name.GetHashCode() ^ m_Variant.GetHashCode());
            }

            public override bool Equals(object obj)
            {
                return (obj is ResourceName) && (this == (ResourceName)obj);
            }

            public bool Equals(ResourceName resourceName)
            {
                return (this == resourceName);
            }

            public static bool operator ==(ResourceName resourceName1, ResourceName resourceName2)
            {
                return resourceName1.CompareTo(resourceName2) == 0;
            }

            public static bool operator !=(ResourceName resourceName1, ResourceName resourceName2)
            {
                return resourceName1.CompareTo(resourceName2) != 0;
            }

            public int CompareTo(object value)
            {
                if(value == null)
                {
                    return 1;
                }

                if(!(value is ResourceName))
                {
                    throw new GameFrameworkException("Type of value is invalid.");
                }

                return CompareTo((ResourceName)value);
            }

            public int CompareTo(ResourceName resourceName)
            {
                int result = string .Compare(m_Name, resourceName.m_Name);

                if(result != 0){
                    return result;
                }

                return string.Compare(m_Variant, resourceName.m_Variant);
            }
        }
        
    }
}