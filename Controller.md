## 使用控制器 

本教程将介绍：

1. 引入和跟踪控制器对象。

2. 使用控制器事件API，与 Unity UI 系统交互。

控制器具有以下特性:

- 无需加载标定文件。 控制器通过蓝牙配对后， 系统根据 控制器的SN编号，自动索引控制器标定文件。

- 支持 Trigger , TouchPad, App, Home 四个按键， 和触摸盘位置信息。




# Controller UI 场景

1. 打开 Assets/Demo/Scenes/Controller UI.unity 场景。这个简单的场景有以下对象:

- ARCamera

- Canvas - 一个标准的 UI canvas。 

## RxController 组件

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Controller-Unity.png ':size=450X400')

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxControllerInspector.png ':size=450X400')

         
```bash
//RxController 是控制器的事件接口。 通过如下代码可以访问控制的事件API: 
//更详细的接口说明， 请参见API文档部分. 

    RXController controller = GetComponent<RXController>();
    bool isTappingAppButton = controller.IsButton(ControllerButtonCode.App);
            
```

> RxController 的 Enable Raycasting 属性如果打开，则 Controller 会发射一条和可以通过 Unity Event System 和其它GameObject对象交互射线。

> 其中 Line Renderer 属性为射线的渲染器。

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxControllerInspector.png ':size=450X400')




## RxEventSystem 组件.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/RxEventSystem-Inspector.png ':size=450X400')

> RxEventSystem 是 Controller 系统事件驱动的核心组件，场景中必须存在此组件，事件机制才会工作。

> 开发者可以配置 RxInputModule上的 Pointer Button，定义与Unity UI系统交互的按键。

!> RxEventSystem 事件继承于 UnityEngine.EventSystem 对象，与Unity自带的EventSystem对象冲突， 所以请删除unity自动创建的EventSystem对象(SDK程序会在运行时自动删除)


## 关于 RxController 的 Raycasting 机制

> Raycast Origin 定义射线的起点和方向。 
> 设置 Raycast Culling Mask 和 Raycast Distance 以射线发射器的交互对象层级和射线的长度。
> Ray Renderer指向一个 LineRenderer ， 负责渲染射线。 此字段可以设置为空值，设置为空则不渲染射线。

```bash
//你可以通过以下方式， 获取射线的信息， 从而实现自定义渲染的射线： 

Ray controllerRay = GetComponent<RXController>().GetRay();
//TODO : render the ray by your code
            
```


!> RXController的 raycasting 基于物理系统，也就是说，要求可交互的GameObject上，必须有 Collider 并且层级处于 RxRaycaster.CullingMask层级内才能与控制器实现交互。
!> 关于Collider的设置， 可以参考 Controller UI场景中的UI组件上的BoxCollider设置。


- 我们已经知道了 Controller 的基本使用方式。 接下来请编译并安装 Controller UI 场景，体验使用 Controller 在AR场景中的交互方式吧 ！