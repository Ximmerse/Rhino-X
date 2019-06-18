#	Advanced Features

##	Launcher Installation

[adb](https://developer.android.com/studio/command-line/adb) provided with the [Android SDK](https://developer.android.com) is required for installation.

To install, connect the device to the computer using the USB type C port at the front of the HMD and issue the following command
```bash
  $ adb shell install -r -g C:\MyApp.apk
````
!> When installing the launcher with adb command, please use -g as an additional parameter. This will set Android level permissions automatically upon a successful installation.

### RhinoX Required Permissions:
The Launcher application (and most applications) require a minimum set of system permissions to operate correctly.
```bash
  <uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
  <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
  <uses-permission android:name="android.permission.CAMERA" />
````

## Adding applications to the RhinoX Launcher

To make custom application appear in the Launcher, developers must ensure that the following attribute is set in the application Android Manifest.xml:

```bash
 <category android:name="com.ximmerse.category.WONDERLAND_AR" />
````

!> RhinoX SDK comes with an <b>AndroidManifest.xml</b>
```bash
<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android" package="com.ximmerse.aio">
  <uses-sdk android:minSdkVersion="23" android:targetSdkVersion="23" />
  <uses-feature android:glEsVersion="0x00030000" />

  <application android:theme="@style/UnityThemeSelector" android:icon="@drawable/app_icon" android:label="@string/app_name" android:debuggable="true">
    <activity android:name="com.unity3d.player.UnityPlayerActivity" android:label="@string/app_name" android:screenOrientation="landscape" android:windowSoftInputMode="stateHidden|adjustResize">
      <intent-filter>
        <action android:name="android.intent.action.MAIN" />
        <category android:name="android.intent.category.LAUNCHER" />
        <category android:name="com.ximmerse.category.WONDERLAND_AR" />
      </intent-filter>
      <meta-data android:name="unityplayer.UnityActivity" android:value="true" />
      <intent-filter>
        <action android:name="android.hardware.usb.action.USB_DEVICE_ATTACHED"/>
      </intent-filter>
      <meta-data android:name="android.hardware.usb.action.USB_DEVICE_ATTACHED" android:resource="@xml/device_filter"/>
    </activity>
  </application>

  <uses-permission android:name="android.permission.INTERNET" />
  <uses-permission android:name="android.permission.WAKE_LOCK" />
  <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE"/>
  <uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
  <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
  <uses-permission android:name="android.permission.CAMERA" />
</manifest>
````

## Uninstall an Application

Select or Aim the to-be-deleted application and hold down the controller 'Trigger' or Confirm button on the HMD. A "Delete" button will show up. After pressing the "Delete" button, users will be prompted for confirmation to uninstall the application.

!>	Note: System applications can not be removed.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Launcher/Launcher-Uninstall.png ':size=865X394')

##	Set the Launcher Language
Click on Wifi button in the task menu. Then select "Language". Change the display language to the desired option.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Launcher/Launcher-ChangeLanguage.png ':size=865X394')
