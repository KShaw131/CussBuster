FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./CussBuster.API/CussBuster.API.csproj ./

RUN dotnet restore

# Copy everything else and build
COPY CussBuster.API/. ./CussBuster.API/
WORKDIR /app/
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime as runtime
WORKDIR /app
COPY --from=build-env /app/out/ ./
EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "CussBuster.API.dll"]

#docker build -t cussbuster.api . -f Docker/CussBuster_App/Dockerfile
#docker run -p 5000:80/tcp cussbuster.api