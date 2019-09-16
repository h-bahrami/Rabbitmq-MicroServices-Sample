FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 86
EXPOSE 445

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MicroService2/MicroService2.csproj", "MicroService2/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "MicroService2/MicroService2.csproj"
COPY . .
WORKDIR "/src/MicroService2"
RUN dotnet build "MicroService2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService2.dll"]