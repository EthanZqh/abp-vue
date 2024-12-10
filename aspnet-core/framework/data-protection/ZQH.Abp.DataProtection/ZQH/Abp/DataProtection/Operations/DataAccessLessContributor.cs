﻿using System.Linq.Expressions;

namespace ZQH.Abp.DataProtection.Operations;
public class DataAccessLessContributor : IDataAccessOperateContributor
{
    public DataAccessFilterOperate Operate => DataAccessFilterOperate.Less;

    public Expression BuildExpression(Expression left, Expression right)
    {
        return Expression.LessThan(left, right);
    }
}