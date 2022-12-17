FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Example.CodingTask.Host/Example.CodingTask.Host.csproj", "Example.CodingTask.Host/"]
COPY ["Example.CodingTask.Core/Example.CodingTask.Core.csproj", "Example.CodingTask.Core/"]
COPY ["Example.CodingTask.Data/Example.CodingTask.Data.csproj", "Example.CodingTask.Data/"]
COPY ["Example.CodingTask.Common/Example.CodingTask.Common.csproj", "Example.CodingTask.Common/"]
COPY ["Example.CodingTask.Utilities/Example.CodingTask.Utilities.csproj", "Example.CodingTask.Utilities/"]
COPY ["Example.CodingTask.Service/Example.CodingTask.Service.csproj", "Example.CodingTask.Service/"]
RUN dotnet restore "Example.CodingTask.Host/Example.CodingTask.Host.csproj"
COPY . .

RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN export PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update --project "Example.CodingTask.Data/Example.CodingTask.Data.csproj"

WORKDIR "/src/Example.CodingTask.Host"
RUN dotnet build "Example.CodingTask.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.CodingTask.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.CodingTask.Host.dll"]