# This Docker file is intended for the CI
# A prerequisite is a published application in src/bin/Release/net8.0/
FROM mcr.microsoft.com/dotnet/aspnet:8.0.3-alpine3.18-amd64

EXPOSE 5000
ENV ASPNETCORE_URLS http://+:5000
ENV APP_NAME VsixGallery

WORKDIR /app
COPY ./src/bin/Release/net8.0/ .
COPY ./src/wwwroot/ ./wwwroot

CMD ["dotnet", "VsixGallery.dll"]