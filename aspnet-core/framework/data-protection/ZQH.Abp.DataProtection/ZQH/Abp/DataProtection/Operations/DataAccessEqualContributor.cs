﻿using System.Linq.Expressions;

namespace ZQH.Abp.DataProtection.Operations;
public class DataAccessEqualContributor : IDataAccessOperateContributor
{
    public DataAccessFilterOperate Operate => DataAccessFilterOperate.Equal;

    public Expression BuildExpression(Expression left, Expression right)
    {
        return Expression.Equal(left, right);
    }
}
