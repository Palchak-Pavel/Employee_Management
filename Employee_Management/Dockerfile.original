FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Employee_Management/Employee_Management.csproj", "Employee_Management/"]
RUN dotnet restore "Employee_Management/Employee_Management.csproj"
COPY . .
WORKDIR "/src/Employee_Management"
RUN dotnet build "Employee_Management.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Employee_Management.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Employee_Management.dll"]
