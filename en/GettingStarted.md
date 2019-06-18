## Hello RhinoX

In this tutorial, we are about to show you how to create an augmented reality application for RhinoX step by step.

- Create a new scene, and name it "Hello RhinoX". Delete the MainCamera Object.
- Add an 'ARCamera' from the menu (shown below). The position can be anywhere but let's set it at [0,0,1.7] for this example.
- Place Cubes and Spheres in the scene to create visual references.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Create-GameObject-Shortcut.png ':size=450X400')

### AR Camera Hiercharchy：

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/ARCameraRig.png)

Please keep this 'GameObject' hierarchy. When changing the position of the ARCamera object, make sure you are moving the parent object, ARCameraRig.

!> This is always the case, be it during runtime (eg. you need to teleport the user to a different area in a game level); or while building your scene (deciding where the user should be located when the application starts).



## Project Compilation

!> Before compilation, please visit [SDK initialization guide](/en/Install-SDK?id=initialization).

If you are not familiar with the Unity Android development process, you can check the [official Unity Android Development Documentation](https://docs.unity3d.com/Manual/android-BuildProcess.html)。


### Install APK and Launch Application through Launcher

!> [adb](https://developer.android.com/studio/command-line/adb) provided with the [Android SDK](https://developer.android.com) is required for installation.

To install, connect the device to the computer using the USB type C port at the front of the HMD and issue the following command
```bash
  $ adb shell install -r -g <TARGET APK>
````
> Make sure to replace &lt;TARGET APK&gt; with the path to the package created in the previous step.
For example "C:\\Builds\\HelloRhinoX.apk"

!> When installing the launcher with adb command, please use -g as an additional parameter. This will set Android level permissions automatically upon a successful installation.

Once the APK is installed and launched, you can wear RhinoX headset to experience the AR experience. If you are not familiar with APK installation process, you can check out [the official Unity Manual](https://docs.unity3d.com/Manual/android-BuildProcess.html) for more information.
