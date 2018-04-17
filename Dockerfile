FROM microsoft/aspnetcore-build AS builder
WORKDIR /source

# Copy everything else and build
COPY ./ ./
RUN dotnet restore
RUN dotnet publish --output /app/

# Default Environment
ENV ASPNETCORE_ENVIRONMENT="Development"

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "BoletoTemplateMock.dll"]