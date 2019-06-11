# RXButtonEventTrigger 

> Namespace: Ximmerse.RhinoX     
> public sealed class RXButtonEventTrigger : MonoBehaviour

Accepts RhinoX button events and sends event message to desired objects.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RxButtonEventTrigger.png ':size=450X400')

Different from RXInput，RXController is designed to be used directly by developers through its API. RXButtonEventTrigger privides developers a quick, customizable event system that is built on Unity event system.

> When RXButtonEventTrigger and RXController are placed on the same GameObject, developers can have a lot of controls over button actions:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RxButtonEventTrigger-AddControllerEvents.jpg ':size=450X400')



> When RXButtonEventTrigger and RXController are not on the same GameObject, event is triggered by App Button by default:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RxButtonEventTrigger-AddSideButtonEvents.jpg ':size=450X400')    

> RhinoX HMD Side Button (Confirm Button)
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/photo/RxSideBarConfirmButton.jpg ':size=300X400')



### Public Methods

#### RegisterRxButtonEvent
`public void RegisterEvent (EventTriggerType eventTriggerType, UnityEngine.Events.UnityAction<RhinoXButton> buttonEvent)`

Register a RxButton event.

```bash
    private void RegisterRxButtonEvent()
    {
        var eventTrigger = GetComponent<RXButtonEventTrigger>();
        eventTrigger.RegisterEvent(EventTriggerType.OnClickConfirmButton, (RhinoXButton button) => {
            Debug.Log("Player is clicking on confirm button !");
        });
    }
```



#### UnregisterEvent
`public void UnregisterEvent (EventTriggerType eventTriggerType, UnityEngine.Events.UnityAction<RhinoXButton> buttonEvent)`

Unregister a RxButton event.
