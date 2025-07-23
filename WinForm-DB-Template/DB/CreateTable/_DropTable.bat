set PGPASSWORD=postgres
psql -U postgres -d test -p 5432  ^
 -c "DROP TABLE \"M_Store\"" ^
 -c "DROP TABLE \"M_Item\"" ^
 -c "DROP TABLE \"I_Sales\"" ^
 -c "DROP TABLE \"I_SalesDetail\""
pause
