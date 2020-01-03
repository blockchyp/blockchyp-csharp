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
export BC_TEST_DELAY := 5
IMAGE := mcr.microsoft.com/dotnet/core/sdk:2.2
SCMROOT := $(shell git rev-parse --show-toplevel)
PWD := $(shell pwd)
CACHE := $(HOME)/.local/share/blockchyp/itest-cache
CONFIGFILE := $(HOME)/.config/blockchyp/sdk-itest-config.json
CACHEPATHS := $(dir $(CONFIGFILE)) $(HOME)/.nuget $(HOME)/.dotnet $(HOME)/.local
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
		$(foreach path,$(CACHEPATHS),mkdir -p $(CACHE)/$(path) ; ) \
		sed 's/localhost/$(HOSTIP)/' $(CONFIGFILE) >$(CACHE)/$(CONFIGFILE) ; \
		$(DOCKER) run \
		-u $(shell id -u):$(shell id -g) \
		-v $(SCMROOT):$(SCMROOT):Z \
		-v /etc/passwd:/etc/passwd:ro \
		$(foreach path,$(CACHEPATHS),-v $(CACHE)/$(path):$(path):Z) \
		-e BC_TEST_DELAY=$(BC_TEST_DELAY) \
		-e HOME=$(HOME) \
		-w $(PWD) \
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
