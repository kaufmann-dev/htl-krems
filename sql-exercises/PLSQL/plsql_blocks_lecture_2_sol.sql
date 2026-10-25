-- ----------------------------------------------------------------------------
-- 1.1) Beispiel - Blocktypen: Packages, Prozeduren
-- ----------------------------------------------------------------------------
-- Grundlagen: Die PLSQL Spezifikation definiert mehrere Typen von
--             Bloecken.

-- 1.) Anonyme  Block
-- 2.) Prozdure Block
-- 3.) Function Block
-- 4.) Package  Block
-- 5.) Trigger  Block

-- Grundlagen: Ein Package fasst logisch zusammenhaengende Prozeduren und
--             Funktionen zu einer modularen Einheit zusammen.

-- PLSQL Packages werden zur Organisation und Strukturierung von PLSQL Programmen
-- verwendet.

-- PLSQL Packages werden in 2 Schritten definiert: Packagespezifikation und der
-- Packageimplementierung

-- 1.) Packagespezifikation: Die Packagespezifikation beschreibt die oeffentliche
--                           Schnittstelle eines Packages.

--     Syntax: CREATE [ OR REPLACE ] PACKAGE <pkg_name>
--             AS
--                ...
--             END [ pkg_name ]

-- 2.) Packageimplementierung: Die Packageimplementierung enthaelt die Implementierung
--                             der in der Spezifikation deklarierten Prozeduren und
--                             Funktionen

--      Syntax: CREATE [ OR REPLACE ] PACKAGE BODY <pkg_name>
--              AS
--                  ...
--                  ...
--              [ BEGIN ]
--              END [ pkg_name ]

-- Prozeduren Parametertypen

-- 1.) IN Parametertyp: IN Parameter verhalten sich in Unterprogrammen
--                      wie Initialisierte Konstante. In der Prozedur
--                      kann der Wert des Parameters gelesen jedoch
--                      nicht veraendert werden.

-- 2.) OUT Parametertyp: OUT Parameter verhalten sich in Unterprogrammen
--                       wie nicht initialisierte Variablen. Der Wert
--                       von OUT Parametern kann in Unterprogrammen ver-
--                       aendert aber nicht gelesen werden.

-- 3.) IN OUT Parametertyp: IN OUT Parameter verhalten sich in Unter-
--                          progarmmen wie initialisierte Variablen.


-- Angabe: Implementieren Sie den LOGGER Package Header


-- region a) Packagespezifikation

CREATE OR REPLACE PACKAGE LOGGER
AS
    -- DEKLARATIONSTEIL
    -- GLOBALE TYPEN
    -- GLOBALE VARIABLEN
    G_PACKAGE_ID LOGS.PACKAGE_ID%TYPE NOT NULL DEFAULT 'PACKAGE';
    G_METHOD_ID LOGS.METHOD_ID%TYPE NOT NULL DEFAULT 'METHOD';

    -- GLOGALE FUNKTONEN
    -- GLOBALE PROZEDUREN

    -- Überprüfen Sie ob folgende Tabellen bereits existieren:

    PROCEDURE LOG(
        P_PACKAGE_ID IN LOGS.PACKAGE_ID%type DEFAULT 'PACKAGE',
        P_METHOD_ID IN LOGS.METHOD_ID%type DEFAULT 'METHOD',
        P_MESSAGE IN LOGS.MESSAGE%type,
        P_TYPE IN LOGS.TYPE%TYPE DEFAULT 'INFO'
    );

    PROCEDURE INFO(P_MESSAGE IN LOGS.MESSAGE%type);

    PROCEDURE WARNING(P_MESSAGE IN LOGS.MESSAGE%type);

    PROCEDURE ERROR(P_MESSAGE IN LOGS.MESSAGE%type);

    PROCEDURE CLEAR;

END LOGGER;
/
-- endregion

-- region b) Packageimplementierung

CREATE OR REPLACE PACKAGE BODY LOGGER
AS
    -- Lokale Porzeduren

    -- INFO
    PROCEDURE INFO(P_MESSAGE IN LOGS.MESSAGE%type)
        IS
    BEGIN
        LOG(P_MESSAGE => P_MESSAGE, P_TYPE => 'INFO');
    END INFO;

    -- WARNING
    PROCEDURE WARNING(P_MESSAGE IN LOGS.MESSAGE%type)
        IS
    BEGIN
        LOG(P_MESSAGE => P_MESSAGE, P_TYPE => 'WARNING');
    END WARNING;

    PROCEDURE ERROR(P_MESSAGE IN LOGS.MESSAGE%type)
        IS
    BEGIN
        LOG(P_MESSAGE => P_MESSAGE, P_TYPE => 'ERROR');
    END ERROR;

    PROCEDURE LOG(
        P_PACKAGE_ID IN LOGS.PACKAGE_ID%type DEFAULT 'PACKAGE',
        P_METHOD_ID IN LOGS.METHOD_ID%type DEFAULT 'METHOD',
        P_MESSAGE IN LOGS.MESSAGE%type,
        P_TYPE IN LOGS.TYPE%TYPE DEFAULT 'INFO'
    )
    IS
    BEGIN
        IF P_PACKAGE_ID != 'PACKAGE' THEN
            G_PACKAGE_ID := P_PACKAGE_ID;
        END IF;

        IF P_METHOD_ID != 'METHOD' THEN
            G_METHOD_ID := P_METHOD_ID;
        END IF;

        INSERT INTO LOGS(PACKAGE_ID, METHOD_ID, MESSAGE, TYPE, CREATED_AT)
        VALUES (G_PACKAGE_ID, G_METHOD_ID, P_MESSAGE, P_TYPE,  sysdate);
        COMMIT;

        SYS.DBMS_OUTPUT.PUT_LINE('['|| G_PACKAGE_ID || ' - ' || G_METHOD_ID || ' ' ||  TO_CHAR(SYSDATE, 'dd.mm.yyyy hh24:mi:ss') || ']: ' || P_MESSAGE);
    END LOG;

    PROCEDURE CLEAR
    IS
    BEGIN
        DELETE FROM LOGS WHERE 1 = 1;
        COMMIT;
    END;

END LOGGER;
/

-- endregion

DECLARE
    -- Deklarationsteil

BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ------------------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.1) Packages, Procedures');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ------------------------------------------------------- --');

    LOGGER.CLEAR;
    LOGGER.LOG('MIGRATION','INIT','HALLO WELT','INFO');
    LOGGER.INFO('ROB OHREN');
END;
/

-- ----------------------------------------------------------------------------
-- 1.2) Beispiel - Blocktypen, Packages
-- ----------------------------------------------------------------------------


-- region a) Packagespezifikation

CREATE OR REPLACE PACKAGE PROJECT_SCHEMA_MIGRATION
AS
    -- DEKLARATIONSTEIL
    -- GLOBALE TYPEN
    TYPE PROJECT_TABLE_TYPE IS TABLE OF PROJECTS_ST%ROWTYPE;

    -- GLOGALE FUNKTINEN
    -- GLOBALE PROZEDUREN

    -- Überprüfen Sie ob folgende Tabellen bereits existieren:
    --
    PROCEDURE INIT;
    PROCEDURE MIGRATE;
    PROCEDURE RELEASE_RESOURCES;

END;
/
-- endregion

-- region b) Packageimplementierung

CREATE OR REPLACE PACKAGE BODY PROJECT_SCHEMA_MIGRATION
AS
    -- Lokale Porzeduren


    -- Globale Prozeduren
    -- INIT
    PROCEDURE INIT
        IS
    BEGIN
        LOGGER.LOG('LOGGER', 'INIT', 'initializing init process', 'INFO');
        LOGGER.INFO('deleting data');

        DELETE PROJECTS_ST WHERE 1 = 1;
        COMMIT;


        LOGGER.INFO('ending init process');
    END INIT;

    -- MIGRATE
    PROCEDURE MIGRATE
        IS
        CURSOR PROJECT_CUR is SELECT p.PROJECT_ID,
                                     CASE WHEN rfp.PROJECT_ID is not null THEN 'REQUEST_FUNDING_PROJECT'
                                          WHEN res.PROJECT_ID is not null THEN 'RESEARCH_FUNDING_PROJECT'
                                          WHEN m.PROJECT_ID is not null THEN 'MANAGEMENT_PROJECT'
                                     END PROJECT_TYPE,
                                     p.TITLE,
                                     p.DESCRIPTION,
                                     p.CREATED_AT,
                                     p.LEGAL_FOUNDATION,
                                     coalesce(res.IS_SMALL_PROJECT, 0),
                                     coalesce(rfp.IS_EU_SPONSORED, 0),
                                     coalesce(rfp.IS_FFG_SPONSORED, 0),
                                     coalesce(rfp.IS_FWF_SPONSORED, 0)
                              FROM PROJECT.PROJECTS_BT P
                                       LEFT JOIN PROJECT.RESEARCH_FUNDING_PROJECTS rfp on P.PROJECT_ID = rfp.PROJECT_ID
                                       LEFT JOIN PROJECT.REQUEST_FUNDING_PROJECTS res on P.PROJECT_ID = res.PROJECT_ID
                                       LEFT JOIN PROJECT.MANAGEMENT_PROJECTS m on P.PROJECT_ID = m.PROJECT_ID

                              ORDER BY rfp.PROJECT_ID;
        TYPE PR_TABLE_TYPE IS TABLE OF PROJECT_CUR%ROWTYPE;

        L_PROJECTS PROJECT_TABLE_TYPE := PROJECT_TABLE_TYPE();
    BEGIN
        LOGGER.LOG('LOGGER', 'MIGRATE', 'initializing migration process', 'INFO');

        OPEN PROJECT_CUR;

        LOOP
            FETCH PROJECT_CUR BULK COLLECT INTO L_PROJECTS LIMIT 10;
            EXIT WHEN PROJECT_CUR%NOTFOUND;

            FORALL I IN L_PROJECTS.FIRST..L_PROJECTS.LAST
                INSERT INTO PROJECTS_ST VALUES L_PROJECTS(I);

        END LOOP;

        CLOSE PROJECT_CUR;

        LOGGER.INFO('ending migration process');
    END MIGRATE;

    PROCEDURE RELEASE_RESOURCES
        IS
    BEGIN
        NULL;
    END RELEASE_RESOURCES;

END PROJECT_SCHEMA_MIGRATION;
/

-- endregion

DECLARE
    -- Deklarationsteil

BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ------------------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.2) Packages, Procedures');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ------------------------------------------------------- --');

    PROJECT_SCHEMA_MIGRATION.INIT;
    PROJECT_SCHEMA_MIGRATION.MIGRATE;
END;
/
