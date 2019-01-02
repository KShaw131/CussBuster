echo 'seeding database'
sleep 10s
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P Levvel1! -d master -i init.sql
echo 'seeding is complete'