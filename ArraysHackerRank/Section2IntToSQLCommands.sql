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

Alter Table Student Add (StudentAddress varchar(100))


    2.3 DROP Statements

basically used to erase a concepts existence; might be a database, table

Drop table student
Drop database AdventureWorks
Drop TypeOfObject NameOfTheObject


    2.4 TRUNCATE Statements

Used to remove all records from a table, without logging the individual record deletions.

The difference separating Truncate statements from delete statements is that truncate statement actions are not logged as said above, making it not possible to retrieve data.

Truncate Table table_name

*/



