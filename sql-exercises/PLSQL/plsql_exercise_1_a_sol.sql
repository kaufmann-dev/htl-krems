 -- ---------------------------------------------------------------------- -
-- 1.1) Beispiel: PLSQL Block, PLSQL Data  (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- region a) Definieren Sie einen Record mit folgender Struktur:

-- project_id       PROJECTS.PROJECT_ID      NOT NULL   DEFAULT 0,
-- title            PROJECTS.TITLE           NOT NULL   DEFAULT 'no data',
-- project_type     VARCHAR2(40)             NOT NULL   DEFAULT 'no data',
-- project_funding  PROJECT_DEBITORS.AMOUNT  NOT NULL   DEFAULT 0

-- endregion

-- region b) Definieren Sie auf Grundlage des Records eine interne Tabelle.
--           Fügen Sie 2 Datensaetze in die interne Tabelle ein.

-- endregion

-- region c) Geben Sie den Inhalt der internen Tabelle in der plsql Konsole
--           aus.
--
--           Hinweis: DBMS_OUTPUT.PUT_LINE

-- endregion

-- User: OE

-- region PLSQL Programm
declare
    -- Deklarationsteil
    TYPE PROJECT_FUNDING_TYPE IS RECORD (
         project_id      OE.PROJECTS.PROJECT_ID%TYPE NOT NULL DEFAULT 0,
         title           OE.PROJECTS.TITLE%TYPE NOT NULL DEFAULT 'no data',
         project_type    VARCHAR2(40) NOT NULL DEFAULT 'no data',
         project_funding OE.PROJECT_DEBITORS.AMOUNT%TYPE NOT NULL DEFAULT 0
    );

    TYPE PROJECT_FUNDING_TABLE_TYPE is TABLE OF PROJECT_FUNDING_TYPE;
    -- Variablendefinition

    l_project_fundings PROJECT_FUNDING_TABLE_TYPE := PROJECT_FUNDING_TABLE_TYPE();
BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.1) Records, Tables');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    l_project_fundings.extend;
    l_project_fundings(1).project_id := 1;
    l_project_fundings(1).project_type := 'REQUEST_FUNDING_PROJECT';
    l_project_fundings(1).title := 'Finite Elemente in der Computersimulation';
    l_project_fundings(1).project_funding := 3400;

    l_project_fundings.extend;
    l_project_fundings(2).project_id := 12;
    l_project_fundings(2).project_type := 'RESEARCH_FUNDING_PROJECT';
    l_project_fundings(2).title := 'Inselaufschüttung';
    l_project_fundings(2).project_funding := 12000;

    for i in l_project_fundings.first..l_project_fundings.LAST
        loop
            DBMS_OUTPUT.PUT_LINE(l_project_fundings(i).project_id ||
                                 ' ' ||
                                 l_project_fundings(i).title ||
                                 ' ' ||
                                 l_project_fundings(i).project_type ||
                                 ' ' ||
                                 l_project_fundings(i).project_funding);
        end loop;

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
-- endregion

-- endregion

-- ---------------------------------------------------------------------- -
-- 1.2) Beispiel: PLSQL Block, for Schleife  (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- Geben Sie fuer Projekte die folgenden Daten in der PLSQL Konsole aus.
-- Ausgabe: PROJECT_ID, TITLE, PROJECT_TYPE, PROJECT_FUNDING

-- Hinweis: Verwenden Sie fuer den Datenzugriff einen impliziten Cursor.

-- @PROJECT_TYPE: Beschreibt den Projekttyp eines Projekts. Die moeglichen
--                Projekttypen sind: REQUEST_FUNDING_PROJECT,
--                                   RESEARCH_FUNDING_PROJECT,
--                                   MANAGEMENT_PROJECT

-- @PROJECT_FUNDING: Die Projektfoerderung berechnet sich als Summe
--                   der einzelnenen Zuwendungen der Geldgeber (PROJECT_DEBITORS)

-- Tabellen: PROJECTS, REQUEST_FUNDING_PROJECTS, RESEARCH_FUNDING_PROJECT
--           MANAGEMENT_PROJECT, PROJECT_DEBITORS

-- User: OE

-- region PLSQL Programm
DECLARE
    -- Deklarationsteil

BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.2) for loop');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    for row in (with PROJECT_FUNDING AS (select sum(pd.AMOUNT) PROJECT_FUNDING, p.PROJECT_ID
                                         from PROJECTS p
                                                  join PROJECT_DEBITORS pd on p.PROJECT_ID = pd.PROJECT_ID
                                         group by p.PROJECT_ID)
                SELECT p.PROJECT_ID,
                       p.TITLE,
                       case
                           when MP.MANAGEMENT_DUTY IS NOT NULL then 'MANAGEMENT_PROJECT'
                           when rfp.IS_SMALL_PROJECT is not null then 'REQUEST_FUNDING_PROJECT'
                           when r.IS_EU_SPONSORED is not null then 'RESEARCH_FUNDING_PROJECT'
                           end                         as PROJECT_TYPE,
                       coalesce(pf.PROJECT_FUNDING, 0) AS PROJECT_FUNDING
                FROM PROJECTS p
                         LEFT JOIN MANAGEMENT_PROJECTS MP on p.PROJECT_ID = MP.PROJECT_ID
                         LEFT JOIN REQUEST_FUNDING_PROJECTS RFP on P.PROJECT_ID = RFP.PROJECT_ID
                         LEFT JOIN RESEARCH_FUNDING_PROJECTS R on P.PROJECT_ID = R.PROJECT_ID
                         LEFT JOIN PROJECT_FUNDING pf on p.PROJECT_ID = pf.PROJECT_ID)
        Loop
            SYS.DBMS_OUTPUT.PUT_LINE(
                        row.PROJECT_ID || ' ' || row.TITLE || ' ' || row.PROJECT_TYPE || ' ' || row.PROJECT_FUNDING);
        end loop;

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
-- endregion

-- endregion

-- ---------------------------------------------------------------------- -
-- 1.3) Beispiel: DDL Statements  (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- region a) Erzeugen Sie eine Tabelle PROJECT_REPORTS mit der folgenden
--           Struktur. Pruefen Sie ob die Tabelle existiert bevor Sie die
--           Tabelle anlegen.


-- project_id       NUMBER(19,0)      NOT NULL   DEFAULT 0,
-- title            VARCHAR(100),
-- project_type     VARCHAR(40),
-- project_funding  NUMBER(10,2)      NOT NULL   DEFAULT 0

-- endregion

-- region b) Existiert die Tabelle, loeschen Sie alle Eintraege aus der
--           Tabelle

-- User: OE

-- region PLSQL Programm
-- Typdefinition
declare
    -- Konstantendefinition
    l_create_table_ddl constant varchar2(4000) := 'create table PROJECT_REPORTS (
         project_id      number(19,0) DEFAULT 1 NOT NULL ,
         title           VARCHAR(100),
         project_type    VARCHAR(40),
         project_funding NUMBER(10,2) DEFAULT 0 NOT NULL
    )';

    l_truncate_table_ddl constant varchar2(4000) := 'truncate table PROJECT_REPORTS';
    -- Variablendefinition

     l_table_exists number(1) default 0;
BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.3) DDL Statements');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    SELECT COUNT(TABLE_NAME)
    INTO L_TABLE_EXISTS
    FROM USER_TABLES
    WHERE LOWER(TABLE_NAME) = LOWER('PROJECT_REPORTS');

    IF l_table_exists = 0 THEN
        EXECUTE IMMEDIATE l_create_table_ddl;
        SYS.DBMS_OUTPUT.PUT_LINE('created table');
    else
        execute immediate l_truncate_table_ddl;
        sys.DBMS_OUTPUT.PUT_LINE('deleted data');
    end if;

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
-- endregion

-- endregion

-- ---------------------------------------------------------------------- -
-- 1.4) Beispiel: forall, bulk collect into  (1.Punkt)
-- ---------------------------------------------------------------------- -
-- region

-- region a) Ermitteln Sie fuer Projekte die folgenden Daten:
--           PROJECT_ID, TITLE, PROJECT_TYPE, PROJECT_FUNDING

--           Schreiben Sie die Daten zur weiteren Verarbeitung in eine interne
--           Tabelle.

-- @PROJECT_TYPE: Beschreibt den Projekttyp eines Projekts. Die moeglichen
--                Projekttypen sind: REQUEST_FUNDING_PROJECT,
--                                   RESEARCH_FUNDING_PROJECT,
--                                   MANAGEMENT_PROJECT

-- Tabellen: PROJECTS, REQUEST_FUNDING_PROJECTS, RESEARCH_FUNDING_PROJECT
--           MANAGEMENT_PROJECT, PROJECT_DEBITORS

-- endregion

-- region b) Schreiben Sie die Daten aus der internen Tabelle in die
--           PROJECT_REPORTS Tabelle. Loeschen Sie zuvor alle Daten der
--           PROJECT_REPORTS Tabelle.

-- endregion

-- User: OE

DECLARE
    -- Typdefinition
    TYPE PROJECT_REPORT_TYPE IS TABLE OF PROJECT_REPORTS%ROWTYPE;

    -- Variablendefinition
    l_project_reports PROJECT_REPORT_TYPE := PROJECT_REPORT_TYPE();
BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.4) bulk collect, forall');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    with PROJECT_FUNDING AS (select sum(pd.AMOUNT) PROJECT_FUNDING, p.PROJECT_ID
                             from PROJECTS p
                                      join PROJECT_DEBITORS pd on p.PROJECT_ID = pd.PROJECT_ID
                             group by p.PROJECT_ID)
    SELECT p.PROJECT_ID,
           p.TITLE,
           case
               when MP.MANAGEMENT_DUTY IS NOT NULL then 'MANAGEMENT_PROJECT'
               when rfp.IS_SMALL_PROJECT is not null then 'REQUEST_FUNDING_PROJECT'
               when r.IS_EU_SPONSORED is not null then 'RESEARCH_FUNDING_PROJECT'
               end                         as PROJECT_TYPE,
           coalesce(pf.PROJECT_FUNDING, 0) AS PROJECT_FUNDING
        bulk collect
    into l_project_reports
    FROM PROJECTS p
             LEFT JOIN MANAGEMENT_PROJECTS MP on p.PROJECT_ID = MP.PROJECT_ID
             LEFT JOIN REQUEST_FUNDING_PROJECTS RFP on P.PROJECT_ID = RFP.PROJECT_ID
             LEFT JOIN RESEARCH_FUNDING_PROJECTS R on P.PROJECT_ID = R.PROJECT_ID
             LEFT JOIN PROJECT_FUNDING pf on p.PROJECT_ID = pf.PROJECT_ID;

    for i in l_project_reports.first..l_project_reports.LAST
        loop
            DBMS_OUTPUT.PUT_LINE(l_project_reports(i).title || ' ' || l_project_reports(i).project_funding);
        end loop;

    delete from PROJECT_REPORTS where 1 = 1;

    forall i in l_project_reports.first..l_project_reports.LAST
        insert into PROJECT_REPORTS values l_project_reports(i);

    commit;

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;

-- endregion

-- ---------------------------------------------------------------------- -
-- 1.5) Beispiel: explizite Cursor (2.Punkte)
-- ---------------------------------------------------------------------- -
-- region

-- region a) Verwenden Sie eine expliziten Cursor um die Daten der
--           PROJECT_HAS_STATES_JT Tabelle in der Datenbankkonsole auszugeben.

--           In jedem Schleifendurchlauf des Cursors sollen dabei immer
--           10 Datensaetze verarbeitet werden

-- endregion

DECLARE
    -- Deklarationsteil

    -- Typendefinition

    -- Variablendefinition

    -- 1.) Cursor definieren
BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.5) ');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    -- 2.) Cursor oeffnen

    -- 3.) Datenzugriff

    -- 4.) Ressourcen freigeben

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;

-- endregion
