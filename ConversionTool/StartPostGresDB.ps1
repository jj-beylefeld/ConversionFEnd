#you need to support linux containers to achieve this
docker pull postgres:latest
docker run --name some-postgres -p 5432:5432 -e POSTGRES_PASSWORD=mysecretpassword -d postgres
docker ps
#please execute  dotnet ef database update with the altered SQL Server migration script for Identity user store
dotnet ef database update
#should now be up and running

########
#
# Stop the container and remove
#
########

<#
 docker stop some-postgres
 docker rm some-postgres
 docker ps
#>


########
#
# Confirm user store present steps (or run application IIS Express; register user and login) - sample code from template
#
########

<#
 docker exec -it some-postgres bash
 su postgres
 psql
 \l
 \c postgres
 \dt
#>