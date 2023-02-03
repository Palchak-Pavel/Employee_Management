FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmployeeManagementGrpc/EmployeeManagementGrpc.csproj", "EmployeeManagementGrpc/"]
RUN dotnet restore "EmployeeManagementGrpc/EmployeeManagementGrpc.csproj"
COPY . .
WORKDIR "/src/EmployeeManagementGrpc"
RUN dotnet build "EmployeeManagementGrpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeManagementGrpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeManagementGrpc.dll"]
