docker pull mcr.microsoft.com/mssql/server; docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password%1#29" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest