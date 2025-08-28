# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EBook/EBook.API.csproj", "EBook/"]
COPY ["EBook.Presentation/EBook.Presentation.csproj", "EBook.Presentation/"]
COPY ["EBook.Application/EBook.Application.csproj", "EBook.Application/"]
COPY ["EBook.Domain/EBook.Domain.csproj", "EBook.Domain/"]
COPY ["EBook.Infrastructure/EBook.Infrastructure.csproj", "EBook.Infrastructure/"]
COPY ["EBook.Persistance/EBook.Persistance.csproj", "EBook.Persistance/"]
RUN dotnet restore "./EBook/EBook.API.csproj"
COPY . .
WORKDIR "/src/EBook"
RUN dotnet build "./EBook.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EBook.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EBook.API.dll"]