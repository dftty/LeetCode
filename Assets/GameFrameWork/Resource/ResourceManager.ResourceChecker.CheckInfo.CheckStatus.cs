namespace GameFramework.Resources
{
    internal sealed partial class ResourceManager
    {
        private sealed partial class ResourceChecker
        {
            private sealed partial class CheckInfo
            {
                public enum CheckStatus
                {
                    // 状态未知
                    Unknown = 0,

                    // 需要更新
                    NeedUpdate,

                    // 存在最新且已存放于只读区中
                    StorageInReadOnly,

                    // 存在最新且已存放于读写区中
                    StorageInReadWrite,

                    // 不适用于当前变体
                    Unavailable,

                    // 已废弃
                    Disuse
                }
            }
        }
    }
}