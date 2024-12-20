using System;
using System.Collections.Generic;
using System.Text;

namespace ZQH.Abp.Identity.Employees;
public static class EmployeeConsts
{
    public static int MaxNameLength {
        get;
        set;
    } = 256;
    public static int MaxSexLength {
        get;
        set;
    } = 6;

    public static int MaxAvatarUrlLength {
        get;
        set;
    } = 1024;

    public static int MaxAddressLength {
        get;
        set;
    } = 256;

    public static int MaxBirthdayLength {
        get;
        set;
    } = 6;
    public static int MaxNationLength {
        get;
        set;
    } = 256;
    public static int MaxNativePlaceLength {
        get;
        set;
    } = 256;
    public static int MaxPhoneNumberLength {
        get;
        set;
    } = 256;
    public static int MaxPositionLength {
        get;
        set;
    } = 256;

}
