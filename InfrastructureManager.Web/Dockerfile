#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InfrastructureManager.Web/InfrastructureManager.Web.csproj", "InfrastructureManager.Web/"]
RUN dotnet restore "InfrastructureManager.Web/InfrastructureManager.Web.csproj"
COPY . .
WORKDIR "/src/InfrastructureManager.Web"
RUN dotnet build "InfrastructureManager.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InfrastructureManager.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InfrastructureManager.Web.dll"]