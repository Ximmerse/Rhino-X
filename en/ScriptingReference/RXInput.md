# RXInput 

> 命名空间: Ximmerse.RhinoX     
> public static class RXInput

- RXInput 静态类提供所有和设备输入相关的接口。

RhinoX目前支持对控制器和侧边栏确认按键的输入接口。RXInput所支持的按键类型见 [RhinoXButton](/ScriptingReference/RhinoXButton)
 

### 静态方法

#### GetConnectedControllerCount
`public static int GetConnectedControllerCount()`

>获取当前已经建立连接的控制器数量。



#### GetConnectedControllerInfos
`public static XDeviceInfo[] GetConnectedControllerInfos ()`

获取已经连接的控制器的详细信息。


#### GetPairedControllerCount
`public static int GetPairedControllerCount()`

获取已经配对的设备的数量。

!> 已经在Launcher中配对过的设备，即使没有处于连接状态，也会被计算在内。


#### GetPairedControllerInfos
`public static XDeviceInfo[] GetPairedControllerInfos ()`

获取已经配对的设备的详细信息。
!> 已经在Launcher中配对过的设备信息，即使没有处于连接状态，也会返回。 



#### IsButtonDown
`public static bool IsButtonDown(RhinoXButton button, ControllerIndex index)`

用户是否正在按下index对应的控制器上的 button 按键? 当且仅当按下button的帧返回True。 

!> 如果 button = ConfirmButton, 对应RhinoX头显上的侧边栏确认键，index的值会忽略。


```bash
    private void CheckInput()
    {
        if(RXInput.IsButtonDown (RhinoXButton.ControllerTrigger, index: ControllerIndex.Any))
        {
            Debug.Log("User is clicking on trigger");
        }
    }
    
    private void CheckInput_ConfirmSideButton()
    {
        if (RXInput.IsButtonDown(RhinoXButton.ConfirmButton))
        {
            Debug.Log("User is clicking on confirm side-button");
        }
    }
````
 
#### IsButton
`public static bool IsButton(RhinoXButton button, ControllerIndex index)`

用户是否正在按着index对应的控制器上的 button 按键? 

!> 如果 button = ConfirmButton, 对应RhinoX头显上的侧边栏确认键，index的值会忽略。


#### IsButtonUp
`public static bool IsButtonUp(RhinoXButton button, ControllerIndex index)`

用户是否正在释放index对应的控制器上的 button 按键? 当且仅当释放button的帧返回True。 

!> 如果 button = ConfirmButton, 对应RhinoX头显上的侧边栏确认键，index的值会忽略。


#### IsButtonTap
`public static bool IsButtonTap(RhinoXButton button, ControllerIndex index)`

用户是否正在单击index对应的控制器上的 button 按键? 

!> 如果 button = ConfirmButton, 对应RhinoX头显上的侧边栏确认键，index的值会忽略。

> 可以在 ProjectSetting/RhinoX Setting中配置单击按键事件的触发时间阀值。
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RhinoXProjectSetting-Threshold-Time.jpg ':size=450X400')


#### IsButtonDoubleTap
`public static bool IsButtonTap(RhinoXButton button, ControllerIndex index)`

用户是否正在双击index对应的控制器上的 button 按键? 

!> 如果 button = ConfirmButton, 对应RhinoX头显上的侧边栏确认键，index的值会忽略。


#### IsButtonLongHeldDown
`public static bool IsButtonLongHeldDown(RhinoXButton button, ControllerIndex index)`

用户是否正在长按index对应的控制器上的 button 按键? 

!> 如果 button = ConfirmButton, 对应RhinoX头显上的侧边栏确认键，index的值会忽略。


#### GetTouchPadPointer
`public static bool GetTouchPadPointer (ref Vector2 TouchPadPointer, ControllerIndex index = ControllerIndex.Any)`

获取用户在控制器上的TouchPad区域的落指信息。 如果有落指信息则返回true，否则返回false。



#### GetControllerRotation
`public static Quaternion GetControllerRotation (ControllerIndex index = ControllerIndex.Any)`

获取用户控制器上的陀螺仪的旋转信息。如果Index = Any，则返回第一个已经连接的控制器上的陀螺仪的旋转信息
