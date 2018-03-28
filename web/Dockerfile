FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src 
COPY web.sln ./
COPY web/web.csproj web/
COPY web.test/web.test.csproj web.test/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/web
RUN dotnet build -c Release -o /app

#FROM build as test
#WORKDIR /src/web.test
#RUN dotnet test

FROM build AS publish
WORKDIR /src/web
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
#COPY --from=test /src/web.test/test-results.xml .
ENTRYPOINT ["dotnet", "web.dll"]
