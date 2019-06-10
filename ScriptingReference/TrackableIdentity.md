# Trackable Identity

> 命名空间: Ximmerse.RhinoX     
> public sealed class TrackableIdentity : MonoBehaviour
    
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/TrackableIdentity.png ':size=450X400')

Trackable identity 组件通过 Trackable ID指向一个可追踪物体。
- 设置 Trackable identity 的 ID 属性，来定义此组件指向的物体。
- Trackable identity 的ID属性可在运行时被程序修改。
- 当物体被追踪/丢失追踪的时候，触发相应的事件。

### 公共成员

#### TrackableID
- `public int TrackableID { get; set; };`

此属性用于设置追踪对象的ID。

内置ID:

 Beacon 01 = 65;
 
 Beacon 02 = 66;
 
 Beacon 03 = 67;
 
 主控制器 = 81;
 
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/TrackableIdentity-Target-Dropdown.jpg ':size=450X400')

> 关于Custom ID : 除了标准的Beacons和Controller， RhinoX 还支持 Cube， Touch平板，Table 等物体跟踪。当使用到这些附加物体时， 就需要设置 Custom ID。
关于如何获取这些附加追踪物，请联系[Ximmerse Support](https://www.ximmerse.com/contact)

#### ActivateGameObject
- `public bool ActivateGameObject { get; set; } `

在建立跟踪/丢失跟踪的时候，设置此GameObject的激活状态。


#### IsVisible
- `public bool IsVisible { get; }`

此属性指示当前对象是否正在被跟踪。也可以通过[ObjectTracking](/ScriptingReference/ObjectTracking)的接口获取物体被跟踪的详细信息。

#### OnVisibilityChange
- `public VisiblityChangeEvent OnVisibilityChange;`

物体开始被跟踪/丢失跟踪的帧会触发此事件。

```bash
    void Start()
    {
        GetComponent<TrackableIdentity>().OnVisibilityChange.AddListener(OnTrackingStatusChange);
    }

    void OnTrackingStatusChange(bool tracked)
    {
        Debug.LogFormat("ID : {0} tracked: {1}", GetComponent<TrackableIdentity>().TrackableID, tracked);
    }
```

#### VerboseLog
- `public bool VerboseLog { get; set; } `

如果打开此开关，则会逐帧打印详细的追踪log。 开发者需要使用 ADB 的 Logcat 工具获取。

