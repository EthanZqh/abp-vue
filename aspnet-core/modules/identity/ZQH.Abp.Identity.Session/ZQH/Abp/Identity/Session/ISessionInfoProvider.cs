using System;

namespace ZQH.Abp.Identity.Session;
public interface ISessionInfoProvider
{
    string SessionId { get; }

    IDisposable Change(string sessionId);
}
