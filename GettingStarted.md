## 创建 Hello RhinoX 场景

本章节将指导您，一步一步的创建第一个可运行于RhinoX 中的AR全息场景

- 新建一个场景，命名为 Hello RhinoX 。 删除场景中的 MainCamera 对象。
- 右键弹出菜单添加 ARCamera, 在这个教程中，我们将 ARCamera 放置于 [0,0,1.7] 这个位置上。具体的位置可以根据开发者需求而定。
- 在场景中创建尽可能多的几何体如 Cube， Sphere， 以充实空间感。

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Create-GameObject-Shortcut.png ':size=450X400')

!> AR Camera 的层级是：
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/ARCameraRig.png) 请保持这个层级。 当需要重新摆放Camera的起点位置的时候，应该移动ARCameraRig对象，并将 AR Camera 保持在本地坐标空间的原点。


## 编译场景

!> 将应用场景在打包成Android APK。编译之前，用户需要先[初始化](/Install-SDK?id=初始化)。然后正常编译APK即可。编译具体操作可以参考Unity[官方文档](https://docs.unity3d.com/Manual/android-BuildProcess.html)。


### 安装 APK ， 并通过Launcher启动
如果开发者不熟悉APK安装过程，可以参考[Unity的官方Android开发文档](https://docs.unity3d.com/Manual/android-BuildProcess.html)。


戴上你的 RhinoX，体验在AR空间中自由移动的感觉。




 

