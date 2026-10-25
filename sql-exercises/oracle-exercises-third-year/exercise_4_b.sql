-- ---------------------------------------------------------------------- -
-- 1. Beispiel: Gruppenfunktionen (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- Welches Ergebnis berechnet Abfrage 1?

-- Tabellen: DISH_INGREDIENTS
-- User: SH

-- Abfrage 1)

select DISH_ID, count(INGREDIENT_ID)
from DISH_INGREDIENTS
group by DISH_ID;

-- endregion

-- ---------------------------------------------------------------------- -
-- 2. Beispiel: Gruppenfunktionen (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- Geben Sie fuer jede Bestellung die Anzahl von Gerichten an die bestellt
-- wurden.

-- Geben Sie die folgenden Spalten aus: ORDER_ID, DISH_COUNT

-- Tabellen: ORDER_ITEMS
-- User: SH



-- endregion

-- ---------------------------------------------------------------------- -
-- 3. Beispiel: Gruppenfunktionen (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- Geben Sie fuer die im System gespeicherten Koeche die folgenden Spalten
-- aus: EMPLOYEE_ID, LAST_NAME, DISH_COUNT

-- Verwendent Sie eine INNER JOIN.

-- Sortieren Sie das Ergebnis nach den Namen der Koeche.

-- Tabellen: EMPLOYEES_ST, COOKS_DISHES
-- User: SH


-- endregion

-- ---------------------------------------------------------------------- -
-- 4. Beispiel: Gruppenfunktionen (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- Geben Sie fuer jeden Kellner die Anzahl von Tischen aus fuer die Sie
-- verantwortlich sind.

-- Geben Sie die folgenden Spalten aus:
-- EMPLOYEE_ID, LAST_NAME, FIRST_NAME, TABLE_COUNT

-- Geben Sie nur Kellner sein die mehr als 2 Tische betreuen.

-- Sortieren Sie das Ergebnis nach den Nachnamen der Kellner.

-- Tabellen: EMPLOYEES_ST, WAITER_HAS_TABLES
-- User: SH



-- endregion

-- ---------------------------------------------------------------------- -
-- 5. Beispiel: Gruppenfunktionen (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- Beim Ausführen der folgenden Abfrage kommt es zu einem Fehler. Erklaeren
-- Sie warum.

-- Tabellen: DISHES
-- User: SH

SELECT DISH_ID, MAX(price)
from DISHES;

-- endregion
