----------------------------------------------------------------------------
/*
    1 - Create Table(s) and Temp Tables

    1.1 Table Creation

    To create a table, we must pursue the following points;

    - Specify the name of the DB if you aren't already using one.

    - Specify the schema to which the new table belongs. (the table would go into the default "dbo" schema in default otherwise)
        Schema: gathering up db concepts and objects related to one another under the same roof

    - Specify the name of the table

    - Each table should have a primary key which consists of one or more columns.
    It is common to list the primary key (as a composite key of multiple keys if so) and then the other attributes

    - The data type of each attribute that will be associated with fields under must be specified right after attribute name

    -Attributes might have multiple constraints like "not null" and unique

    -A table may have constraints specified in the table constraints section such as "foreign key", "primary key", "unique" and "check".


    CREATE TABLE Declaration Prototype

    CREATE TABLE [database_name.][schema_name.]table_name
    ( pk_column data_type PRIMARY KEY,
    column_1 data_type NOT NULL,
    column_2 data_type,
    ...,
    table_constraints );


    CREATE table example

    • CREATE TABLE sales.visits ( //We did not specify the db name cuz we ld have to also type the schema name here.
    visit_id INT PRIMARY KEY IDENTITY (1, 1), //Our visit_id attribute is the primary key in the identity type
    //Identity type gets populated by SQL Server Engine. (1.1) means that the identification will start from 1 and increase by 1 for each record.
    first_name VARCHAR (50) NOT NULL,
    last_name VARCHAR (50) NOT NULL,
    visited_at DATETIME, phone VARCHAR(20),
    store_id INT NOT NULL,
    FOREIGN KEY (store_id) REFERENCES sales.stores (store_id) ); //After the declaration in the previous line, we are declaring
    //that it is a foreign key, assigned to the store_id primary key of the table sales.stores


    1.2 Temp Tables

    - A temp table stores a subset of data from a normal table for a certain period of time.
    - Instead of fetching particular data from a table with filters again and again, you can utilize from this,
    creating tables saved in the "tempdb" (a system db in the disk) rather than in the db. The data in the tempdb is lost
    once the server is restarted.

    -- Method 1: CREATE TABLE + INSERT INTO
    -- Define the structure manually, then populate it.

    CREATE TABLE #temp_table_name
    ( column_1 data_type NOT NULL,
      column_2 data_type,
      ... );

    INSERT INTO #temp_table_name (column_1, column_2, ...)
    SELECT column_1, column_2, ...
    FROM source_table
    WHERE condition;


    -- Method 2: SELECT INTO (faster & shorter)
    -- Structure is inferred automatically from the SELECT result.
    -- No need to define columns manually.

    SELECT column_1, column_2, ...
    INTO #temp_table_name
    FROM source_table
    WHERE condition;


    Key notes on Temp Tables:

    - A single hash (#) prefix  --> Local temp table. Only visible in the current session.
    - A double hash (##) prefix --> Global temp table. Visible across all sessions until the
      last session using it is closed.
    - Temp tables are stored in the system database "tempdb" and are automatically dropped
      when the session ends (local) or when all sessions using it are closed (global).
    - You can also explicitly drop a temp table with: DROP TABLE #temp_table_name
    - Method 2 (SELECT INTO) is generally preferred for quick, one-off subsets of data
      since it saves you from manually specifying column types.
    - About square bracket syntax:
      - You can use square brackets to specify a table name that contains spaces or special characters.
      - You can also use square brackets to specify a table name that is not a valid identifier.
      - You can also use square brackets to specify a table name that is a reserved word.
        Many developers always use brackets as a habit since it makes the query bulletproof against naming conflicts,
    especially when working with databases where you don't control the naming conventions.































*/