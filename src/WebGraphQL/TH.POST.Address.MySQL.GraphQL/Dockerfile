#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/WebGraphQL/TH.POST.Address.MySQL.GraphQL/TH.POST.Address.MySQL.GraphQL.csproj", "src/WebGraphQL/TH.POST.Address.MySQL.GraphQL/"]
RUN dotnet restore "src/WebGraphQL/TH.POST.Address.MySQL.GraphQL/TH.POST.Address.MySQL.GraphQL.csproj"
COPY . .
WORKDIR "/src/src/WebGraphQL/TH.POST.Address.MySQL.GraphQL"
RUN dotnet build "TH.POST.Address.MySQL.GraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TH.POST.Address.MySQL.GraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TH.POST.Address.MySQL.GraphQL.dll"]