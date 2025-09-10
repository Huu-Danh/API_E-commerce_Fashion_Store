# E-commerce Clothing Store API (.NET 8)

API RESTful cho hệ thống thương mại điện tử bán quần áo, hỗ trợ quản lý sản phẩm, người dùng, giỏ hàng, đơn hàng.

## Tính năng chính

👕 Quản lý sản phẩm (CRUD)

🛒 Giỏ hàng (thêm, xoá, cập nhật sản phẩm trong giỏ)

📦 Quản lý đơn hàng

👤 Đăng ký / đăng nhập (JWT Authentication)

🔍 Tìm kiếm sản phẩm theo tên, loại

📑 Swagger UI để test API

## Công nghệ sử dụng

⚙️ .NET 8 (ASP.NET Core Web API)

🗄️ Entity Framework Core (EF Core) + SQL Server

🔑 JWT Authentication

🧪 xUnit / NUnit (Unit Test – nếu có)

📄 Swagger / Swashbuckle

## 🚀 Cài đặt & Chạy dự án

```bash
# Clone project
git clone https://github.com/Huu-Danh/API_E-commerce_Fashion_Store.git
```

# Di chuyển vào thư mục

cd API_E-commerce_Fashion_Store

# Cập nhật connection string trong appsettings.json

# Apply migrations (nếu dùng EF Core)

dotnet ef database update

# Chạy project

dotnet run
