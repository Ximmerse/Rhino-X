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

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxControllerInspector.png ':size=450X400')

         
```bash
//RxController class can be used to access RxController APIs.
//Please check SDK documentation for more details. 

    RXController controller = GetComponent<RXController>();
    bool isTappingAppButton = controller.IsButton(ControllerButtonCode.App);
            
```

> RxController Raycasts against UI elements when EnableRaycasting is enabled. 

> Line Renderer is used to render the rays.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxControllerInspector.png ':size=450X400')




## RxEventSystem Component

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxEventSystem-Inspector.png ':size=450X400')

> RxEventSystem is RxController's event system driver. There must be one instance in the scene to have the system work properly.

> Developers can config RxInputModule Pointer Button to define which physical to use to interact with Unity UI.

!> RxEventSystem inherits from UnityEngine.EventSystem，so please delete Unity auto-created EventSystem object/component. (SDK does this automatically)


## RxController and Raycasting 

> Raycasting origin can be defined under RxController inspector.
> Raycast Culling Mask and Raycast Distance can be configurated under RxController Inspector.
> Ray Renderer is a pointer to a LineRenderer component, taking care of line rendering. Note: If this field is empty, then nothing will be rendered.

```bash
// Developers can get ray cast info through the following API call： 

Ray controllerRay = GetComponent<RXController>().GetRay();
//TODO : render the ray by your code

```


!> RXController raycasting is based on physics raycast , meaning it requires Collider component to work. RxRaycaster.CullingMask must be also configurated to interact with GameObjects on a specific layer.
!> For Collider configuration, please use BoxCollider on UIs in Controller UI scene as a sample configuration.


