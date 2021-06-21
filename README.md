# OnePunch
dotnet aspnet-codegenerator identity -dc OnePunch.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"

dotnet aspnet-codegenerator identity -dc OnePunch.Data.ApplicationDbContext --files "Account.RegisterConfirmation;Account.ForgotPassword;Account.ForgotPasswordConfirmation"


dotnet user-secrets set "ConnectionStrings:LocalHostConnection" "server=localhost;port=3306;database=OnePunch;user=;password="
