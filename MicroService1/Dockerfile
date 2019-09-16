FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 85
EXPOSE 444

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MicroService1/MicroService1.csproj", "MicroService1/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "MicroService1/MicroService1.csproj"
COPY . .
WORKDIR "/src/MicroService1"
RUN dotnet build "MicroService1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService1.dll"]