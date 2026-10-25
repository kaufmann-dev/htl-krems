# Repository Instructions

## Project Structure

- Treat every top-level folder as an independent project. There is no root build, shared code, workspace file, or CI. Run every command from inside the project folder you are working on.
- Keep top-level folder names English and kebab-case. When adding or renaming a project, update its row in the matching section of `README.md`. Every top-level folder must appear there exactly once.
- Leave inner C# project folders (`VierGewinnt/`, `EnumWiederholung/`, …) under their original names. `.sln` files reference them by path.
- Keep one version per project. Replace an outdated copy instead of adding `v2/` folders.
- Many projects carry their own `.gitignore`. Check it before adding files, and never commit `bin/`, `obj/`, `.vs/`, `node_modules/`, `vendor/` or Unity `Library/`, `Logs/`, `UserSettings/`.

## Build and Verification

- `dotnet` is not installed on the host. Build and test C# projects in a container with the SDK that matches the project's `<TargetFramework>`:

  ```sh
  podman run --rm -v "$PWD":/w:Z -w /w mcr.microsoft.com/dotnet/sdk:3.1 dotnet test
  ```

  Use `sdk:5.0`, `sdk:6.0` or `sdk:7.0` for `net5.0`, `net6.0` or `net7.0`. Projects with `<TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>` are .NET Framework and do not build with the .NET SDK on Linux.
- Node projects have `package-lock.json`. Use `npm ci`, not yarn or pnpm.
- Laravel and PHP projects have `composer.lock`. Use `composer install`.
- Unity projects (`unity-*`) target Unity 2021.3.16f1 and cannot be verified headlessly here.
- Database folders contain scripts only. Verify them against a real database (`docker-database-setups/` has Compose files) or not at all.

## Change Policy

- This is an archive of finished schoolwork. Do not upgrade target frameworks, dependencies or language versions, or refactor, unless the task asks for it.
- Keep the original German identifiers, comments and UI text in source files. Translate only when asked.
- Several `appsettings*.json` files contain connection strings for old school and personal database servers. Do not add new credentials. Use placeholders in any config you create.
