#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Install clang/zlib1g-dev dependencies for publishing to native
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Codebreaker.GameAPIs.NativeAOT/Codebreaker.GameAPIs.NativeAOT.csproj", "Codebreaker.GameAPIs.NativeAOT/"]
COPY ["Codebreaker.Data.Sqlite/Codebreaker.Data.Sqlite.csproj", "Codebreaker.Data.Sqlite/"]
COPY ["Codebreaker.GameAPIs.Models/Codebreaker.GameAPIs.Models.csproj", "Codebreaker.GameAPIs.Models/"]
RUN dotnet restore "Codebreaker.GameAPIs.NativeAOT/Codebreaker.GameAPIs.NativeAOT.csproj"
COPY . .
WORKDIR "/src/Codebreaker.GameAPIs.NativeAOT"
RUN dotnet build "Codebreaker.GameAPIs.NativeAOT.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Codebreaker.GameAPIs.NativeAOT.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["./Codebreaker.GameAPIs.NativeAOT"]