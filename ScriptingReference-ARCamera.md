# ARCamera

> 命名空间: Ximmerse.RhinoX

在虚拟世界中， ARCamera 代表用户的头部节点。ARCamera在SDK中的功能包括:
- 如果开启了TrackingRotation开关, 逐帧更新头部的朝向。
- 如果开启了TrackingPosition开关，逐帧更新头部的位置。
- 驱动 Tag Tracking 模组，扫描真实环境中的可追踪物体。
- 双目渲染虚拟世界。
- 渲染准星 (Rectile)，并提供侧边栏确认键的事件接口， 以让用户方便的通过头部瞄准的方式，与Unity的可交互对象（例如 uGUI Button, Toggle）交互。


### 公共属性
- `TrackPosition` bool - 读/写  默认值：`true`

控制是否实时跟踪用户头部位置的开关属性


- `TrackRotation` bool - 读/写  默认值：`true`

控制是否实时跟踪用户头部朝向的开关属性


- `RenderReticle` bool - 读/写  默认值：`true`

控制是否实时渲染准星


- `ReticleImage` Texture2D - 读/写  默认值：内置准星图标

准星的图标， 支持实时变化。


- `InteractMask` LayerMask - 读/写  默认值：UI

在渲染准星的情况下， 准星交互对象的层级。 准星会对层级内的交互对象发出unity event system事件， 常见的事件有 ：IPointerEnter， IPointerExit， IPointerClick

- `DebugView` bool - 读/写 默认值：`true`

控制是否显示头部实时坐标和朝向的 Debug 模式开关。

- `TrackingProfile` ObjectTrackingProfile - 读/写 默认值：`null`

如果为非空， 则会将所持有的追踪数据传递给追踪模组。

- `InterPupilDistance` float - 读/写 默认值：`0.062`

双目间距，默认值为人类双目间距平均值也就是62mm ， 开发者可以自定义此数值。


### 公共方法


- `RecenterTracking()` 

对ARCamera 做归中操作，调用后， ARCamera 的transform 的local position 和 local rotation 都会归零。