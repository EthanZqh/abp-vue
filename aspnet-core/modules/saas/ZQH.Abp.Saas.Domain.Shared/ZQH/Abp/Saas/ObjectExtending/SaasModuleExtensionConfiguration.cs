﻿using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace ZQH.Abp.Saas.ObjectExtending;

public class SaasModuleExtensionConfiguration : ModuleExtensionConfiguration
{
    public SaasModuleExtensionConfiguration ConfigureTenant(
        Action<EntityExtensionConfiguration> configureAction)
    {
        return this.ConfigureEntity(
            SaasModuleExtensionConsts.EntityNames.Edition,
            configureAction
        );
    }
}
