### C\# Review 3
#### Mark W.
#### Demonstrates basic understanding of week three C# material, _10.20.2017_


#### Description
This is a C# program that manages a database containing info on stylists and clients at a hair salon.

### Specfications
* page starts by offering users a link to a list of available stylists.
* @stylist list:

|Behavior | Example Input| Example Output|
| ---|:---:| :---:|
| clicking a stylist takes user to a list of that stylists clients| N/a | \* user redirected to list of that stylists clients \* [uses format: client.name : client.id]|
|->user clicks a client on stylist page| N/a |\*user redirected to page with client name form and link home\*|
|->>user inputs a name|"Sarah"+\*Submit\*|current client's name is replaced with new name|
|->user clicks link "remove client" on stylist page| N/a |user redirected to page to select id of client to remove|
|->>user enters id number|"3"|client table in database is searched and, if found, the client with id 3 is deleted|
|->user clicks link "add client" on stylist page| N/a |takes user to form to input new stylist|
| clicking \*Add\* on homepage | N/a | \* user redirected to input form for new stylist \* |
| ->user is prompted for new stylist's name in form text field| "George" + \*Submit\* | \*User returned to homepage\* + new entry "George : {id}" displayed
| user clicks \*Clear\* on homepage| N/a | \*clears the list and database table of stylists\* |


* @stylist client list:

|behavior								       |	input				   |	output							|
|---|:---:|:---:|
|show all clients for selected stylist(has entries) | “3” | list formatted as “clientName : client id” |
|show all clients for selected stylist(has no entries) | “3” | page displays “no clients have been recorded for this stylist" |
|add client to stylist’s list(valid name,valid stylist id) | “clientName”+”1" | *new client is recorded*+returns to stylist's list |
|add client to stylist’s list(invalid name) | “client-N4m3!”+1 |  returns to stylist's list+page displays “Invalid client name; use only alphabetic characters” |
|add client to stylist’s list(invalid stylist id) | “clientName”+9999 | returns to stylist's list+page displays “Invalid stylist id; check list of stylists for valid ids" |
|remove all clients from selected stylist	| N/a	| *empties list* |
|remove one client from selected stylist(valid id) | “1" | returns to stylist's list+page displays remaining clients |
|remove one client from selected stylist(invalid id) | “1234" | returns to stylist's list+page displays “Invalid client id check list of clients for valid ids" |
|update a clients name(valid name)   | “newName”    | clients old name is replaced+user returned to client stylist list |
|update a clients name(invalid name) | “!n3wN4m3*&” | user returned to client stylist list+page displays “Invalid client name; use only alphabetic characters" |
|update a clients stylistId(valid)   | "1"    | clients old stylistId is replaced+user returned to client stylist list |
|update a clients stylistId(invalid) | "987654321" | user returned to client stylist list+page displays “Invalid stylistId; see stylist list for valid ids" |



### Setup/Installation
* Download from GitHub.
* import the two databases at the top level directory into MAMP
* Use terminal command, "dotnet restore" in "HairSalon.Solutions/HairSalon".
* Use terminal command, "dotnet run" in "HairSalon.Solutions/HairSalon".
* Enter URL given into your preferred browser

### Technologies Used
* .NET framework
* C#
* HTML
* CSS
* MySQL/MAMP

### Contact Information
If any questions or concerns arise, contact someone at some.email@thisPlace.net

### License
This software is licensed under the GPL license.
