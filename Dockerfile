FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app
COPY *.sln ./
COPY ./ReservationVols.Api/*.csproj ./ReservationVols.Api/
COPY ./ReservationVols.Domain/*.csproj ./ReservationVols.Domain/
COPY ./ReservationVols.Infrastructure/*.csproj ./ReservationVols.Infrastructure/
RUN dotnet restore 
COPY . ./
RUN dotnet restore

COPY . .
RUN dotnet build  -c Release -o /app/build

FROM build AS publish
RUN dotnet publish  -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReservationVols.Api.dll"]