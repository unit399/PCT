FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/PCT/PCT.Infrastructure/PCT.Infrastructure/PCT.Infrastructure.csproj", "Services/PCT/PCT.Infrastructure/PCT.Infrastructure/"]
RUN dotnet restore "Services/PCT/PCT.Infrastructure/PCT.Infrastructure/PCT.Infrastructure.csproj"
COPY . .
WORKDIR "/src/Services/PCT/PCT.Infrastructure/PCT.Infrastructure"
RUN dotnet build "PCT.Infrastructure.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PCT.Infrastructure.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PCT.Infrastructure.dll"]
