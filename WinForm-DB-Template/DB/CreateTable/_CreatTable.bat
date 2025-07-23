set PGPASSWORD=postgres
psql -U postgres -d test -p 5432  ^
 -f M_Store.sql ^
 -f M_Item.sql ^
 -f I_Sales.sql ^
 -f I_SalesDetail.sql
pause
