FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/BankDeposits.Domain/BankDeposits.Domain.csproj", "BankDeposits.Domain/"]
COPY ["src/BankDeposits.Razor/BankDeposits.Razor.csproj", "BankDeposits.Razor/"]
RUN dotnet restore "BankDeposits.Razor/BankDeposits.Razor.csproj"
COPY src/ .
WORKDIR "/src/BankDeposits.Razor"
RUN ["dotnet", "build", "BankDeposits.Razor.csproj", "-c", "Release", "-o", "/app/build"]

FROM build as publish
RUN dotnet publish "BankDeposits.Razor.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "BankDeposits.Razor.dll" ]