## 物体追踪 (ObjectTracking)

本教程将介绍，如何针对特定的物体实现实时跟踪。

- 创建一个空的场景，命名 Beacon-Tracking 。 删除场景中的 MainCamera 对象。

我们先以随箱附件中的小圆盘为例，这个小圆盘我们一般称为 Beacon， 也就是“路标”的意思。
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/IMG_BEACON_01.JPG ':size=450X400')

!> Beacon 上的 “1" 代表1号beacon，打开 Plugins/Android/assets/BEACON-500.json 文件:

```bash


BEACON-500.json 是Beacon 的标定文件，定义了跟踪Beacon所需要的数据。
本教程将分步骤，指导开发者如何使用这些标定文件。
BEACON-500.json 文件内容:

{
    "CARD_SINGLE":
    {
        "CalibFile": "BEACON-500.dat", // Beacon 的标定数据文件
        "Markers": [65,66,67],  //65, 66, 67 分别对应 1号，2号，3号 beacon 在Unity场景中的ID。
        "MarkersSize": [0.15,0.15,0.15] //Beacon 的实物尺寸，单位是米。
    }
}
```

- 在Project上右键弹出菜单， 创建一个 ObjectTrackingProfile:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Create-Tracking-Profile.png)

- 勾选 "Track Beacons" 选项。

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Assign-Beacon-JSON.png)

!> TrackingProfile是一个数据库，存储需要跟踪的对象的标定数据。

- 接下来， 创建 ARCamera， 将刚才创建的 TrackingProfile 对象拖入到 ARCamera 的 Tracking Profile 属性。

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/AssignTrackingProfile.png ':size=450X400')

!> ARCamera 组件会在启动的时候， 把 TrackingProfile 所持有的标定数据发送给底层硬件接口。底层硬件则会根据这些数据去扫描和追踪物体。 

- 最后一步，创建 Dynamic Target 对象. 把 Trackable Identity 的 Target 值设置为 'Beacon 01'.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Create-GameObject-Shortcut.png ':size=450X400')

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/SetTrackableIdentity.png ':size=450X400')

!> 如果要跟踪2号和3号Beacon, 只需要将 Target 设置为 'Beacon 02', 'Beacon 03'.

- 保存Beacon-Tracking场景，编译并运行。

戴上你的 RhinoX，观察 Beacon 被追踪到的视图。

