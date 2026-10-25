-- ----------------------------------------------------------
-- 1.1) Beispiel - Grundlagen
-- ----------------------------------------------------------

-- Grundlagen:

-- PL/SQL als Programmiersprache stellt eine prozedurale
-- Erweiterung der SQL Sprachspezifikation dar.

-- PL/SQL Programme haben einen direkten Zugriff auf die
-- Strukturen und Daten einer Datenbank

-- Damit können Teile der Anwendunglogik vom Applikation-
-- server in den Datenbankserver verlagert werden. Die
-- Verlagerung der Anwendungslogik auf den Datenbankserver
-- resultiert dabei in einer signifikanten Steigerung des
-- der Verarbeitungsgeschwindigkeit datenzentrierter An-
-- wendungen.

-- Zur Ausfuehrung der eines PL/SQL Programms verwendet ver-
-- wendet eine Datenbank ein eigenes Programm die PL/SQL
-- Engine


-- Aufgabe: Schreiben Sie ein Programm, welches hallo welt
--          in der Konsole ausgibt.

BEGIN
    SYS.DBMS_OUTPUT.PUT_LINE('hallo welt');
END;
/

-- ----------------------------------------------------------
-- 1.2) Beispiel - Datentypen: einfache Datentypen
-- ----------------------------------------------------------

-- Grundlagen:

-- Ein PL/SQL Programm stellt ein freie Abfolge von PL/SQL
-- Anweisungen und SQL Befehlen dar.

-- PL/SQL als Programmiersprache wird den Block orientierten
-- Programmiersprachen zugerechnet.

-- Das grundlegende Element eines PL/SQL ist der PL/SQL Block.
-- Bloecke werden zur Codestrukturierung und Programmausfuehrung
-- verwendet.

-- Strukturell gliedert sich ein PL/SQL Block in 3 Teile:

--     Deklarationsteil (optional)
--     Ausfuehrungsteil (obligatorisch)
--     Fehlerbehandlungsteil (optional)


-- Aufgabe: Deklarieren Sie die Variablen project_title und
--          project_description. Initialisieren Sie die Variablen
--          und geben Sie sie in der Konsole aus.

--          Deklarieren Sie eine Konstante fuer die Ueberschrift
--          des Beispiels.

--          Deklarieren Sie die Variablen IS_FWF_SPONSORED und
--          IS_FFG_SPONSORED. Initialisieren Sie die Varialblen
--          jeweils als true.

--          Deklarieren Sie die Variable PROJECT_START und PROJECT_END.
--          Bei beiden Variablen handelt es sich um Datumswerte. Ini-
--          tialisieren Sie die Variablen und geben Sie sie in der
--          Konsole aus.

--          Deklarieren Sie eine Variable PROJECT_FUNDING. Bei der
--          Foerderung handelt es sich um einen numerischen Wert.
--          Initialisieren Sie den Werte und geben Sie den Werte in
--          der Konsole aus.

--          Deklarieren Sie eine Variable PROJECT_RATING. Die Variable
--          darf nur Werte zwischen 1 und 5 annehmen.

DECLARE
    -- Deklarationsteil
    -- Konstantendeklaration
    LC_HEADER CONSTANT VARCHAR2(20) NOT NULL := 'Basic Concepts';

    -- Variablendeklaration
    L_PROJECT_TITLE    VARCHAR2(50) NOT NULL DEFAULT 'title';
    L_DESCRIPTION      VARCHAR2(4000) NOT NULL DEFAULT 'description';
    L_IS_FWF_SPONSORED BOOLEAN NOT NULL DEFAULT false;
    L_IS_FFG_SPONSORED BOOLEAN NOT NULL DEFAULT false;
    L_PROJECT_START    DATE NOT NULL DEFAULT SYSDATE;
    L_PROJECT_END      DATE NOT NULL DEFAULT ADD_MONTHS(L_PROJECT_START, 12);
    L_PROJECT_FUNDING  NUMBER(10, 2) NOT NULL DEFAULT 10000;
    L_PROJECT_RATING   NATURAL RANGE 1..5 NOT NULL DEFAULT 1;

BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.2) ');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');


    SYS.DBMS_OUTPUT.PUT_LINE(
                'DATA'
                || CHR(13)
                || 'FWF FUNDING: ' || sys.DIUTIL.BOOL_TO_INT(L_IS_FWF_SPONSORED)
                || CHR(13)
                || 'FFG FUNDING: ' || SYS.DIUTIL.BOOL_TO_INT(L_IS_FFG_SPONSORED)
                || CHR(13)
                || 'PROJECT FUNDING: ' || L_PROJECT_FUNDING
                || CHR(13)
                || 'PROJECT START: ' || TO_CHAR(L_PROJECT_START, 'DD.MM.YYYY')
                || CHR(13)
                || 'PROJECT END: ' || TO_CHAR(L_PROJECT_END, 'DD.MM.YYYY')
                || CHR(13)
                || 'PROJECT RATING: ' || L_PROJECT_RATING
        );

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/

-- ----------------------------------------------------------
-- 1.3) Beispiel - Datentypen: strukturierte Datentypen
-- ----------------------------------------------------------

-- Grundlagen:

-- Strukturierte Datentypen ermoegliechen es logisch zusammen-
-- haengende Variablen zu einem strukturellen Verbund zu ver-
-- binden.

-- Ein Record ist eine Variable mit einem strukturiertem
-- Datentyp.

-- Records werden zur Verarbeitung von Datensaetzen verwendet.

-- Bevor ein Record verwendet werden kann muss fuer den Record
-- ein strukturierten Datentyp definiert werden.

-- Aufgabe: Definieren Sie zur Verarbeitung von Projektdaten-
--          saetzen einen Record. Der Record soll folgende
--          Variablen verwalten koennen:

--   PROJECT_TITLE       VARCHAR2 (100)      NOT NULL
--   DESCRIPTION         VARCHAR2 (4000)     NOT NULL
--   IS_FFG_SPONSORED    BOOLEAN             NOT NULL DEFAULT TRUE
--   IS_FFW_SPONSORED    BOOLEAN             NOT NULL DEFAULT TRUE
--   PROJECT_START       DATE                NOT NULL
--   PROJECT_FUNDING     NUMBER(10,2)        NOT NULL
--   PROJECT_RATING      NATURAL             NOT NULL DEFAULT 1;

DECLARE
    -- Deklarationsteil

    -- Typdefinitionen
    TYPE PROJECT_TYPE
        IS RECORD
           (
               PROJECT_TITLE    VARCHAR2(100) NOT NULL,
               DESCRIPTION      VARCHAR2(4000) NOT NULL,
               IS_FFG_SPONSORED BOOLEAN NOT NULL DEFAULT TRUE,
               IS_FFW_SPONSORED BOOLEAN NOT NULL DEFAULT TRUE,
               PROJECT_START    DATE NOT NULL,
               PROJECT_FUNDING  NUMBER(10, 2) NOT NULL,
               PROJECT_RATING   NATURAL NOT NULL DEFAULT 1
           );


    /*TYPE PROJECT_REC_T
        IS RECORD
           (
               PROJECT_TITLE    VARCHAR2(100),
               DESCRIPTION      VARCHAR2(4000),
               IS_FFG_SPONSORED BOOLEAN NOT NULL DEFAULT TRUE,
               IS_FFW_SPONSORED BOOLEAN NOT NULL DEFAULT TRUE,
               PROJECT_START    DATE NOT NULL DEFAULT SYSDATE,
               PROJECT_FUNDING  NUMBER(10, 2) NOT NULL DEFAULT 0,
               PROJECT_RATING   NATURAL RANGE 1..5 DEFAULT 1
           );*/

    -- Variablendeklaration
    L_PROJECT PROJECT_TYPE;
BEGIN
    -- Ausfuehrungsteil

    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.3)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    L_PROJECT.PROJECT_TITLE := 'Finite Elemente';
    L_PROJECT.DESCRIPTION := 'Lorem Ipsum ...';
    L_PROJECT.IS_FFW_SPONSORED := true;
    L_PROJECT.IS_FFG_SPONSORED := false;
    L_PROJECT.PROJECT_FUNDING := 65000;
    L_PROJECT.PROJECT_RATING := 4;

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
    SYS.DBMS_OUTPUT.PUT_LINE(
                'Project data'
                || chr(13)
                || 'title: ' || L_PROJECT.PROJECT_TITLE
                || chr(13)
                || 'description: ' || L_PROJECT.DESCRIPTION
                || chr(13)
                || 'fwf, ffg: ' || SYs.DIUTIL.BOOL_TO_INT(L_PROJECT.IS_FFW_SPONSORED) || ' ' ||
                SYS.DIUTIL.BOOL_TO_INT(L_PROJECT.IS_FFW_SPONSORED)
                || chr(13)
                || 'project start: ' || TO_CHAR(L_PROJECT.PROJECT_START, 'dd.mm.yyyy')
                || chr(13)
                || 'funding: ' || L_PROJECT.PROJECT_FUNDING
        );
END;
/

-- ----------------------------------------------------------
-- 1.4) Beispiel - Datentypen abgeleitete Datentypen
-- ----------------------------------------------------------

-- Grundlagen:

-- Bei der Definition einer Variable kann alternativ zur An-
-- gabe eines Datentyps, der Datentyp einer Variable auch
-- implizit referenziert werden.

-- Mit den %TYPE bzw. %ROWTYPE Attributen kann der Datentyp
-- von Variablen implizit referenziert werden.


-- Angabe: Legen Sie eine Variable LAST_NAME an. Referenzieren Sie
--         dazu den Typ der der CUSTOMER_CC->LAST_NAME Spalte.

--         Definieren Sie anschliessend einen Record zur
--         Verarbeitung von CUSTOMER_CC Datensaetzen.

DECLARE
    -- Deklarationsteil
    L_SHIP_NAME   SHIPS.NAME%type;
    L_CRUISE_NAME CRUISES.LABEL%type;
    L_CRUISE      CRUISES%rowtype;

BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.4)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    L_SHIP_NAME := 'WTF Pani';
    L_CRUISE_NAME := 'Golden Cruise';

    L_CRUISE.CRUISE_ID := 1;
    L_CRUISE.DATE_OF_ARRIVAL := TO_DATE('3.9.1992', 'dd.mm.yyyy');

    SYS.DBMS_OUTPUT.PUT_LINE(
                'DATA: '
                || chr(13)
                || 'ship name: ' || L_SHIP_NAME
                || chr(13)
                || 'cruise name: ' || L_CRUISE_NAME
                || chr(13)
                || 'cruiseID: ' || L_CRUISE.CRUISE_ID
                || chr(13)
                || 'arriaval: ' || TO_CHAR(L_CRUISE.DATE_OF_ARRIVAL, 'dd.mm.yyyy')
        );


    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/

-- ----------------------------------------------------------
-- 1.5) Beispiel - Datentypen: Collection von Werten
-- ----------------------------------------------------------

-- Grundlagen:

-- Bevor eine Liste benutzt werden kann muss der Datentyp der
-- Liste definiert werden.

-- Listen werden in PL/SQL als Interne Tabllen bezeichnet

-- Angabe: Definieren Sie eine Interne Tabelle zur Verwaltung
--         von Integern. Speichern Sie die Werte 5,6,7 und
--         geben Sie sie aus.

DECLARE
    -- Deklarationsteil

    -- Typendefinitionen
    TYPE PROJECT_RATING_TYPE IS TABLE OF NATURAL;
    type PROJECT_MEMBER_TYPE IS TABLE OF varchar2(100);

    -- Variablen
    L_PROJECT_RATINGS PROJECT_RATING_TYPE := PROJECT_RATING_TYPE();
    L_PROJECT_MEMBERS PROJECT_MEMBER_TYPE := PROJECT_MEMBER_TYPE('Luki', 'Nagi');
BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.5)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    L_PROJECT_RATINGS.extend;
    L_PROJECT_RATINGS(1) := 3;

    L_PROJECT_RATINGS.extend;
    L_PROJECT_RATINGS(2) := 7;

    SYS.DBMS_OUTPUT.PUT_LINE(
                'DATA: '
                || CHR(13)
                || L_PROJECT_RATINGS(1) || ' ' || L_PROJECT_RATINGS(2)
                || chr(13)
                || L_PROJECT_MEMBERS(1) || ' ' || L_PROJECT_MEMBERS(2)
        );

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/

-- ----------------------------------------------------------
-- 1.6) Beispiel - Datentypen: Listen von Werten
-- ----------------------------------------------------------

-- Angabe: Definieren Sie eine Interne Tabelle zur Verwaltung
--         von EMPLOYEES

--         Geben Sie den Inhalt der Internen Tabelle in einer
--         Schleife aus.

DECLARE
    -- Deklarationsteil

    -- Typendefinitionen
    TYPE CRUISE_TYPE IS TABLE OF CRUISES%ROWTYPE;

    -- Variablen
    L_CRUISES CRUISE_TYPE := CRUISE_TYPE();
BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 1.6)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    -- Bevor ein Datensatz eingetragen werden kann muss
    -- Speicherplatz reserviiert werden.

    -- 1 Datensatz
    L_CRUISES.extend;
    L_CRUISES(1).CRUISE_ID := 1;
    L_CRUISES(1).LABEL := 'Down under';

    -- 2 Datensatz
    L_CRUISES.extend;
    L_CRUISES(2).CRUISE_ID := 3;
    L_CRUISES(2).LABEL := 'alora alora';

    for i in L_CRUISES.FIRST..L_CRUISES.LAST
        Loop
            sys.DBMS_OUTPUT.PUT_LINE(L_CRUISES(i).LABEL);
        end loop;

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/

-- ----------------------------------------------------------
-- 2.1) Beispiel - PL/SQL Befehle: DQL Statements
-- ----------------------------------------------------------
-- Angabe: Geben Sie den Vor- und Nachnamen des Angestellten
--         mit der employee_id 100 aus

DECLARE
    -- Deklarationsteil

    -- Variablen
    L_CRUISE_ID    CRUISES.CRUISE_ID%type;
    L_CRUISE_LABEL CRUISES.LABEL%type;

BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 2.1)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    SELECT C.CRUISE_ID, C.LABEL
    INTO L_CRUISE_ID, L_CRUISE_LABEL
    FROM CRUISES C
    WHERE C.CRUISE_ID = 1;

    sys.DBMS_OUTPUT.PUT_LINE(
                'data: '
                || chr(13)
                || L_CRUISE_ID || ' ' || L_CRUISE_LABEL
        );

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/

-- ----------------------------------------------------------
-- 2.2) Beispiel - PL/SQL Befehle:  DQL Statements
-- ----------------------------------------------------------
-- Angabe: Geben Sie die ersten 50 Datensaetze der employees
--         Tabelle aus.


DECLARE
    -- Deklarationsteil

    -- Typendefinition
    TYPE CRUISE_TYPE IS TABLE OF CRUISES%ROWTYPE;

    -- Variablen
    L_CRUISES CRUISE_TYPE := CRUISE_TYPE();

BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 2.2)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    SELECT *
    BULK COLLECT INTO L_CRUISES
    FROM CRUISES C
    WHERE ROWNUM < 21;

    FOR I IN L_CRUISES.FIRST..L_CRUISES.LAST
        LOOP
            SYS.DBMS_OUTPUT.PUT_LINE(
                    'CRUISE: ' || L_CRUISES(I).CRUISE_ID || ' ' || L_CRUISES(I).LABEL
                );
        END LOOP;

    FOR CRUISE IN (SELECT * FROM CRUISES)
        LOOP
            SYS.DBMS_OUTPUT.PUT_LINE(CRUISE.LABEL);
        END LOOP;

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/

-- ----------------------------------------------------------
-- 2.3) Beispiel - PL/SQL Befehle:  DDL Statements
-- ----------------------------------------------------------
-- Angabe: Erstellen Sie die fuer weitere Berechnungen die
--         CRUISE_REPORTS Tabelle.

--         Erstellen Sie die Tabelle jedoch nur wenn Sie nicht
--         bereits existiert. Existiert die Tabelle, loeschen
--         Sie die enthaltenen Daten.

DECLARE
    -- Deklarationsteil

    -- Constanten
    l_create_table_ddl   constant varchar2(400) :=
        'CREATE TABLE CRUISE_REPORTS (
            CRUISE_ID NUMBER(19,0) NOT NULL,
            LABEL     VARCHAR(100) NOT NULL,
            BOOKING_COUNT  NUMBER(4) NOT NULL,
            DATE_OF_REPORT DATE DEFAULT SYSDATE NOT NULL,
            PRIMARY KEY (CRUISE_ID)
        )';
    l_truncate_table_ddl CONSTANT varchar2(400) :=
        'TRUNCATE TABLE CRUISE_REPORTS';

    -- Variablen
    L_IS_TABLE_PRESENT NUMBER(1);

BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 2.3)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    SELECT count(*)
    INTO L_IS_TABLE_PRESENT
    FROM USER_TABLES ut
    WHERE ut.TABLE_NAME = 'CRUISE_REPORTS';

    IF L_IS_TABLE_PRESENT = 0 THEN
        EXECUTE IMMEDIATE l_create_table_ddl;
    ELSE
        EXECUTE IMMEDIATE l_truncate_table_ddl;
    END IF;

    SELECT count(*)
    INTO L_IS_TABLE_PRESENT
    FROM USER_TABLES ut
    WHERE ut.TABLE_NAME = 'CRUISE_REPORTS';

    SYS.DBMS_OUTPUT.PUT_LINE(L_IS_TABLE_PRESENT);

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/
-- ----------------------------------------------------------
-- 2.4) Beispiel - PL/SQL Befehle:  DML Statements
-- ----------------------------------------------------------
-- Das Berichtwesen umfasst alle Einrichtungen Mittel und Mass-
-- nahmen eines Unternehmens zur Erarbeitung, Verarbeitung und
-- Speicherung von Informationen in Form von Berichten.

-- Zur Beurteilung der Unternehmensleistung werden dazu die
-- Eckdaten des Unternehmens periodisch (monatlich, woechentlich,
-- taeglich) erfasst.

-- Angabe: Legen Sie die Tabelle CRUISE_REPORTS_STAGING an. Sollte
--         die Tabelle bereits existieren loeschen Sie alle Daten
--         der Tabelle.

CREATE TABLE CRUISE_REPORTS_STAGING (
            REPORT_ID NUMBER(19,0) ,
            CRUISE_ID NUMBER(19,0)  NOT NULL,
            LABEL     VARCHAR(100)  NOT NULL,
            BOOKING_COUNT NUMBER(4) NOT NULL,
            DATE_OF_REPORT DATE    DEFAULT SYSDATE NOT NULL,
            VERSION        INTEGER DEFAULT 0 NOT NULL,
            PRIMARY KEY (REPORT_ID)
        );

DECLARE
    -- Deklarationsteil
    -- Constantendeklaration
    L_CREATE_TABLE_DDL   CONSTANT VARCHAR2(700) :=
        'CREATE TABLE CRUISE_REPORTS_STAGING (
            REPORT_ID NUMBER(19,0) GENERATED BY DEFAULT ON NULL AS IDENTITY,
            CRUISE_ID NUMBER(19,0)  NOT NULL,
            LABEL     VARCHAR(100)  NOT NULL,
            BOOKING_COUNT NUMBER(4) NOT NULL,
            DATE_OF_REPORT DATE    DEFAULT SYSDATE NOT NULL,
            VERSION        INTEGER DEFAULT 0 NOT NULL,
            PRIMARY KEY (REPORT_ID)
        )';
    L_TRUNCATE_TABLE_DDL CONSTANT VARCHAR2(400) :=
        'TRUNCATE TABLE CRUISE_REPORTS_STAGING';

    -- Typdefinitionen
    TYPE CRUISE_REPORT_STAGING_TYPE
        IS RECORD
            (
                REPORT_ID NUMBER(19,0),
                CRUISE_ID NUMBER(19,0)  NOT NULL DEFAULT 1,
                LABEL     VARCHAR(100)  NOT NULL DEFAULT 'DEFAULT',
                BOOKING_COUNT NUMBER(4) NOT NULL DEFAULT 0,
                DATE_OF_REPORT DATE     NOT NULL DEFAULT SYSDATE,
                VERSION        INTEGER  NOT NULL DEFAULT 0
            );

    TYPE CRUISE_REPORTS_TYPE IS TABLE OF CRUISE_REPORT_STAGING_TYPE;

    -- Variablen
    L_EXISTS NUMBER(1) NOT NULL DEFAULT 0;
    L_CRUISE_REPORTS CRUISE_REPORTS_TYPE;
BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 2.4)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    SELECT count(*)
    INTO L_EXISTS
    FROM USER_TABLES
    WHERE TABLE_NAME = 'CRUISE_REPORTS_STAGING';

    IF L_EXISTS = 0 THEN
        EXECUTE IMMEDIATE L_CREATE_TABLE_DDL;
    ELSE
        EXECUTE IMMEDIATE L_TRUNCATE_TABLE_DDL;
    END IF;

    WITH BOOKING_REPORT AS (SELECT CHB.CRUISE_ID, COUNT(CHB.BOOKING_ID) BOOKING_COUNT
                            FROM CRUISE_HAS_BOOKINGS_JT CHB
                            GROUP BY CHB.CRUISE_ID)
    SELECT ROWNUM,
           C.CRUISE_ID,
           C.LABEL,
           COALESCE(BR.BOOKING_COUNT, 0),
           SYSDATE,
           0
    BULK COLLECT INTO L_CRUISE_REPORTS
    FROM CRUISES C
             LEFT JOIN BOOKING_REPORT BR ON C.CRUISE_ID = BR.CRUISE_ID;

    FORALL I IN L_CRUISE_REPORTS.FIRST..L_CRUISE_REPORTS.LAST
        INSERT INTO CRUISE_REPORTS_STAGING VALUES L_CRUISE_REPORTS(I);
    COMMIT;

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/

-- ----------------------------------------------------------
-- 2.5) Beispiel - PL/SQL Befehle:  DDL Statements
-- ----------------------------------------------------------
-- Angabe: Fuegen Sie eine Spalte VERSION zur CRUISE_REPORTS
--         Tabelle hinzu falls diese noch nicht existiert.

DECLARE
    -- Deklarationsteil

    -- Constanten
    L_UPDATE_TABLE_DDL CONSTANT VARCHAR2(400) :=
        'ALTER TABLE CRUISE_REPORTS ADD VERSION INTEGER DEFAULT 0 NOT NULL ';

    -- Variablen
    L_COLUMN_EXISTS NUMBER(1) NOT NULL DEFAULT 0;

BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 2.5)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    SELECT count(*)
    INTO L_COLUMN_EXISTS
    FROM USER_TAB_COLUMNS
    WHERE TABLE_NAME = 'CRUISE_REPORTS' AND COLUMN_NAME = 'VERSION';

    IF L_COLUMN_EXISTS = 0 THEN
        EXECUTE IMMEDIATE L_UPDATE_TABLE_DDL;
    end if;

    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/

-- ----------------------------------------------------------
-- 3.1) Beispiel - Cursor: implizite Cursor
-- ----------------------------------------------------------
-- Bevor die Daten einer Datenbank verarbeitet werden koennen,
-- muessen Sie in die Kontextarea der plsql Engine geladen
-- werden.

-- Als Kontextarea wird jener Bereich des Arbeitsspeichers
-- bezeichnet, der für die Ausführung von SQL Anweisungen
-- reserviert ist.

-- Fuer den Zugriff auf die Daten der Kontextarea werden in
-- plsql Cursor verwendet. Ein Cursor ermoeglicht die
-- zeilenweise Verarbeitung der gewuenschten Datensaetze.

-- Bei Cursorn unterscheidet man zwischen expliziten und
-- impliziten Cursorn.

-- implizite Cursor: for Schleife
-- explizite Cursor: Cursor Block

-- Differenzierung: Je nach Anwendungsfall werden unter-
--                  schiedliche Formen des Cursors eingesetzt

--  Datenquelle mit 0 - 200   -> SELECT BULK COLLECT INTO
--  Datenquelle mit 0 - 1000  -> FOR Schleife
--  Datenquelle > 1000        -> CURSOR MIT SELECT BULK COLLECT

-- Angabe: Geben Sie Datensaetze der CRUISE_REPORSTS_STAGING
--         Tabelle aus.

--         Ausgabe: CRUISE_ID, LABEL , BOOKING_COUNT

--         Hinweis: Verwenden Sie die FOR Schleife

DECLARE
    -- Deklarationsteil

    -- Typdefinitionen

    -- Variablendefinitionen
BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 3.1)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    SYS.DBMS_OUTPUT.PUT_LINE('report output');


    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/
-- ----------------------------------------------------------
-- 3.2) Beispiel - Cursor: Explizite Cursor
-- ----------------------------------------------------------
-- Mit expliziten Cursorn koennen grosse Mengen von Daten
-- einfach und schnell verarbeitet werden.

-- Bevor ein Cursor verwendet werden kann muss er explizit
-- im Deklarationsteil definiert werden.

-- Fuer den Datenzugriff mit expliziten Cursorn muessen dabei
-- 4 Schritte durchgefuehrt werden:

-- 1.Phase) CURSOR Declaration
-- 2.Phase) CURSOR Initialisation
-- 3.Phase) DATA Access
-- 4.Phase) Release CURSOR

-- Angabe: Geben Sie alle CARD_TRANSACTIONS_JT Datensaetze aus.

-- Ausgabe: TRANSACTION_ID, CARD_ID, ACCOUNT_ID

DECLARE
    -- Deklarationsteil

    -- Variablendefinitionen


BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 3.2)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));


    SYS.DBMS_OUTPUT.PUT_LINE('fetched data');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/

-- ----------------------------------------------------------
-- 3.3) Beispiel - Cursor: Explizite Cursor
-- ----------------------------------------------------------
-- Angabe: Geben Sie alle CARD_TRANSACTIONS_JT Datensaetze aus.

-- Ausgabe: TRANSACTION_ID, CARD_ID, ACCOUNT_ID

DECLARE
    -- Deklarationsteil

    -- Typdefinition


    -- Variablendefinitionen


BEGIN
    -- Ausfuehrungsteil
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE('-- Exercise 3.3)');
    SYS.DBMS_OUTPUT.PUT_LINE('-- ----------------------------------------------- --');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));

    -- 2.Phase) CURSOR Initialisation


    -- 3.Phase) Data Access


    -- 4.Phase) Release resources


    SYS.DBMS_OUTPUT.PUT_LINE('fetched data');
    SYS.DBMS_OUTPUT.PUT_LINE(chr(13));
END;
/
