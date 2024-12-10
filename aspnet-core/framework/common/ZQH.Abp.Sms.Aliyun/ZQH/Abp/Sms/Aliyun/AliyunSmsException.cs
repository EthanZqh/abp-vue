using ZQH.Abp.Aliyun;

namespace ZQH.Abp.Sms.Aliyun;

public class AliyunSmsException : AbpAliyunException
{
    public AliyunSmsException(string code, string message)
        :base(code, message)
    {
    }
}
