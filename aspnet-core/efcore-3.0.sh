#!/usr/bin/env zsh

# Define the modules to update
mods=("Management")
# mods=("Alterations" "Runtime" "Management" "Identity" "Labels")

# Define the list of providers
providers=("MySql" "SqlServer" "Sqlite" "PostgreSql")
# providers=("SqlServer")

# Connection strings for each provider
typeset -A connStrings
connStrings=(
    MySql "Server=127.0.0.1;Database=ElsaServerStudio-V9.2;User Id=root;Password=123456;Port=3308;SslMode=None;"
    SqlServer ""
    Sqlite ""
    PostgreSql ""
)

# Loop through each module
for module in "${mods[@]}"; do
    # Loop through each provider
    for provider in "${providers[@]}"; do
        providerPath="../migrations/Elsa.EntityFrameworkCore.$provider"
        migrationsPath="Migrations/$module"
    
        echo "Updating migrations for $provider..."
        echo "Provider path: ${providerPath:?}/${migrationsPath}"
        echo "Migrations path: $migrationsPath"
        echo "Connection string: ${connStrings[$provider]}"
    
        # 1. Delete the existing migrations folder
        rm -rf "${providerPath:?}/${migrationsPath}"
    
        # 2. Run the migrations command
        dotnet ef migrations add Initial -c "$module"ElsaDbContext -p "$providerPath"  -o "$migrationsPath" -- --connectionString "${connStrings[$provider]}"
    done
done
