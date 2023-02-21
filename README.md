TODO- 
Should the child services.. vendor, budget, etc return list of strings read to go? 

Get the file layout for contract, budget, changes, etc <-- still todo 1/1/2023 ugh
AttachmentAmendmentDocs is now seperate
 Criteria for what gets into the file and what keeps it in the file
INS? MAIN|UPD 
What is the criteria for update? 
Generate contract number - can we change it?
//How does Export Date get set? Like, how do we know a contract is finally uploaded correctly
DateTime should be param
Setup Exports file\Export[370].ZIP <-- what is the format to these
JOINS, procurement method, users, vendor
 public int? PublicContractAppContractId { get; set; }  //What was this for? Does this need to be added

 Once it is exported, add an exported date?

 At some point find out if it is easier to get each child record list from the DB in the foreach of one ig collection of collections


 #Contract order
 OLO
 Agency Service Area What is this?
 Contract Number 5 digit
 Service Type Contract's Short Title (I think service type)
 Contract's Long Title
 Agency Assigned Contract Identifier (This data must not be sent to FLAIR. what is this? Looks like ContractId? 11760)
 Contract’s Type (SC? supreme court or State Wide)
 Contract Status (2 character)
  Contract’s Vendor Id (21 character) But 0.0000 is what is in the file, the hell?