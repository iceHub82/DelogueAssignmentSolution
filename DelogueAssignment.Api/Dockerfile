# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and restore
COPY ../DelogueAssignment.sln ./ 
COPY . ../DelogueAssignment.Api/
WORKDIR /app/../DelogueAssignment.Api
RUN dotnet restore

# Build and publish
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /out .

EXPOSE 80
ENTRYPOINT ["dotnet", "DelogueAssignment.Api.dll"]

