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

>! 地面组件在场景中