#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["API_Pessoas/API_Pessoas.csproj", "API_Pessoas/"]
RUN dotnet restore "API_Pessoas/API_Pessoas.csproj"
COPY . .
WORKDIR "/src/API_Pessoas"
RUN dotnet build "API_Pessoas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_Pessoas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_Pessoas.dll"]