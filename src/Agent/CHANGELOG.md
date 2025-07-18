# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [10.42.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.41.0...v10.42.0) (2025-06-24)


### Notice

* As of this release, there is a new public key available for apt.newrelic.com at https://download.newrelic.com/NEWRELIC_APT_2DAD550E.public. This key uses a more secure GPG algorithm than the current public key. If you use APT to install or upgrade the agent on APT-based Linux hosts, we recommend that you switch to using the new key, following the instructions found here: https://docs.newrelic.com/install/dotnet/?deployment=linux&docker=noDocker#apt ([1001cf7](https://github.com/newrelic/newrelic-dotnet-agent/commit/1001cf7fc5b250a580dd75168b8440eb86573278))


### New features

* Add support for Azure Service Bus. ([#3124](https://github.com/newrelic/newrelic-dotnet-agent/issues/3124)) ([6a075cc](https://github.com/newrelic/newrelic-dotnet-agent/commit/6a075ccbb2b7b59c509ce93fcad36202d4d5a6da))


### Fixes

* Fix Profiler build errors with latest VS ([#3162](https://github.com/newrelic/newrelic-dotnet-agent/issues/3162)) ([0cfdedb](https://github.com/newrelic/newrelic-dotnet-agent/commit/0cfdedb4ff2a9bfc602f6844e262c2d4d455583a))

## [10.41.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.40.1...v10.41.0) (2025-04-25)


### New features

* Allow incoming W3C traceparent `sampled` flag to influence .NET agent sampling decision. ([#3100](https://github.com/newrelic/newrelic-dotnet-agent/issues/3100)) ([6047bda](https://github.com/newrelic/newrelic-dotnet-agent/commit/6047bda423e7d6a8c0d639142584c3651618f4a5))


### Fixes

* Null reference exception in Asp.NET Core 6+ browser monitoring injection.  ([#3102](https://github.com/newrelic/newrelic-dotnet-agent/issues/3102)) ([49df7bf](https://github.com/newrelic/newrelic-dotnet-agent/commit/49df7bfb75fbccc5961cc59a597b2e92f371982c))

## [10.40.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.40.0...v10.40.1) (2025-04-15)


### Fixes

* Specify a non-infinite timeout when creating `HttpClient` and `SocketsHttpHandler` instances. ([#3084](https://github.com/newrelic/newrelic-dotnet-agent/issues/3084)) ([6f72158](https://github.com/newrelic/newrelic-dotnet-agent/commit/6f72158b201f1b7f134c2336ecd02c6ac8fca261))
* When sql explain plan generation fails, don't attempt to generate an explain plan on future invocations of the same query. ([#3075](https://github.com/newrelic/newrelic-dotnet-agent/issues/3075)) ([12e1743](https://github.com/newrelic/newrelic-dotnet-agent/commit/12e17434496fdf9da9f357853578fa1548d266d0))

## [10.40.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.39.0...v10.40.0) (2025-04-01)


### New features

* Add Couchbase 3.x instrumentation ([#3048](https://github.com/newrelic/newrelic-dotnet-agent/issues/3048)) ([7ef0c82](https://github.com/newrelic/newrelic-dotnet-agent/commit/7ef0c82be230438f99e1398b81455de7d2b88e48))
* Add instrumentation for AWS Kinesis Data Streams and Kinesis Delivery Streams (Firehose) ([7b52a67](https://github.com/newrelic/newrelic-dotnet-agent/commit/7b52a67c65f9f3fdb78e0ac194b608c75726090a))
* Add support for MongoDB.Driver 3.x and above. ([#3065](https://github.com/newrelic/newrelic-dotnet-agent/issues/3065)) ([c8acbc5](https://github.com/newrelic/newrelic-dotnet-agent/commit/c8acbc5b3767402b08544e550a771712c802f24a))


### Fixes

* Add more null checks to Asp.NET Core 6+ browser instrumentation logic ([#3070](https://github.com/newrelic/newrelic-dotnet-agent/issues/3070)) ([5f5cf12](https://github.com/newrelic/newrelic-dotnet-agent/commit/5f5cf12703264fde15ef0bd332734329dc3355a3))
* In-process Azure Function publishes Nuget agent DLLs to the wrong folder ([#3068](https://github.com/newrelic/newrelic-dotnet-agent/issues/3068)) ([ee04d25](https://github.com/newrelic/newrelic-dotnet-agent/commit/ee04d257a2dbddb40bce0c6c2601a53fa90a7364))
* Profiler should not log "with parent process" unless parent process is non-empty ([#3066](https://github.com/newrelic/newrelic-dotnet-agent/issues/3066)) ([a6c6d7d](https://github.com/newrelic/newrelic-dotnet-agent/commit/a6c6d7d15f516ae65671d0146af3d7785334a190))

## [10.39.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.38.0...v10.39.0) (2025-03-19)


### Notice

* Automatic browser agent injection for ASP.NET Core v6+ web applications has been enabled by default. If you experience any issues with this feature, please see item 2 on [this page](https://docs.newrelic.com/docs/apm/agents/net-agent/other-features/browser-monitoring-net-agent/#enable_netcore6plus) for a setting that can be set to `false` to disable the feature and [contact us for support](https://docs.newrelic.com/docs/new-relic-solutions/solve-common-issues/find-help-use-support-portal/). ([051ceab](https://github.com/newrelic/newrelic-dotnet-agent/commit/051ceab6e2747209c965dc7d9156d9cf59dbf9e2))


### New features

* Enable ASP.NET Core browser auto-injection by default. ([051ceab](https://github.com/newrelic/newrelic-dotnet-agent/commit/051ceab6e2747209c965dc7d9156d9cf59dbf9e2))
* Instrument In-Process Azure Function invocations, with distributed tracing support for Http and Service Bus triggers. ([#3003](https://github.com/newrelic/newrelic-dotnet-agent/issues/3003)) ([47d22a1](https://github.com/newrelic/newrelic-dotnet-agent/commit/47d22a11321f160084d230785b8d6475181e77c7))


### Fixes

* Look for `ASPNETCORE_IIS_APP_POOL_ID` if `APP_POOL_ID` isn't found. ([#3036](https://github.com/newrelic/newrelic-dotnet-agent/issues/3036)) ([620064c](https://github.com/newrelic/newrelic-dotnet-agent/commit/620064c3c3c59891f5daa3948663bf892bed8358))
* Remove diagnostics tracing output from agent API calls ([#3029](https://github.com/newrelic/newrelic-dotnet-agent/issues/3029)) ([be7b7f4](https://github.com/newrelic/newrelic-dotnet-agent/commit/be7b7f4b3b57a5d056313c940026c4681243b038))
* Remove unnecessary dependency on `System.Runtime.InteropServices.RuntimeInformation` in .NET 4.6.2  builds. ([#3033](https://github.com/newrelic/newrelic-dotnet-agent/issues/3033)) ([ab81d1c](https://github.com/newrelic/newrelic-dotnet-agent/commit/ab81d1c5eaed14b3928bcaed0fe2c64b31795ad9))
* Set Profiler logger to initialized when configuration load fails. ([#3015](https://github.com/newrelic/newrelic-dotnet-agent/issues/3015)) ([7ab30d7](https://github.com/newrelic/newrelic-dotnet-agent/commit/7ab30d712ab59901d21c434019b8d28eb95f7280))

## [10.38.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.37.0...v10.38.0) (2025-03-04)


### New features

* Add support for PackageReference with NewRelic.Azure.WebSites packages. ([#3001](https://github.com/newrelic/newrelic-dotnet-agent/issues/3001)) ([8fb397f](https://github.com/newrelic/newrelic-dotnet-agent/commit/8fb397fe4d7b8c11f5939182119ce00097ae0640))
* Azure Function instrumentation is enabled by default ([#3007](https://github.com/newrelic/newrelic-dotnet-agent/issues/3007)) ([8eba1bf](https://github.com/newrelic/newrelic-dotnet-agent/commit/8eba1bf0da15d8efdb606bd49ffdb881c8c0549f))

## [10.37.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.36.0...v10.37.0) (2025-02-19)


### New features

* Add AI Monitoring instrumentation for `AmazonBedrockRuntimeClient.ConverseAsync()` ([#2997](https://github.com/newrelic/newrelic-dotnet-agent/issues/2997)) ([cdc2f6c](https://github.com/newrelic/newrelic-dotnet-agent/commit/cdc2f6c6de6640a72ad2c729f8f3abe31a14289c))
* Add AI Monitoring instrumentation for OpenAI and Azure.AI.OpenAI ([#2987](https://github.com/newrelic/newrelic-dotnet-agent/issues/2987)) ([aa06d9d](https://github.com/newrelic/newrelic-dotnet-agent/commit/aa06d9db633f12f345fdfa6a574dd9e1a8fbec85))
* Add support for .NET Framework Azure Function Apps ([#2992](https://github.com/newrelic/newrelic-dotnet-agent/issues/2992)) ([5b077f3](https://github.com/newrelic/newrelic-dotnet-agent/commit/5b077f3dc898f57a3637de01d5da4bf4a3b5e143))
* Improve logging and validation for license keys. ([#2982](https://github.com/newrelic/newrelic-dotnet-agent/issues/2982)) ([19e8387](https://github.com/newrelic/newrelic-dotnet-agent/commit/19e8387a49e01d706691512dea1bb32e8d124b87))

## [10.36.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.35.0...v10.36.0) (2025-02-05)


### New features

* Add .NET 8+ support for System.Data.Odbc ([#2948](https://github.com/newrelic/newrelic-dotnet-agent/issues/2948)) ([7ee9825](https://github.com/newrelic/newrelic-dotnet-agent/commit/7ee9825b21fbd442c066ccfe9040a0bd129840dd))
* Add support for instrumenting OpenSearchClient requests. ([#2956](https://github.com/newrelic/newrelic-dotnet-agent/issues/2956)) ([4309938](https://github.com/newrelic/newrelic-dotnet-agent/commit/4309938c5d0593029398d7658a37b5ebe78c283c))


### Fixes

* Add Azure Function app name prefix to `faas.name` attribute in Azure Function transactions. ([#2973](https://github.com/newrelic/newrelic-dotnet-agent/issues/2973)) ([80d4c76](https://github.com/newrelic/newrelic-dotnet-agent/commit/80d4c7619cbe8876b0ceacbf561b55b458a1189b))
* Custom attribute values of type float and decimal were not serialized correctly. ([#2975](https://github.com/newrelic/newrelic-dotnet-agent/issues/2975)) ([8812fe1](https://github.com/newrelic/newrelic-dotnet-agent/commit/8812fe1127270937fa869370443afff7aeb862e3))
* Improve error handling in AWS account ID parsing logic ([#2984](https://github.com/newrelic/newrelic-dotnet-agent/issues/2984)) ([9b66750](https://github.com/newrelic/newrelic-dotnet-agent/commit/9b66750e3343bccd10f269701d257b056eb660cc))

## [10.35.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.34.1...v10.35.0) (2025-01-21)


### New features

* Enable DynamoDB entity relationships ([#2923](https://github.com/newrelic/newrelic-dotnet-agent/issues/2923)) ([f70b64a](https://github.com/newrelic/newrelic-dotnet-agent/commit/f70b64aa20ac21e5b30dfa5d2f63ab59850bcf58))
* Instrument Lambda invocations in AWS SDK ([#2901](https://github.com/newrelic/newrelic-dotnet-agent/issues/2901)) ([3b655e4](https://github.com/newrelic/newrelic-dotnet-agent/commit/3b655e423de4d5bf77ba491d63eec38b3323ffda))
* Use `SocketsHttpHandler` to configure `HttpClient` in .NET 6+. ([#2931](https://github.com/newrelic/newrelic-dotnet-agent/issues/2931)) ([eb3afda](https://github.com/newrelic/newrelic-dotnet-agent/commit/eb3afdafc450f4b268885a45264c328fab6bfd9a))


### Fixes

* Console logging is inconsistent between Agent and Profiler ([#2955](https://github.com/newrelic/newrelic-dotnet-agent/issues/2955)) ([7c42b33](https://github.com/newrelic/newrelic-dotnet-agent/commit/7c42b33279c948a69ea36aaf54630554ebf5a5e6))
* Incorrect string comparison in the profiler caused constructor instrumentation to fail on Linux ([#2912](https://github.com/newrelic/newrelic-dotnet-agent/issues/2912)) ([49a71c5](https://github.com/newrelic/newrelic-dotnet-agent/commit/49a71c50d43f2cb18e208dddb258a456aebb7e61))
* Refactoring to reduce the likelihood of a deadlock in `HttpClient.SendAsync()`. ([#2931](https://github.com/newrelic/newrelic-dotnet-agent/issues/2931)) ([eb3afda](https://github.com/newrelic/newrelic-dotnet-agent/commit/eb3afdafc450f4b268885a45264c328fab6bfd9a))

## [10.34.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.34.0...v10.34.1) (2024-12-02)


### Fixes

* Remove .NET Standard libraries from .NET Framework target ([#2896](https://github.com/newrelic/newrelic-dotnet-agent/issues/2896)) ([0873941](https://github.com/newrelic/newrelic-dotnet-agent/commit/0873941b6c869db7696e154950b36762a2e2b16f))

## [10.34.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.33.1...v10.34.0) (2024-11-19)


### Notice

* The .NET agent now allows you to opt-in to adding your custom tags (labels) to agent-forwarded logs. With custom tags on logs, platform engineers can easily filter, search, and correlate log data for faster and more efficient troubleshooting, improved performance, and optimized resource utilization. To learn more about this feature see the [documentation](https://docs.newrelic.com/docs/logs/logs-context/Custom-tags-agent-forwarder-logs).(https://github.com/newrelic/newrelic-dotnet-agent/pull/2831) ([d1e29ea](https://github.com/newrelic/newrelic-dotnet-agent/commit/d1e29eaa5103fede483c7248fed5ace0620c6ccd))


### New features

* Add Distributed Tracing support for Azure Functions HTTPTrigger. ([#2868](https://github.com/newrelic/newrelic-dotnet-agent/issues/2868)) ([0278836](https://github.com/newrelic/newrelic-dotnet-agent/commit/0278836fc9b538f9eceabd47af7b5da46ed13274))
* The .NET agent now allows you to opt-in to adding your custom tags (labels) to agent-forwarded logs. With custom tags on logs, platform engineers can easily filter, search, and correlate log data for faster and more efficient troubleshooting, improved performance, and optimized resource utilization. To learn more about this feature see the [documentation](https://docs.newrelic.com/docs/logs/logs-context/Custom-tags-agent-forwarder-logs).(https://github.com/newrelic/newrelic-dotnet-agent/pull/2831) ([d1e29ea](https://github.com/newrelic/newrelic-dotnet-agent/commit/d1e29eaa5103fede483c7248fed5ace0620c6ccd))


### Fixes

* Don't instrument certain processes in Azure Linux App Service deployments. Resolves [#2871](https://github.com/newrelic/newrelic-dotnet-agent/issues/2871). ([7ed945b](https://github.com/newrelic/newrelic-dotnet-agent/commit/7ed945b659be8a670d27c5a266738ffd5a712a41))
* Fix a bug in `run.sh`. Resolves [#2887](https://github.com/newrelic/newrelic-dotnet-agent/issues/2887) ([#2888](https://github.com/newrelic/newrelic-dotnet-agent/issues/2888)) ([df17cfd](https://github.com/newrelic/newrelic-dotnet-agent/commit/df17cfdf6d777ed623c437c2f9dd5dfab3651260))

## [10.33.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.33.0...v10.33.1) (2024-10-31)


### Fixes

* Fix syntax error in `setenv.sh` ([#2864](https://github.com/newrelic/newrelic-dotnet-agent/issues/2864)) ([a629138](https://github.com/newrelic/newrelic-dotnet-agent/commit/a629138e0e0b00a52f513d64c661576376e64455)), closes [#2863](https://github.com/newrelic/newrelic-dotnet-agent/issues/2863)

## [10.33.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.32.0...v10.33.0) (2024-10-30)


### New features

* Add AWSSDK.DynamoDBv2 instrumentation.  Versions 3.5 through 4.0.0-preview.4 are supported.  Note: previous agent versions would instrument DynamoDB calls as Externals; now DynamoDB calls will show up as Database operations in the New Relic UI. ([2460527](https://github.com/newrelic/newrelic-dotnet-agent/commit/2460527c83c0b196329a2e2b61e435cd20cd6dbd))
* Add config option for providing AWS account ID for linking ([#2851](https://github.com/newrelic/newrelic-dotnet-agent/issues/2851)) ([936b6f6](https://github.com/newrelic/newrelic-dotnet-agent/commit/936b6f63c837dd03222281870ae5db40574693ff))
* New Garbage Collection Metrics Sampler for .NET 6+ ([#2838](https://github.com/newrelic/newrelic-dotnet-agent/issues/2838)) ([f24a5da](https://github.com/newrelic/newrelic-dotnet-agent/commit/f24a5daa2cc6117a73eac96f2a45d738335d063a))


### Fixes

* Fix potential race condition in AWS SDK, AWS Bedrock, and Elastisearch that could lead to an orphaned Transaction. ([#2842](https://github.com/newrelic/newrelic-dotnet-agent/issues/2842)) ([3afa15f](https://github.com/newrelic/newrelic-dotnet-agent/commit/3afa15f3cf70d4bda5cecbd728c377ad7cb4ff28))
* Remove usage of non-thread safe HashSet in AwsSdk pipeline wrappers. Thanks, [@gjunge](https://github.com/gjunge)! ([#2855](https://github.com/newrelic/newrelic-dotnet-agent/issues/2855)) ([#2857](https://github.com/newrelic/newrelic-dotnet-agent/issues/2857)) ([ae1d422](https://github.com/newrelic/newrelic-dotnet-agent/commit/ae1d4220e684192525f13c670436dbf4400012bd))
* Revert environment variable name change in installers and scripts ([#2852](https://github.com/newrelic/newrelic-dotnet-agent/issues/2852)) ([e77683b](https://github.com/newrelic/newrelic-dotnet-agent/commit/e77683b7e60afa502b6e700a51945c757530a47b))

## [10.32.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.31.0...v10.32.0) (2024-10-15)


### Notice

* Environment variables that start with or contain `NEWRELIC_` are deprecated and may be removed in a future major release. Users are encouraged to update their installation to use `NEW_RELIC_` names as soon as possible. ([b00edda](https://github.com/newrelic/newrelic-dotnet-agent/commit/b00edda2e617ff3176cff8b2243171cbe51e391f))


### New features

* Implement consistent naming scheme for all environment variables. All environment variables starting with (or containing) `NEWRELIC_` are now named `NEW_RELIC_`. Support for previous environment variables is retained, so this is not a breaking change. ([#718](https://github.com/newrelic/newrelic-dotnet-agent/issues/718)) ([#2812](https://github.com/newrelic/newrelic-dotnet-agent/issues/2812)) ([b00edda](https://github.com/newrelic/newrelic-dotnet-agent/commit/b00edda2e617ff3176cff8b2243171cbe51e391f))
* Update CosmosDB instrumentation to support latest version ([#2832](https://github.com/newrelic/newrelic-dotnet-agent/issues/2832)) ([27a78cb](https://github.com/newrelic/newrelic-dotnet-agent/commit/27a78cb141fed90f2a3585d910bd8a5f74f94238))


### Fixes

* Handle null or empty SQS messages and/or message attributes ([#2833](https://github.com/newrelic/newrelic-dotnet-agent/issues/2833)) ([758b770](https://github.com/newrelic/newrelic-dotnet-agent/commit/758b770bb0ecf7c1a39e12b43c3279f26fdc0ed1))
* Update Profiler to check whether Azure function mode support is enabled ([#2822](https://github.com/newrelic/newrelic-dotnet-agent/issues/2822)) ([9669641](https://github.com/newrelic/newrelic-dotnet-agent/commit/966964114018066d0e72f2b3fc12ff7974b66804))

## [10.31.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.30.0...v10.31.0) (2024-09-25)


### New features

* Add support for the EnyimMemcachedCore client. ([#2781](https://github.com/newrelic/newrelic-dotnet-agent/issues/2781)) ([52bdc11](https://github.com/newrelic/newrelic-dotnet-agent/commit/52bdc11a5194074afb2e6f806ab764c8aca39051))
* Allow container linking for AWS ECS applications. ([#2683](https://github.com/newrelic/newrelic-dotnet-agent/issues/2683)) ([d55567f](https://github.com/newrelic/newrelic-dotnet-agent/commit/d55567fb4674ea64443ac4a96e7d3f7f81dc3c97))
* Parse Azure Function HttpTrigger parameters ([#2776](https://github.com/newrelic/newrelic-dotnet-agent/issues/2776)) ([7e8c28b](https://github.com/newrelic/newrelic-dotnet-agent/commit/7e8c28bbbcb97c62d0da0db6e1affcae2ff445b1))


### Fixes

* Prevent FileNotFoundException when handling connection issues while instrumenting .NET Framework apps. ([#2750](https://github.com/newrelic/newrelic-dotnet-agent/issues/2750)) ([#2751](https://github.com/newrelic/newrelic-dotnet-agent/issues/2751)) ([cebd287](https://github.com/newrelic/newrelic-dotnet-agent/commit/cebd28703224afed1fda24cb984657eb86f4b51d))

## [10.30.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.29.0...v10.30.0) (2024-09-11)


### New features

* Oracle instrumentation now supports latest version ([#2721](https://github.com/newrelic/newrelic-dotnet-agent/issues/2721)) ([50cb663](https://github.com/newrelic/newrelic-dotnet-agent/commit/50cb663957ccfcfd55d104a7f54755100bfa46cc))
* Preview support for instrumentation of "isolated" model Azure Functions. Instrumentation is disabled by default. Please reach out to your account team if you would like to try this new feature. ([d8a79e5](https://github.com/newrelic/newrelic-dotnet-agent/commit/d8a79e51683225e9b574efc8d1b154b2a4b9eadc))


### Fixes

* Preserve custom query name even if statement can't be parsed. ([#2708](https://github.com/newrelic/newrelic-dotnet-agent/issues/2708)) ([#2709](https://github.com/newrelic/newrelic-dotnet-agent/issues/2709)) ([3ab0cb4](https://github.com/newrelic/newrelic-dotnet-agent/commit/3ab0cb4f36d3f5fa07d4003b930917e533c7cba2))

## [10.29.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.28.0...v10.29.0) (2024-08-20)


### New features

* Additional metrics and attributes for some instrumented libraries ([#2675](https://github.com/newrelic/newrelic-dotnet-agent/issues/2675)) ([a033b81](https://github.com/newrelic/newrelic-dotnet-agent/commit/a033b81b19ba65b7336762c89a974160cc2e5491))
* Auto-instrument ASP.NET Core Lambda functions ([#2662](https://github.com/newrelic/newrelic-dotnet-agent/issues/2662)) ([#2674](https://github.com/newrelic/newrelic-dotnet-agent/issues/2674)) ([ceaefc5](https://github.com/newrelic/newrelic-dotnet-agent/commit/ceaefc51bd15c3baaa05f4d0306645852aea1392))
* Use Lambda function name if application name is not set ([#2695](https://github.com/newrelic/newrelic-dotnet-agent/issues/2695)) ([3dcf3af](https://github.com/newrelic/newrelic-dotnet-agent/commit/3dcf3af535ad14b39cb27d9de2704b41780f89b4))

## [10.28.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.27.0...v10.28.0) (2024-08-05)


### New features

* Improve serverless mode detection ([#2661](https://github.com/newrelic/newrelic-dotnet-agent/issues/2661)) ([5f5dda8](https://github.com/newrelic/newrelic-dotnet-agent/commit/5f5dda860a78152574f71f4f1095248707e8c7e3))
* Set application name via command line with the .msi installer ([#2648](https://github.com/newrelic/newrelic-dotnet-agent/issues/2648)) ([369dcba](https://github.com/newrelic/newrelic-dotnet-agent/commit/369dcbab4f3fa59354f683bae16b711f45be2387))


### Fixes

* Better Lambda web request input parameter validation. ([#2653](https://github.com/newrelic/newrelic-dotnet-agent/issues/2653)) ([810d4af](https://github.com/newrelic/newrelic-dotnet-agent/commit/810d4aff20457200b4166daa9744cefe8dfc699b)), closes [#2652](https://github.com/newrelic/newrelic-dotnet-agent/issues/2652)
* Revert recent Profiler warning fixes to address reported instability ([#2663](https://github.com/newrelic/newrelic-dotnet-agent/issues/2663)) ([b3c9cd1](https://github.com/newrelic/newrelic-dotnet-agent/commit/b3c9cd10c47dbe5c4654a1dcb1f90c3adeabe90f))
* SQS instrumentation could cause InvalidOperationException ([#2645](https://github.com/newrelic/newrelic-dotnet-agent/issues/2645)) ([#2646](https://github.com/newrelic/newrelic-dotnet-agent/issues/2646)) ([40b6ad5](https://github.com/newrelic/newrelic-dotnet-agent/commit/40b6ad5b899942eff9241da362a653a010cf2e7f))

## [10.27.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.26.0...v10.27.0) (2024-07-15)


### New features

* Add support for disabling LLM monitoring at the account level. ([#2592](https://github.com/newrelic/newrelic-dotnet-agent/issues/2592)) ([c31451a](https://github.com/newrelic/newrelic-dotnet-agent/commit/c31451a962404115d3cbe924347681919627c9e9))
* Instrumentation for Amazon Simple Queuing Service (AWSSDK.SQS) ([#2620](https://github.com/newrelic/newrelic-dotnet-agent/issues/2620)) ([ac738ba](https://github.com/newrelic/newrelic-dotnet-agent/commit/ac738ba250822b67854f273c4badc8dd45c3602e))

## [10.26.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.25.1...v10.26.0) (2024-06-26)


### Notice

* The .NET Agent now supports instrumenting AWS Lambda functions. See documentation for details: [https://docs.newrelic.com/docs/serverless-function-monitoring/aws-lambda-monitoring/get-started/monitoring-aws-lambda-serverless-monitoring/](https://docs.newrelic.com/docs/serverless-function-monitoring/aws-lambda-monitoring/get-started/monitoring-aws-lambda-serverless-monitoring/). ([d96e29f](https://github.com/newrelic/newrelic-dotnet-agent/commit/d96e29fff0f040d148f26f2e5ed81edd7192e17f))


### New features

* Add an option to disable the file system watcher. ([#2536](https://github.com/newrelic/newrelic-dotnet-agent/issues/2536)) ([27d0ed0](https://github.com/newrelic/newrelic-dotnet-agent/commit/27d0ed005073b624ba8806aa3acf9ef008102a9d))
* Add support for capturing container id from AWS ECS. ([#2481](https://github.com/newrelic/newrelic-dotnet-agent/issues/2481)) ([c018b8a](https://github.com/newrelic/newrelic-dotnet-agent/commit/c018b8ac93ae4aaf3144dcc28c3c4924c6259d2d))
* Add support for using Sitecore.Logging and log4net together ([#2537](https://github.com/newrelic/newrelic-dotnet-agent/issues/2537)) ([332529b](https://github.com/newrelic/newrelic-dotnet-agent/commit/332529b8cd0d48b11e6f4cc8796327db70a56e0b))


### Fixes

* Prevent NullReferenceExeption on APIGatewayProxyRequest ([#2529](https://github.com/newrelic/newrelic-dotnet-agent/issues/2529)) ([18d833f](https://github.com/newrelic/newrelic-dotnet-agent/commit/18d833ff6a91e63174ffe7dbd0e534a5493c8151))
* Refactor to eliminate usage of `.GetAwaiter().GetResult()` in Framework builds. ([#2534](https://github.com/newrelic/newrelic-dotnet-agent/issues/2534)) ([#2535](https://github.com/newrelic/newrelic-dotnet-agent/issues/2535)) ([cfb2c28](https://github.com/newrelic/newrelic-dotnet-agent/commit/cfb2c28975fb16b73341daa92923e387c85a2c3b))

## [10.25.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.25.0...v10.25.1) (2024-06-04)


### Fixes

* Agent license key should be optional in Serverless mode. ([#2499](https://github.com/newrelic/newrelic-dotnet-agent/issues/2499)) ([#2500](https://github.com/newrelic/newrelic-dotnet-agent/issues/2500)) ([801edc3](https://github.com/newrelic/newrelic-dotnet-agent/commit/801edc32a01dbc62a449963a41899ca68f987e78))
* Nested logging contexts should not disable context data for Microsoft.Extensions.Logging (2508) ([#2516](https://github.com/newrelic/newrelic-dotnet-agent/issues/2516)) ([6196af5](https://github.com/newrelic/newrelic-dotnet-agent/commit/6196af5a8f13b4c1e3bd7f315837c8b365fdb57a))

## [10.25.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.24.0...v10.25.0) (2024-05-21)


### New features

* Add support for AWS Lambda `APIGatewayHttpApiV2ProxyRequest` ([#2472](https://github.com/newrelic/newrelic-dotnet-agent/issues/2472)) ([3f06bf6](https://github.com/newrelic/newrelic-dotnet-agent/commit/3f06bf6a95465c37ee141c566b501d290e62d1fc))
* Enable configuration of ignored and expected HTTP status code errors with environment variables ([#2487](https://github.com/newrelic/newrelic-dotnet-agent/issues/2487)) ([eeb574f](https://github.com/newrelic/newrelic-dotnet-agent/commit/eeb574f3adfa1d90fcf39cd68b11e936d28292b4))


### Fixes

* Accept inbound tracing headers in Kafka consume method instrumentation ([#2488](https://github.com/newrelic/newrelic-dotnet-agent/issues/2488)) ([476378a](https://github.com/newrelic/newrelic-dotnet-agent/commit/476378aaddb58da22de3cbe30ce0cf778973fe5a))
* Upgrade Wix to v5 to fix an issue with non-elevated installs. ([#2471](https://github.com/newrelic/newrelic-dotnet-agent/issues/2471)) ([acd12fa](https://github.com/newrelic/newrelic-dotnet-agent/commit/acd12fae2b2bd4af6a1b29cb5574ea7e4513b870))

## [10.24.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.23.1...v10.24.0) (2024-05-07)


### Notice

* Due to an ongoing issue with the WiX Toolset, the Windows MSI installer must be run as admin. This will be addressed in an upcoming release. ([4d40da5](https://github.com/newrelic/newrelic-dotnet-agent/commit/4d40da5e8b76a32814a8cffd21f092451caaaf9e))


### New features

* Add preliminary support for AWS Lambda instrumentation. For details on how to enable this functionality, please contact your New Relic representative. ([4d40da5](https://github.com/newrelic/newrelic-dotnet-agent/commit/4d40da5e8b76a32814a8cffd21f092451caaaf9e))


### Fixes

* Fix bug in distributed tracing when `excludeNewrelicHeader` is set to true ([#2457](https://github.com/newrelic/newrelic-dotnet-agent/issues/2457)) ([1f95c9c](https://github.com/newrelic/newrelic-dotnet-agent/commit/1f95c9cdfee17172ce8517679f2f6168fd9ebb63))

## [10.23.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.23.0...v10.23.1) (2024-04-24)


### Fixes

* Fix duplicate key error when using Kafka with DT enabled ([#2433](https://github.com/newrelic/newrelic-dotnet-agent/issues/2433)) ([6a85c03](https://github.com/newrelic/newrelic-dotnet-agent/commit/6a85c034ba14d408d5b63fe6e77c9132f9f11c6c))
* Fix incorrectly tagging AIM data when AIM is disabled ([#2408](https://github.com/newrelic/newrelic-dotnet-agent/issues/2408)) ([30d12bb](https://github.com/newrelic/newrelic-dotnet-agent/commit/30d12bbc28795a857ed2b241fb157fa55bf9f17d))

## [10.23.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.22.0...v10.23.0) (2024-04-02)


### Notice

* AI monitoring offers custom-built insights and tracing for the complete lifecycle of an LLM’s prompts and responses, from raw user input to repaired/polished responses. AI monitoring provides built-in integrations with popular LLMs and components of the AI development stack. This release provides instrumentation for AWS Bedrock. ([a6f3364](https://github.com/newrelic/newrelic-dotnet-agent/commit/a6f3364d799e836d50862135b25d8ae654e9d613))
* New Relic AI monitoring is the industry’s first APM solution that provides end-to-end visibility for AI Large Language Model (LLM) applications. It enables end-to-end visibility into the key components of an AI LLM application. With AI monitoring, users can monitor, alert, and debug AI-powered applications for reliability, latency, performance, security and cost. AI monitoring also enables AI/LLM specific insights (metrics, events, logs and traces) which can easily integrate to build advanced guardrails for enterprise security, privacy and compliance. ([a6f3364](https://github.com/newrelic/newrelic-dotnet-agent/commit/a6f3364d799e836d50862135b25d8ae654e9d613))
* When AI monitoring is enabled, the agent will now capture AI LLM related data. This data will be visible under a new APM tab called AI Responses. See our [AI Monitoring documentation](https://docs.newrelic.com/docs/ai-monitoring/intro-to-ai-monitoring/) for more details. ([a6f3364](https://github.com/newrelic/newrelic-dotnet-agent/commit/a6f3364d799e836d50862135b25d8ae654e9d613))


### New features

* A new AI monitoring related public API method has been added - [SetLlmTokenCountingCallback](https://docs.newrelic.com/docs/apm/agents/net-agent/net-agent-api/setllmtokencountingcallback-net-agent-api/) ([a6f3364](https://github.com/newrelic/newrelic-dotnet-agent/commit/a6f3364d799e836d50862135b25d8ae654e9d613))
* Add auto-instrumentation for AWS Bedrock ([a6f3364](https://github.com/newrelic/newrelic-dotnet-agent/commit/a6f3364d799e836d50862135b25d8ae654e9d613))
* **deps:** Updated `Elastic.Clients.ElasticSearch` instrumentation points to work with v8.12.1+ ([453d15e](https://github.com/newrelic/newrelic-dotnet-agent/commit/453d15e9de84f91bea6ca5507bbecba354c773dd))
* New configuration options are available specific to [AI monitoring](https://docs.newrelic.com/docs/apm/agents/net-agent/configuration/net-agent-configuration/#ai_monitoring). ([a6f3364](https://github.com/newrelic/newrelic-dotnet-agent/commit/a6f3364d799e836d50862135b25d8ae654e9d613))


### Fixes

* Handle InvalidOperationException in StringsHelper.CleanUri() [#2373](https://github.com/newrelic/newrelic-dotnet-agent/issues/2373) ([#2374](https://github.com/newrelic/newrelic-dotnet-agent/issues/2374)) ([9f1a6af](https://github.com/newrelic/newrelic-dotnet-agent/commit/9f1a6af7d6006f6af70c98a21486ceb5795aa39f))

## [10.22.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.21.1...v10.22.0) (2024-03-19)


### New features

* Add a new API method to time currently unsupported datastore method calls. ([#2320](https://github.com/newrelic/newrelic-dotnet-agent/issues/2320)) ([81abc5c](https://github.com/newrelic/newrelic-dotnet-agent/commit/81abc5c78e39655f4153b2f9f0f7e5e8328f3577))
* Add transaction ID to intrinsic attributes for error events and traces regardless of DT/CAT settings ([#2341](https://github.com/newrelic/newrelic-dotnet-agent/issues/2341)) ([1df0342](https://github.com/newrelic/newrelic-dotnet-agent/commit/1df03420a690b1f1e46b9ef17b2184d27d314667))


### Fixes

* Fix a context data capture when the Microsoft.Extensions.Logging console logger is used (thanks [@lowell-trimble](https://github.com/lowell-trimble)!) ([#2261](https://github.com/newrelic/newrelic-dotnet-agent/issues/2261)) ([#2315](https://github.com/newrelic/newrelic-dotnet-agent/issues/2315)) ([f8422d6](https://github.com/newrelic/newrelic-dotnet-agent/commit/f8422d6c538db6ff32e0b1055e824b3536245c59))

## [10.21.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.21.0...v10.21.1) (2024-03-07)


### Fixes

* Update regex parsing for CGroup v1 to match agent spec. ([#2286](https://github.com/newrelic/newrelic-dotnet-agent/issues/2286)) ([7fa3410](https://github.com/newrelic/newrelic-dotnet-agent/commit/7fa34102a27114f3bc09f47a5c9e08a9e0382f52))

## [10.21.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.20.2...v10.21.0) (2024-02-26)


### Notice

* [Browser monitoring instrumentation](https://docs.newrelic.com/docs/apm/agents/net-agent/other-features/browser-monitoring-net-agent) for **ASP.NET CORE v6+ web applications** is disabled by default but can be [manually enabled by following these instructions](https://docs.newrelic.com/docs/apm/agents/net-agent/other-features/browser-monitoring-net-agent/#enable_netcore6plus). ([da8dd44](https://github.com/newrelic/newrelic-dotnet-agent/commit/da8dd446acf2f1a491c213838220294d67e7c1c5))


### New features

* Add new configuration options for logging to control log file size, log retention and log rollover strategy. Refer to our [log configuration documentation](https://docs.newrelic.com/docs/apm/agents/net-agent/configuration/net-agent-configuration/#log) for details. ([#1880](https://github.com/newrelic/newrelic-dotnet-agent/issues/1880)) ([#2264](https://github.com/newrelic/newrelic-dotnet-agent/issues/2264)) ([d33714f](https://github.com/newrelic/newrelic-dotnet-agent/commit/d33714f066f9cb521e2154cbae0570b84a07dd8d))
* Allows instrumentation to be disabled from a newrelic.config file. ([#2250](https://github.com/newrelic/newrelic-dotnet-agent/issues/2250)) ([1632adb](https://github.com/newrelic/newrelic-dotnet-agent/commit/1632adb94827c159e66fc000cb216caac5d80865))


### Fixes

* Certain Profiler log messages did not print correctly when running under Linux. ([#2200](https://github.com/newrelic/newrelic-dotnet-agent/issues/2200)) ([#2209](https://github.com/newrelic/newrelic-dotnet-agent/issues/2209)) ([1b75bf9](https://github.com/newrelic/newrelic-dotnet-agent/commit/1b75bf95c7b219c7bf310b1a8cd2fa1a95b11768))
* Use original regex to get container id from cgroup v1 in fallback case ([#2263](https://github.com/newrelic/newrelic-dotnet-agent/issues/2263)) ([9ecb88d](https://github.com/newrelic/newrelic-dotnet-agent/commit/9ecb88d5ceb582597937c7ac89a9ab0de6c98cb5))

## [10.20.2](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.20.1...v10.20.2) (2024-01-16)


### Fixes

* Eliminate intermittent deadlock on agent startup. ([#2183](https://github.com/newrelic/newrelic-dotnet-agent/issues/2183)) ([#2184](https://github.com/newrelic/newrelic-dotnet-agent/issues/2184)) ([11c0241](https://github.com/newrelic/newrelic-dotnet-agent/commit/11c02417ebb3cf845083ffa0c22e7338d7f99691))
* Path to agentinfo.json was built incorrectly, leading to file not found errors when running on Linux. ([#2156](https://github.com/newrelic/newrelic-dotnet-agent/issues/2156)) ([#2157](https://github.com/newrelic/newrelic-dotnet-agent/issues/2157)) ([bd7e0c3](https://github.com/newrelic/newrelic-dotnet-agent/commit/bd7e0c3b95010c7f5be3a207959801c8f620870a))
* Prevent multiple SessionCache instances from being created. ([#2180](https://github.com/newrelic/newrelic-dotnet-agent/issues/2180) ) ([#2186](https://github.com/newrelic/newrelic-dotnet-agent/issues/2186)) ([08a3015](https://github.com/newrelic/newrelic-dotnet-agent/commit/08a301513ede5792320ff87891f033cc4ef23e4a))
* Prevent null reference exceptions while serializing LoadedModuleWireModelCollection. ([#2185](https://github.com/newrelic/newrelic-dotnet-agent/issues/2185)) ([#2187](https://github.com/newrelic/newrelic-dotnet-agent/issues/2187)) ([afb6352](https://github.com/newrelic/newrelic-dotnet-agent/commit/afb635290173badc48c48846bc9cafdcf63dedd9))

## [10.20.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.20.0...v10.20.1) (2023-12-12)


### Fixes

* Fix a crash that can occur when the profiler logs certain characters. ([#1982](https://github.com/newrelic/newrelic-dotnet-agent/issues/1982)) ([#2109](https://github.com/newrelic/newrelic-dotnet-agent/issues/2109)) ([742d232](https://github.com/newrelic/newrelic-dotnet-agent/commit/742d232189ae5c94480711172d5db4219b20c384))
* Improve handling of .NET environments and settings from appsettings.*.json files ([#2125](https://github.com/newrelic/newrelic-dotnet-agent/issues/2125)) ([3c21fe9](https://github.com/newrelic/newrelic-dotnet-agent/commit/3c21fe9172f5e788f6d4879e50ced2fff9a07983))
* Obfuscate logged appSettings values ([#2110](https://github.com/newrelic/newrelic-dotnet-agent/issues/2110)) ([2d8da68](https://github.com/newrelic/newrelic-dotnet-agent/commit/2d8da680294b7dd5c0ae30e9ebcb93f1c940f754))
* Revert RabbitMQ HandleBasicDeliver instrumentation change from [#1972](https://github.com/newrelic/newrelic-dotnet-agent/issues/1972). Resolves [#2047](https://github.com/newrelic/newrelic-dotnet-agent/issues/2047) ([#2118](https://github.com/newrelic/newrelic-dotnet-agent/issues/2118)) ([0525182](https://github.com/newrelic/newrelic-dotnet-agent/commit/05251824d7540d01356760c126c4ec478722a8eb))
* Update instrumentation to support Elasticsearch v8.11.0 ([#2100](https://github.com/newrelic/newrelic-dotnet-agent/issues/2100)) ([9effb5d](https://github.com/newrelic/newrelic-dotnet-agent/commit/9effb5d952984141af18634f7eb3073fc1bd44c3))

## [10.20.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.19.2...v10.20.0) (2023-11-21)


### New features

* Allow the agent to run in environments with read-only filesystems. ([#2085](https://github.com/newrelic/newrelic-dotnet-agent/issues/2085)) ([09ab29d](https://github.com/newrelic/newrelic-dotnet-agent/commit/09ab29dabeef358cb8c6c035c4d726f5c14f0029))


### Fixes

* Defensively handle null source address in MassTransit instrumentation. ([#2055](https://github.com/newrelic/newrelic-dotnet-agent/issues/2055)) ([0249582](https://github.com/newrelic/newrelic-dotnet-agent/commit/024958260f628da018be883eb1b446713091760e))
* During browser agent injection, don't set ContentLength if headers have already been sent. Resolves [#2051](https://github.com/newrelic/newrelic-dotnet-agent/issues/2051) ([#2059](https://github.com/newrelic/newrelic-dotnet-agent/issues/2059)) ([c191aa6](https://github.com/newrelic/newrelic-dotnet-agent/commit/c191aa6035de4d0d95b94d8adbc80560745d06e0))
* Remove dependency on Serilog.Expressions. Resolves [#2083](https://github.com/newrelic/newrelic-dotnet-agent/issues/2083). ([9e355f3](https://github.com/newrelic/newrelic-dotnet-agent/commit/9e355f3507130394e0660e1eb7c99e6d368f6bfc))

## [10.19.2](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.19.1...v10.19.2) (2023-11-09)


### Fixes

* ASP.NET Core 6+ browser agent injection is disabled by default. ([e571ac1](https://github.com/newrelic/newrelic-dotnet-agent/commit/e571ac1094a86b6717a0d356432e067727f25130))

## [10.19.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.19.0...v10.19.1) (2023-11-08)


### Fixes

* Add defensive coding and exception handling during ASP.NET Core 6+ browser injection. ([#2035](https://github.com/newrelic/newrelic-dotnet-agent/issues/2035)) ([#2038](https://github.com/newrelic/newrelic-dotnet-agent/issues/2038)) ([5ddd0ea](https://github.com/newrelic/newrelic-dotnet-agent/commit/5ddd0ea6cd196da5a9aa4b00a8c097c111211251))

## [10.19.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.18.0...v10.19.0) (2023-11-07)


### New features

* Add a supportability metric (Supportability/Logging/Forwarding/Empty) when an "empty" log event is not forwarded. Resolves [#1472](https://github.com/newrelic/newrelic-dotnet-agent/issues/1472) ([1db5335](https://github.com/newrelic/newrelic-dotnet-agent/commit/1db5335d2ada4e6e1a9b1da7f406a3e9fc1ef8e3))
* Add automatic browser agent injection for ASP.NET Core v6+ web applications. ([14c6bb1](https://github.com/newrelic/newrelic-dotnet-agent/commit/14c6bb15030e1744bdd85a46610c1fc269bb58c4))
* Add automatic instrumentation for ASP.NET Core v6+ Razor Pages. ([14c6bb1](https://github.com/newrelic/newrelic-dotnet-agent/commit/14c6bb15030e1744bdd85a46610c1fc269bb58c4))
* Add automatic instrumentation of MassTransit clients v7.1.0 and newer. [#1282](https://github.com/newrelic/newrelic-dotnet-agent/issues/1282) ([3b79002](https://github.com/newrelic/newrelic-dotnet-agent/commit/3b790029242d92abf6c766af81715ab474c2384c))
* Add new span attributes to more closely match OTel spec. This includes server.address and server.port for database calls, and thread.id where appropriate. ([9500d4d](https://github.com/newrelic/newrelic-dotnet-agent/commit/9500d4d52fe583015799bdb02e9b2585b3769b6f))
* Allow forwarding of logs where context data is present but the message and exception are missing. Previously, logs with no message or exception were not forwarded, even if they held context data. ([1db5335](https://github.com/newrelic/newrelic-dotnet-agent/commit/1db5335d2ada4e6e1a9b1da7f406a3e9fc1ef8e3))
* Enable auto-instrumentation for Confluent.Kafka versions 1.4.0 to 2.x.x. ([#1990](https://github.com/newrelic/newrelic-dotnet-agent/issues/1990)) ([9f8d22f](https://github.com/newrelic/newrelic-dotnet-agent/commit/9f8d22fc383020bcee20c12bc2b3321c345ba8d9))
* Update RabbitMQ instrumentation to capture more message consumption scenarios. ([3b79002](https://github.com/newrelic/newrelic-dotnet-agent/commit/3b790029242d92abf6c766af81715ab474c2384c))


### Fixes

* Ensure log lines are written to the audit log file when audit logging is enabled. ([#2028](https://github.com/newrelic/newrelic-dotnet-agent/issues/2028)) ([#2029](https://github.com/newrelic/newrelic-dotnet-agent/issues/2029)) ([c6b940d](https://github.com/newrelic/newrelic-dotnet-agent/commit/c6b940d1c51e79acfa918504bf3adbfbb3e379e5))
* Fix a segfault when using sendDataOnExit with Linux on Docker. ([#2018](https://github.com/newrelic/newrelic-dotnet-agent/issues/2018)) ([3ac75a0](https://github.com/newrelic/newrelic-dotnet-agent/commit/3ac75a0073bee60859475d3fa1f08e8edfe932ee))
* Reduce exception logging on CallVendorApi failures. Resolves [#2005](https://github.com/newrelic/newrelic-dotnet-agent/issues/2005) ([#2006](https://github.com/newrelic/newrelic-dotnet-agent/issues/2006)) ([bf4102b](https://github.com/newrelic/newrelic-dotnet-agent/commit/bf4102b75ef4bc036ba4c5ae8f1da2ad12cbe1be))

## [10.18.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.17.0...v10.18.0) (2023-10-17)


### New features

* Enable configuration of High Security Mode via environment variable (NEW_RELIC_HIGH_SECURITY). ([a86d98d](https://github.com/newrelic/newrelic-dotnet-agent/commit/a86d98d2e1b5d7062c79e4baff6a8207c8762b61)), closes [#1948](https://github.com/newrelic/newrelic-dotnet-agent/issues/1948)
* Enable startup logging to Event Log for all applications on Windows. ([#1969](https://github.com/newrelic/newrelic-dotnet-agent/issues/1969)) ([cdac8b7](https://github.com/newrelic/newrelic-dotnet-agent/commit/cdac8b707b679f08f099ef9c111141372321aa80))



### Fixes

* Detect Docker container id on cgroup v2. ([#1943](https://github.com/newrelic/newrelic-dotnet-agent/issues/1943)) ([9c7e114](https://github.com/newrelic/newrelic-dotnet-agent/commit/9c7e1146029522efee296ed3654158931b4eafe0))
* Update Serilog EventLog sink configuration to enable event source creation (if the app is running with admin privileges). ([#1963](https://github.com/newrelic/newrelic-dotnet-agent/issues/1963)) ([274072b](https://github.com/newrelic/newrelic-dotnet-agent/commit/274072baba12888c49e402b81d2e0d598f717614))

## [10.17.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.16.0...v10.17.0) (2023-09-26)


### New Features

* Add more detail to "heartbeat" message in log. ([#1884](https://github.com/newrelic/newrelic-dotnet-agent/issues/1884)) ([c0c1362](https://github.com/newrelic/newrelic-dotnet-agent/commit/c0c13624d8839f9b84fce3af528cd9d291c6c8a2))
* Use structured logging for internal logs ([#1903](https://github.com/newrelic/newrelic-dotnet-agent/issues/1903)) ([0031700](https://github.com/newrelic/newrelic-dotnet-agent/commit/00317003b1997ab397f42c45b2b60fe686f48275))


### Fixes

* Reinstate max number of log files. ([#1930](https://github.com/newrelic/newrelic-dotnet-agent/issues/1930)) ([41eef7b](https://github.com/newrelic/newrelic-dotnet-agent/commit/41eef7b3d43dcb38b1d833334fc90850aa797973))

## [10.16.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.15.0...v10.16.0) (2023-09-11)


### Notice

* The transactionTracer.stackTraceThreshold setting has been deprecated and no longer has any effect. ([#1896](https://github.com/newrelic/newrelic-dotnet-agent/issues/1896)) ([20ab0e7](https://github.com/newrelic/newrelic-dotnet-agent/commit/20ab0e72c86020e712024165ee4d72f832522db2))


### New Features

* Add 32bit profiler path to IIS registry when installing 64bit agent. ([#1890](https://github.com/newrelic/newrelic-dotnet-agent/issues/1890)) ([65dd50b](https://github.com/newrelic/newrelic-dotnet-agent/commit/65dd50be55e27c3b45384f54df40a96cb1e115a4))
* Prevent using different bitness installer when in-place upgrading. ([#1890](https://github.com/newrelic/newrelic-dotnet-agent/issues/1890)) ([65dd50b](https://github.com/newrelic/newrelic-dotnet-agent/commit/65dd50be55e27c3b45384f54df40a96cb1e115a4))


### Fixes

* Fix misleading log message on transaction name change. ([#1857](https://github.com/newrelic/newrelic-dotnet-agent/issues/1857)) ([#1886](https://github.com/newrelic/newrelic-dotnet-agent/issues/1886)) ([737b4f1](https://github.com/newrelic/newrelic-dotnet-agent/commit/737b4f1dda8831225fcf9bbeea61ff3cc0024da5))
* Fix NRHttpClientFactory so that it creates only one client. ([#1873](https://github.com/newrelic/newrelic-dotnet-agent/issues/1873)) ([fc88ff7](https://github.com/newrelic/newrelic-dotnet-agent/commit/fc88ff7690c367043f074cb6df154a58f8eb4f63))
* Prevent broken traces when HttpClient content headers contain tracing headers. ([#1843](https://github.com/newrelic/newrelic-dotnet-agent/issues/1843)) ([#1888](https://github.com/newrelic/newrelic-dotnet-agent/issues/1888)) ([541dd2c](https://github.com/newrelic/newrelic-dotnet-agent/commit/541dd2ccbb01533ac14b903d84394a02aaf84295))
* Remove the retained file count limit for Agent log files. ([#1879](https://github.com/newrelic/newrelic-dotnet-agent/issues/1879)) ([e49250a](https://github.com/newrelic/newrelic-dotnet-agent/commit/e49250aac7e35e06fcea4fd67ef221b2a967a9b6))

## [10.15.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.14.0...v10.15.0) (2023-08-28)


### New Features

* Add support for Serilog.Extensions.Logging and NLog.Extensions.Logging. ([#1860](https://github.com/newrelic/newrelic-dotnet-agent/issues/1860)) ([#1859](https://github.com/newrelic/newrelic-dotnet-agent/issues/1859)) ([ad24201](https://github.com/newrelic/newrelic-dotnet-agent/commit/ad242019989b9105b1ccb0dd5602640a057f3333))
* Log a warning when an unsupported .NET version is detected. ([#1852](https://github.com/newrelic/newrelic-dotnet-agent/issues/1852)) ([7da3e59](https://github.com/newrelic/newrelic-dotnet-agent/commit/7da3e59c9e9dbf865053de5eccd448560f5d78ce))
* Use HttpWebRequest instead of HttpClient on .NET Framework ([#1853](https://github.com/newrelic/newrelic-dotnet-agent/issues/1853)) ([8d6cf0f](https://github.com/newrelic/newrelic-dotnet-agent/commit/8d6cf0faf1b08eb54cc76f8fcbb21d7afc994140))

## [10.14.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.13.0...v10.14.0) (2023-08-08)


### New Features

* Add support for Sitecore.Logging. ([#1790](https://github.com/newrelic/newrelic-dotnet-agent/issues/1790)) ([#1795](https://github.com/newrelic/newrelic-dotnet-agent/issues/1795)) ([6d1934a](https://github.com/newrelic/newrelic-dotnet-agent/commit/6d1934aa3756d20bf45a1b42e5da2286967b2db5))

## [10.13.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.12.1...v10.13.0) (2023-07-14)


### Security

* Update Grpc.Net.Client library to address Dependabot alerts. ([#1768](https://github.com/newrelic/newrelic-dotnet-agent/issues/1768)) ([#1769](https://github.com/newrelic/newrelic-dotnet-agent/issues/1769)) ([eee7564](https://github.com/newrelic/newrelic-dotnet-agent/commit/eee7564cbe79b653ad7909af36f09c9a64cdb731))


### New Features

* Add support for filtering log events based on a list of log levels so that they are not forwarded to New Relic. Also adds new logging metrics to count the total number of filtered log events (Logging/denied). Refer to our [application logging configuration](https://docs.newrelic.com/docs/apm/agents/net-agent/configuration/net-agent-configuration/#application_logging) documentation for more details. ([#1760](https://github.com/newrelic/newrelic-dotnet-agent/issues/1760)) ([#1761](https://github.com/newrelic/newrelic-dotnet-agent/issues/1761)) ([#1762](https://github.com/newrelic/newrelic-dotnet-agent/issues/1762)) ([#1766](https://github.com/newrelic/newrelic-dotnet-agent/issues/1766)) ([aadce3a](https://github.com/newrelic/newrelic-dotnet-agent/commit/aadce3a09f9fe3c77a93f557686f1ddc26fc6169))
* Instrument OpenAsync() for SQL libraries. ([#1725](https://github.com/newrelic/newrelic-dotnet-agent/issues/1725)) ([a695ce6](https://github.com/newrelic/newrelic-dotnet-agent/commit/a695ce6de7e56bc3f803c9b9f6c8c09b30c106fd))


### Fixes

* Refactor StackExchange.Redis v2+ instrumentation to eliminate potential memory leaks. ([902b025](https://github.com/newrelic/newrelic-dotnet-agent/commit/902b025c8c420b8bc288b15d914b47aabc1bd426))
* Remove invalid trailing comma added to W3C tracestate header. ([#1779](https://github.com/newrelic/newrelic-dotnet-agent/issues/1779)) ([790a3b7](https://github.com/newrelic/newrelic-dotnet-agent/commit/790a3b75dd7609d76638ea3625a9289f58b24378))
* Update the MSI UI to clean up formatting and readability issues. ([#1748](https://github.com/newrelic/newrelic-dotnet-agent/issues/1748)) ([3fbc543](https://github.com/newrelic/newrelic-dotnet-agent/commit/3fbc54310ed3989f915e6f39b27ef8867ed573db))

## [10.12.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.12.0...v10.12.1) (2023-06-26)


### Fixes

* Resolved an issue in the `all_solutions.yml` workflow where the MSI installers were built with a self-signed certificate rather than the production code signing certificate. ([386a277](https://github.com/newrelic/newrelic-dotnet-agent/commit/386a27705701a07d591a95f95830bda27898d255))

## [10.12.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.11.0...v10.12.0) (2023-06-23)


### New Features

* add instrumentation for newer MongoDB.Client methods ([#1732](https://github.com/newrelic/newrelic-dotnet-agent/issues/1732)) ([1aa5680](https://github.com/newrelic/newrelic-dotnet-agent/commit/1aa5680a8f7f855895203a45b8dfcc5059d656e0))
* add support for MySql.Data version 8.0.33+ ([#1708](https://github.com/newrelic/newrelic-dotnet-agent/issues/1708)) ([69d15df](https://github.com/newrelic/newrelic-dotnet-agent/commit/69d15dfbed178fb5698695253160ae12a4f7a410))


### Fixes

* Add more validation to msi installer. ([#1716](https://github.com/newrelic/newrelic-dotnet-agent/issues/1716)) ([d7bb7f2](https://github.com/newrelic/newrelic-dotnet-agent/commit/d7bb7f290beae8394599cee1ea9b3213cf2dc473))
* Cache the AgentEnabled setting value. ([#1723](https://github.com/newrelic/newrelic-dotnet-agent/issues/1723)) ([1624938](https://github.com/newrelic/newrelic-dotnet-agent/commit/1624938ab48b63c1fa6e98037d74976dbc8186da))
* Exclude WebResource.axd and ScriptResource.axd from browser instrumentation (via default config). ([#1711](https://github.com/newrelic/newrelic-dotnet-agent/issues/1711)) ([2fcce95](https://github.com/newrelic/newrelic-dotnet-agent/commit/2fcce95093ed4ef6d1efe67489c8d1ae6c9b29e6))
* Format and log audit-level messages only when audit logging is enabled. ([#1734](https://github.com/newrelic/newrelic-dotnet-agent/issues/1734)) ([f71521f](https://github.com/newrelic/newrelic-dotnet-agent/commit/f71521f2540311e97d13646ff6d6524dfcc3965f))
* Handle empty Request.Path values in AspNetCore middleware wrapper. ([#1704](https://github.com/newrelic/newrelic-dotnet-agent/issues/1704)) ([8b734a5](https://github.com/newrelic/newrelic-dotnet-agent/commit/8b734a59a53cfd218322d83acbe9d7eb4e7cc055))
* Include config file path in the "Agent is disabled " message on all platforms. ([#1727](https://github.com/newrelic/newrelic-dotnet-agent/issues/1727)) ([1a56612](https://github.com/newrelic/newrelic-dotnet-agent/commit/1a5661243eaa84683694e022fe9806768b8af9f7))
* Update install script to correctly stop and restart IIS. ([#1740](https://github.com/newrelic/newrelic-dotnet-agent/issues/1740)) ([3b91dff](https://github.com/newrelic/newrelic-dotnet-agent/commit/3b91dff0ad9aa2fc4218cd85d28fb6d0892cc7fb))

## [10.11.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.10.0...v10.11.0) (2023-06-03)


### Notice

* The Dotnet VMs UI page is now available for .NET CLR performance metrics. There is a new New Relic APM UI page available called "Dotnet VMs" that displays the data the .NET agent collects about an application's CLR performance.  See the [performance metrics documentaton](https://docs.newrelic.com/docs/apm/agents/net-agent/other-features/net-performance-metrics/) for more details. ([cc7cede](https://github.com/newrelic/newrelic-dotnet-agent/commit/cc7cedecc113812b5f7274e7a6bf1aa5a2511720))


### Fixes

* Clearing transaction context for held transactions and async WCF client instrumentation timing. ([#1608](https://github.com/newrelic/newrelic-dotnet-agent/issues/1608)) ([db9a48e](https://github.com/newrelic/newrelic-dotnet-agent/commit/db9a48e50b66c345fd53ff64b296025d03da77bb))
* Stop double injecting headers with HttpClient on .NET Framework ([#1679](https://github.com/newrelic/newrelic-dotnet-agent/issues/1679)) ([e8bdc34](https://github.com/newrelic/newrelic-dotnet-agent/commit/e8bdc34072f044e7b056dd2ce773f184aed3bfe5))


### New Features

* Add detailed assembly reporting to enable Vulnerability Management support. ([#1685](https://github.com/newrelic/newrelic-dotnet-agent/issues/1685)) ([f249753](https://github.com/newrelic/newrelic-dotnet-agent/commit/f2497536dadb34caded7aa916b5f404ebf19e52a))
* Adds minimal support for Devart Oracle client. ([181a628](https://github.com/newrelic/newrelic-dotnet-agent/commit/181a628ff1cb7a0f0b7a347378644782f085f3ab))
* Use Serilog instead of log4net for internal logging.  ([#1661](https://github.com/newrelic/newrelic-dotnet-agent/issues/1661)) ([51080df](https://github.com/newrelic/newrelic-dotnet-agent/commit/51080df3848e36e0b6aa29b6cb9a0e94a1638b6f))

## [10.10.0](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.9.1...v10.10.0) (2023-04-26)


### New Features

* Add additional logging when RUM injection is being skipped. ([#1561](https://github.com/newrelic/newrelic-dotnet-agent/issues/1561)) ([e1b8eca](https://github.com/newrelic/newrelic-dotnet-agent/commit/e1b8eca24fc63671a8ea1bafaebabbb9f3b29cb2))
* Add instrumentation for .NET Elasticsearch clients. ([#1575](https://github.com/newrelic/newrelic-dotnet-agent/issues/1575)) ([8e49d7b](https://github.com/newrelic/newrelic-dotnet-agent/commit/8e49d7bfc22df88abc96a6ebc2518a7be8a1d29b))
* Move TLS config logging closer to connect. ([#1562](https://github.com/newrelic/newrelic-dotnet-agent/issues/1562)) ([0ff3ddd](https://github.com/newrelic/newrelic-dotnet-agent/commit/0ff3ddde1c8c0aed3b0a3c1aaf4c59e7ddc3837c))


### Fixes

* Add missing instrumentation to MSI installer ([#1569](https://github.com/newrelic/newrelic-dotnet-agent/issues/1569)) ([b65b117](https://github.com/newrelic/newrelic-dotnet-agent/commit/b65b1170d7649ab6e82a9796f235925ca147393c))
* Add NServiceBus instrumentation to the MSI installer for .NET Core/5+. ([#1576](https://github.com/newrelic/newrelic-dotnet-agent/issues/1576)) ([3cae03e](https://github.com/newrelic/newrelic-dotnet-agent/commit/3cae03eacbfb4b2c250abb3a35047190571d35a6))
* IsOsPlatform() can fail on older .NET Framework Versions ([#1552](https://github.com/newrelic/newrelic-dotnet-agent/issues/1552)) ([699c205](https://github.com/newrelic/newrelic-dotnet-agent/commit/699c2056883e4548c025e3ee893e215400899e0e))

## [10.9.1](https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.9.0...v10.9.1) (2023-04-10)

### Fixes

* Allow StackExchange.Redis v2+ profiling to start outside of a transaction. ([#1501](https://github.com/newrelic/newrelic-dotnet-agent/issues/1501)) ([#1504](https://github.com/newrelic/newrelic-dotnet-agent/issues/1504)) ([925d016](https://github.com/newrelic/newrelic-dotnet-agent/commit/925d016c145b50b75a3b3401de303f5fa9a64609))
* allow the agent to accept multiple versions of legacy NR distributed tracing headers ([#1489](https://github.com/newrelic/newrelic-dotnet-agent/issues/1489)) ([23ee241](https://github.com/newrelic/newrelic-dotnet-agent/commit/23ee24141ad44afa39e3f35f93aa2ae7570acb72))
* Fix a memory leak when using StackExchange.Redis v2+. ([#1473](https://github.com/newrelic/newrelic-dotnet-agent/issues/1473)) ([#1504](https://github.com/newrelic/newrelic-dotnet-agent/issues/1504)) ([925d016](https://github.com/newrelic/newrelic-dotnet-agent/commit/925d016c145b50b75a3b3401de303f5fa9a64609))
* Retry connection on HttpRequestException error ([#1514](https://github.com/newrelic/newrelic-dotnet-agent/issues/1514)) ([#1484](https://github.com/newrelic/newrelic-dotnet-agent/issues/1484)) ([99b520e](https://github.com/newrelic/newrelic-dotnet-agent/commit/99b520e271df4357f8ea62cad2403884edb4d856))

## [10.9.0] - 2023-03-28

### New Errors inbox features
* **User tracking**: You can now see the number of users impacted by an error group. Identify the end user with the setUserId method.
* **Error fingerprint**: Are your error occurrences grouped poorly? Set your own error fingerprint via a callback function.

### New Features
* Agent API now supports associating a User Id with the current transaction. See our [ITransaction API documentation](https://docs.newrelic.com/docs/apm/agents/net-agent/net-agent-api/itransaction/#setuserid) for more details.  [#1420](https://github.com/newrelic/newrelic-dotnet-agent/pull/1420)
* Agent API now supports providing a callback to determine what error group an exception should be grouped under. See our [SetErrorGroupCallback API documentation](https://docs.newrelic.com/docs/apm/agents/net-agent/net-agent-api/seterrorgroupcallback-net-agent-api/) for more details. [#1434](https://github.com/newrelic/newrelic-dotnet-agent/pull/1434)
* Adds the `Supportability/Logging/Forwarding/Dropped` metric to track the number of log messages that were dropped due to capacity constraints. [#1470](https://github.com/newrelic/newrelic-dotnet-agent/pull/1470)

### Fixes
* Reduce redundant collector request data payload logging in the agent log at DEBUG level. [#1449](https://github.com/newrelic/newrelic-dotnet-agent/pull/1449)
* Fixes [#1459](https://github.com/newrelic/newrelic-dotnet-agent/issues/1459), a regression in NLog local decoration when logging messages with object parameters. [#1480](https://github.com/newrelic/newrelic-dotnet-agent/pull/1480)

### Other
* Renamed `NewRelic.Providers.Wrapper.Asp35` to `NewRelic.Providers.Wrapper.AspNet` since this wrapper instruments multiple versions of ASP.NET. Updated installers to remove old `Asp35` artifacts. [#1448](https://github.com/newrelic/newrelic-dotnet-agent/pull/1448)

## [10.8.0] - 2023-03-14

### New Features
* When running on Linux, distro name and version will be reported as environment settings [#1439](https://github.com/newrelic/newrelic-dotnet-agent/pull/1439)

### Fixes
* Fixes [#1353](https://github.com/newrelic/newrelic-dotnet-agent/issues/1353) so that out-of-process .Net Core web applications are instrumented according to the <applicationPools> setting in newrelic.config. [1392](https://github.com/newrelic/newrelic-dotnet-agent/pull/1392)
* Update NLog to improve local log decoration coverage. [#1393](https://github.com/newrelic/newrelic-dotnet-agent/pull/1393)
* Fixes [#1353](https://github.com/newrelic/newrelic-dotnet-agent/issues/1353) so that out-of-process .Net Core web applications are instrumented according to the <applicationPools> setting in newrelic.config. [1392](https://github.com/newrelic/newrelic-dotnet-agent/pull/1392)

## [10.7.0] - 2023-02-14

### New Features
* Postgres client instrumentation support has been extended to include the following versions: 4.0.x, 4.1.x, 5.0.x, 6.0.x and 7.0.x [#1363](https://github.com/newrelic/newrelic-dotnet-agent/pull/1363)
* Enables gzip compression by default for Infinite Tracing [#1383](https://github.com/newrelic/newrelic-dotnet-agent/pull/1383)

### Fixes
* Fix a race condition when using SetApplicationName [#1361](https://github.com/newrelic/newrelic-dotnet-agent/pull/1361)
* Resolves [#1374](https://github.com/newrelic/newrelic-dotnet-agent/issues/1374) related to enabling Context Data for some loggers [#1381](https://github.com/newrelic/newrelic-dotnet-agent/pull/1381)
* Add missing supportability metrics to gRPC response streams and improve Infinite Tracing integration test reliability [#1379](https://github.com/newrelic/newrelic-dotnet-agent/pull/1379)

### Deprecations
* Infinite Tracing for .NET Framework applications will be deprecated in May 2023. The Infinite Tracing feature depends on the gRPC framework to send streaming data to New Relic. The gRPC library currently in use, [gRPC Core](https://github.com/grpc/grpc/tree/master/src/csharp), has been in the maintenance-only phase since May 2021, and will be deprecated as of May 2023.  The .NET Agent on .NET Core has been migrated to [gRPC for .NET](https://github.com/grpc/grpc-dotnet) per the guidance from grpc.io. However, this library does not have the full functionality that is required for Infinite Tracing on .NET Framework applications.  Those applications will continue to use [gRPC Core](https://github.com/grpc/grpc/tree/master/src/csharp) until May 2023, at which time we will end support for Infinite Tracing for .NET Framework. We may revisit this decision in the future if the situation changes. [#1367](https://github.com/newrelic/newrelic-dotnet-agent/pull/1367)

### Other
* Resolved several static code analysis warnings relating to unused variables and outdated api usage [#1369](https://github.com/newrelic/newrelic-dotnet-agent/pull/1369)
* Update gRPC log message when a response stream is automatically cancelled due to no messages in a time period [#1378](https://github.com/newrelic/newrelic-dotnet-agent/pull/1378)
* Proxy configuration for Infinite Tracing should be specified using only the `https_proxy` environment variable. `grpc_proxy` is no longer supported for all application types.

## [10.6.0] - 2023-01-24

### New Features
* Custom instrumentation now supports targeting specific assembly versions. See [the documentation](https://docs.newrelic.com/docs/apm/agents/net-agent/custom-instrumentation/add-detail-transactions-xml-net/#procedures)  for more details. [#1342](https://github.com/newrelic/newrelic-dotnet-agent/pull/1342)
* RestSharp client instrumentation support has been extended to include the following versions: 106.11.x, 106.12.0, 106.13.0, and 106.15.0. [#1352](https://github.com/newrelic/newrelic-dotnet-agent/pull/1352)
* RestSharp client instrumentation has been verified for versions 107.x and 108.x. For newer versions of RestSharp, external segments/spans are actually generated via our instrumentation of HttpClient. [#1356](https://github.com/newrelic/newrelic-dotnet-agent/pull/1356)
* .NET TLS options are now logged during startup. [#1357](https://github.com/newrelic/newrelic-dotnet-agent/pull/1357)

### Fixes
* StackExchange.Redis versions 2 and above use a new wrapper with improved performance and reduced network overhead. [#1351](https://github.com/newrelic/newrelic-dotnet-agent/pull/1351)

## [10.5.1] - 2023-01-17

### Fixes
* Resolves [#1346](https://github.com/newrelic/newrelic-dotnet-agent/issues/1346) where some NuGet packages were incomplete for the 10.5.0 release. Impacted packages have been delisted from NuGet. ([#1347](https://github.com/newrelic/newrelic-dotnet-agent/pull/1347))

## [10.5.0] - 2023-01-12

### Fixes
* Resolves [#1130](https://github.com/newrelic/newrelic-dotnet-agent/issues/1130). Attribute collections in the agent will now more reliably track the number of attributes contained, and allow updates to attributes that already exist in the collection when collection limits have been reached (255 global attributes, 65 custom attributes). ([#1335](https://github.com/newrelic/newrelic-dotnet-agent/pull/1335))
* The agent has been updated to use System.Net.Http.HTTPClient to send data to New Relic instead of System.Net.WebRequest, in order to fix issue [#897](https://github.com/newrelic/newrelic-dotnet-agent/issues/897), as well as remove use of a deprecated library. ([#1325](https://github.com/newrelic/newrelic-dotnet-agent/pull/1325))

## [10.4.0] - 2022-12-06

### New Features
* Support for .NET 7 has been verified with the GA version of the .NET 7 SDK. Please note that if you use [dynamically-created assemblies](https://learn.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/emitting-dynamic-methods-and-assemblies), there is a [bug in .NET 7](https://github.com/dotnet/runtime/issues/76016) that prevents them from being instrumented at this time.
* Application log fowarding can now be configured to capture and forward context data (also referred to as "custom attributes") to New Relic.  Details (including how to enable and configure this new feature) can be found [here](https://docs.newrelic.com/docs/logs/logs-context/net-configure-logs-context-all/).
* The [NewRelic.Agent NuGet package](https://www.nuget.org/packages/NewRelic.Agent) now includes the Linux Arm64 profiler. This can be found in the `newrelic/linux-arm64` directory. Configure your `CORECLR_PROFILER_PATH` environment variable to use this version of the profiler when deploying to linux ARM64 targets.
* When finest logs are enabled, the transaction guid will be applied to attribute limit log messages, if present.

### Fixes
* Resolves potential crash when using Infinite Tracing. [#1319](https://github.com/newrelic/newrelic-dotnet-agent/issues/1319)

## [10.3.0] - 2022-10-26

### New Features
* Custom Event Limit Increase
  * This version increases the default limit of custom events from 10,000 events per minute to 30,000 events per minute. In the scenario that custom events were being limited, this change will allow more custom events to be sent to New Relic. There is also a new configurable maximum limit of 100,000 events per minute. To change the limits, see the documentation for [max_samples_stored](https://docs.newrelic.com/docs/apm/agents/net-agent/configuration/net-agent-configuration/#custom_events). To learn more about the change and how to determine if custom events are being dropped, see our Explorers Hub [post](https://discuss.newrelic.com/t/send-more-custom-events-with-the-latest-apm-agents/190497). [#1284](https://github.com/newrelic/newrelic-dotnet-agent/pull/1284)

### Fixes

## [10.2.0] - 2022-10-03

### New Features
* Add new environment variables to control SendDataOnExit functionality: `NEW_RELIC_SEND_DATA_ON_EXIT`, `NEW_RELIC_SEND_DATA_ON_EXIT_THRESHOLD_MS`. [#1250](https://github.com/newrelic/newrelic-dotnet-agent/pull/1250)
* Enables integration with CodeStream Code-Level Metrics by default. This allows you to see Golden Signals in your IDE through New Relic CodeStream without altering agent configuration. [Learn more here](https://docs.newrelic.com/docs/apm/agents/net-agent/other-features/net-codestream-integration). For any issues or direct feedback, please reach out to support@codestream.com. [#1255](https://github.com/newrelic/newrelic-dotnet-agent/pull/1255)

### Fixes
* Resolves an issue where the .NET Core agent could crash during application shutdown when SendDataOnExit functionality was triggered. [#1254](https://github.com/newrelic/newrelic-dotnet-agent/pull/1254)
* Resolves an issue where the .NET agent incorrectly injects the browser agent script inside Html pages. [#1247](https://github.com/newrelic/newrelic-dotnet-agent/pull/1247)
* Resolves an issue where some instrumentation was missing for Microsoft.Data.SqlClient in .NET Framework. [#1248](https://github.com/newrelic/newrelic-dotnet-agent/pull/1248)
* Resolves an issue with local log decoration for NLog where the original log message was not included in the output. [#1249](https://github.com/newrelic/newrelic-dotnet-agent/pull/1249)
* Resolves an issue where the .NET agent failed to serialize custom attributes containing some non-primtive types. [#1256](https://github.com/newrelic/newrelic-dotnet-agent/pull/1256)
* Includes missing profiler environment variables in debug logs during application startup. [#1255](https://github.com/newrelic/newrelic-dotnet-agent/pull/1255)
* Resolves an issue where the .NET agent still sends up disabled event types during reconnecting period. [#1251](https://github.com/newrelic/newrelic-dotnet-agent/pull/1251)

## [10.1.0] - 2022-09-12

**Notice:** If using Microsoft.Extensions.Logging as your logging framework of choice, please use .NET agent version 10.1.0 or newer.  We encourage you to adopt the newer version due to bug [#1230](https://github.com/newrelic/newrelic-dotnet-agent/issues/1230), which we fixed in [#1237](https://github.com/newrelic/newrelic-dotnet-agent/pull/1237), that was resolved in .NET agent version 10.1.0.

### New Features
* Support of setting up labels via appsettings.json and app/web.config file. [#1204](https://github.com/newrelic/newrelic-dotnet-agent/pull/1204)
* Additional DEBUG-level logging of all environment variables.
* Forwarded application logs now capture exception details including, error message, error stack, and error class. [#1228](https://github.com/newrelic/newrelic-dotnet-agent/pull/1228)
  * Log events with no message will now be accepted if an exception is present in the log event.
  * The error stack is created using the stack of the inner exception, up to 5 levels deep, just like existing Agent error reporting.
* Adds a new `SetName()` method to the Agent API for spans which allows customization of segment/span/metric names. [#1238](https://github.com/newrelic/newrelic-dotnet-agent/pull/1238)

### Fixes
* Resolves an issue where log forwarding could drop logs in async scenarios. [#1174](https://github.com/newrelic/newrelic-dotnet-agent/pull/1201)
* Resolves an issue where more logs were forwarded than expected from Microsoft.Extensions.Logging. [#1237](https://github.com/newrelic/newrelic-dotnet-agent/pull/1237)
* Resolves an agent configuration bug where values set in the `MAX_EVENT_SAMPLES_STORED` and `MAX_TRANSACTION_SAMPLES_STORED` environment variables, which configure the maximum samples stored per one-minute harvest interval, were not being properly converted to apply to the five-second harvest interval for those data types. [#1239](https://github.com/newrelic/newrelic-dotnet-agent/pull/1239)

## [10.0.0] - 2022-07-19

**Notice:** If using Microsoft.Extensions.Logging as your logging framework of choice, please use .NET agent version 10.1.0 or newer.  We encourage you to adopt the newer version due to bug [#1230](https://github.com/newrelic/newrelic-dotnet-agent/issues/1230), which we fixed in [#1237](https://github.com/newrelic/newrelic-dotnet-agent/pull/1237), that was resolved in .NET agent version 10.1.0.

### New Features
* Adds support for forwarding application logs to New Relic for .NET Framework 4.6.2 and newer applications using Microsoft.Extensions.Logging. [#1172](https://github.com/newrelic/newrelic-dotnet-agent/pull/1172)
* Additional agent configuration options are now visible and easily accessible through the UI on NR1. Agent configuration is also now reported during agent connect. This information can be seen in the `APM->Environment->Agent Initialization` view. [#1174](https://github.com/newrelic/newrelic-dotnet-agent/pull/1174)

### Fixes
* Resolves an issue with transaction trace aggregation where the slowest transaction trace was not always captured due to a race condition. [#1166](https://github.com/newrelic/newrelic-dotnet-agent/pull/1166)
* Adds an ignore rule to prevent profiling `SMSvcHost.exe`. [#1182](https://github.com/newrelic/newrelic-dotnet-agent/pull/1182)
* Updates applicationLogging attribute `log.level` to be `level`. [#1144](https://github.com/newrelic/newrelic-dotnet-agent/pull/1144)

### Deprecations/Removed Features
* This is a major release of the agent, and contains breaking changes. See the [migration guide](https://docs.newrelic.com/docs/apm/agents/net-agent/getting-started/9x-to-10x-agent-migration-guide/) for details.
* This agent release targets .NET Framework 4.6.2 and .NET Standard 2.0. The minimum supported runtime versions for profiled applications are .NET Framework 4.6.2+ and .NET Core 3.1+.
* The scriptable installers have been removed. [#1170](https://github.com/newrelic/newrelic-dotnet-agent/pull/1170)
* Windows installation files have been consolidated and renamed. [#1187](https://github.com/newrelic/newrelic-dotnet-agent/pull/1187)
* The Linux installation packages have been renamed. [#1180](https://github.com/newrelic/newrelic-dotnet-agent/pull/1180)
* Castle.Monorail instrumentation has been removed. [#1177](https://github.com/newrelic/newrelic-dotnet-agent/pull/1177)

## [9.9.0] - 2022-06-08

**Notice:** If using Microsoft.Extensions.Logging as your logging framework of choice, please use .NET agent version 10.1.0 or newer.  We encourage you to adopt the newer version due to bug [#1230](https://github.com/newrelic/newrelic-dotnet-agent/issues/1230), which we fixed in [#1237](https://github.com/newrelic/newrelic-dotnet-agent/pull/1237), that was resolved in .NET agent version 10.1.0.

### New Features
* Adds support for logging metrics, forwarding application logs, and enriching application logs written to disk or standard out for NLog versions v5 and v4. [#1087](https://github.com/newrelic/newrelic-dotnet-agent/pull/1087)
* Adds integration with CodeStream, introducing Code-Level Metrics! Golden Signals visible in your IDE through New Relic CodeStream. [Learn more here](https://docs.newrelic.com/docs/apm/agents/net-agent/other-features/net-codestream-integration). For any issues or direct feedback, please reach out to support@codestream.com
* Updates the following installation methods to check for and remove deprecated files. ([#1104](https://github.com/newrelic/newrelic-dotnet-agent/pull/1104))
  * MSI Installer
  * Azure Site Extension
  * RPM package
  * DEB package

### Fixes
* Upgrades Newtonsoft.Json to version 13.0.1 to address potential security vulnerabilities identified by Snyk ([#1107](https://github.com/newrelic/newrelic-dotnet-agent/pull/1107))
* The agent will now send the values of application logging config options (e.g. `application_logging.forwarding.enabled`) to the agent initialization settings page. ([#1135](https://github.com/newrelic/newrelic-dotnet-agent/pull/1135))

## [9.8.1] - 2022-05-19

**Notice:** If using Microsoft.Extensions.Logging as your logging framework of choice, please use .NET agent version 10.1.0 or newer.  We encourage you to adopt the newer version due to bug [#1230](https://github.com/newrelic/newrelic-dotnet-agent/issues/1230), which we fixed in [#1237](https://github.com/newrelic/newrelic-dotnet-agent/pull/1237), that was resolved in .NET agent version 10.1.0.

### Fixes
* Fixes an [issue with log forwarding](https://github.com/newrelic/newrelic-dotnet-agent/issues/1088) where an agent could momentarily forward logs even if the feature had been disabled at an account level. ([#1097](https://github.com/newrelic/newrelic-dotnet-agent/pull/1097))
* Adds an internal list of deprecated instrumentation xml files which will cause the profiler to ignore deprecated instrumentation. This feature avoids an issue where orphaned deprecated log forwarding instrumentation could conflict with newer instrumentation. ([#1097](https://github.com/newrelic/newrelic-dotnet-agent/pull/1097))
* Serilog instrumentation is now performed by injecting a custom sink in to the logging chain. ([#1084](https://github.com/newrelic/newrelic-dotnet-agent/pull/1084))

## [9.8.0] - 2022-05-05

**Notice:** If using Microsoft.Extensions.Logging as your logging framework of choice, please use .NET agent version 10.1.0 or newer.  We encourage you to adopt the newer version due to bug [#1230](https://github.com/newrelic/newrelic-dotnet-agent/issues/1230), which we fixed in [#1237](https://github.com/newrelic/newrelic-dotnet-agent/pull/1237), that was resolved in .NET agent version 10.1.0.

### APM logs in context
Automatic application log forwarding is now enabled by default. This version of the agent will automatically send enriched application logs to New Relic. To learn more about about this feature see [here](https://docs.newrelic.com/docs/apm/new-relic-apm/getting-started/get-started-logs-context/), and additional configuration options are available [here](https://docs.newrelic.com/docs/logs/logs-context/net-configure-logs-context-all). To learn about how to toggle log ingestion on or off by account see [here](https://docs.newrelic.com/docs/logs/logs-context/disable-automatic-logging).

### New Features
* Error messages in error traces and error events now retain up to 1023 characters instead of 255 characters. [#1058](https://github.com/newrelic/newrelic-dotnet-agent/pull/1058)
* New environment variables have been added for AllowAllHeaders and Attributes configuration settings. See our [documentation](https://docs.newrelic.com/docs/apm/agents/net-agent/configuration/net-agent-configuration/#optional-environment-variables) for more details. [#1059](https://github.com/newrelic/newrelic-dotnet-agent/pull/1059)
* Introduces [environment variables to enabled/disable cloud detection](https://github.com/newrelic/newrelic-dotnet-agent/issues/818) to facilitate customer use cases and reduce errors in logs. ([#1061](https://github.com/newrelic/newrelic-dotnet-agent/pull/1061))
* New environment variables have been added for all Proxy configuration settings.  See our [documentation](https://docs.newrelic.com/docs/apm/agents/net-agent/configuration/net-agent-configuration/#optional-environment-variables) for more details. [#1063](https://github.com/newrelic/newrelic-dotnet-agent/pull/1063)
* Introduces a new configuration option to force custom instrumentation to [create new transactions](https://github.com/newrelic/newrelic-dotnet-agent/issues/347) in async scenarios versus re-using an existing transaction. [#1071](https://github.com/newrelic/newrelic-dotnet-agent/pull/1071)

### Fixes
* Fixes Agent fails to execute explain plan for parameterized stored procedure. ([#1066](https://github.com/newrelic/newrelic-dotnet-agent/pull/1066)) 
* Fixes getting duplicate logs using log forwarding and Serilog. [#1076](https://github.com/newrelic/newrelic-dotnet-agent/pull/1076)

### Deprecations
Microsoft has officially EOL .NET Framework versions 4.5.1, 4.5.2, and 4.6.1 on  Apr 26, 2022.
The informational blog can be found [here](https://devblogs.microsoft.com/dotnet/net-framework-4-5-2-4-6-4-6-1-will-reach-end-of-support-on-april-26-2022).  The official product lifecycle start and end dates can be found [here](https://docs.microsoft.com/en-us/lifecycle/products/microsoft-net-framework).  The dotnet agent support of these framework versions is will continue as is with the released versions.  In a future major release, we will target .NET framework 4.6.2 onwards.

## [9.7.1] - 2022-04-13

**Notice:** If using Microsoft.Extensions.Logging as your logging framework of choice, please use .NET agent version 10.1.0 or newer.  We encourage you to adopt the newer version due to bug [#1230](https://github.com/newrelic/newrelic-dotnet-agent/issues/1230), which we fixed in [#1237](https://github.com/newrelic/newrelic-dotnet-agent/pull/1237), that was resolved in .NET agent version 10.1.0.

### Fixes
* Adds missing instrumentation for application logging feature when using the MSI installer ([#1055](https://github.com/newrelic/newrelic-dotnet-agent/pull/1055))
* Fixes [issue on Linux](https://github.com/newrelic/newrelic-dotnet-agent/issues/763) when specifying a non-default profiler log directory with non-existent intermediate directories. ([#1051](https://github.com/newrelic/newrelic-dotnet-agent/pull/1051))

## [9.7.0] - 2022-04-04

**Notice:** For the new application logging features, if you install using the MSI, please update to version 9.7.1 or later.

**Notice:** If using Microsoft.Extensions.Logging as your logging framework of choice, please use .NET agent version 10.1.0 or newer.  We encourage you to adopt the newer version due to bug [#1230](https://github.com/newrelic/newrelic-dotnet-agent/issues/1230), which we fixed in [#1237](https://github.com/newrelic/newrelic-dotnet-agent/pull/1237), that was resolved in .NET agent version 10.1.0.

### New Features
* Adds support for logging metrics which shows the rate of log message by severity in the Logs chart in the APM Summary view for Log4net, Serilog, and Microsoft.Extensions.Logging. This is enabled by default in this release. ([#1034](https://github.com/newrelic/newrelic-dotnet-agent/pull/1034))
* Adds support for forwarding application logs to New Relic. This automatically sends enriched application logs for Log4net, Serilog, and Microsoft.Extensions.Logging. This is disabled by default in this release. ([#1034](https://github.com/newrelic/newrelic-dotnet-agent/pull/1034))
* Adds support for enriching application logs written to disk or standard out for Log4net, Serilog, Microsoft.Extensions.Logging. This can be used with another log forwarder if in-agent log forwarding is not desired. We recommend enabling either log forwarding or local log decorating, but not both features. This is disabled by default in this release. ([#1034](https://github.com/newrelic/newrelic-dotnet-agent/pull/1034))
* Adds flexibility to what is accepted to enable/disable boolean environment variables per [FR #1008](https://github.com/newrelic/newrelic-dotnet-agent/issues/1008). "0"/"1", and case insensitive "true"/"false" are now accepted. ([#1033](https://github.com/newrelic/newrelic-dotnet-agent/pull/1033))

### Fixes
* Adds a new environment variable `NEW_RELIC_DISABLE_APPDOMAIN_CACHING` for customers to try when experiencing [#533 high lock contention related to AppDomain.GetData()](https://github.com/newrelic/newrelic-dotnet-agent/issues/533) usage by the agent when profiling .NET Framework applications. ([#1033](https://github.com/newrelic/newrelic-dotnet-agent/pull/1033))

### Deprecations
* The scriptable installers are now deprecated and will be removed from the download site in a future major release. (Issue: [#571](https://github.com/newrelic/newrelic-dotnet-agent/issues/571))
* The established release installers are now deprecated and will be removed from the download site in a future major release. (Issue: [#578](https://github.com/newrelic/newrelic-dotnet-agent/issues/578))

## [9.6.1] - 2022-03-15
### Fixes
* Fixes [application pool allow/deny listing bug](https://github.com/newrelic/newrelic-dotnet-agent/issues/1014) introduced in 9.5.0 ([#1015](https://github.com/newrelic/newrelic-dotnet-agent/pull/1015))

## [9.6.0] - 2022-02-24
### Fixes
* Adds new supportability metrics to track agent endpoint data usage. New metrics will be reported under the `Supportability/DotNET/Collector` namespace. ([#899](https://github.com/newrelic/newrelic-dotnet-agent/pull/899))
* Uses IMDSv2 instead of IMDSv1 to gather utilization details for AWS hosted instances. ([#965](https://github.com/newrelic/newrelic-dotnet-agent/pull/965))

## [9.5.1] - 2022-02-03
### Fixes
* Fixes [application crashes on Alpine Linux](https://github.com/newrelic/newrelic-dotnet-agent/issues/918) introduced in 9.5.0. ([#929](https://github.com/newrelic/newrelic-dotnet-agent/pull/929))

## [9.5.0] - 2022-02-01
### New Features
* Internal improvements to runtime detection logic in the profiler component of the agent. ([#891](https://github.com/newrelic/newrelic-dotnet-agent/pull/891))
### Fixes
* Fixed an [issue with NuGet package metadata](https://github.com/newrelic/newrelic-dotnet-agent/issues/896). ([#901](https://github.com/newrelic/newrelic-dotnet-agent/pull/901))

## [9.4.0] - 2022-01-18
### New Features
* Allows NewRelicQueryName to be specified for SQL, to implement [this suggestion](https://discuss.newrelic.com/t/provide-a-pattern-to-explicitly-name-sql-queries-displayed-in-databases-dashboard/78755). Thanks to community contributor @kevinpohlmeier for the implementation. ([#799](https://github.com/newrelic/newrelic-dotnet-agent/pull/799))
### Fixes
* Resolves an issue where GC metrics were not being properly captured for .NET 6 applications ([#874](https://github.com/newrelic/newrelic-dotnet-agent/pull/874))

## [9.3.0] - 2022-01-04
### New Features
* NServiceBus versions 6 and 7 are now supported in .NET Framework and .NET Core. ([#857](https://github.com/newrelic/newrelic-dotnet-agent/pull/857))
* Add ability to disable agent support for Server-Configuration with `NEW_RELIC_IGNORE_SERVER_SIDE_CONFIG` environment variable. The available value options are `true` and `false`. ([#814](https://github.com/newrelic/newrelic-dotnet-agent/pull/814))
### Fixes
* Fixes issue [#36](https://github.com/newrelic/newrelic-dotnet-agent/issues/36): Total system memory will now be correctly reported on Linux. ([#855](https://github.com/newrelic/newrelic-dotnet-agent/pull/855))
* Fixes an issue in `newrelic.config` file schema validation that could block agent startup. ([#835](https://github.com/newrelic/newrelic-dotnet-agent/pull/835))

## [9.2.0] - 2021-11-18
### .NET 6 Compatibility
As of version 9.2.0, the New Relic .NET Core agent supports .NET 6.

### New Features
* Adds automatic instrumentation for the `Microsoft.Azure.Cosmos` client library. ([#811](https://github.com/newrelic/newrelic-dotnet-agent/pull/811))
* Adds additional logging to the Garbage Collection performance metrics to aid in troubleshooting performance counter issues. ([#792](https://github.com/newrelic/newrelic-dotnet-agent/pull/792))
* Feature [#800](https://github.com/newrelic/newrelic-dotnet-agent/issues/800): On .NET Framework apps instrumented with the .NET Framework agent, the value of the ".NET Version" property in the Environment data page will more accurately reflect the version of .NET Framework in use. ([#801](https://github.com/newrelic/newrelic-dotnet-agent/pull/801))  
### Fixes
* Fixes issue [#803](https://github.com/newrelic/newrelic-dotnet-agent/issues/803): Thread safety issue occurred when accessing HTTP headers collection in HttpClient on .NET 6. ([#804](https://github.com/newrelic/newrelic-dotnet-agent/pull/804))

## [9.1.1] - 2021-11-02
### Fixes
* Fixes issue [#780](https://github.com/newrelic/newrelic-dotnet-agent/issues/780): Improves management of gRPC channels during connection failure scenarios. ([#782](https://github.com/newrelic/newrelic-dotnet-agent/pull/782))
* Fixes issue [#781](https://github.com/newrelic/newrelic-dotnet-agent/issues/781): Windows MSI installer was not deploying gRPC libraries for netcore applications. ([#788](https://github.com/newrelic/newrelic-dotnet-agent/pull/788))

## [9.1.0] - 2021-10-26
### New Features
* Feature [#365](https://github.com/newrelic/newrelic-dotnet-agent/issues/365): This version adds support for the Linux ARM64/AWS Graviton2 platform using .NET 5.0. ([#768](https://github.com/newrelic/newrelic-dotnet-agent/pull/768))
  * Includes a new `Processor Architecture` property reported by the Agent with the Environment.
### Fixes
* Fixes issue [#754](https://github.com/newrelic/newrelic-dotnet-agent/issues/754): Agent could cause applications that use configuration builders from `Microsoft.Configuration.ConfigurationBuilders` to hang on startup. ([#753](https://github.com/newrelic/newrelic-dotnet-agent/pull/753))

## [9.0.0] - 2021-09-16
### New Features
* Feature [#672](https://github.com/newrelic/newrelic-dotnet-agent/issues/672): This release of the .NET agent enables Distributed Tracing by default, and deprecates Cross Application Tracing. ([#700](https://github.com/newrelic/newrelic-dotnet-agent/pull/700))
* Feature [#671](https://github.com/newrelic/newrelic-dotnet-agent/issues/671): The maximum number of samples stored for Span Events can be configured via the `spanEvents.maximumSamplesStored` configuration in the `newrelic.config` or the `NEW_RELIC_SPAN_EVENTS_MAX_SAMPLES_STORED` Environemnt Variable.([#701](https://github.com/newrelic/newrelic-dotnet-agent/pull/701))
* Feature [#703](https://github.com/newrelic/newrelic-dotnet-agent/issues/703): Increases the default maximum number of samples stored for Span Events from 1000 to 2000.([#705](https://github.com/newrelic/newrelic-dotnet-agent/pull/705))
* Feature [#532](https://github.com/newrelic/newrelic-dotnet-agent/issues/532): Adds Environment variables for log level `NEWRELIC_LOG_LEVEL` and directory `NEWRELIC_LOG_DIRECTORY` to allow better control of logs for the Agent and the Profiler. ([#717](https://github.com/newrelic/newrelic-dotnet-agent/pull/717))

### Fixes
* Fixes issue [#707](https://github.com/newrelic/newrelic-dotnet-agent/issues/707): In 8.40.1 SQL explain plans are not being captured for parameterized SQL statements. ([#708](https://github.com/newrelic/newrelic-dotnet-agent/pull/708))
* Fixes issue [#502](https://github.com/newrelic/newrelic-dotnet-agent/issues/502): Agent encountering serialization error ([#715](https://github.com/newrelic/newrelic-dotnet-agent/pull/715))
* Fixes issue [#679](https://github.com/newrelic/newrelic-dotnet-agent/issues/679): Update gRPC libraries from 2.35.0 to 2.40.0 to reduce installation size ([#721](https://github.com/newrelic/newrelic-dotnet-agent/pull/721))

### Deprecations/Removed Features
* Cross Application Tracing is now deprecated, and disabled by default. To continue using it, enable it with `crossApplicationTracer.enabled = true` and `distributedTracing.enabled = false`.
* Issue [#667](https://github.com/newrelic/newrelic-dotnet-agent/issues/611), [668](https://github.com/newrelic/newrelic-dotnet-agent/issues/668), [#669](https://github.com/newrelic/newrelic-dotnet-agent/issues/669): previously deprecated agent configuration options are now disabled.  See the [migration guide](https://docs.newrelic.com/docs/agents/net-agent/getting-started/8x-to-9x-agent-migration-guide/#removal-of-deprecated-agent-configuration-settings) for details.
* Issue [#666](https://github.com/newrelic/newrelic-dotnet-agent/issues/666): previously deprecated agent APIs have been removed, and disabled in the Agent. Disabled APIs will log a warning when invoked by old versions of the Agent API. See the [migration guide](https://docs.newrelic.com/docs/agents/net-agent/getting-started/8x-to-9x-agent-migration-guide/#removal-of-deprecated-public-agent-api-methods) for details. ([#687](https://github.com/newrelic/newrelic-dotnet-agent/pull/687))
* Issue [#702](https://github.com/newrelic/newrelic-dotnet-agent/issues/702) Deprecate instrumentation for Castle.Monorail ([#710](https://github.com/newrelic/newrelic-dotnet-agent/pull/710))

## [8.41.1] - 2021-08-25
### New Features
### Fixes
* Fixes issue [#627](https://github.com/newrelic/newrelic-dotnet-agent/issues/627): Grpc channel shutdown can cause `license_key is required` error message. ([#663](https://github.com/newrelic/newrelic-dotnet-agent/pull/663))
* Fixes issue [#683](https://github.com/newrelic/newrelic-dotnet-agent/issues/683): Requested stack trace depth is not always honored. ([#684](https://github.com/newrelic/newrelic-dotnet-agent/pull/684))

## [8.41.0] - 2021-07-21
### New Features
* Feature [#611](https://github.com/newrelic/newrelic-dotnet-agent/issues/611): Capture HTTP request method on transactions in the AspNetCore, Asp35, Wcf3, and Owin wrappers.
* Feature [#580](https://github.com/newrelic/newrelic-dotnet-agent/issues/580): Send initial app name and source in environment data. ([#653](https://github.com/newrelic/newrelic-dotnet-agent/pull/653))
* Adds support for capturing stack traces for each instrumented method in a Transaction Trace.
  * This feature is disabled by default.
  * You can enable the capture of stack traces by setting either maxStackTrace to any value greater than 1.  This value will only be used to determine if stack traces are captured or not despite the name.
  * The following are the default settings for stack traces. These can be changed using the newrelic.config:
    * A maximum 80 stack frames are reported per stack trace.

### Fixes
* Fixes issue [#639](https://github.com/newrelic/newrelic-dotnet-agent/issues/639): RabbitMQ instrumentation can delete user headers from messages. Thank you @witoldsz for finding and reporting this bug. ([#648](https://github.com/newrelic/newrelic-dotnet-agent/pull/648))

## [8.40.1] - 2021-07-08
### Fixes
* Fixes issue [#485](https://github.com/newrelic/newrelic-dotnet-agent/issues/485): `SendDataOnExit` configuration setting will prevent Infinite Traces data sending interuption on application exit. ([#550](https://github.com/newrelic/newrelic-dotnet-agent/pull/609))
* Fixes issue [#155](https://github.com/newrelic/newrelic-dotnet-agent/issues/155): MVC invalid Action for valid Controller can cause MGI. ([#608](https://github.com/newrelic/newrelic-dotnet-agent/pull/608))
* Fixes issue [#186](https://github.com/newrelic/newrelic-dotnet-agent/issues/186): Attribute based Routing (ex WebAPI) can cause transaction naming issues. ([#612](https://github.com/newrelic/newrelic-dotnet-agent/pull/612))
* Fixes issue [#463](https://github.com/newrelic/newrelic-dotnet-agent/issues/463): Handle OPTIONS requests for asp.net applications. ([#612](https://github.com/newrelic/newrelic-dotnet-agent/pull/612))
* Fixes issue [#551](https://github.com/newrelic/newrelic-dotnet-agent/issues/551): Missing external calls in WCF Service. ([#610](https://github.com/newrelic/newrelic-dotnet-agent/pull/610))
* Fixes issue [#616](https://github.com/newrelic/newrelic-dotnet-agent/issues/616): Linux Kudu not accessible when .NET agent presents. ([#618](https://github.com/newrelic/newrelic-dotnet-agent/pull/618))
* Fixes issue [#266](https://github.com/newrelic/newrelic-dotnet-agent/issues/266): Agent fails to initialize and provides no logs when configured with capitalized booleans. ([#617](https://github.com/newrelic/newrelic-dotnet-agent/pull/617))
* Explain plans will be created if [transactionTracer.explainEnabled](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration/#tracer-explainEnabled) is true and one or both [transactionTracer.enabled](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration/#tracer-enabled) or [slowSql.enabled](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration/#slow_sql) are true.  If transactionTracer.explainEnabled is false or both transactionTracer.enabled and slowSql.enabled are false, no Explain Plans will be created.
* Fixes issue [#600](https://github.com/newrelic/newrelic-dotnet-agent/issues/600): Thread id will now be used in agent logging, even if a thread name has been set. ([#626](https://github.com/newrelic/newrelic-dotnet-agent/pull/626))
* Fixes issue [#476](https://github.com/newrelic/newrelic-dotnet-agent/issues/476): When generating and explain plan MS SQL parsing is matching parts of words instead of whole words
* Fixes issue [#477](https://github.com/newrelic/newrelic-dotnet-agent/issues/476): SQL Explain plans MS SQL parser needs to be able to ToString an object to work with parameterized queries
  * Improves handling serializable types like DateTimeOffset
  * The presence DbTypes Binary and Object will prevent an Explain Plan from being executed.  In order to execute an explain plan, the agent must replace any parameters in a query with the real values.  Binary and Object are too complex to properly serialize without introducing errors.

## [8.40.0] - 2021-06-08
### New Features
* Adds Agent support for capturing HTTP Request Headers.
  * Support included for ASP.NET 4.x, ASP.NET Core, Owin, and WCF instrumentation. ([#558](https://github.com/newrelic/newrelic-dotnet-agent/issues/558), [#559](https://github.com/newrelic/newrelic-dotnet-agent/issues/559), [#560](https://github.com/newrelic/newrelic-dotnet-agent/issues/560), [#561](https://github.com/newrelic/newrelic-dotnet-agent/issues/561))

### Fixes
* Fixes issue [#264](https://github.com/newrelic/newrelic-dotnet-agent/issues/264): Negative GC count metrics will now be clamped to 0, and a log message will be written to note the correction. This should resolve an issue where the GCSampler was encountering negative values and crashing. ([#550](https://github.com/newrelic/newrelic-dotnet-agent/pull/550))
* Fixes issue [#584](https://github.com/newrelic/newrelic-dotnet-agent/issues/584): When the agent is configured to log to the console, the configured logging level from `newrelic.config` will be respected. ([#587](https://github.com/newrelic/newrelic-dotnet-agent/pull/587))

## [8.39.2] - 2021-04-14
### Fixes
* Fixes issue [#500](https://github.com/newrelic/newrelic-dotnet-agent/issues/500): For transactions without errors, Agent should still create the `error` intrinsics attribute with its value set to `false`. ([#501](https://github.com/newrelic/newrelic-dotnet-agent/pull/501))
* Fixes issue [#522](https://github.com/newrelic/newrelic-dotnet-agent/issues/522): When the `maxStackTraceLines` config value is set to 0, the agent should not send any stack trace data in the `error_data` payload. ([#523](https://github.com/newrelic/newrelic-dotnet-agent/pull/523))

## [8.39.1] - 2021-03-17
### Fixes
* Fixes issue [#22](https://github.com/newrelic/newrelic-dotnet-agent/issues/22): Agent causes exception when distributed tracing is enabled in ASP.NET Core applications that use the RequestLocalization middleware in a Linux environment. ([#493](https://github.com/newrelic/newrelic-dotnet-agent/pull/493))
* Fixes issue [#267](https://github.com/newrelic/newrelic-dotnet-agent/issues/267): On Linux, the profiler fails to parse config files that start with a UTF-8 byte-order-mark (BOM). ([#492](https://github.com/newrelic/newrelic-dotnet-agent/pull/492))
* Fixes issue [#464](https://github.com/newrelic/newrelic-dotnet-agent/issues/464): Distributed tracing over RabbitMQ does not work with `RabbitMQ.Client` versions 6.x+ ([#466](https://github.com/newrelic/newrelic-dotnet-agent/pull/466))
* Fixes issue [#169](https://github.com/newrelic/newrelic-dotnet-agent/issues/169): Profiler should be able to match method parameters from XML that contain a space. ([#461](https://github.com/newrelic/newrelic-dotnet-agent/pull/461))

## [8.39] - 2021-02-10
### New Features
* Add `GetBrowserTimingHeader(string nonce)` overload.
  * This allows sites with a `Content-Security-Policy` that disables `'unsafe-inline'` to emit the inline script with a nonce.

### Fixes
* Fixes Issue [#394](https://github.com/newrelic/newrelic-dotnet-agent/issues/394): agent fails to enable infinite tracing in net5.0 docker images

## [8.38] - 2021-01-26
### New Features
* **Improvements to New Relic Edge (Infinite Tracing)** <br/>
  * The agent will now handle having its infinite tracing traffic moved from one backend host to another without losing data or requiring an agent restart.
  * Improved logging of infinite tracing connections.

## [8.37] - 2021-01-04
### New Features
* **Updated support for RabbitMQ** <br/>
  * Adds support for .NET Core applications using RabbitMQ.Client.
  * Adds support for RabbitMQ.Client version 6.2.1.
  * Not supported: Distributed Tracing is not supported with the RabbitMQ AMQP 1.0 plugin.

* **Adds [configuration](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration) Environment Variables** <br/>
  * Adds MAX_TRANSACTION_SAMPLES_STORE - the maximum number of samples stored for Transaction Events.
  * Adds MAX_EVENT_SAMPLES_STORED - the maximum number of samples stored for Custom Events. 
  * Adds NEW_RELIC_LOG - the unqualifed name for the Agent's log file.

## [8.36] - 2020-12-08

### Fixes
* Fixes Issue [#224](https://github.com/newrelic/newrelic-dotnet-agent/issues/224): leading "SET" commands will be ignored when parsing compound SQL statements. ([#370](https://github.com/newrelic/newrelic-dotnet-agent/pull/370))
* Fixes Issue [#226](https://github.com/newrelic/newrelic-dotnet-agent/issues/226): the profiler ignores drive letter in `HOME_EXPANDED` when detecting running in Azure Web Apps. ([#373](https://github.com/newrelic/newrelic-dotnet-agent/pull/373))
* Fixes Issue [#93](https://github.com/newrelic/newrelic-dotnet-agent/issues/93): when the parent methods are blocked by their asynchronous child methods, the agent deducts the child methods' duration from the parent methods' exclusive duration.([#374](https://github.com/newrelic/newrelic-dotnet-agent/pull/374))
* Fixes Issue [#9](https://github.com/newrelic/newrelic-dotnet-agent/issues/9) where the agent failed to read settings from `appsettings.{environment}.json` files. ([#372](https://github.com/newrelic/newrelic-dotnet-agent/pull/372))
* Fixes Issue [#116](https://github.com/newrelic/newrelic-dotnet-agent/issues/116) where the agent failed to read settings from `appsettings.json` in certain hosting scenarios. ([#375](https://github.com/newrelic/newrelic-dotnet-agent/pull/375))
* Fixes Issue [#234](https://github.com/newrelic/newrelic-dotnet-agent/issues/234) by reducing the likelihood of a Fatal CLR Error. ([#376](https://github.com/newrelic/newrelic-dotnet-agent/pull/376))
* Fixes Issue [#377](https://github.com/newrelic/newrelic-dotnet-agent/issues/377) when using the `AddCustomAttribute` API with `Microsoft.Extensions.Primitives.StringValues` type causes unsupported type exception. ([378](https://github.com/newrelic/newrelic-dotnet-agent/pull/378))


## [8.35] - 2020-11-09

### New Features
* **.NET 5 GA Support** <br/>
We have validated that this version of the agent is compatible with .NET 5 GA. See the [compatibility and requirements for .NET Core](https://docs.newrelic.com/docs/agents/net-agent/getting-started/net-agent-compatibility-requirements-net-core) page for more details.

### Fixes
* Fixes Issue [#337](https://github.com/newrelic/newrelic-dotnet-agent/issues/337) by removing obsolete code which was causing memory growth associated with a large number of transaction names.
* PR [#348](https://github.com/newrelic/newrelic-dotnet-agent/pull/348): guards against potential exceptions being thrown from the agent API when the agent is not attached.  

## [8.34] - 2020-10-26

### New Features
* **.NET 5 RC2 Support** <br/>
We have validated that this version of the agent is compatible with .NET 5 Release Candidate 2.

### Fixes
* Fixes issue [#301](https://github.com/newrelic/newrelic-dotnet-agent/issues/301) where the agent incorrectly parses server-side configuration causing agent to shutdown.([#310](https://github.com/newrelic/newrelic-dotnet-agent/pull/310))
* Modifies WCF Instrumentation to address [#314](https://github.com/newrelic/newrelic-dotnet-agent/issues/314) by minimizing the reliance upon handled exceptions during the  attempt to capture CAT and DT payloads.

## [8.33] - 2020-10-12

### Fixes
* Fixes [#223](https://github.com/newrelic/newrelic-dotnet-agent/issues/223) so the agent can be compatible with ASP.NET Core 5 RC1.
* Fixes issue in .NET 5 applications where external calls made with HttpClient may not get instrumented. For example, calls made with `HttpClient.GetStringAsync` would be missed. ([#235](https://github.com/newrelic/newrelic-dotnet-agent/pull/235))
* Fixes issue [#257](https://github.com/newrelic/newrelic-dotnet-agent/issues/223) where .NET Standard Libraries that do not reference `mscorlib` fail to be instrumented in .NET Framework applications.
* Reduces the performance impact of large amounts of instrumentation. See issue [#269](https://github.com/newrelic/newrelic-dotnet-agent/issues/269) for more information.

## [8.32] - 2020-09-17

### New Features
* **Proxy Password Obfuscation Support** <br/>
Agent configuration supports the obfuscation of the proxy password. [The New Relic Command Line Interface (CLI)](https://github.com/newrelic/newrelic-cli/blob/main/README.md) may be used to obscure the proxy password.  The following [documentation](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#proxy) describes how to use an obscured proxy password in the .NET Agent configuration.
* **MySqlConnector Support** <br/>
The MySqlConnector ADO.NET driver is instrumented by default. Fixes [#85](https://github.com/newrelic/newrelic-dotnet-agent/issues/85) and implements [this suggestion](https://discuss.newrelic.com/t/feature-idea-support-mysqlconnector-driver-for-db-instrumentation/63414).

* **Nullable Reference Type support in the API**<br/>
Enables nullable reference types that are part of the C# 8.0 language specification and updates the signatures of API methods accordingly.  There should be no required changes in API usage.

* **Improved Support for NetTCP Binding in WCF Instrumation**
When the NetTCP Binding type is used in Windows Communication Foundation (WCF), the Agent will now send and receive trace context information in support of Distributed Tracing (DT) or Cross Application Tracing (CAT).  Implements [#209](https://github.com/newrelic/newrelic-dotnet-agent/issues/209).

### Fixes
* Fixes an issue that may cause `InvalidCastException` due to an assembly version mismatch in Mvc3 instrumentation.
* Fixes an async timing issue that can cause the end time of `Task`-returning methods to be determined incorrectly.


## [8.31] - 2020-08-17
### New Features
* **Expected Errors Support** <br/>
Certain errors that are expected within the application may be identified so that they will not be counted towards the application's error rate and Apdex Score.  Only errors that truly affect the health of the application will be alerted on.  Please review the following [documentation](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#error_collector) for details on how to configure Expected Errors.

* **Ignored Errors Enhancements** <br/>
Certain errors may be identified in configuration so that they will be ignored.  These errors will not be counted towards the application's error rate, Apdex score, and will not be reported by the agent. Please review the following [documentation](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#error_collector) for details on how to configure Ignored Errors.
    * New configuration element [`<ignoreMessages>`](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#error-ignoreErrors)supports filtering based on the error message. 
    * Please note that the [`<ignoreErrors>`](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#error-ignoreErrors) configuration element has been deprecated and replaced by [`<ignoreClasses>`](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#error-ignoreClasses).  The .NET Agent continues to support this configuration element, but its support may be removed in the future.

### Fixes
* **Garbage Collection Performance Metrics for Windows** <br/>
Fixes an issue where Garbage Collection Performance Metrics may not be reported for Windows Applications.

* **Maintaining newrelic.config on Linux package upgrades** <br/>
Fixes an issue where `newrelic.config` was being overwritten when upgrading the agent via either `rpm`/`yum` (RedHat/Centos) or `dpkg`/`apt` (Debian/Ubuntu).

## [8.30] - 2020-07-15
### New Features
* **The .NET Agent is now open source!** <br/>
The New Relic .NET agent is now open source! Now you can view the source code to help with troubleshooting, observe the project roadmap, and file issues directly in this repository.  We are now using the [Apache 2 license](/LICENSE). See our [Contributing guide](/CONTRIBUTING.md) and [Code of Conduct](https://opensource.newrelic.com/code-of-conduct/) for details on contributing!

### Fixes
* **Memory Usage Reporting for Linux** <br/>
Fixes issue where applications running on Linux were either reporting no physical memory usage or using VmData to report the physical memory usage of the application. The agent now uses VmRSS through a call to [`Process.WorkingSet64`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.workingset64) to report physical memory usage. See the [dotnet runtime discussion](https://github.com/dotnet/runtime/issues/28990) and the [proc man pages](https://man7.org/linux/man-pages/man5/proc.5.html) for more details about this change.

* **Infinite Tracing Performance** <br/>
Fixes issue where the Agent may consume too much memory when using Infinite Tracing.

* **.NET 5 support** <br/>
Fixes issue with applications running on .NET 5 that prevented instrumentation changes at runtime (either though editing instrumentation XML files or through the Live Instrumentation editor Beta).

## [8.29] - 2020-06-25
### New Features

* **Additional Transaction Information applied to Span Events** <br/>
When Distributed Tracing and/or Infinite Tracing are enabled, the Agent will now incorporate additional information from the Transaction Event on to the root Span Event of the transaction.

    * The following items are affected:

        * Request Parameters `request.parameter.*`
        * Custom Attribute Values applied to the Transaction via API Calls [`AddCustomParameter`](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api/addcustomparameter-net-agent-api/) and [`ITransaction.AddCustomAttribute`](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api/itransaction#addcustomattribute).
        * `request.uri`
        * `response.status`
        * `host.displayName`
    * **Security Recommendation** <br>
    Review your [Transaction Attributes](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#transaction_events) configuration.  Any attribute include or exclude settings specific to Transaction Events, should be applied to your [Span Attributes](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#span_events) configuration or your [Global Attributes](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#agent-attributes) configuration.
    
### Fixes
Fixes issue where updating custom instrumentation while application is running could cause application to crash.

## [8.28] - 2020-06-04
### New Features
### Fixes
* **Infinite Tracing** <br>
    * Fixes issue with Infinite Tracing where a communication error can result in consuming too much CPU.
    * Fixes issue with Infinite Tracing where a communication error did not clean up its corresponding communication threads.
    * <p style="color:red;">Agent version 8.30 introduces significant performance enhancements to Infinite Tracing.  To use Infinite Tracing, please upgrade to version 8.30 or later.</p>

* Fixes issue in .NET Framework ASP.NET MVC applications where transactions started on one thread would flow to background threads (e.g., started with `Task.Run`) in some scenarios but not others. Transaction state used to only flow to a background thread if the transaction originated from an async controller action. Transaction state now flows to background threads regardless of whether the controller action is async or not.
* Fixes issue in .NET Framework ASP.NET MVC applications where agent instrumentation of an MVC controller action could cause an `InvalidProgramException`.
* Fixes a problem with the reporting of Errors where Error Events may not appear even though Error Traces are being sent.

## [8.27] - 2020-04-30
### New Features
* **Support for W3C Trace Context, with easy upgrade from New Relic trace context**
  * [Distributed Tracing now supports W3C Trace Context headers](https://docs.newrelic.com/docs/distributed-tracing/concepts/how-new-relic-distributed-tracing-works/#headers) for HTTP when distributed tracing is enabled.  Our implementation can accept and emit both W3C trace header format and New Relic trace header format. This simplifies agent upgrades, allowing trace context to be propagated between services with older and newer releases of New Relic agents. W3C trace header format will always be accepted and emitted. New Relic trace header format will be accepted, and you can optionally disable emission of the New Relic trace header format.
  * When distributed tracing is enabled with `<distributedTracing enabled="true" />`, the .NET agent will now accept W3C's `traceparent` and `tracestate` headers when calling [Transaction.AcceptDistributedTraceHeaders](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api/itransaction#acceptdistributedtraceheaders).  When calling [Transaction.InsertDistributedTraceHeaders](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api/itransaction#insertdistributedtraceheaders), the .NET agent will include the W3C headers along with the New Relic distributed tracing header, unless the New Relic trace header format is disabled using `<distributedTracing enabled="true" excludeNewrelicHeader="true" />`.
  * The existing `Transaction.AcceptDistributedTracePayload` and `Transaction.CreateDistributedTracePayload` APIs are **deprecated** in favor of [Transaction.AcceptDistributedTraceHeaders](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api/itransaction#acceptdistributedtraceheaders) and [Transaction.InsertDistributedTraceHeaders](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api/itransaction#insertdistributedtraceheaders).

### Fixes
* Fixes issue which prevented Synthetics from working when distributed tracing is enabled.
* Fixes issue where our RPM package for installing the agent on RPM-based Linux distributions included a 32-bit shared library, which created unnecessary dependencies on 
  32-bit system libraries.
* Fixes issue where the TransportDuration metric for distributed traces was always reporting 0.


## [8.26] - 2020-04-20
### New Features
* **Infinite Tracing on New Relic Edge**

  This release adds support for [Infinite Tracing on New Relic Edge](https://docs.newrelic.com/docs/distributed-tracing/enable-configure/language-agents-enable-distributed-tracing/#infinite-tracing). Infinite Tracing observes 100% of your distributed traces and provides visualizations for the most actionable data so you have the examples of errors and long-running traces so you can better diagnose and troubleshoot your systems.

  You configure your agent to send traces to a trace observer in New Relic Edge. You view your distributed traces through the New Relic’s UI. There is no need to install a collector on your network.

  Infinite Tracing is currently available on a sign-up basis. If you would like to participate, please contact your sales representative.

  <p style="color:red;">Agent version 8.30 introduces significant performance enhancements to Infinite Tracing.  To use Infinite Tracing, please upgrade to version 8.30 or later.</p>
  
* **Error attributes now added to each span that exits with an error or exception**

  Error attributes `error.class` and `error.message` are now included on the span event in which an error or exception was noticed, and, in the case of unhandled exceptions, on any ancestor spans that also exit with an error. The public API method `NoticeError` now attaches these error attributes to the currently executing span.

  [Spans with error details are now highlighted red in the Distributed Tracing UI](https://docs.newrelic.com/docs/distributed-tracing/ui-data/understand-use-distributed-tracing-ui/#error-tips), and error details will expose the associated `error.class` and `error.message`. It is also now possible to see when an exception leaves the boundary of the span, and if it is caught in an ancestor span without reaching the entry span. NOTE: This “bubbling up” of exceptions will impact the error count when compared to prior behavior for the same trace. It is possible to have a trace that now has span errors without the trace level showing an error.

  If multiple errors occur on the same span, only the most recent error information is added to the attributes. Prior errors on the same span are overwritten.

  These span event attributes conform to [ignored errors](https://docs.newrelic.com/docs/agents/manage-apm-agents/agent-data/manage-errors-apm-collect-ignore-or-mark-expected#ignore) configuration.

### Fixes
* Fixes issue in the MSI installer which prevented the `InstrumentAllNETFramework` feature selection from working as expected on the command line.
* Fixes issue for Azure App Service environments running on Linux that caused both the application and its Kudu process to be instrumented by the agent. The Kudu process is no longer instrumented.
* Fixes issue when using the [`ignoreErrors` configuration](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#error-ignoreErrors). Previously, when an exception contained a inner exception(s), the `ignoreErrors` config was only applied to the outer-most exception. Now, both the outer-most and inner-most exception type are considered when evaluating the `ignoreErrors` configuration.
* Fixes an issue that could cause an exception to occur in the instrumentation for StackExchange Redis. This exception caused the instrumentation to shut down leaving StackExchange Redis uninstrumented.

## [8.25] - 2020-03-11

### New Features
* **Thread profiling support for Linux**

  Thread profiling on Linux will be supported on .NET Core 3.0 or later applications when running .NET agent version 8.23 or later. Triggering a thread profile is done from the `Thread profiler` page in APM. This page does not yet have the functionality enabled, but it will be enabled in the next few business days.

* **Accessing Span-Specific information using the .NET Agent API**
  
  New property, `CurrentSpan` has been added to `IAgent` and `ITransaction`.  It returns an object implementing `ISpan` which provides access to span-specific functions within the API.

* **Adding Custom Span Attributes using the .NET Agent API**
  
  New method, `AddCustomAttribute(string, object)` has been added to `ISpan`.

  * This new method accepts and supports all data-types.
  * Further information may be found within [.NET Agent API documentation](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api/ispan).
  * Adding custom attributes to spans requires distributed tracing and span events to be enabled. See [.NET agent configuration](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#distributed_tracing)


### Fixes
* Fixes issue where adding multiple custom attributes on a Transaction using [`ITransaction.AddCustomAttribute`](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api/itransaction#addcustomattribute) causes the agent to ignore additional attempts to add custom attributes to any transaction. 
* Fixes issue that prevented Custom Events from being sent to New Relic until the agent shuts down.
* Fixes issue that can cause asynchronous Redis calls in an ASP.NET MVC application to report an inflated duration.


## [8.24] - 2020-02-19

### New Features
* **Adding Custom Transaction Attributes using the .NET Agent API**

  New method, `AddCustomAttribute(string, object)` has been added to `ITransaction`.
  * This new method accepts and supports all data-types.
  * Method `AddCustomParameter(string, IConvertable)` is still available with limited data-type support; however, this method should be considered obsolete and will  be removed in a future release of the Agent API.
  * Further information may be found within [.NET Agent API documentation](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api/itransaction).

* **Enhanced type support for `RecordCustomEvent` and `NoticeError` API Methods.**

  APIs for recording exceptions and custom events now support values of all types.
  * The `NoticeError` API Method has new overloads that accept an `IDictionary<string, object>`.
  * The `RecordCustomEvent` methods have been modified to handle all types of data.  In that past, they only handled `string` and `float` types.
  * Further information may be found within [.NET Agent API documentation](https://docs.newrelic.com/docs/agents/net-agent/net-agent-api).

* **New attributes on span events**

  * Spans created for external HTTP calls now include the `http.statusCode` attribute representing the status code of the call.
  * Spans created for calls to a datastore now include the `db.collection` attribute. For instance, this will be the table name for a call to MS SQL Server.

* **Ability to exclude attributes from span events**

  Attributes on span events (e.g., `http.url`) can now be excluded via configuration. See [.NET agent configuration](https://docs.newrelic.com/docs/agents/net-agent/configuration/net-agent-configuration#span_events) for further information.


### Fixes
* New Relic distributed tracing relies on propagating trace and span identifiers in the headers of external calls (e.g., an HTTP call). These identifiers now only contain lowercase alphanumeric characters. Previous versions of the .NET agent used uppercase alphanumeric characters. The usage of uppercase alphanumeric characters can break traces when calling downstream services also monitored by a New Relic agent that supports W3C trace context (New Relic's .NET agent does not currently support W3C trace context. Support for W3C trace context for .NET will be in an upcoming release). This is only a problem if a .NET application is the originator of the trace.

[Unreleased]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.9.0...HEAD
[10.9.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.8.0...v10.9.0    
[10.8.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.7.0...v10.8.0
[10.7.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.6.0...v10.7.0
[10.6.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.5.1...v10.6.0
[10.5.1]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.5.0...v10.5.1
[10.5.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.4.0...v10.5.0
[10.4.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.3.0...v10.4.0
[10.3.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.2.0...v10.3.0
[10.2.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.1.0...v10.2.0
[10.1.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v10.0.0...v10.1.0
[10.0.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.9.0...v10.0.0
[9.9.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.8.1...v9.9.0
[9.8.1]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.8.0...v9.8.1
[9.8.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.7.1...v9.8.0
[9.7.1]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.7.0...v9.7.1
[9.7.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.6.1...v9.7.0
[9.6.1]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.6.0...v9.6.1
[9.6.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.5.1...v9.6.0
[9.5.1]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.5.0...v9.5.1
[9.5.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.4.0...v9.5.0
[9.4.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.3.0...v9.4.0
[9.3.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.2.0...v9.3.0
[9.2.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.1.1...v9.2.0
[9.1.1]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.1.0...v9.1.1
[9.1.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v9.0.0...v9.1.0
[9.0.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.41.1...v9.0.0
[8.41.1]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.41.0...v8.41.1
[8.41.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.40.1...v8.41.0
[8.40.1]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.40.0...v8.40.1
[8.40.0]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.39.2...v8.40.0
[8.39.2]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.39.1...v8.39.2
[8.39.1]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.39.0...v8.39.1
[8.39]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.38.0...v8.39.0
[8.38]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.37.0...v8.38.0
[8.37]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.36.0...v8.37.0
[8.36]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.35.0...v8.36.0
[8.35]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.34.0...v8.35.0
[8.34]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.33.0...v8.34.0
[8.33]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.32.0...v8.33.0
[8.32]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.31.0...v8.32.0
[8.31]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.30.0...v8.31.0
[8.30]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.29.0...v8.30.0
[8.29]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.28.0...v8.29.0
[8.28]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.27.139...v8.28.0
[8.27]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.26.630...v8.27.139
[8.26]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.25.214...v8.26.630
[8.25]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.24.244...v8.25.214
[8.24]: https://github.com/newrelic/newrelic-dotnet-agent/compare/v8.23.107...v8.24.244
