# This Docker file is intended for the CI
# A prerequisite is a published application in the .build/release
FROM mcr.microsoft.com/dotnet/sdk:8.0

EXPOSE 5000
ENV ASPNETCORE_URLS http://+:5000
ENV APP_NAME VsixGallery

WORKDIR /app
COPY src/bin/Release/net8.0/ .
COPY src/wwwroot/ ./wwwroot

CMD ["dotnet", "VsixGallery.dll"]