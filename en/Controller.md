## RxController

Topics：

1. How to use RxController programmatically.

2. RxController related API and Unity UI interactions.

RxController has the following characteristics:

- No need to config tracking profile. When paired through bluetooth, the system will automatically config the tracking profile.

- Supports Trigger, TouchPad, App, Home button.




# Controller UI Scene

1. Open Assets/Demo/Scenes/Controller UI.unity. There are 2 objects in the scene:

- ARCamera

- Canvas - a Unity UI canvas。

## RxController Component

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Controller-Unity.png ':size=450X400')
> Developers can use the included controller model in their own applications

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxControllerInspector.png ':size=450X400')

The RxController Unity component allows for developers to handle the RhinoX controllers as they would any other input device, with familiar methods like IsButton, IsButtonDown, etc.

```bash
//RxController class can be used to access RxController APIs.
//Please check SDK documentation for more details.

    RXController controller = GetComponent<RXController>();
    bool isTappingAppButton = controller.IsButton(ControllerButtonCode.App);

```

RxController Raycasts against UI elements when EnableRaycasting is enabled.

Line Renderer is used to render the Ray used for testing against UI elements.

!> Note: If no Line Renderer is assigned, then nothing will be rendered.

## RxEventSystem Component
RxEventSystem is RxController's event system driver.  There must be one instance in the scene to have the system work properly.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxEventSystem-Inspector.png ':size=450X400')

> Developers can configure RxInputModule Pointer Button to define which physical button to use by default for Unity UI interactions

!> RxEventSystem inherits from UnityEngine.EventSystem，so please make sure to delete Unity any other EventSystem object/component. (SDK does this automatically)


## RxController and Raycasting
RXController raycasting is based on physics raycast , meaning it requires Collider component to work. RxRaycaster.CullingMask must be also configurated to interact with GameObjects on a specific layer.

Raycasting origin, culling mask and distance can all be defined directly in the RxController inspector.

> Ray Renderer is a pointer to a LineRenderer component, taking care of line rendering.
Note: If this field is empty, then nothing will be rendered.

Developers can choose to use their own visualization to suit their pointer needs, or manipulate it directly by accessing the Ray object used by the controller
```bash
// Developers can get ray cast info through the following API call：

Ray controllerRay = GetComponent<RXController>().GetRay();
//TODO : render the ray by your code
```

!> For Collider configuration, please use BoxCollider on UIs. For sample configurations, see the UI scene.
