cd ..

dotnet ef dbcontext scaffold "Server=localhost;Database=test;Port=5432;Username=postgres;Password=postgres;" Npgsql.EntityFrameworkCore.PostgreSQL -o DB/Models -f --no-onconfiguring

pause
