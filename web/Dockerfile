FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

#this caching proj files that was here in the first place was causing confusion 
# amongst us non-galaxy meme brain
COPY . ./
# since the test project relies on the api project, we get the api restore "free" here.
RUN dotnet restore ./web.test/web.test.csproj
#this step will result in a build failure if the tests do not pass
RUN dotnet test ./web.test/web.test.csproj --no-restore > ./web.test/results.xml

RUN dotnet publish ./web/web.csproj -c Release -o ../out
#now that there's an output directory, we ought to copy the test results out there.
RUN cp ./web.test/results.xml ./out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "web.dll"]