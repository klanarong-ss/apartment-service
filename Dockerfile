#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApartmentService/ApartmentService.csproj", "ApartmentService/"]
COPY ["ApartmentService.Business/ApartmentService.Business.csproj", "ApartmentService.Business/"]
COPY ["ApartmentService.DataAccess/ApartmentService.DataAccess.csproj", "ApartmentService.DataAccess/"]
RUN dotnet restore "ApartmentService/ApartmentService.csproj"
COPY . .
WORKDIR "/src/ApartmentService"
RUN dotnet build "ApartmentService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApartmentService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApartmentService.dll"]