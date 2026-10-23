💰 MoneyFlow

MoneyFlow is a modern, full-stack personal finance web application built with ASP.NET Core MVC (.NET 10), C#, and Entity Framework Core. It allows users to track incomes and expenses, manage recurring service categories, and keep detailed logs of all financial transactions.

🚀 Features

Service Management: Create, edit, and filter financial services (income vs. expense categories).

Transaction Logging: Track payments and revenue with custom dates, amounts, and detailed comments.

Dynamic Asynchronous UI: Smooth user experience leveraging JavaScript (Fetch API) and Select2 for dynamic dropdown filtering.

Data Validation & Security: Strict server-side validation using Data Annotations (ModelState) combined with client-side error feedback.

Clean Architecture: Built using proper separation of concerns with Controllers, Managers/Services, ViewModels, and Entity Data Models.

🛠️ Tech Stack

Framework: ASP.NET Core MVC (.NET 10)

Language: C#

ORM: Entity Framework Core (Code-First)

Database: SQL Server

Frontend: Bootstrap 5, Razor Views, JavaScript (Fetch API), jQuery, Select2

🏗️ Project Structure

MoneyFlow/
├── Context/             # Entity Framework DbContext setup
├── Controllers/         # Handles HTTP requests & routing
├── DTOs/                # Data Transfer Objects
├── Entities/            # Database Domain Models (User, Service, Transaction)
├── Managers/            # Business Logic & Repository/Service Layer
├── Models/              # ViewModels for data presentation and validation
├── Views/               # Razor templates & UI layouts
└── wwwroot/             # Static assets (CSS, JavaScript, Libraries)


🗄️ Database Domain Model

User: Manages individual user profile references.

Service: Defines income/expense categories (Name, Type, UserId).

Transaction: Logs actual monetary movements (TotalAmount, Date, Comment, ServiceId, UserId).

⚙️ Getting Started

Prerequisites

.NET 10 SDK

SQL Server (LocalDB or SQL Express)

Installation & Setup

Clone the repository:

git clone https://github.com/your-username/MoneyFlow.git
cd MoneyFlow


Configure Database Connection:
Update the connection string in appsettings.json to point to your local SQL Server instance:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MoneyFlowDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}


Apply Database Migrations:
Run the following command in your terminal or Package Manager Console:

dotnet ef database update


Run the Application:

dotnet run


📸 Demo & Screenshots

(Optional: Add screenshots or GIFs of your Index, New Service, and New Transaction views here)

📄 License

This project is licensed under the MIT License.
