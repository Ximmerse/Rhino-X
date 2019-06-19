# RXController

> Namespace: Ximmerse.RhinoX    
> public sealed class RXController : MonoBehaviour



![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RxController.jpg ':size=450X400')

RxController is paired to a physical controller identified through an unique Index. RhinoX supports up to 4 controllers.
If the application is only planning to use one controller, we recommend using the Index to Any. By doing so, RxController component will use the controller currently connected to the device.

### Public Member

#### Index

`public ControllerIndex Index { get; set; }`

RXController index. By default, Index = Any, pointing to the first connected device.
All Possible Index Values:
Controller 01, Controller 02, Controller 03, Controller 04.

#### IsControllerConnected
`public bool IsControllerConnected { get; }`

If the controller is connected to RhinoX successfully, this value will return true, otherwise false.

!> When RXController Index = Any, `IsControllerConnected` returns true if any of the controllers is connected.

#### EnableRaycasting
`public bool EnableRaycasting { get; set; }`

When this is set to true, controller can interact with Unity Event System.

!> There must be a RxEventSystem and a RxInputModule in the scene for RXController to interact with Unity Event System.


#### Raycast Origin
`public Transform RaycastOrigin { get; set; }`

Gets or sets the raycast origin transform. Ray starts from this transform's world position, pointing ahead by the forward direction of this transform. Useful for applications with their own 3D model representation of the user's hands or to change the raycast direction.

```bash
using UnityEngine;
using Ximmerse.RhinoX;

public class CustomRaycastOrigin : MonoBehaviour
{

    public Transform newOrigin;
    public RXController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller.RaycastOrigin = newOrigin;    
    }    
}
````

!> If Raycast Origin is null, RxController.transform will be used to generate ray by default.
> Set Raycaster Origin.   
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/photo/Controller-Raycaster.jpg ':size=390X264')



#### Raycast Culling Mask
`public LayerMask RaycastCullingMask { get; set; }`

RXController is on UI layer by default.


#### RaycastDistance
`public float RaycastDistance { get; set; }`

Default value is Infinity.



#### RenderRay
`public bool RenderRay { get; set; }`

Render ray or not.


#### RayRenderer
`public LineRender RayRenderer { get; set; }`

LineRenderer is used to render ray.


#### RaycastResult
`public RXRaycasterResult RaycasterResult { get; }`

RaycasterResult struct is the raycast result for current frame. Check [RaycasterResult](/ScriptingReference/RaycasterResult) for more details.


### Public Methods

#### GetRay
`public Ray GetRay()`

Get a new ray that is shooting from RxController to where the controller is pointing.

`GetRay()` Implementation:
```bash
        public Ray GetRay ()
        {
            return new Ray(RaycastOrigin.position, RaycastOrigin.forward);
        }
````

#### IsButton
`public bool IsButton(ControllerButtonCode button)`

Check if user is pressing this specific controller button in this frame. See also static method [RXInput.IsButton(ControllerButtonCode button, ControllerIndex index)](en/ScriptingReference/RXInput.md?id=IsButton)

Sample Code:

```bash
void CheckButtonPressingController ()
{
    //Is user currently pressing App button?
    GetComponent<RXController>().IsButton(ControllerButtonCode.App);
}
void CheckButtonPressingRXInput ()
{
    //By RXInput. No need to refer to RXController instance.
    RXInput.IsButton(RhinoXButton.App, ControllerIndex.Any);
}
````
> Both implementations shown above can be used to check if a button is pressed. [RXInput](/ScriptingReference/RXInput) is a more convenient option.


#### IsButtonDown
`public bool IsButtonDown(ControllerButtonCode button)`

Returns true during the frame the user starts pressing down the target button.

#### IsButtonUp
`public bool IsButton(ControllerButtonCode button)`

Returns true during the frame the user release the target button up.


#### IsTap
`public bool IsTap(ControllerButtonCode button)`

Check if any button is clicked (down and up within a set time window).

> User can config click threshold in ProjectSetting/RhinoX Settings.
> ![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RhinoXProjectSetting-Threshold-Time.jpg ':size=450X400')

#### IsDoubleTap
`public bool IsDoubleTap(ControllerButtonCode button)`

Check if a button is double clicked.
> User can config double click threshold in ProjectSetting/RhinoX Setting.

#### IsLongHoldingButton
`public bool IsLongHoldingButton(ControllerButtonCode button)`

Check if a button hold action is performed.
> User can config long hold threshold in ProjectSetting/RhinoX Setting.


#### GetTouchPadPoint
`public bool GetTouchPadPoint(out Vector2 TouchPadPointer)`

When user's finger is on Controller touchpad, this will return true. SDK will output a 2D position to help developer to locate where the finger is on physical touch pad：
Left bottom corner = [-1,-1] , Right top corner = [1, 1]

If this method returns false, it means there is no finger touching the touchpad.
