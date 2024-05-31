FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ImageMagick.Test.csproj", "./"]
RUN dotnet restore "ImageMagick.Test.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ImageMagick.Test.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ImageMagick.Test.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chmod -R 777 /app/Assets/DSCF7482.jpg
ENTRYPOINT ["dotnet", "ImageMagick.Test.dll"]
