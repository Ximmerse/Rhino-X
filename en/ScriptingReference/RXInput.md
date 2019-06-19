# RXInput

> Namespace: Ximmerse.RhinoX     
> public static class RXInput

- RXInput is a static class that provides access to all input devices.

RhinoX currently supports controller and HMD side button input access. RXInput supported inputs can be found at [RhinoXButton](en/ScriptingReference/RhinoXButton.md)


### Static Methods

#### GetConnectedControllerCount
`public static int GetConnectedControllerCount()`

Get connected controller count.



#### GetConnectedControllerInfos
`public static XDeviceInfo[] GetConnectedControllerInfos ()`

Get a list of connected controller info.


#### GetPairedControllerCount
`public static int GetPairedControllerCount()`

Get paired controller count.

!> Paired controller includes the controllers that has been previously paired, even if they are not connected.


#### GetPairedControllerInfos
`public static XDeviceInfo[] GetPairedControllerInfos ()`

Get paired controller info list.

!> Paired controller list includes the controllers that has been previously paired, even if they are not connected.

#### IsButtonDown
`public static bool IsButtonDown(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index was first pressed this frame.

!> if button = ConfirmButton, this method will return the state of the button located on the side of the RhinoX device.  In this case, index value will be ignored.


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

Check if a button of a controller that is associated to the index is currently held down.

!> if button = ConfirmButton, this method will return the state of the button located on the side of the RhinoX device. In this case, index value will be ignored.


#### IsButtonUp
`public static bool IsButtonUp(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index was released this frame.

!> if button = ConfirmButton, this method will return the state of the button located on the side of the RhinoX device. In this case, index value will be ignored.

#### IsButtonTap
`public static bool IsButtonTap(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index was clicked.

!> if button = ConfirmButton, this method will return the state of the button located on the side of the RhinoX device. In this case, index value will be ignored.


> Click time threshold can be configurated in ProjectSetting/RhinoX Setting.
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RhinoXProjectSetting-Threshold-Time.jpg ':size=450X400')


#### IsButtonDoubleTap
`public static bool IsButtonTap(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index was double clicked.

!> if button = ConfirmButton, this method will return the state of the button located on the side of the RhinoX device. In this case, index value will be ignored.


#### IsButtonLongHeldDown
`public static bool IsButtonLongHeldDown(RhinoXButton button, ControllerIndex index)`

Check if a button of a controller that is associated to the index is being held.

!> if button = ConfirmButton, this method will return the state of the button located on the side of the RhinoX device. In this case, index value will be ignored.


#### GetTouchPadPointer
`public static bool GetTouchPadPointer (ref Vector2 TouchPadPointer, ControllerIndex index = ControllerIndex.Any)`

Get user finger touch location on touch pad. Returns to true if there is a finger touch. Returns false if there is no finger touch detected on touch pad.

Left bottom corner = [-1,-1] , Right top corner = [1, 1]

#### GetControllerRotation
`public static Quaternion GetControllerRotation (ControllerIndex index = ControllerIndex.Any)`

Get controller orientation associated to the Index. If Index = Any，this method will return the first connected device.
