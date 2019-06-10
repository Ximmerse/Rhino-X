# Dynamic Target

> 命名空间: Ximmerse.RhinoX      
> public sealed class DynamicTarget : TrackableBehaviour

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/DynamicTarget.png ':size=350X300')

Dynamic Target 用于实时更新一个追踪物体相对于用户头部的位置和朝向。

- 当 Trackable Identity 指向一个 Beacon 的时候，Dynamic Target的轴向如下图所示:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/photo/Beacon-Axis.jpg ':size=400X350')

- 当 Trackable Identity 指向一个 Controller 的时候，Dynamic Target的轴向如下图所示:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/photo/Controller-Axis.jpg ':size=400X350')

!> 当勾选了 YawOnly 后， Dynamic Target的朝向中，只有Y轴的旋转值会被更新。 此功能可被用于渲染一些不需要Pitch （X轴） 和 Roll （Z轴） 旋转的沙盘模型。

### 公共成员

#### YawOnly
- `public bool YawOnly { get; set; };`

如果为 False， 则对象的Rotation中的三个轴都会被实时更新， 否则， 只有Y轴的转动会更新。
