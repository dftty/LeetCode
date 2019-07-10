using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        /// <summary>
        /// 资源初始化器
        /// </summary>
        private sealed class ResourceIniter
        {
            private readonly ResourceManager m_ResourceManager;
            private string m_CurrentVariant;

            public GameFrameworkAction ResourceInitComplete;

            public ResourceIniter(ResourceManager resourceManager)
            {
                m_ResourceManager = resourceManager;
                m_CurrentVariant = null;
                ResourceInitComplete = null;
            }

            public void Shutdown()
            {

            }

            public void InitResources(string currentVariant)
            {
                m_CurrentVariant = currentVariant;

                if(m_ResourceManager.m_ResourceHelper == null)
                {
                    throw new GameFrameworkException("Resource helper is invalid.");
                }

                if(string.IsNullOrEmpty(m_ResourceManager.m_ReadOnlyPath))
                {
                    throw new GameFrameworkException("ReadOnlyListHeader path is invalid.");
                }

                m_ResourceManager.m_ResourceHelper.LoadBytees(Utility.Path.GetRemotePath(m_ResourceManager.m_ReadOnlyPath, Utility.Path.GetResourceNameWithSuffix(VersionListFileName)), ParsePackageList);
            }

            /// <summary>
            /// 解析资源包资源列表
            /// </summary>
            /// <param name="fileUri"></param>
            /// <param name="bytes"></param>
            /// <param name="errorMessage"></param>
            private void ParsePackageList(string fileUri, byte[] bytes, string errorMessage)
            {
                if (bytes == null || bytes.Length <= 0)
                {
                    throw new GameFrameworkException(Utility.Text.Format("Package list '{0}' is invalid, error message is '{1}'.", fileUri, string.IsNullOrEmpty(errorMessage) ? "<Empty>" : errorMessage));
                }

                MemoryStream memoryStream = null;
                try
                {
                    memoryStream = new MemoryStream(bytes, false);
                    using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                    {
                        memoryStream = null;
                        if (binaryReader.ReadChar() != PackageListHeader[0] || binaryReader.ReadChar() != PackageListHeader[1] || binaryReader.ReadChar() != PackageListHeader[2])
                        {
                            throw new GameFrameworkException("Package list header is invalid.");
                        }

                        byte listVersion = binaryReader.ReadByte();

                        if (listVersion == 0)
                        {
                            byte[] encryptBytes = binaryReader.ReadBytes(4);

                            m_ResourceManager.m_ApplicableGameVersion = m_ResourceManager.GetEncryptedString(binaryReader, encryptBytes);
                            m_ResourceManager.m_InternalResourceVersion = binaryReader.ReadInt32();

                            int assetCount = binaryReader.ReadInt32();
                            m_ResourceManager.m_AssetInfos = new Dictionary<string, AssetInfo>(assetCount);
                            int resourceCount = binaryReader.ReadInt32();
                            m_ResourceManager.m_ResourceInfos = new Dictionary<ResourceName, ResourceInfo>(resourceCount, new ResourceNameComparer());

                            for (int i = 0; i < resourceCount; i++)
                            {
                                string name = m_ResourceManager.GetEncryptedString(binaryReader, encryptBytes);
                                string variant = m_ResourceManager.GetEncryptedString(binaryReader, encryptBytes);
                                ResourceName resourceName = new ResourceName(name, variant);

                                LoadType loadType = (LoadType)binaryReader.ReadByte();
                                int length = binaryReader.ReadInt32();
                                int hashCode = binaryReader.ReadInt32();
                                byte[] hashCodeBytes = Utility.Converter.GetBytes(hashCode);

                                int assetNamesCount = binaryReader.ReadInt32();
                                for (int j = 0; j < assetNamesCount; j++)
                                {
                                    string assetName = m_ResourceManager.GetEncryptedString(binaryReader, hashCodeBytes);

                                    int dependencyAssetNamesCount = binaryReader.ReadInt32();
                                    string[] dependencyAssetNames = new string[dependencyAssetNamesCount];
                                    for (int k = 0; k < dependencyAssetNamesCount; k++)
                                    {
                                        dependencyAssetNames[k] = m_ResourceManager.GetEncryptedString(binaryReader, hashCodeBytes);
                                    }

                                    if (variant == null || variant == m_CurrentVariant)
                                    {
                                        m_ResourceManager.m_AssetInfos.Add(assetName, new AssetInfo(assetName, resourceName, dependencyAssetNames));
                                    }
                                }

                                if (variant == null || variant == m_CurrentVariant)
                                {
                                    ProcessResourceInfo(resourceName, loadType, length, hashCode);
                                }
                            }
                        }
                        else
                        {
                            throw new GameFrameworkException("Package list version is invalid.");
                        }
                    }

                    ResourceInitComplete();
                }
                catch (Exception exception)
                {
                    if (exception is GameFrameworkException)
                    {
                        throw;
                    }

                    throw new GameFrameworkException(Utility.Text.Format("Parse package list exception '{0}'.", exception.Message), exception);
                }
                finally
                {
                    if (memoryStream != null)
                    {
                        memoryStream.Dispose();
                        memoryStream = null;
                    }
                }
            }

            private void ProcessResourceInfo(ResourceName resourceName, LoadType loadType, int length, int hashCode)
            {
                if(m_ResourceManager.m_ResourceInfos.ContainsKey(resourceName))
                {
                    throw new GameFrameworkException(Utility.Text.Format("Resource info '{0}' is already exist.", resourceName.FullName));
                }

                m_ResourceManager.m_ResourceInfos.Add(resourceName, new ResourceInfo(resourceName, loadType, length, hashCode, true));
            }
        }
    }
}