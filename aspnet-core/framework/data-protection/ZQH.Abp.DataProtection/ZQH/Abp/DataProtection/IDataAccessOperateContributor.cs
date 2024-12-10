﻿using System.Linq.Expressions;

namespace ZQH.Abp.DataProtection;
public interface IDataAccessOperateContributor
{
    DataAccessFilterOperate Operate { get; }
    Expression BuildExpression(Expression left, Expression right);
}
