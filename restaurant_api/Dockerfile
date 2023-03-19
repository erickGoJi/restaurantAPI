FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["restaurant_api/restaurant_api.csproj", "restaurant_api/"]
RUN dotnet restore "restaurant_api/restaurant_api.csproj"
COPY . .
WORKDIR "/src/restaurant_api"
RUN dotnet build "restaurant_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "restaurant_api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "restaurant_api.dll"]
