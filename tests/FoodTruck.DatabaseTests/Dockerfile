FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./src ./src
COPY ./tests ./tests
RUN dotnet restore ./tests/FoodTruck.DatabaseTests/FoodTruck.DatabaseTests.csproj

COPY . ./

ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.5.0/wait /wait
RUN chmod +x /wait

CMD /wait && dotnet test ./tests/FoodTruck.DatabaseTests/FoodTruck.DatabaseTests.csproj --logger trx --results-directory /var/temp