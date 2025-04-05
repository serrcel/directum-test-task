FROM mcr.microsoft.com/dotnet/aspnet:9.0-bookworm-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

ARG BUILD_CONFIGURATION=Release

COPY ["Directum.Backend/Directory.Build.props", "Directory.Build.props"]

COPY ["Directum.Backend/Directum.Backend.API/Directum.Backend.API.csproj", "Directum.Backend.API/"]
COPY ["Directum.Backend/Directum.Backend.Infrastructure/Directum.Backend.Infrastructure.csproj", "Directum.Backend.Infrastructure/"]
COPY ["Directum.Backend/Directum.Backend.Core/Directum.Backend.Core.csproj", "Directum.Backend.Core/"]

RUN dotnet restore "Directum.Backend.API/Directum.Backend.API.csproj"
RUN dotnet restore "Directum.Backend.Infrastructure/Directum.Backend.Infrastructure.csproj"
RUN dotnet restore "Directum.Backend.Core/Directum.Backend.Core.csproj"

COPY ["Directum.Backend/Directum.Backend.API", "Directum.Backend.API/"]
COPY ["Directum.Backend/Directum.Backend.Infrastructure", "Directum.Backend.Infrastructure/"]
COPY ["Directum.Backend/Directum.Backend.Core", "Directum.Backend.Core/"]

WORKDIR "/src/Directum.Backend.API"
RUN dotnet build "Directum.Backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Directum.Backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Directum.Backend.API.dll"]
