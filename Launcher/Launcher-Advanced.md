#	更多功能

##	安装应用

使用[Android SDK](https://developer.android.com)自带的 [adb](https://developer.android.com/studio/command-line/adb) 工具安装应用。

!> 当使用 adb 安装的时候，请注意使用 -g 参数，在安装应用的时候赋予默认的应用权限。
```bash
  $ adb install -r -g C:\MyApp.apk
````

!> RhinoX应用需要以下权限:

```bash
  <uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
  <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
  <uses-permission android:name="android.permission.CAMERA" />
````



!> 要让你的应用出现在Launcher中，需要在Android Manifest.xml中添加以下属性:

```bash
 <category android:name="com.ximmerse.category.WONDERLAND_AR" />
````
 
RhinoX SDK 已经附带了 <b>AndroidManifest.xml</b> :

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

## 卸载应用

将光标对准一个应用，并长按扳机（控制器模式）或长按OK键（头瞄模式） > 点击弹出的卸载按钮 >  确认卸载

!>	系统应用无法被卸载

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Launcher/Launcher-Uninstall.png ':size=865X394')

##	更换语言
点击主界面任务栏的Wi-Fi按钮 > 选择语言按钮 > 选择想要更换的语言

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Launcher/Launcher-ChangeLanguage.png ':size=865X394')
