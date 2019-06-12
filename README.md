# pdbtomdb

A super simple CLI program to convert PDB to MDB (Mono). This project is trivial all the heavy lifting is done by [Cecil](https://cecil.pe/).

# Usage:

## Windows

```
PdbToMdb.exe <DLL path>
```

## UNIX

```
mono PdbToMdb.exe <DLL path>
```

## Paths / Dependencies

For simplicity, all dependencies of the DLL must be placed in the same directory as the target DLL.

The PDB must also be adjacent to the target DLL, and the resultant MDB will be output adjacent to the target DLL also.

