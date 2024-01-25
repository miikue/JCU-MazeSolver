## Popis projektu
Projekt Bludiště je implementací různých algoritmů pro průchod bludištěm v jazyce C#. Program umožňuje načítání bludišť ze souboru, vizualizaci aktuálního stavu bludiště v konzoli a aplikaci různých algoritmů pro hledání cesty od začátku bludiště k jeho konci.

### Ovládání a vstupní soubor
Ovládání programu probíhá prostřednictvím konzole. Vstupní soubor bludiště má následující znaky:

- `x`: Zeď
- `a`: Hráč (začátek)
- `b`: Východ (konec)
- `" "`: Prázdno (cesta) nebo jakýkoliv jiný znak (např.: `o`)

## Třídy a metody

### Třída `Program`

- `Guide()`: Základní prvek pro ovládání programu pro uživatele.
- `ReadFormFileMap()`: Načítá bludiště ze souboru.

### Třída `Items`

Enum, který drží hodnoty používané v programu, např. směry (pravá, levá, dole, nahoře).

### Třída `MazeSolver`

- `ReadMap()`: Vypisuje aktuální stav bludiště do konzole.
- `CopyMap()`: Zkopíruje mapu do dvou map.
- `ReadHeatMap()`: Zobrazuje, kde a kolikrát hráč na mapě byl.
- `FindPlayer()`: Vrací pozici hráče v bludišti.
- `FindEnd()`: Vrací pozici konce bludiště.

### Třída `Tile`

- Getter a setter pro informace o druhu políčka a kolikrát na něj hráč stoupnul.
- Vlastní implementace `ToString()` pro "hezčí" výpis do konzole.

### Třída `Player`

- Drží pozici hráče (x a y).
- Getter a setter pro pozici hráče.

### Třída `BogoWalk`

- `Solve()`: Metoda pro průchod bludištěm pomocí algoritmu Bogo.
- `BogoWalkOneStep()`: Jedna iterace algoritmu.

### Třída `LeftHandRule`

- `Solve()`: Metoda pro průchod bludištěm pomocí algoritmu LeftHandRule.
- `OneStep()`: Jedna iterace algoritmu.

### Třída `DontLookBack`

- `Solve()`: Metoda pro průchod bludištěm pomocí algoritmu DontLookBack.
- `DontLookBackOneStep()`: Jedna iterace algoritmu.
- `DirectionsToChoose()`: Pomocná metoda pro kontrolu možných směrů.

## Algoritmy

### Pravidlo levé ruky (LeftHandRule)

- Jednoduché pravidlo: drž se levou rukou stěny a postupuj vpřed.
- Plusy: Často najde konec.
- Mínusy: Ne vždy nalezne nejkratší cestu.

### Pohazování drobků (DontLookBack)

- Chodí "náhodně" po bludišti, zanechává drobky a v případě výběru cesty preferuje ty s méně drobků.
- Plusy: Lepší manipulace s odděleným začátkem a koncem.
- Mínusy: Může projít celým bludištěm.

### Náhodná chůze (Bogo)

- Úplně náhodný pohyb.
- Plusy: Vždy najde cestu, ale může trvat dlouho.
- Mínusy: Může se zacyklit a trvat nekonečně dlouho.

## Poznámky

Tento projekt slouží pro studium a experimentování s různými algoritmy pro průchod bludištěm v rámci jazyka C#. Algoritmy mají své výhody a nevýhody a mohou být použity pro různé typy bludišť.
