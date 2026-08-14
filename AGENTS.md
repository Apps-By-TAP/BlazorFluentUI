# Repository agent instructions

The canonical library documentation is the [OKF bundle](docs/OKF/index.md). Before writing or modifying Razor that consumes this library:

1. Read `docs/OKF/index.md`, the page for every component involved, and any linked supporting-type reference.
2. Copy parameter names, generic type arguments, enum members, callback types, and `@bind-*` pairs exactly. Never invent an attribute or theme token.
3. Preserve the library's WPF-style API. Names such as `IsChecked`, `SelectedItem`, `WholeValue`, and `DecimalValue` are intentional even where another Blazor convention might be more common.
4. Treat each component page's gotchas and limitations as part of the current runtime contract. Do not silently refactor documented behavior while completing an unrelated task.
5. Use only CSS custom properties listed in `docs/OKF/components/theme.md`; token names and casing are exact.
6. When a component contract changes, update/regenerate its OKF page and the related supporting references in the same change.
7. Before finishing documentation or component work, run:

   ```powershell
   dotnet run --project tools/OkfDocsValidator/OkfDocsValidator.csproj -c Release -- check
   ```

The source and compiled component assembly are authoritative. Legacy files under `docs/` are discovery pointers and must not be used as API references.
