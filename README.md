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

---

to clear up the https trust issue use this command in the project

dotnet dev-certs https --trust
