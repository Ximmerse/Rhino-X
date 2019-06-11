# RXInput 

> Namespace: Ximmerse.RhinoX     
> public static class RXInput

- RXInput is a static class that provides access to all input devices.

RhinoX currently supports controller and sidebar input access. RXInput所支持的按键类型见 [RhinoXButton](/ScriptingReference/RhinoXButton)
 

### Static Methods

#### GetConnectedControllerCount
`public static int GetConnectedControllerCount()`

> Get connected controller count.



#### GetConnectedControllerInfos
`public static XDeviceInfo[] GetConnectedControllerInfos ()`

Get a list of connected controller info.


#### GetPairedControllerCount
`public static int GetPairedControllerCount()`

Get paired controller count.

!> Paired controller includes the controllers that has been previously paried, even if they are not connected.


#### GetPairedControllerInfos
`public static XDeviceInfo[] GetPairedControllerInfos ()`

Get paired controller info list.
!> Paired controller list includes the controllers that has been previously paried, even if they are not connected.


#### IsButtonDown
`public static bool IsButtonDown(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index is pressed. 

!> If button = ConfirmButton, then the confirm button located on the RhinoX is  Down. In this case, index value will be ignored.


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

Check if a button of a controller that is associated to the index is held down.

!> If button = ConfirmButton, then the confirm button located on the RhinoX is  held down. In this case, index value will be ignored.


#### IsButtonUp
`public static bool IsButtonUp(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index is released.

!> If button = ConfirmButton, then the confirm button located on the RhinoX is  released. In this case, index value will be ignored.


#### IsButtonTap
`public static bool IsButtonTap(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index is clicked.

!> If button = ConfirmButton, then the confirm button located on the RhinoX is  clicked. In this case, index value will be ignored.


> Click time threshold can be configurated in ProjectSetting/RhinoX Setting.
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RhinoXProjectSetting-Threshold-Time.jpg ':size=450X400')


#### IsButtonDoubleTap
`public static bool IsButtonTap(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index is double clicked.

!> If button = ConfirmButton, then the confirm button located on the RhinoX is  double clicked. In this case, index value will be ignored.


#### IsButtonLongHeldDown
`public static bool IsButtonLongHeldDown(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index is being long held.

!> If button = ConfirmButton, then the confirm button located on the RhinoX is  being long held. In this case, index value will be ignored.


#### GetTouchPadPointer
`public static bool GetTouchPadPointer (ref Vector2 TouchPadPointer, ControllerIndex index = ControllerIndex.Any)`

Get user finger touch location on touch pad. Returns to true if there is a finger touch. Returns false if there is no finger touch detected on touch pad.


#### GetControllerRotation
`public static Quaternion GetControllerRotation (ControllerIndex index = ControllerIndex.Any)`

Get controller orientation with a Index. If Index = Any，this method will return the first connected device.