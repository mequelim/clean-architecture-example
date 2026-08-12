# `CleanArchitectureMvc.Infra.Data` project

## Commands to generate migrations

```bash
dotnet ef migrations add {name} --project CleanArchitectureMvc.Infra.Data --startup-project CleanArchitectureMvc.WebUI
dotnet ef database update --project CleanArchitectureMvc.Infra.Data --startup-project CleanArchitectureMvc.WebUI
```