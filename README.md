# JCU MazeSolver

Implementace tří algoritmů pro průchod bludištěm v jazyce C#. Program načítá bludiště ze souboru `.txt`, vizualizuje pohyb hráče v konzoli a po dokončení zobrazí heat mapu (kolikrát hráč prošel každým políčkem).

## Požadavky

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Build a spuštění

```bash
dotnet build MazeProjekt.csproj
dotnet run --project MazeProjekt.csproj
```

Po spuštění program interaktivně nabídne výběr bludiště a algoritmu.

## Formát bludiště

Bludiště je textový soubor `.txt`, kde každý znak reprezentuje jedno políčko:

| Znak | Význam |
|------|--------|
| `x`  | Zeď |
| `a`  | Hráč (start) |
| `b`  | Cíl (konec) |
| ` `  | Volná cesta |

Příklad:
```
xxxxxxxxxxxxxxxxxxxx
xoaoooooooooxoooooox
xxxxxxxxxxxoxoxxxoxx
xoooooooooobxoxoxoxx
```

Vlastní bludiště stačí vložit jako `.txt` soubor do složky `mazes/`.

## Algoritmy

### Pravidlo levé ruky (Left Hand Rule)
Hráč se drží levé stěny a postupuje vpřed. Spolehlivý na jednoduchých bludištích, ale nenajde vždy nejkratší cestu.

### Nehleď zpět (Don't Look Back)
Hráč si pamatuje navštívená políčka a preferuje méně navštívené směry. Lépe zvládá složitější bludiště.

### Náhodná chůze (Bogo Walk)
Čistě náhodný pohyb — vždy nakonec najde cestu, ale může trvat velmi dlouho.

## Struktura projektu

```
├── src/          # zdrojové soubory
├── mazes/        # bludiště ve formátu .txt
├── MazeProjekt.csproj
└── JCU-MazeSolver.sln
```
