# improved-lamp
Learning Things!

Basic REPL

./Database/database.sln for Visual Studio  
./Lamp/Lamp.csproj for VSCode & .Net Core

# Query Syntax

## Example Table
Table: Scores  

| ID | Name | Score |  
| :---: | :---: | :---: |  
| INT | STRING | INT |  

## Basic Queries

### Simple Add  
ADD Scores { Name:"some name", Score:100 };  
_add row to table_  

### Simple Get,
GET 10 Scores;  
_get X many whole rows_

### Bulk Add
ADD-M Scores [{ Name:"some name", Score:100 }, { Name:"some name", Score:100 }];  
_adds many rows, discarding all rows that fails to add_

### Filtered Get
GET * Scores:Scores.Score > 10;  
_get all column where table.column > x_

## Numerical Functions

### AVG
GET AVG Scores.Score:Scores.Score > 10;  
_Get the average of table.column where Table.column > x_  

### MAX
GET MAX Scores.Score  
_get maximum value_

### MIN
GET MIN Scores.Score  
_get minimum value_

### HIST
GET HIST:10 Scores.Score
_compute a histogram for table.column with bucket size of 10_

### EXEC
GET 10 EXEC(10-x*3) Scores.Score  
