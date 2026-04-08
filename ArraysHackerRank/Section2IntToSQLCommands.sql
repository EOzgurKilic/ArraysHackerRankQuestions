/*
Types of SQL Statements
----------------------------------------|
DML -----> Data Manipulation Language   |
DDL -----> Data Definition Language     |
DCL -----> Data Control Language        |
TCL -----> Transaction Control Language |
----------------------------------------|


______________________________________________________________________________________________________________________________

    1. Data Manipulation Language Statements

Deals with data manipulation as its name suggests. The concept includes the most common SQL statements like Select,Insert, Update, Delete.

    1.1 SELECT Statements

Used to bring records from tables with or without conditions.

Exp: Select * from student where rank > 5  - Gets records with the condition where students' ranks are greater than 5.


    1.2 INSERT Statements

Used to insert a set of values into DB tables.

Insert into Student          (Rank, StudentName, Mark) Values (1,'Efe', 100)
        Name of the table     Attributes of the table       Respectively fields


    1.3 UPDATE Statements

Used to update existing records entirely or fields in tables based on conditions.

update student          set StudentName       ='Ozgur'        where StudentName='Imran'
    Name of the table      Attribute Name    the change         the field of the record
                                            in the field        that will be affected
                                            of the record


    1.4 DELETE Statements

Used to delete records from a table based on conditions helping find the records intended to be deleted.

Delete from Student where StudentName='Efe' - will delete the record with 'Efe' field under StudentName attribute in the Student table


    2. Data Definition Language Statements

These statements mess with DB schemas and descriptions. It involves CREATE, ALTER, DROP, TRUNCATE statements.

    2.1 CREATE Statements

CREATE statements can be used to generate different types of DB concepts such as new tables, functions, procedures, etc.

    Create Table Student (Rank Int, StudentName varchar(50), Mark Float)
                            NameOfTheAttribute TypeOfTheAttribute

    2.2 ALTER Statements

Used to add or modify or drop or rename attributes.

Alter Table Student Add StudentAddress varchar(100)


    2.3 DROP Statements

basically used to erase a concepts existence; might be a database, table

Drop table student
Drop database AdventureWorks
Drop TypeOfObject NameOfTheObject


    2.4 TRUNCATE Statements

Used to remove all records from a table, without logging the individual record deletions.

The difference separating Truncate statements from delete statements is that truncate statement actions are not logged as said above, making it not possible to retrieve data.

Truncate Table table_name


    3. Data Control Language Statements

This title is about granting access to users of the DB.


    3.1 Grant statement

    Grant statement is used to grant performing DML statements to user.

    Prototype 1: Grant Update on table nameOfTheTable to nameOfTheUser with grant option
    This gives whoever that person is to grant some user else the grant of the update operation in the table specified.

    Prototype 2: Grant Select on table nameOfTable to Public
    This gives everybody in the DB granted access to get data from the specified table.


    3.2 Revoke Statements

    Basically used to revoke granted permissions.

    Prototype1: Revoke delete on table employees from Efe
    Prototype2: Revoke all on table employees from Efe


    4. Transaction Control Language Statements

Used to form transactions consisting of a set of DML statements.


    4.1 Commit statements

    This command is used to save transactions into the DB.
    Whenever we utilize from Commit in any query, the change made by that query will be visible then.

    Exp.
    begin tran d
    update nameOfTable set nameOfAttribute = 'Sadiqo' where nameOfAttribute='it'
    commit tran d //til this commit, the tran d wasn't execute but merely saved.


    4.2 Rollback statements

    This statement is used to retrieve a transaction if it is not committed yet.

    DECLARE @BookCount int //This is an int variable declaration

    BEGIN TRANSACTION AddBook

    INSERT INTO Books VALUES (20, 'Book15', 'Cat5', 2000)

    SELECT @BookCount = COUNT(*)
    FROM Books
    WHERE name = 'Book15'

    IF @BookCount > 1 //If else statement start. If the variable is higher than one,
    BEGIN             //it takes the changes in the transaction back with rollback,
                      //giving a warning thet the book already exists in the table
        ROLLBACK TRANSACTION AddBook
        PRINT 'A book with the same name already exists'
    END
    ELSE
    BEGIN
        COMMIT TRANSACTION AddStudent
        PRINT 'New book added successfully'
    END


    4.3 SavePoint statements

    So instead of rolling all the way back to the point where the transaction did not begin,
    you can define Savepoints at certain points that you can retrieve the changes made after in the transaction
    with the rollback statement. Actually from a different angle, the name of the transaction is acting like a savepoint too.

    BEGIN TRAN

    SAVE TRAN point1

    DELETE FROM DEPT
    WHERE DEPTNO = 10

    SAVE TRAN point2

    DELETE FROM DEPT
    WHERE DEPTNO = 20

    SAVE TRAN point3

    ROLLBACK TRAN point2 //rather than giving a name to the transaction and rolling back to it, we rolled back to the savepoint
                        //we defined within it.
    SELECT * FROM DEPT


*/



