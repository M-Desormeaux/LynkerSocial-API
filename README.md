initial migration:

dotnet-ef migrations add ""

---

makes database changes

dotnet-ef database update

---

User Secrets

dotnet user-secrets init

Personal connection string

dotnet user-secrets set "ConnectionStrings:connect" {connections string for your instance}
