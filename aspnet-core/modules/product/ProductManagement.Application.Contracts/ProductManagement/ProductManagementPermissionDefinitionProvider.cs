using ProductManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ProductManagement
{
    public class ProductManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var productManagementGroup = context.AddGroup(ProductManagementPermissions.GroupName, L("Permission:ProductManagement"));

            var products = productManagementGroup.AddPermission(ProductManagementPermissions.Products.Default, L("Permission:Products"));
            products.AddChild(ProductManagementPermissions.Products.Update, L("Permission:Edit"));
            products.AddChild(ProductManagementPermissions.Products.Delete, L("Permission:Delete"));
            products.AddChild(ProductManagementPermissions.Products.Create, L("Permission:Create"));

            products.AddChild(ProductManagementPermissions.Products.UpLoad, L("Permission:UpLoad"));




            products.AddChild(ProductManagementPermissions.Products.DownLoad, L("Permission:DownLoad"));





            var tests = productManagementGroup.AddPermission(ProductManagementPermissions.Tests.Default, L("Permission:Tests"));
            tests.AddChild(ProductManagementPermissions.Tests.Update, L("Permission:Edit"));
            tests.AddChild(ProductManagementPermissions.Tests.Delete, L("Permission:Delete"));
            tests.AddChild(ProductManagementPermissions.Tests.Create, L("Permission:Create"));

            tests.AddChild(ProductManagementPermissions.Tests.UpLoad, L("Permission:UpLoad"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductManagementResource>(name);
        }
    }
}