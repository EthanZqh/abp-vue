﻿namespace ZQH.Abp.Aliyun.Features;
public static class AliyunFeatureNames
{
    public const string GroupName = "AlibabaCloud";

    public const string Enable = GroupName + ".Enable";

    public static class Sms
    {
        public const string Default = GroupName + ".Sms";

        public const string Enable = Default + ".Enable";

        /// <summary>
        /// 发送次数上限
        /// </summary>
        public const string SendLimit = Default + ".SendLimit";
        /// <summary>
        /// 发送次数上限时长
        /// </summary>
        public const string SendLimitInterval = Default + ".SendLimitInterval";
        /// <summary>
        /// 默认发送次数上限
        /// </summary>
        public const int DefaultSendLimit = 1000;
        /// <summary>
        /// 默认发送次数上限时长
        /// </summary>
        public const int DefaultSendLimitInterval = 1;
    }

    public static class BlobStoring
    {
        public const string Default = GroupName + ".BlobStoring";

        public const string Enable = Default + ".Enable";
    }
}