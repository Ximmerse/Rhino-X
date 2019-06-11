# RXController

> Namespace: Ximmerse.RhinoX    
> public sealed class RXController : MonoBehaviour



![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RxController.jpg ':size=450X400')

> RxController is paired to a physical controller through Index. RhinoX supports update to 4 controllers.
If developer is only planning to use one controller, please change the Index to Any. By doing so, RxController component will point to currently connected device.


### Public Member

#### Index

`public ControllerIndex Index { get; set; }`

RXController index. By default, Index = Any, pointing to the first connected device.
All Possible Index Values:
Controller 01, Controller 02, Controller 03, Controller 04.

#### IsControllerConnected 
`public bool IsControllerConnected { get; }`

If the controller is connected to RhinoX successfully, this value will return true, otherwise false.

!> When RXController Index = Any, `IsControllerConnected` returns to true if any of the controllers is connected.

#### EnableRaycasting
`public bool EnableRaycasting { get; set; }`

Controller是否支持通过射线与Unity Event System交互。 

!> 场景内必须有激活状态的 RxEventSystem 和 RxInputModule, RXController才能通过Unity Event System与对象交互。


#### Raycast Origin
`public Transform RaycastOrigin { get; set; }`

RXController 控制器射线的锚点。 定义射线的起点和方向。起点为RaycastOrigin的Posiiton, 方向为RaycastOrigin的Forward方向。

以下代码为 Raycast Origin 的内部实现:
```bash
        /// <summary>
        /// Gets or sets the raycast origin transform.
        /// The origin transform for raycasting. Ray starts from this transform's world position, pointing ahead by the forward direction of this transform.
        /// </summary>
        /// <value>The raycast origin.</value>
        public Transform RaycastOrigin
        {
            get 
            { 
                return m_RaycastOrigin; 
            }
            set
            {
                m_RaycastOrigin = value;
            }
        }
````

!> 如果 Raycast Origin 属性为null值，则RXController.transform会做为默认的射线发射起点。
> 设置Raycaster Origin属性，设置射线的起点和方向。   
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/photo/Controller-Raycaster.jpg ':size=390X264')



#### Raycast Culling Mask
`public LayerMask RaycastCullingMask { get; set; }`

RXController射线发射器的交互对象层级。默认值只与UI对象交互。


#### RaycastDistance
`public float RaycastDistance { get; set; }`

射线发射器发射射线的长度。默认值 : Infinity



#### RenderRay
`public bool RenderRay { get; set; }`

控制渲染射线的开关值。


#### RayRenderer
`public LineRender RayRenderer { get; set; }`

渲染RXController的交互射线所使用的 LineRenderer。


#### raycastResult
`public RXRaycasterResult RaycasterResult { get; }`

RaycasterResult 结构体返回的是当前帧内的射线检测结果。详细参数见 [RaycasterResult](/ScriptingReference/RaycasterResult)

此属性再配合 `GetRay()`方法，开发者可以自定义射线渲染流程。


### 公共方法

#### GetRay
`public Ray GetRay()` 

获取指示当前RXController瞄准方向的射线。

以下代码为 `GetRay()` 方法的内部实现:
```bash
        
        public Ray GetRay ()
        {
            return new Ray(RaycastOrigin.position, RaycastOrigin.forward);
        }
````


#### IsButton
`public bool IsButton(ControllerButtonCode button)`

如果当前帧内，用户正在按着button按键， 返回True，否则返回False。

代码举例:

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
> 上述两种方法是相同的。
当开发者需要通过编程接口获取Controller按钮事件的时候， 使用 [RXInput](/ScriptingReference/RXInput) 类是一个更方便的选择。


#### IsButtonDown
`public bool IsButtonDown(ControllerButtonCode button)`

当且仅当用户正在按下button按键的帧内， 返回True，否则返回False。 

#### IsButtonUp
`public bool IsButton(ControllerButtonCode button)`

当且仅当用户松开button按键的帧内， 返回True，否则返回False。 


#### IsTap
`public bool IsTap(ControllerButtonCode button)`

当用户单击button的时候，返回True，否则返回False。 

> 可在 ProjectSetting/RhinoX Setting中配置单击按键事件的触发时间阀值。
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/RhinoXProjectSetting-Threshold-Time.jpg ':size=450X400')

#### IsDoubleTap
`public bool IsDoubleTap(ControllerButtonCode button)`

当用户双击button的时候，返回True，否则返回False。 

> 在 ProjectSetting/RhinoX Setting中配置双击按键事件的触发时间阀值。


#### IsLongHoldingButton
`public bool IsLongHoldingButton(ControllerButtonCode button)`

当用户长按button的时候，返回True，否则返回False。 

> 在 ProjectSetting/RhinoX Setting中配置长按按键事件的触发时间阀值。


#### GetTouchPadPoint
`public bool GetTouchPadPoint(out Vector2 TouchPadPointer)`

当用户落指于Controller的touchpad 感应区内， 输出手指落点的坐标： 
左下角 = [-1,-1] , 右上角 = [1, 1]

如果没有落指，返回 False。