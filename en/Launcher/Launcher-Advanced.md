#	Advanced Features

##	Launcher Installation

[adb](https://developer.android.com/studio/command-line/adb) provided in [Android SDK](https://developer.android.com) is required for installation.

!> When installing the launcher with adb command, please use -g as an additional parameter. Doing this enabling permissions upon successful installation.
```bash
  $ adb shell install -r -g C:\MyApp.apk
````

!> RhinoX Required Permissions:

```bash
  <uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
  <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
  <uses-permission android:name="android.permission.CAMERA" />
````



!> To make your custom application appear in Launcher application, developers would need to add the following attribute in Android Manifest.xml:

```bash
 <category android:name="com.ximmerse.category.WONDERLAND_AR" />
````
 
RhinoX SDK comes with an <b>AndroidManifest.xml</b> :

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

## Uninstall Application

Aim to a to-be-deleted application, hold down controler Trigger button or Confirm button on HMD. A dialog will pop up. User can uninstall the application through this pop-up dialog.

!>	Note: system applications can not be removed.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Launcher/Launcher-Uninstall.png ':size=865X394')

##	Change Display Language
Click on Wifi button in task menu, then select "Change Language", then change your display language to your desired language.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Launcher/Launcher-ChangeLanguage.png ':size=865X394')
