# =========================
# BUILD STAGE
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# copy everything else and publish
COPY . ./
RUN dotnet publish -c Release -o out

# =========================
# RUNTIME STAGE
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out ./

# Render uses port 8080
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080




ENTRYPOINT ["dotnet", "backend.dll"]
