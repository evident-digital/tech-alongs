# How to add migration
0. Make sure you have the dotnet entity framework extensions installed.
    Run "dotnet tool install --global dotnet-ef" if you don't

## Using dotnet CLI
1. Navigate to `/EviMatch` in a terminal
2. Run: dotnet ef migrations add <MigrationName> -c MatchContext --project Persistence --startup-project EviMatch
3. (optional) To update database: dotnet ef database update -c MatchContext --project Persistence --startup-project EviMatch

----

# How to remove migration

## Using dotnet CLI
1. Navigate to `/EviMatch` in a terminal
2. Run: dotnet ef migrations remove --project Persistence --startup-project EviMatch

----

# Revert to migration in database

## Using dotnet CLI
1. Navigate to `/EviMatch` in a terminal
2. dotnet ef database update -c MatchContext <MigrationName> --project Persistence --startup-project EviMatch

Also read:
https://www.entityframeworktutorial.net/efcore/pmc-commands-for-ef-core-migration.aspx
https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx