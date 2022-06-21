#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SoftP.ApiDotNet.Api/SoftP.ApiDotNet.Api.csproj", "SoftP.ApiDotNet.Api/"]
COPY ["SoftP.ApiDotnet.Infra.Ioc/SoftP.ApiDotNet.Infra.Ioc.csproj", "SoftP.ApiDotnet.Infra.Ioc/"]
COPY ["SoftP.ApiDotnet.Application/SoftP.ApiDotNet.Application.csproj", "SoftP.ApiDotnet.Application/"]
COPY ["SoftP.Dotnet.Domain/SoftP.ApiDotNet.Domain.csproj", "SoftP.Dotnet.Domain/"]
RUN dotnet restore "SoftP.ApiDotNet.Api/SoftP.ApiDotNet.Api.csproj"
COPY . .
WORKDIR "/src/SoftP.ApiDotNet.Api"
RUN dotnet build "SoftP.ApiDotNet.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SoftP.ApiDotNet.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoftP.ApiDotNet.Api.dll"]