# ARCamera

> 命名空间: Ximmerse.RhinoX

public sealed class ARCamera : MonoBehaviour

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/ARCamera.png ':size=450X400')

ARCamera 代表用户头部在虚拟世界中的节点对象。ARCamera在SDK中的功能包括:
- 跟踪用户头部运动。
- 驱动 Tag Tracking 模组，扫描真实环境中的可追踪物体。
- 双目渲染虚拟世界。
- 渲染准星 (Rectile)，并提供侧边栏确认键的事件接口， 以让用户方便的通过头部瞄准的方式，与Unity的可交互对象（例如 uGUI Button, Toggle）交互。

!> ARCamera 必须在场景中唯一， 是一个单例对象，可通过 ARCamera.Instance 获取单例引用。

### 公共成员

#### TrackPosition
- `public bool TrackPosition { get; set; };// Default : true`

ARCamera 实时更新用户头部的位置。


#### TrackRotation
- `public bool TrackRotation { get; set; }; // Default : true`

ARCamera 实时更新用户头部的朝向。




#### IsObjectTrackingEnabled
- `public bool IsObjectTrackingEnabled { get; } `

如果为true， 则代表 Object Tracking Engine 已成功启动了。 只有当 `IsObjectTrackingEnabled == True` 以后，`SetObjecTrackingProfile()`方法才能正常工作。

```bash
//Example code: how to loads a new tracking profile:
IEnumerator ChangeTrackingProfile ()
{
   while(ARCamera.Instance.IsObjectTrackingEnabled == false)
   {
      yield return null;//wait for object tracking enabled.
   }
   ARCamera.Instance.SetObjecTrackingProfile(newProfile: Resources.Load<ObjectTrackingProfile>("Cube+Beacons"));//loads new profile
}
```


#### EnableReticle
- `public bool EnableReticle { get; set; } ; // Default : true`

在双目中心点渲染出一个小圆点，用以指示用户当前注视方向的正前方。而 `Reticle射线` 则是从这个点沿着正前方射出的一条射线发射器， 它可以与其它 GameObject 对象交互。
`EnableReticle`属性控制是否渲染Reticle准星贴图，并且激活 `Reticle射线发射器`。

!> <b>只有当 RenderRectile = true， 并且场景中存在激活状态的 `RxEventSystem` 和 `RxInputModule` 对象， Reticle射线才能与InteractMask层级内的物体交互。</b>


#### ReticleImage
- `public Texture2D ReticleImage { get; set; } // See : RhinoXGlobalSetting.DefaultRectileImage`

Reticle准星图标， 可在运行时被修改为其它贴图。
如果`ReticleImage`为空，则准星不会被渲染， 但是射线发射器依然可以与GameObject交互。

```bash
    void ChangeReticleTexture()
    {
        ARCamera arCamera = ARCamera.Instance;
        arCamera.ReticleImage = Resources.Load<Texture2D>("MyReticle");
    }
```

#### ReticleInteractMask
- `public LayerMask ReticleInteractMask { get; set; } // Default : see : 1 << 5 (UI mask)`

在双目准星射线被激活的情况下， 设置准星交互对象的层级。 用户可通过双目中心准星射线与此层级内的对象通过 unity event system 事件工作， 常见的事件有 ：IPointerEnter， IPointerExit， IPointerClick

```bash
    void ChangeReticleTexture()
    {
        ARCamera arCamera = ARCamera.Instance;
        arCamera.InteractMask = LayerMask.GetMask("Default", "UI");
    }
```

#### TrackingProfile
- public ObjectTrackingProfile TrackingProfile { get; } // Default : null

获取当前正在使用的Tracking Profile。 可在ARCamera的Inspector界面上配置。 要在运行时更改 Tracking Profile， 参见方法 `SetObjecTrackingProfile()`


#### InterPupilDistance
- `public float InterPupilDistance { get; set; } // Default : 0.062`

双目间距，默认值为人类双目间距平均值也就是62mm ， 开发者可以自定义此数值。

```bash
    void ChangeIPD()
    {
        ARCamera arCamera = ARCamera.Instance;
        arCamera.InterPupilDistance = 0.060f;//change IPD to 60mm (default 62mm)
    }
```

### 公共方法


#### GetReticleRay()
- `public Ray GetReticleRay();`

获取一条射线，代表当前 Reticle 射线发生器的起点和方向。

```bash
    void GetGazeAt()
    {
        Ray ray = ARCamera.Instance.GetReticleRay();
        RaycastHit hitInfo;
        if(Physics.Raycast (ray, out hitInfo))
        {
            Debug.LogFormat("Gaze at : {0}", hitInfo.collider.name);
        }
    }
```

#### SetObjecTrackingProfile
- `public bool SetObjecTrackingProfile(ObjectTrackingProfile newProfile);`

在运行时重新载入一个 Tracking Profile,之前载入的Tracking Profile 就会被卸载。

```bash
//Example code: how to loads a new tracking profile:
IEnumerator ChangeTrackingProfile ()
{
   while(ARCamera.Instance.IsObjectTrackingEnabled == false)
   {
      yield return null;//wait for object tracking enabled.
   }
   ARCamera.Instance.SetObjecTrackingProfile(newProfile: Resources.Load<ObjectTrackingProfile>("Cube+Beacons"));//loads new profile
}
```

!> <b>载入 tracking profile 是一个异步操作，需要间隔一帧才能看见跟踪结果的改变。</b>

#### RecenterTracking()
- `public void RecenterTracking();`

对ARCamera 做归中操作，调用后， ARCamera 的transform 的local position 和 local rotation 都会归零。



### 静态成员

#### Instance
- `public static ARCamera Instance { get; }`

ARCamera 的静态单例引用。

```bash
    void Update()
    {
        //Print head trcked position and rotation per frame:
        ARCamera arCamera = ARCamera.Instance;
        Debug.LogFormat("Head position:{0}, rotation:{1}", arCamera.transform.localPosition, arCamera.transform.localEulerAngles);
    }
```


#### OnCreateStereoCameras
- `public static event System.Action<Camera LeftEye, Camera RightEye>` 

静态事件，在创建左右眼之后触发此静态事件。 开发者可以监听此事件来处理一些和左右眼相关的行为，例如添加后期处理。

```bash
    void Start()
    {
        ARCamera.OnCreateStereoCameras += OnCreateStereoCameras;
    }

    /// <summary>
    /// Creates post image effect : blur on left and right eye.
    /// </summary>
    /// <param name="leftEye">Left eye.</param>
    /// <param name="rightEye">Right eye.</param>
    void OnCreateStereoCameras(Camera leftEye, Camera rightEye)
    {
        leftEye.gameObject.AddComponent<BlurImageEffect>();
        rightEye.gameObject.AddComponent<BlurImageEffect>();
        ARCamera.OnCreateStereoCameras -= OnCreateStereoCameras;
    }
```