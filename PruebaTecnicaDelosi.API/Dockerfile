#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PruebaTecnicaDelosi.Domain/PruebaTecnicaDelosi.Domain.csproj", "PruebaTecnicaDelosi.Domain/"]
RUN dotnet restore "PruebaTecnicaDelosi.Domain/PruebaTecnicaDelosi.Domain.csproj"
COPY ["PruebaTecnicaDelosi.API/PruebaTecnicaDelosi.API.csproj", "PruebaTecnicaDelosi.API/"]
RUN dotnet restore "PruebaTecnicaDelosi.API/PruebaTecnicaDelosi.API.csproj"
COPY . .
WORKDIR "/src/PruebaTecnicaDelosi.Domain"
RUN dotnet build "PruebaTecnicaDelosi.Domain.csproj" -c Release -o /app/build
WORKDIR "/src/PruebaTecnicaDelosi.API"
RUN dotnet build "PruebaTecnicaDelosi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaTecnicaDelosi.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaTecnicaDelosi.API.dll"]