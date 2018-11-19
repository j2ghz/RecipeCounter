FROM microsoft/dotnet:sdk AS build-env
RUN curl -sL https://deb.nodesource.com/setup_11.x | bash -
RUN curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add -
RUN echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list
RUN apt install apt-transport-https dirmngr
RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
RUN echo "deb https://download.mono-project.com/repo/debian stable-stretch main" | tee /etc/apt/sources.list.d/mono-official-stable.list
RUN apt-get update
RUN apt-get install -y --no-install-recommends \
        nodejs \
        yarn \
        mono-devel

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
