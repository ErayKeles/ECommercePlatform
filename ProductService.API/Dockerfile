FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrderPaymentService.API/OrderPaymentService.API.csproj", "OrderPaymentService.API/"]
RUN dotnet restore "./OrderPaymentService.API/OrderPaymentService.API.csproj"
COPY . .
WORKDIR "/src/OrderPaymentService.API"
RUN dotnet build "./OrderPaymentService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OrderPaymentService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderPaymentService.API.dll"]
