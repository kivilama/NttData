FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR webapi

#COPY PROJECT FILE
COPY ./*.csproj ./
RUN dotnet restore

#COPY EVERYTHING ELSE
COPY . .
RUN dotnet publish -c Release -o out

#Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 
WORKDIR /webapi
COPY --from=build /webapi/out .
ENTRYPOINT ["dotnet","NttDataApi.dll"]

