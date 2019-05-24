# Getting Started

> This tutorial is a Slide-In SDK step by step guidance.



## Prerequisites

Please make sure the following prerequisites are met.

### Hardware

- Samsung Galaxy S8 or Samsung Galaxy S9
- At least one marker, or a marker group

### Software

- [Android Developer Tools](https://developer.android.com/studio/)

  The development PC must have Android SDK installed. API level needs to be 24 or above.

  Once Android Studio installed, the system will automatically update Android Developer tools.

- [Unity 3D Engine](https://unity3d.com/cn/get-unity/download/archive)

  Supported Unity Version: 2017.4.17 f1 / Unity 2018.2.20 f1 / Unity 2018.3.x（You may experience issues with other versions of Unity）

- [Vysor](https://www.vysor.io) (**Optional**， this is used for Android mirroring, increasing development effeciency)



## SDK Setup

### Download SDK

1. Clone the repo:

```bash
$ git clone git@github.com:Ximmerse/SlideInSDK.git
```



2. You can also go to Github page to download latest releases: [https://github.com/Ximmerse/SlideInSDK/releases](https://github.com/Ximmerse/SlideInSDK/releases) 

   - **Slide-InSDK.unitypackage** Unity SDK package.
   - **Slide-InSDK-WithSamples.unitypackage** Unity SDK package with samples.
   - **PEPlugins-2018.3.x.unitypackage** If you are using Unity version 2018.3.x, please import this package to replace the relative PolyEngine plugins.

> If you only need the bare-bone version of SDK, please download **Slide-InSDK.unitypackage**.
>
> If you need a SDK with samples, please download **Slide-InSDK-WithSamples.unitypackage**.

3. Open Unity Engine editor, and start a new project.

> Import the SDK you desired to Unity.

!> If you are using Unity version 2018.3.x, please download additional plugin **PEPlugins-2018.3.x.unitypackage** to replace files from original plugin.



### Directory

- _DemoAssets

  SDK demos and sample scripts.

- Controller Management

  Controller manager source code.

- [LunarConsole](https://assetstore.unity.com/packages/tools/gui/lunar-mobile-console-free-82881)

  This is a free debug logging tool we recommend to use.
  
- **Android/x86_64**

  This directory contains the required libraries on Android and Windows platforms. OS X is not supported at the moment.

- **SlideInSDK**

  Slide-In SDK high level API; this is what you would be interact with.

- **PEPlugins**

  This directory contains helper tools for developers.



### Project Settings

After importing SDK, we need to make sure settings are correctly configured.

Click on `File/Build Settigns` to enter Build Settings.

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-file-build-settings.png)

Then, click on "Player Settings" to enter Player Settings panel.

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-build-settings-player-settings.png)

First setting we need to modify is `Resolution and Presentation`, which needs to be set to "Landscape Right".

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/device-orientation.png)

Please also make sure Minimum API level is set to 24 or above.

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-android-minimum-api-level.png)

Next, please config your `XR Settings` to match the setup below.

!> **None** option must exist.

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/xr-settings.png)

Lastly, Click on `Tools/Slide in/Initialize SDK` to initialize Slide-In SDK. Now you have finished setting up the SDK.

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/init-sdk.png)

## Samples

**Bench Marker**

Bench Marker sample demo.

**Bench Marker Match Scale Content**

·Bench Marker sample assets，including `Bench Marker` coordination system sample setup.



## Tutorials

> `PEPlugins` contains BuildManager tools, which helps users to quickly setup project by using `BuildPreset`.

Click on `Tools/PolyEngine/Build Manager`

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/buildmanager.png)

Select `Tag Tracking` Preset，and then click "Load Preset".

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/build-manager-settings.png)

Once Preset is loaded，the tool will setup everything automatically.

Then we can go back to Build Settings to start deployment of the applications.

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/build-project.png)

Lastly, install the apk to phone and you can start testing.
