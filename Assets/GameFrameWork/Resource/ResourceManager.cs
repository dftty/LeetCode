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
    }
}