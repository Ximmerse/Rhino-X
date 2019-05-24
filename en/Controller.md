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
    controller.OnTap.AddListener((ControllerButtonCode btn) => {
        Debug.LogFormat("On controller tap : {0}", btn);
    });
            
```

> RxController Raycasts against UI elements.



![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxControllerInspector.png ':size=450X400')




## RxEventSystem Component

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxEventSystem-Inspector.png ':size=450X400')

> RxEventSystem is RxController's event system driver. There must be one instance in the scene to have the system work properly.

> Developers can config RxInputModule Pointer Button to define which physical to use to interact with Unity UI.

!> RxEventSystem inherits from UnityEngine.EventSystem，so please delete Unity auto-created EventSystem object/component. (SDK does this automatically)


## RxRaycast Component

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxRaycaster-Inspector.png ':size=450X400')

> RxRaycast compoennet defines raycast origin and direction. It works with Unity  built-in event system.
> Config EventMask and Raycast Distance to define raycast layers and raycast distance.

```bash
//The following sample shows how RxController works with Unity event system.

public class EventListenerDemo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogFormat(this, "Click : {0}", name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.LogFormat(this, "Down : {0}", name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.LogFormat(this, "Enter : {0}", name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.LogFormat(this, "Exit : {0}", name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.LogFormat(this, "Up : {0}", name);
    }
}
            
```


!> RxRaycaster is based on physics raycast, so there must be a Collider component attached on the Gameobject. Additionaly, the gameobject must be on the layer that is included in EventMask.

!> For configuration of Collider, you can use BoxCollider configuration in Controller UI scene as an example.

- Now that we have finished basic RxController usaged, the project is ready to be deployed and tested on the device.