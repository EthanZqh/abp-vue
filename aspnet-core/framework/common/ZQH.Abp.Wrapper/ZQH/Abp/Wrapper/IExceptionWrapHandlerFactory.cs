using System;

namespace ZQH.Abp.Wrapper;

public interface IExceptionWrapHandlerFactory
{
    IExceptionWrapHandler CreateFor(ExceptionWrapContext context);
}
