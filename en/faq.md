# Fequently Asked Questions




## Why doesn't my application do stereo rendering?

There could be 2 causes for this issue：

1. `Player Settings` doesn't have correct `XR Settings`. Please config your XR settings as shown below.

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/xr-settings.png)

2. The ARCamera component needs to be set to `Stereo".

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/main-cam-rendering-mode.png)



## Why doesn't my application track physical marker?

- Please make sure the wire between phone and headset is tightly plugged.

- Check if the Tracking file is correctly configurated. 

- If above 2 items are cleared, please check application permissions. 

  Sometimes, on certain devices, after application installations, the phone doesn't pop up permission dialog. In this case, user needs to turn on the `save/read` permission for this application manually.

- Please make sure there is only one application that requires VPU connection in the system background. If there are multiple ones running at the sametime, the running applications will battle for the connections, causing tracking problems.



## Why does Bluetooth connection between controller and VPU keep dropping？

- Please make sure the bluetooth controller is connected. Typically, the LED of the controller should stay lit when the controller is connected.
- Make sure the controller is only connected to only one VPU. If the controller is also connected to other VPU, bluetooth connections can drop frequently.
