## Ground Plane 组件

在 RhoniX SDK 启动以后， AR Camera 会实时的反映出用户头部所在的位置和姿态。但是有时候，这并不够。

!> 开发者往往需要获取“地面”所在的平面，把头部的位置姿态归中到以地面点为中心的坐标系上。

在本章教程中，我们将介绍 GroundPlane 组件是如何定义地面的。


- 打开 Assets/Demo/Scenes/DeerIsland 场景。

- 选中 GroundPlane 对象。

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/GroundPlane-Inspector.png ':size=450X400')

> 在本示例中，我们使用 1号beacon 去定义地面的所在平面。

> GroundPlane 参数中， Tilt Euler用于吧 Marker 的轴旋转90度以定Y轴向上，以此构建一个向上的坐标系。
> Min 和 Max Tracked Distance 定义当GroundPlane 可以定位的时候的最佳跟踪距离范围，这个数值取决于实际追踪物体的尺寸。

> Min head error distance 和 Head diff angle 定义需要矫正的头部位置和角度容差值。 当距离和角度偏差在此误差范围内， 则GroundPlane 不会矫正头部的位置和姿态。

> DebugView 则用于打开Debug 实时视图，方面开发者了解GroundPlane 的跟踪信息。

- 编译并运行此场景，观察 GroundPlane 是怎样矫正头部相对于世界原点的位置和朝向。

>! GroundPlane 组件会矫正用户的头部旋转的Yaw （Y轴旋转角度）， 不会改变 Pitch（X轴旋转角度） 和 Roll （Z轴旋转角度）


### GroundPlane 工作原理

当 RhinoX 的追踪系统跟踪到一个物体时候， 可以获取到物体相对于用户的头部位置和旋转。GroundPlane组件将这个相对关系做了逆向转换计算，计算出头部相对于物体的相对位置和相对旋转，这样就可以主动改变头部的世界位置和世界旋转， 以令用户头部的位置和朝向与被追踪物体的位置和朝向对齐。

When the tracking system finds the marker associated to the Trackable Identity of the anchor object, the GroundPlane component will use this Transform to move (i.e. recenter) the user's head Transform relative to the anchor object.

!> GroundPlane 组件与 DynamicTarget 组件是对立的两种工作原理， DynamicTarget 以用户头部为中心，更新组件自身transform 的位置和朝向。
GroundPlane则是以自身为中心，更新用户头部的位置和朝向。
