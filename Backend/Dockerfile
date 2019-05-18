FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY app/ChefSnacks.Web/ChefSnacks.Web.csproj app/ChefSnacks.Web/
COPY app/ChefSnacks.Core/ChefSnacks.Core.csproj app/ChefSnacks.Core/
RUN dotnet restore app/ChefSnacks.Web/ChefSnacks.Web.csproj
COPY . .
WORKDIR /src/app/ChefSnacks.Web
RUN dotnet build ChefSnacks.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ChefSnacks.Web.csproj -c Release -o /app

FROM nginx
EXPOSE 80
RUN rm /etc/nginx/nginx.conf
COPY nginx.conf /etc/nginx/nginx.conf

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ChefSnacks.Web.dll"]
