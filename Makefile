# Version config
TAG := $(shell git tag --points-at HEAD | sort --version-sort | tail -n 1)
LASTTAG := $(or $(shell git tag -l | sort -r -V | head -n 1),"0.1.0")
SNAPINFO := $(shell date +%Y%m%d%H%M%S)git$(shell git log -1 --pretty=%h)
RELEASE := $(or $(BUILD_NUMBER), 1)
VERSION := $(or $(TAG:v%=%),$(LASTTAG:v%=%))-$(or $(BUILD_NUMBER), 1)$(if $(TAG),,.$(SNAPINFO))

# Executables
DOCKER := docker
DOTNET := dotnet

# Integration test config
IMAGE := mcr.microsoft.com/dotnet/core/sdk:2.2
TEST :=
CACHE := $(HOME)/.local/share/blockchyp/itest-cache
HOSTCONFIGFILE := $(HOME)/.config/blockchyp/sdk-itest-config.json
CONFIGFILE := $(CACHE)/sdk-itest-config.json
HOSTCERTFILE := src/BlockChyp/Assets/BlockChyp.crt
CERTFILE := $(CACHE)/blockchyp.crt
ifeq ($(shell uname -s), Linux)
HOSTIP = $(shell ip -4 addr show docker0 | grep -Po 'inet \K[\d.]+')
else
HOSTIP = host.docker.internal
endif

# Default target
.PHONY: all
all: clean build test

# Builds artifacts
.PHONY: clean
clean:
	$(DOTNET) clean

# Compiles the package
.PHONY: build
build:
	$(DOTNET) restore -v n
	$(DOTNET) build src/BlockChyp/BlockChyp.csproj -c Release -v n
	$(DOTNET) pack src/BlockChyp/BlockChyp.csproj -c Release -v n

# Runs unit tests
.PHONY: test
test:
	$(DOTNET) test tests/BlockChypTest/BlockChypTest.csproj --filter "Category!=Integration" -v n

# Runs integration tests. Set LOCALBUILD=1 to run locally, or run in docker by default.
.PHONY: integration
integration:
	$(if $(LOCALBUILD),,\
		mkdir -p $(CACHE) ; \
		sed 's/localhost/$(HOSTIP)/' $(HOSTCONFIGFILE) >$(CONFIGFILE) ; \
		/bin/cp $(HOSTCERTFILE) $(CERTFILE) ; \
		$(DOCKER) run \
		-v $(shell pwd):/tmp/workspace:Z \
		-v $(CACHE)/.nuget:/root/.nuget:Z \
		-v $(CACHE)/blockchyp.crt:/tmp/workspace/src/BlockChyp/Assets/BlockChyp.crt:Z \
		-v $(CACHE)/sdk-itest-config.json:/root/.config/blockchyp/sdk-itest-config.json:Z \
		-e BC_TEST_DELAY=$(BC_TEST_DELAY) \
		-w /tmp/workspace \
		--rm $(IMAGE)) \
	$(DOTNET) test tests/BlockChypTest/BlockChypTest.csproj \
	$(if $(TEST), --filter FullyQualifiedName~$(TEST),--filter Category=Integration) \
	-v n

# Performs any tasks necessary before a release build
.PHONY: stage
stage:

# Publishes package
.PHONY: publish
publish:
	$(DOTNET) nuget push src/BlockChyp/bin/Release/BlockChyp.*.nupkg \
		--api-key "${NUGET_API_KEY}" \
		--source https://api.nuget.org/v3/index.json
