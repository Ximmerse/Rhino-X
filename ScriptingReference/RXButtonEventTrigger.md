# RXButtonEventTrigger 

> 命名空间: Ximmerse.RhinoX     
> public sealed class RXButtonEventTrigger : MonoBehaviour

接受 RhinoX 按键事件并且调用注册事件调用的工具类。

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RxButtonEventTrigger.png ':size=450X400')

不同于RXInput，RXController被设计为API接口类的设计初衷， RXButtonEventTrigger提供给开发者一个便捷的，可配置的，基于Unity Editor UI的事件注册及调用类。

> 当 RXButtonEventTrigger 与 RXController放在同一个GameObject上时，可以注册基于控制器按键的事件:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RxButtonEventTrigger-AddControllerEvents.jpg ':size=450X400')



> 当 RXButtonEventTrigger 不与 RXController 并存在一个GameObject上时，可以注册基于侧边栏确认键的事件:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RxButtonEventTrigger-AddSideButtonEvents.jpg ':size=450X400')    

> 侧边栏确认键
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/photo/RxSideBarConfirmButton.jpg ':size=300X400')


### 公共方法

#### RegisterRxButtonEvent
`public void RegisterEvent (EventTriggerType eventTriggerType, UnityEngine.Events.UnityAction<RhinoXButton> buttonEvent)`

注册一个RxButton事件。

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

注销RxButton事件。
