using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace ZQH.Abp.Employees;
public class EmployeeNameAlreadyExistsException: BusinessException
{
    public EmployeeNameAlreadyExistsException(string employeeName)
        : base("EM:000001", $"A employee with name {employeeName} has already exists!")
    {

    }
}
