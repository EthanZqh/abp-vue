using Volo.Abp.Reflection;

namespace ProductManagement
{
    public class ProductManagementPermissions
    {
        public const string GroupName = "ProductManagement";

        public static class Products
        {
            public const string Default = GroupName + ".Product";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";

            public const string UpLoad = Default + ".UpLoad";


            public const string DownLoad = Default + ".DownLoad";



        }
        public static class Tests
        {
            public const string Default = GroupName + ".Test";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";

            public const string UpLoad = Default + ".UpLoad";


        }
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProductManagementPermissions));
        }
    }
}