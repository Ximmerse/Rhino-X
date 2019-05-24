# Bluetooth Controller



## Introduction

The Slide-In HMD has a Bluetooth chip, which is responsible for connections between controller and headset. We use VPU Bluetooth module to estabilish connections with controller. Please note that the bluetooth controller is NOT supposed to be directly connected to the phone. 

Therefore, the phone needs to be connected to VPU(the headset) through cable first in order to use Bluetooth controller. The benefit of this setup is that no Bluetooth permission is required on the phone.



## Controller Type

Slide-In supports the following Ximmerse devices:

- Flip (3DOF)
- Neon (6DOF)
- Cube
- LightSaber
- Mirage 2B



## Controller Connection

Because the Bluetooth moduel is located on VPU, we will need a tool to establish Bluetooth connection.

Please deploy the scene Controller Management under `Assets/ControllerManagement` (or download ControllerManager.apk [here](https://github.com/Ximmerse/SlideInSDK/releases/tag/v2.0.1)). Install the apk to Android phone, and then connect the VPU to the phone. We can then use Conttoller Manager application to manage the Bluetooth connections.

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/doc-controller-manager.png)

Turn on the Bluetooth controller, then press the paring buttons on the Bluetooth controllers. Notice that when the Bluetooth controller LED starts to blink, and then click "Start Paring" button to pair.

When controller is connected, the LED on controller(if applicable) should stay lit. The status of controller shown in Bluetooth Manager app should change to "Connected" from "Disconnected".

When controller is successfully connected, you can click on any button on the controller, and you should be able to observe the data log output in Bluetooth manager.

> Currently, Slide-In system supports update to 2 controllers at the same time. 

!> Please make sure that the Bluetooth is only connected to one VPU. If you would like to use the controller with other VPUs, please make sure the connection with old VPU is cleared before pairing.



### Pair Bluetooth Controller with Mac Address

// TODO



## Bluetooth Controller API

First of all, please make sure that there is a "Ximmerse Input Module" in the scene. Then you could use the following API to get controller data:

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



