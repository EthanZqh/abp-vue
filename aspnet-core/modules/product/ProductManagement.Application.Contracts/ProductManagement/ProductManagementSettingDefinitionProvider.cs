﻿using ProductManagement.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace ProductManagement
{
    /* These setting definitions will be visible to clients that has a ProductManagement.Application.Contracts
     * reference. Settings those should be hidden from clients should be defined in the ProductManagement.Application
     * package.
     */
    public class ProductManagementSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    ProductManagementSettings.MaxPageSize,
                    "100",
                    displayName: L("DisplayName:MaxPageSize"),
                    description: L("Description:MaxPageSize"),
                    isVisibleToClients: true
                )
            );
        }





        protected LocalizableString L(string name)
        {
            return LocalizableString.Create<ProductManagementResource>(name);
        }
    }
}