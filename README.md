# Project Name

## Mô tả

Bài test của Awing.
Gồm 2 project 
- fe: front end dùng reactjs(Nextjs): có sử dụng 1 số thứ viện Material UI, tailwindcss,  react-hook-form, Zustand, Axios 
- AwingApi: backend API C# sử dụng Entity framework Code first, backend xử lý tính toán và lưu dữ liệu vào DB(SQL Server)

## Yêu cầu

- .NET 8.0
- NodeJs 20.12.2 

## Cách thiết lập

1. Clone repository:
   ```bash
   git clone https://github.com/duccanh247/awing-test.git

2. Config backend
	- Open Project backend AwingApi, 
	- Open file appsetting, change connectionString to your DB
	- Open "Package Manager Console" and run
		```bash
		Update-Database
	- Run project
3. Run Frontend 
	- Open project fe
	- Open TERMINAL (Ctrl+`), run command
		```bash
		npm i
		npm run dev

	- Access http://localhost:3000/cal