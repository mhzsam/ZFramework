#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/Presentation/Presentation.csproj", "Presentation/Presentation/"]
COPY ["Application/Application/Application.csproj", "Application/Application/"]
COPY ["Domain/Domain/Domain.csproj", "Domain/Domain/"]
COPY ["Infrustracture/Infrastructure/Infrastructure.csproj", "Infrustracture/Infrastructure/"]
RUN dotnet restore "Presentation/Presentation/Presentation.csproj"
COPY . .
WORKDIR "/src/Presentation/Presentation"
RUN dotnet build "Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.dll"]