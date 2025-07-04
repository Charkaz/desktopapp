# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["desktopapp.csproj", "."]
RUN dotnet restore "./desktopapp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "desktopapp.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "desktopapp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "desktopapp.dll"]
