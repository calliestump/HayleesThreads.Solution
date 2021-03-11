# HayleesThreads

#### **01/04/2021**

## By _Callie Stump_
---
## <u>**About** </u>
### 🚩 **Description**
This is an E-Commerce application for a Haylees Threads. Data and significant relationships are all stored/managed in a MySql database. 

### 🐛 Known Bugs
* There's no cart functionality
* Order form isnt connected
* Payment method isnt functioning. 
* Search bar is inactive. 

### **📖 User Stories**
<details>
<summary>Expand</summary>

* As a user I should be able to navigate to a splash page that lists all categories and products.
* As the user, I need to be able to select a category and see a list of all of the products in that cataegory. I also need to be able to select a product, and see it's details.
* As the user, I need to be able to add products to my cart.
* As the admin, I need to be able to add new categories and products to our system.
* As an admin, I need to be able to add, edit, or remove categories and products. I also need to be able to modify their relationship from the other side.
</details>
<hr>

## <u>**Getting Started**</u>
### **☑️ Requirements**
* C# .Net Core v2.2.4 installed on your local machine.
* Console/Terminal access.
* Code Editor 
Ex.) [Visual Studio Code](https://code.visualstudio.com/)
* MySQL Community Server & Workbench

#### **Import Database with Entity Framework Core**
1. Navigate to the "HayleesThreads.Solution/HayleesThreads" directory using your terminal.
2. Run the command 'dotnet ef database update' to generate the database through Entity Framework Core.
3. (Optional) To update the database with any changes to the code, run the command 'dotnet ef migrations add [MigrationsName] which will use Entity Framework Core's code-first principle to generate a database update. After, run the previous command 'dotnet ef database update' to update the database.

### 🔧 **Setup/Installation**
#### **Project Editor Setup**
1. Copy this download link: https://github.com/calliestump/HayleesThreads.Solution.git
2. Open bash and go to the directory where you would like to store your cloned project.
3. Clone the repo.
```
git clone https://github.com/calliestump/HayleesThreads.Solution.git
```
4. Navigate to the cloned project folder and open VS code.
```
$ cd Desktop
$ cd [known directory]
$ code .
```
5. If you wish to see if everything is compiling correctly go to the HayleesThreads directory and run the following:
```
dotnet build
```
6. To see if the program is functioning properly you can use:
```
dotnet watch run
```
This will show you if everything is compiling correctly; otherwise you be will prompt with error messages.

#### **Dont forget that in order to push any changes you need to add your own GitHub repo. to your project.**
```
git remote add origin [personal Github repo. link]
```
#### **Note**: Do this is your main parent directory. You do not want to have git initialized in any other places.

#### **AppSettings/Database Connection Setup**
1. Create a new file in the "HayleesThreads.Solution/HayleesThreads" directory named appsettings.json
2. Add in the following code snippet to the new appsettings.json file:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=firstName_lastName_HayleesThreads;uid=root;pwd=YourPassword;"
  }
}

```
<hr />

## <u>**Technologies Used**</u>
* Visual Studio Code 1.52.1
* C# V:7.3
* .NET Core V: 2.2.0
* ASP.NET Core MVC
* ASP.NET Core Razor Pages
* MySQL WorkBench V: 8.0
* Entity Framework Core V: 2.2.6
* dotnet script, REPL
* Identity 
<hr />

## <u>**Setting up User Roles**</u>
#### Navigate to HayleesThreads/Controllers/AdministrationController.cs" and comment out [Authorize(Roles = "Admin")] underneath the namespace. This will give you  access to Admin views without being logged in. 
<br />

#### Complete the following steps to assign an account to a user role:

1. Register an account you would like to use with admin.
2. Login into new account.
3. In the url navigate to 'localhost:5000/administration/listroles'.
4. Create a new role and name it "Admin".
4. Click edit - this is where you add/remove accounts from the role using the checkbox.
5. To have new permissions you need to logout and log back into designated account you selected. 
6. You can now uncomment [Authorize(Roles = "Admin")] in the AdministrationController.cs to make the Admin views only accessible to your admin account.
#### You now have access to the 'Administration' tab in the navbar as well as the admin panels at the bottom of each page to manage your products & categories.
------------------------------
## 👤 Contributor

| Author | Email |
|--------|:-----:|
| [Callie Stump](https://www.linkedin.com/in/callie-stump/) | [callie@stu.mp](mailto:callie@stu.mp) |
------------------------------

## 📝 Legal
```
MIT License

Copyright (c) 2021 Callie Stump

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
```
<center><a href="#">Return to Top</a></center>
