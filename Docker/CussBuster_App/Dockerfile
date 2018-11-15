#New dockerfile including both projects
FROM microsoft/dotnet:2.1-sdk AS base
WORKDIR /app
EXPOSE 5000/tcp

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY CussBuster.sln ./
COPY CussBuster.API/CussBuster.API.csproj ./CussBuster.API/
COPY CussBuster.Models/CussBuster.Models.csproj ./CussBuster.Models/
COPY CussBuster.Database/CussBuster.Database.csproj ./CussBuster.Database/

RUN dotnet restore
COPY . .

WORKDIR /src/CussBuster.Models
RUN dotnet build -c Release -o /app

WORKDIR /src/CussBuster.Database
RUN dotnet build -c Release -o /app

WORKDIR /src/CussBuster.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CussBuster.API.dll"]