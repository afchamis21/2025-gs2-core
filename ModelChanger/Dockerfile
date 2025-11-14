FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

ARG PROJECT_PATH
COPY $PROJECT_PATH .

COPY . .

RUN dotnet restore $PROJECT_PATH

RUN dotnet build $PROJECT_PATH -c Release -o /app/build

RUN dotnet publish $PROJECT_PATH -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "ModelChanger.dll"] 