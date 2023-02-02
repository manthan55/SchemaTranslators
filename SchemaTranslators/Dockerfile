#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/azure-functions/dotnet-isolated:4-dotnet-isolated6.0 AS base
WORKDIR /home/site/wwwroot
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SchemaTranslators/SchemaTranslators.csproj", "SchemaTranslators/"]
RUN dotnet restore "SchemaTranslators/SchemaTranslators.csproj"
COPY . .
WORKDIR "/src/SchemaTranslators"
RUN dotnet build "SchemaTranslators.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchemaTranslators.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true