# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
LABEL maintainer="username@hostname"

WORKDIR /app

# RID is short for Runtime IDentifier.
# https://docs.microsoft.com/en-us/dotnet/core/rid-catalog#linux-rids

COPY *.csproj .
RUN dotnet restore \
    --runtime linux-musl-x64

COPY . .
RUN dotnet publish \
    --configuration release \
    --output /app/out \
    --runtime linux-musl-x64 \
    --self-contained false \
    --no-restore


FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine
LABEL maintainer="username@hostname"

WORKDIR /app

# https://github.com/dotnet/announcements/issues/20
RUN apk add --no-cache icu-libs=64.2-r1
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT false
# ENV LC_ALL en_US.UTF-8
# ENV LANG en_US.UTF-8

RUN addgroup application-group --gid 1001 \
    && adduser application-user --uid 1001 \
    --ingroup application-group \
    --disabled-password

COPY --from=build /app/out .
RUN chown --recursive application-user .
USER application-user
ENTRYPOINT ["./dotnetapp"]
