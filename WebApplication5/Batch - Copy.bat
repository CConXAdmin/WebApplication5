
dotnet aspnet-codegenerator --no-build controller -name SubsController --force -m WebApplication5.Models.Sub -dc WebApplication5.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout
dotnet aspnet-codegenerator --no-build controller -name OtherSubsController --force -m WebApplication5.Models.OtherSub -dc WebApplication5.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout
 