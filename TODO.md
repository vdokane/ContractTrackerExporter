APPLY TABLE CHANGES TO YOUR LAPTOP
a) The folder thast got sent was Export[370].zip.. what does that name mean?
1) Get proc docs and figure out how they are named/exported and set up in index (emailed about this again 2023/03/02)
2) What are the missing fields in the index.txt?
3) Finish contract order
4) What are the missing fields in the contract order?
5) Build a log table for this, insert time it runs and stuff for each step
6) OMG! EXPORT DATE@
7) what additional logs? Should I record which files get exported each night?
What is the name of the actual file that gets exported?

//These were done 1/25, wooo
9807
9796
9815
9337

2/13 COOL! Make sure it is writing to file and then in order
New table can be something like, 
PK
ContractId int null
Message varchar(2000)
Timestamp
IsErrorEntry