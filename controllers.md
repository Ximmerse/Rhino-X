# 蓝牙控制器

本章节，我们将详细说明在Slide-In 设备中可以连接使用的蓝牙控制机的连接方法以及注意事项。



## 概述

Slide-In 设备具有内置的蓝牙连接模块。当我们建立一个蓝牙连接时，我们是通过VPU 的蓝牙模块进行连接，而不是直接连接手机设备的。

正因如此，我们必须先手机设备连接VPU（头显）才能进行控制器的连接建立。也因如此，手机是不需要有蓝牙权限或者开启蓝牙的。



## 控制器类型

Slide-In 支持Ximmerse 所有控制器类型：

- Flip (3DOF)
- Neon (6DOF)
- Cube
- LightSaber
- Mirage 2B



## 控制器连接

因为控制器连接的蓝牙模块是在VPU 上，如果我们需要预先连接蓝牙设备，我们需要一个辅助工具/应用帮助我们连接。

将此SDK 目录中`Assets/ControllerManagement` 中有一个Controller Management 场景打包成apk(或者[Release](https://github.com/Ximmerse/SlideInSDK/releases/tag/v2.0.1) 中下载ControllerManager.apk) 安装到手机设备上，并且将设备连接到VPU(头显)上，我们就可以通过Controller Manager 这个应用帮助我们管理蓝牙控制器的连接情况。

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/doc-controller-manager.png)

打开需要连接的蓝牙控制器，按住设备对应的连接按钮会发现控制器的指示灯快速闪动，此时点击"Start Pairing" 按钮进行配对。

控制器连接成功通常会伴随指示灯常亮以及手柄震动两个物理提示，同时Controller Manager 应用中也会更改连接状态从"Disconnected" 到"Connected" 。

控制器连接成功后，你可以尝试点击控制器上面的按钮，Controller Manager 应用会提示触发的按键事件。

> 目前Slide-In 支持同时保持两个蓝牙控制器的配对状态，你可以通过点击"Unpair All Controller" 按钮来清除所有已保存的控制器配对信息。

!> 确保控制器一次只与一个VPU 建立配对、连接关系，如果需要连接其他的控制器，请先将其旧的VPU 取消了配对。不然控制器有可能会出现连接一会儿后直接断开的情况。



### 通过MAC 地址在应用内进行主动蓝牙连接

// TODO



## 控制器输入接口

首先在场景中确保存在"Ximmerse Input Module" 的实例，然后可以通过以下的程序接口获取按键事件。

```csharp
private ControllerButton _targetBtn;

public void Update()
{
    // getting button input events
	if(XimmerseControllerInput.IsKey(_targetBtn, 0))
    {
        Debug.Log("Button down.")
    }
    
    if(XimmerseControllerInput.IsKeyUp(_targetBtn, 0))
    {
        Debug.Log("Button up.")
    }
    
    if(XimmerseControllerInput.IsTap(_targetBtn, 0))
    {
        Debug.Log("Button tapped.")
    }
    
    // getting controller rotation
    Quaternion rawRotation = XimmerseControllerInput.GetInputRotation();
}

// recenter controller
public void Recenter(float finalYaw)
{ 
    XimmerseControllerInput.RecenterControllerIMURotation(finalYaw);
}
```



至此，蓝牙控制器的连接说明与注意事项已全部结束。