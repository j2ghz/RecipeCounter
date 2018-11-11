FROM microsoft/dotnet:sdk AS build-env
RUN curl -sL https://deb.nodesource.com/setup_11.x | bash - \
    && curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg | sudo apt-key add -
    && echo "deb https://dl.yarnpkg.com/debian/ stable main" | sudo tee /etc/apt/sources.list.d/yarn.list
    && apt-get update && apt-get install -y --no-install-recommends \
        nodejs \
        yarn

WORKDIR /app
RUN dotnet tool install fake-cli -g

# Copy everything else and build
COPY . ./
RUN export PATH="$PATH:/root/.dotnet/tools" && fake build --target Bundle

FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
COPY --from=build-env /app/deploy /
WORKDIR /Server
EXPOSE 8085
ENTRYPOINT [ "dotnet", "Server.dll" ]
