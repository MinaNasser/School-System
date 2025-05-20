# 🎓 School Management System – ASP.NET Core MVC

A structured web application to manage students and their assigned subjects using the MVC pattern with clean architecture, DTO separation, and full CRUD support.

GitHub Repository 👉 [School-System](https://github.com/MinaNasser/School-System)

---

## 🚀 Features

- Add, edit, delete students
- Assign multiple subjects to each student using checkboxes
- Manage subjects in a separate module (CRUD)
- Display students with their subjects clearly
- Form validation with error messages
- Layered, testable, and maintainable architecture

---

## 🛠️ Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (Code-First)
- SQL Server
- C# & LINQ
- Bootstrap 5
- Repository Pattern + Unit of Work
- Lazy Loading via EF Core Proxies

---

## 🧱 Project Architecture
```text
School-System/
│
├── School.Entities # Domain entities (Student, Subject, StudentSubject)
├── School.DAL # AppDbContext + Fluent API Configurations
├── School.Repositories # Generic Repositories + UnitOfWork
│ └── Interfaces
│
├── School.DTOs # View-friendly Data Transfer Objects
│
├── School.Services # Business logic layer
│ └── Interfaces
│
├── School.Presentation # MVC Layer (Controllers + Views)
│ ├── Controllers
│ └── Views
│ ├── Student
│ └── Subject
│
└── README.md
```



---

## ⚙️ How to Run Locally

1. **Clone the repo:**

   ```bash
   git clone https://github.com/MinaNasser/School-System.git


