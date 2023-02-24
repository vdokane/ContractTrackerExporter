Row 1 - MAIN = Contract/Grant Disbursement Agreement
Row 2 - CTCH = Contract/Grant Disbursement Agreement Change/Amendment, if applicable
Row 3 - BUGT = Budget Info, if applicable
Row 4 - VNDR = Vendor Info, if applicable
Row 5 - DLBL = Deliverable Info, if applicable
Row 6 - CSFA = CSFA Info, if applicable
Row 7 - CFDA = CFDA Info, if applicable

Once the spreadsheet data is verified, save the file in the format and with the prescribed file name “Batch_OLO number_date code” (e.g. Batch_830000_2012_03_31) so the FACTS web application can process.
 

How do I determine if just children record? Shit..
“ADD” – When Adding a new contract/grant disbursement agreement
“UPD” – When Updating an existing contract/grant disbursement agreement
“NONE” - When Updating/Adding an existing contract/grant disbursement agreement’s children.

#“Main” Contract/Grant Disbursement Agreement Information Record
Record Type
Action
FLAIR Agency Identifier (OLO)
FLAIR Contract/Grant Disbursement Agreement Identifier (FLAIR ID)
Short Title
Long Title
Agency Assigned Contract/Grant Disbursement Agreement Identifier
Contract/Grant Disbursement Agreement’s Type
Contract/Grant Disbursement Agreement’s Status
Original Contract/Grant Disbursement Agreement Amount
Contract/Grant Disbursement Agreement’s Date of Execution    YYYY-MM-DD
Contract/Grant Disbursement Agreement’s Beginning Date
Contract/Grant Disbursement Agreements’ Original Ending Date
Agency Service Area
Agency Contract/Grant Disbursement Agreement Manager’s Name
Agency Contract/Grant Disbursement Agreement Manager’s Phone Number
Agency Contract/Grant Disbursement Agreement Manager‘s e-mail address
Authorized Advance Payment
Contract/Grant Disbursement Agreement’s Method of Procurement
State Term Contract Identifier
Agency Reference Number
Contract/Grant Disbursement Agreement’s Exemption Explanation
Contract/Grant Disbursement Agreement’s Statutory Authority
General Description of the Contract/Grant Disbursement Agreement
Contract/Grant Disbursement Agreement Involves State or Federal Financial Aid
Recipient Type
Provide for Administrative Cost
Administrative Cost Percentage
Provide for Periodic Increase
Periodic Increase Percentage
Business Case Study Done
Business Case Date
Legal Challenges to Procurement
Legal Challenge Description
Was the Contracted Functions Previously Done by the State
Was the Contracted Functions Considered for Insourcing back to the State
Did the Vendor Make Capital Improvements on State Property
Capital Improvements Description
Value of Capital Improvements
Value of Unamortized Capital Improvements
Do not publish this contract/grant disbursement agreement on the FACTS website
New Ending Date

#change
Record Type “CTCH”
AAction
Contract/Grant Disbursement Agreement Change Type
Amendment Amount
Agency Amendment Reference
Amendment Effective Date
Change Date Executed
New Ending Date
Change Description
Amendment Order

#budget (done but what about BudgetaryRate?)
Record Type BUGT
Agency Amendment Reference
Budgetary Amount
Budgetary Amount Type
Budgetary Amount Account Code
Budgetary Amount Fiscal Year Effective Date
OCA

#vendor
VNDR”
Vendor Id  Text 21

#Deliverable (done)
DLBL”
Commodity/Service Type
Major Deliverable
Method of Payment
Major Deliverable Price
Non-Price Justification
Performance Metrics
Financial Consequences
Source Documentation Page Reference
Deliverable Number  <--- what is this?

# really? CSFA”
CSFA”
CSFA Code

CFDA”
CFDA Code

Error logs will use the following naming convention:
FilenameRecieved_YYYYMMDD_HHMMSS_Log.txt
The resulting error record will be formatted as:
Error: Error Description | Delimited record received

So what about the documents??