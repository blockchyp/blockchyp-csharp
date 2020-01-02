# Version config
TAG := $(shell git tag --points-at HEAD | sort --version-sort | tail -n 1)
LASTTAG := $(or $(shell git tag -l | sort -r -V | head -n 1),"0.1.0")
SNAPINFO := $(shell date +%Y%m%d%H%M%S)git$(shell git log -1 --pretty=%h)
RELEASE := $(or $(BUILD_NUMBER), 1)
VERSION := $(or $(TAG:v%=%),$(LASTTAG:v%=%))-$(or $(BUILD_NUMBER), 1)$(if $(TAG),,.$(SNAPINFO))

# Executables
DOTNET := dotnet

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

# Runs integration tests
.PHONY: integration
integration:
	$(DOTNET) test tests/BlockChypTest/BlockChypTest.csproj --filter "Category=Integration" -v n

# Performs any tasks necessary before a release build
.PHONY: stage
stage:

# Publishes package
.PHONY: integration
publish:
	$(DOTNET) nuget push src/BlockChyp/bin/Release/BlockChyp.*.nupkg \
		--api-key "${NUGET_API_KEY}" \
		--source https://api.nuget.org/v3/index.json
