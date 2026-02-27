/*
KEYS-

Candidate Key: There can be multiple candidate keys as selected columns containing unique data.

Primary Key: There can be only one primary key selected among candidate keys, but it might be consisting of multiple columns. Primary key field contains a clustered (the word cluster itself alone is called listing records based on an ascending order of a column where the indexes might be the same but unique in primary key case certainly) index. Primary keys can't involve null data.

Unique Key: Can be potential primary keys. Similarly, they identify records uniquely. Its difference from primary key is that unique keys may contain null data and non-clustered indexes.

Composite Key: Might be either a candidate or a primary key, used to uniquely identify records as a combination of attributes (columns).

Foreign Key: is the second most important key after the primary key. It refers to the primary key of another table's primary key and used to form relationships among tables. This key may contain duplicate indexes.

---------------------------------------------------------------------------------------------------------------------

What is a transaction?
A transaction is a single logical unit of work which accesses and modifies the contents of a database.

A transaction model:

Transaction Begins...
-----------------------------------------------------------------------------
1- Begin Transaction                   |====> Start Transaction


2- Update savingAccounts               |
    SET balance = balance - 1000       | ====> Decrease Savings Account
    WHERE accountNo = 9187;            |


3- UPDATE checkingAccounts             |
    SET balance = balance + 1000       | ====> Increase Checking Account
    WHERE accountNo = 7819;            |


4- INSERT INTO transactionsLogs VALUES | =====> Record Log In Table
        ("1W2aF", 9187, 7819, 1000);   |


5- COMMIT TRANSACTION                  | =====> End Transaction
-----------------------------------------------------------------------------
...Transaction Ends

---------------------------------------------------------------------------------------------------------------------

ACID Properties

ACID is a concept that refers to the four properties of a transaction in a database system, which are Atomicity, Consistency, Isolation, and Durability.

1) Atomicity

Atomicity means all parts of a transaction must succeed, or none of them should happen at all. If a transaction contains 5 operations (insert, update, delete…), and one of them fails, the database rolls back everything and returns the system to the state before the transaction began. This prevents partial updates and ensures that a transaction is treated as a single, indivisible unit.

2) Consistency

Consistency ensures that a transaction can only bring the database from one valid state to another valid state. It enforces rules, constraints, triggers, foreign keys, and prevents data from violating schema requirements. If a transaction attempts to insert invalid data or breaks integrity rules, the database rejects it, preserving overall correctness.


3) Isolation

Isolation means that each transaction should behave as if it is running alone, even when many transactions occur at the same time.
Databases use isolation levels (READ COMMITTED, SERIALIZABLE, etc.) to control how and when one transaction can “see” data from another.
This prevents issues like dirty reads, non-repeatable reads, and phantom reads.
As an example: Imagine there is two customers trying to buy the last stock of a product, the DB system allows the first one to add it to their cart by blocking the other to do the same thing.


4) Durability

Durability guarantees that once a transaction is committed, its changes are permanent, even in the case of crashes, power loss, or system failures.
Databases achieve this using logs, write-ahead logs (WAL), journaling, or replication.
After commit, the data is safely stored and cannot disappear. This remains immutable until another update or deletion transaction affects it.

---------------------------------------------------------------------------------------------------------------------


Normalization & NFs

First Normal Form

-Each cell must be atomic, meaning that they must have one value only. No lists, no multiple items in one column.
-No repeating columns. No Phone1, Phone2, Phone3.
-Rows are uniquely identifiable (usually by a primary key).

Wrong example to be considered in 1NF;
UserID | Phones
------------------------
1      | 555-1234, 555-6789

After the correction (if the table above had multiple different columns, and it was for individual list, then this part would have to be separated as a new table like below. The phone numbers belonging to those people in records should be accessible via the new table)

UserID | Phone
----------------
1      | 555-1234
1      | 555-6789


Second Normal Form

-First NF already applied.
-There should be no partial dependencies to the primary key;
    Imagine we have a composite primary key consisting of courseID and studentID columns and we have courseName column in the same table

studentID | courseID | courseName
------------------------
1      | 546 | Physical Education

Because courseName only depends on a part (courseID merely) of the primary key, we must create a new table for only courseID and courseName and look up for course names via course ID from the new table in need;

studentID | courseID
------------------------
1      | 546

courseID | courseName
------------------------
546 | Physical Education


Third Normal Form

-Already the 2nd NF is applied.
-There are no transitive dependencies. A transitive dependency means that a column depends on a non-key column.

Students
-------------------------------------------------
StudentID | Name | DepartmentID | DepartmentName

Imagine there isn't a diff table in the DB where the departmentID is a primary key, and it is a non-key column in the Students table accordingly but the departmentname column depends on it. We will create a separate table taking these relevant two columns outta this table by making the DepartmentID the primary key. This meets the 3rd NF criteria and DepartmentID becomes a foreign key in our first table. Check below;

Students
-------------------------------------------------
StudentID | Name | DepartmentID

Departments
-------------------------------------------------
DepartmentID | DepartmentName


In conclusion;
1NF: Atomic columns, no repeating groups.
2NF: No partial dependency on a composite key.
3NF: No transitive dependency between non-key attributes (columns).
-------------------------------------------------------------------------------------------------------------------


Interchangeable Terms Table !!!

Practical Term   | Theoretical Term | Meaning
-----------------|------------------|-------------------------------
Table            | Relation         | A dataset
Row              | Tuple            | One record
Column           | Attribute        | One data category
Cell             | Field            | Single value in a row+column
Schema           | Structure        | Table design
Domain           | Value set        | Allowed values
Key              | Identifier       | Uniqueness/link

*/
