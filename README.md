# pdbtomdb

A super simple CLI program to convert PDB to MDB (Mono). This project is trivial all the heavy lifting is done by [Cecil](https://cecil.pe/).

# Usage:

## Windows

```
PdbToMdb.exe <DLL path>
```

## Mono (Unix)

```
mono PdbToMdb.exe <DLL path>
```

## .NET Core (Unix)

```
dotnet PdbToMdb.dll <DLL path>
```

## Paths / Dependencies

For simplicity, all dependencies of the DLL, as well as the target DLL's PDB, must be placed in the same directory as the target DLL.

The resultant MDB will also be output adjacent to the target DLL.

