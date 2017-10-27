### C\# Review 3
#### Mark W.
#### Demonstrates basic understanding of week three C# material, _10.20.2017_


#### Description
This is a C# program that manages a database containing info on stylists and clients at a hair salon.

### Specfications
* homepage starts by offering users a list of available stylists.

|Behavior | Example Input| Example Output|
| ---|:---:| :---:|
| clicking a stylist takes user to a list of that stylists clients|  \*clicks link\*| \* user redirected to list of that stylists clients \* [uses format: client.name : client.id]|
|->user clicks a client on stylist page|\*clicks link\*|\*user redirected to page with client name form and link home\*|
|->>user inputs a name|"Sarah"+\*Submit\*|current client's name is replaced with new name|
|->user clicks link "remove client" on stylist page|\*clicks link\*|user redirected to page to select id of client to remove|
|->>user enters id number|"3"|client table in database is searched and, if found, the client with id 3 is deleted|
|->user clicks link "add client" on stylist page|\*clicks link\*|takes user to form to input new stylist|
| clicking \*Add\* on homepage | \*clicks link\* | \* user redirected to input form for new stylist \* |
| ->user is prompted for new stylist's name in form text field| "George" + \*Submit\* | \*User returned to homepage\* + new entry "George : {id}" displayed
| user clicks \*Clear\* on homepage| \*clicks link\* | \*clears the list and database table of stylists\* |

### Setup/Installation
* Download from GitHub.
* Use terminal command, "dotnet run" at top-level directory of project.
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
