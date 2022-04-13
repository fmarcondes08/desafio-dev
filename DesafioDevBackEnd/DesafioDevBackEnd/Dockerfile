#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DesafioDevBackEnd/DesafioDevBackEnd.API.csproj", "DesafioDevBackEnd/"]
COPY ["DesafioDevBackEnd.Infrastructure/DesafioDevBackEnd.Infrastructure.csproj", "DesafioDevBackEnd.Infrastructure/"]
COPY ["DesafioDevBackEnd.Domain/DesafioDevBackEnd.Domain.csproj", "DesafioDevBackEnd.Domain/"]
COPY ["DesafioDevBackEnd.Application/DesafioDevBackEnd.Application.csproj", "DesafioDevBackEnd.Application/"]
COPY ["DesafioDevBackEnd.Service/DesafioDevBackEnd.Service.csproj", "DesafioDevBackEnd.Service/"]
RUN dotnet restore "DesafioDevBackEnd/DesafioDevBackEnd.API.csproj"
COPY . .
WORKDIR "/src/DesafioDevBackEnd"
RUN dotnet build "DesafioDevBackEnd.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioDevBackEnd.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioDevBackEnd.API.dll"]