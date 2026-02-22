# Android NativeAOT publish fails when configuration is not release or debug config.

Tested on: 
Windows 11 Pro - 25H2 - 26200.7840
Dotnet SDK 10.0.103 with maui-android workload 10.0.103

NativeAot-Android-NonReleaseConfig.csproj is the default sample dotnet maui app.

Debug, Release and AppStore configs have all had the following Properties added

```
    <Optimize>True</Optimize>
    <OptimizationPreference>Speed</OptimizationPreference>
    <DebugSymbols>False</DebugSymbols>
    <PublishTrimmed>True</PublishTrimmed>
    <PublishAot>True</PublishAot>
    <AndroidPackageFormat>aab</AndroidPackageFormat>
    <AndroidUseAapt2>True</AndroidUseAapt2>
    <AndroidCreatePackagePerAbi>True</AndroidCreatePackagePerAbi>
    <RuntimeIdentifiers>android-arm64</RuntimeIdentifiers>
    <UseMonoRuntime>False</UseMonoRuntime>
    <JsonSerializerIsReflectionEnabledByDefault>False</JsonSerializerIsReflectionEnabledByDefault>

<!-- Workaround for build error IL1011: Failed to write 'obj\Release\net10.0-android36.0\android-arm64\linked\Java.Interop.dll'. -->
    <_UseNativeLibPrefix Condition=" '$(_UseNativeLibPrefix)' == '' ">true</_UseNativeLibPrefix>
```


dotnet publish .\NativeAot-Android-NonReleaseConfig.csproj --framework net10.0-android36.0 --configuration Release -r android-arm64
dotnet publish .\NativeAot-Android-NonReleaseConfig.csproj --framework net10.0-android36.0 --configuration Debug -r android-arm64

are successful.


dotnet publish .\NativeAot-Android-NonReleaseConfig.csproj --framework net10.0-android36.0 --configuration AppStore -r android-arm64

fails with:

```
 dotnet publish .\NativeAot-Android-NonReleaseConfig\NativeAot-Android-NonReleaseConfig.csproj --framework net10.0-android36.0 --configuration AppStore -r android-arm64
  NativeAot-Android-NonReleaseConfig net10.0-android36.0 android-arm64 failed with 23 error(s) and 5 warning(s) (57.0s)
    C:\Users\james\source\repos\dotnet-repros\NativeAot-Android-NonReleaseConfig\obj\AppStore\net10.0-android36.0\android-arm64\linked\SQLitePCLRaw.batteries_v2.dll : warning IL2104: Assembly 'SQLitePCLRaw.batteries_v2' produced trim warnings. For more information see https://aka.ms/il2104
    C:\Users\james\source\repos\dotnet-repros\NativeAot-Android-NonReleaseConfig\obj\AppStore\net10.0-android36.0\android-arm64\linked\NativeAot-Android-NonReleaseConfig.dll : warning IL2104: Assembly 'NativeAot-Android-NonReleaseConfig' produced trim warnings. For more information see https://aka.ms/il2104
    C:\Users\james\source\repos\dotnet-repros\NativeAot-Android-NonReleaseConfig\obj\AppStore\net10.0-android36.0\android-arm64\linked\NativeAot-Android-NonReleaseConfig.dll : warning IL3053: Assembly 'NativeAot-Android-NonReleaseConfig' produced AOT analysis warnings.
    C:\Users\james\source\repos\dotnet-repros\NativeAot-Android-NonReleaseConfig\obj\AppStore\net10.0-android36.0\android-arm64\linked\CommunityToolkit.Maui.dll : warning IL2104: Assembly 'CommunityToolkit.Maui' produced trim warnings. For more information see https://aka.ms/il2104
    C:\Users\james\source\repos\dotnet-repros\NativeAot-Android-NonReleaseConfig\obj\AppStore\net10.0-android36.0\android-arm64\linked\Mono.Android.dll : warning IL3053: Assembly 'Mono.Android' produced AOT analysis warnings.
    ld.lld : error undefined symbol: _monodroid_gref_get
    ld.lld : error undefined symbol: _monodroid_weak_gref_get
    ld.lld : error undefined symbol: XA_Host_NativeAOT_JNI_OnLoad
    ld.lld : error undefined symbol: XA_Host_NativeAOT_OnInit
    ld.lld : error undefined symbol: clr_initialize_gc_bridge
    ld.lld : error undefined symbol: _monodroid_max_gref_get
    ld.lld : error undefined symbol: monodroid_TypeManager_get_java_class_name
    ld.lld : error undefined symbol: monodroid_free
    ld.lld : error undefined symbol: monodroid_log
    ld.lld : error undefined symbol: monodroid_timing_start
    ld.lld : error undefined symbol: monodroid_timing_stop
    ld.lld : error undefined symbol: _monodroid_lookup_replacement_type
    ld.lld : error undefined symbol: _monodroid_lookup_replacement_method_info
    ld.lld : error undefined symbol: _monodroid_timezone_get_default_id
    ld.lld : error undefined symbol: _monodroid_getifaddrs
    ld.lld : error undefined symbol: _monodroid_freeifaddrs
    ld.lld : error undefined symbol: _monodroid_detect_cpu_and_architecture
    ld.lld : error undefined symbol: _monodroid_gc_wait_for_bridge_processing
    ld.lld : error undefined symbol: _monodroid_gref_log
    ld.lld : error undefined symbol: _monodroid_gref_log_new
    ld.lld : error too many errors emitted, stopping now (use --error-limit=0 to see all errors)
    clang : error linker command failed with exit code 1 (use -v to see invocation)
    C:\Users\james\.nuget\packages\microsoft.dotnet.ilcompiler\10.0.3\build\Microsoft.NETCore.Native.targets(389,5): error MSB3073: The command ""clang" "obj\AppStore\net10.0-android36.0\android-arm64\native\NativeAot-Android-NonReleaseConfig.o" -o "bin\AppStore\net10.0-android36.0\android-arm64\native\libNativeAot-Android-NonReleaseConfig.so" -Wl,--version-script="obj\AppStore\net10.0-android36.0\android-arm64\native\NativeAot-Android-NonReleaseConfig.exports" -Wl,--export-dynamic -gz=zlib -fuse-ld=lld C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libSystem.Native.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libSystem.Globalization.Native.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libSystem.IO.Compression.Native.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libSystem.Security.Cryptography.Native.Android.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libbootstrapperdll.o C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libRuntime.WorkstationGC.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libeventpipe-disabled.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libstandalonegc-disabled.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libaotminipal.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libbrotlienc.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libbrotlidec.a C:\Users\james\.nuget\packages\microsoft.netcore.app.runtime.nativeaot.android-arm64\10.0.3/runtimes/android-arm64/\native\libbrotlicommon.a --target=aarch64-linux-android21 -g -Wl,--build-id=sha1 -Wl,--as-needed -Wl,-e,0x0 -pthread -ldl -lz -llog -lm -shared -Wl,-z,relro -Wl,-z,now -Wl,--eh-frame-hdr -Wl,-z,max-page-size=16384 "-Wl,-soname,libNativeAot-Android-NonReleaseConfig.so" -Wl,--error-unresolved-symbols -Wl,--no-undefined "C:\Program Files (x86)\Android\android-sdk\ndk-bundle\toolchains/llvm/prebuilt/windows-x86_64/sysroot/usr/lib/aarch64-linux-android/libc++_static.a" "C:\Program Files (x86)\Android\android-sdk\ndk-bundle\toolchains/llvm/prebuilt/windows-x86_64/sysroot/usr/lib/aarch64-linux-android/libc++abi.a" obj\AppStore\net10.0-android36.0\android-arm64\android\jni_init_funcs.arm64-v8a.o obj\AppStore\net10.0-android36.0\android-arm64\android\environment.arm64-v8a.o -Wl,--discard-all -Wl,--gc-sections -Wl,-T,"obj\AppStore\net10.0-android36.0\android-arm64\native\sections.ld"" exited with code 1.
 ```