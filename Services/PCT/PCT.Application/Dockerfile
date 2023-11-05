FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/PCT/PCT.Application/PCT.Application/PCT.Application.csproj", "Services/PCT/PCT.Application/PCT.Application/"]
RUN dotnet restore "Services/PCT/PCT.Application/PCT.Application/PCT.Application.csproj"
COPY . .
WORKDIR "/src/Services/PCT/PCT.Application/PCT.Application"
RUN dotnet build "PCT.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PCT.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PCT.Application.dll"]
