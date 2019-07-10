using GameFramework.Download;
using GameFramework.ObjectPool;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        private static readonly char[] PackageListHeader = new char[] {'E', 'L', 'P'};
        private static readonly char[] VersionListHeader = new char[] {'E', 'L', 'V'};
        private static readonly char[] ReadOnlyListHeader = new char[] {'E', 'L', 'R'};
        private static readonly char[] ReadWriteListHeader = new char[] {'E', 'L', 'W'};
        private const string VersionListFileName = "version";
        private const string ResourceListFileName = "list";
        private const string BackupFileSuffixName = ".bak";
        private const byte ReadWriteListVersionHeader = 0;
        private const int OneMegaBytes = 1024 * 1024;

        private Dictionary<string, AssetInfo> m_AssetInfos;
        private Dictionary<ResourceName, ResourceInfo> m_ResourceInfos;
        private readonly SortedDictionary<ResourceName, ReadWriteResourceInfo> m_ReadWriteResourceInfos;
        private readonly byte[] m_CachedBytesForEncryptedString;


        private IResourceHelper m_ResourceHelper;
        private string m_ReadOnlyPath;
        private string m_ReadWritePath;
        private ResourceMode m_ResourceMode;
        private bool m_RefuseSetCurrentVariant;
        private string m_CurrentVariant;
        private string m_UpdatePrefixUri;
        private string m_ApplicableGameVersion;
        private int m_InternalResourceVersion;
        private byte[] m_UpdateFileCache;
        private Stream m_DecompressCache;

        public int UpdateFileCacheLength
        {
            get
            {
                return m_UpdateFileCache != null ? m_UpdateFileCache.Length : 0;
            }
            set
            {
                if(m_UpdateFileCache != null && m_UpdateFileCache.Length == value)
                {
                    return;
                }
                m_UpdateFileCache = new byte[value];
            }
        }

        private string GetEncryptedString(BinaryReader binaryReader, byte[] encryptBytes)
        {
            int length = binaryReader.ReadByte();
            if (length <= 0)
            {
                return null;
            }

            for (int i = 0; i < length; i++)
            {
                m_CachedBytesForEncryptedString[i] = binaryReader.ReadByte();
            }

            Utility.Encryption.GetSelfXorBytes(m_CachedBytesForEncryptedString, encryptBytes, length);

            return Utility.Converter.GetString(m_CachedBytesForEncryptedString, 0, length);
        }

        private AssetInfo? GetAssetInfo(string assetName)
        {
            if(string.IsNullOrEmpty(assetName))
            {
                throw new GameFrameworkException("Asset name is invalid.");
            }

            if(m_AssetInfos == null)
            {
                return null;
            }

            AssetInfo assetInfo = default(AssetInfo);
            if(m_AssetInfos.TryGetValue(assetName, out assetInfo))
            {
                return assetInfo;
            }

            return null;
        }

        private ResourceInfo? GetResourceInfo(ResourceName resourceName)
        {
            if(m_ResourceInfos == null)
            {
                return null;
            }

            ResourceInfo resourceInfo = default(ResourceInfo);
            if(m_ResourceInfos.TryGetValue(resourceName, out resourceInfo))
            {
                return resourceInfo;
            }

            return null;
        }

    }
}