# Ground Plane

> 命名空间: Ximmerse.RhinoX      
> public sealed class DynamicTarget : TrackableBehaviour

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/GroundPlane.jpg ':size=450X400')

> GroundPlane 如其名字所示，做为世界内容的中心点。   
> GroundPlane 一般被放置在地面上。  
> Ground Plane 和 Dynamic Target的工作原理相反: 
> Dynamic Target 以用户的头部位置为中心更新追踪物体的方位。只要被追踪到，追踪物体的方位就始终是变化的。    
> Ground Plane 则以追踪物体为中心，更新用户头部(ARCamera)的方位。更新结果是 GroundPlane 不动， ARCamera的位置和朝向被改变。GroundPlane不会改变自身 Transform 的方向和位置。



!> 理论上， 所有的可追踪物体，都可做为 Ground Plane 使用。    
实际使用中，投影面积越大的物体，越适合长距离的稳定追踪，所以 Beacon (相对于Controller) 更适合被做为 Ground Plane 使用。

### 两种模式

- 当 GroundPlane.recenterMode == Automate 的时候

 Min Tracked Distance 和 Max Tracked Distance 控制GroundPlane 能做为归中地标点使用时候的最小追踪距离。

!> 之所以需要设置这两个字段，是因为 Beacon 距离用户头部太远的时候， 追踪质量会下降。 所以需要为Ground Plane设置一个工作范围。
默认的设置是指，当 Beacon 的追踪距离超过2米的时候， Ground Plane 不会自动更新用户头部的方位。 除非调用了 `ForceRecenter()` 方法。


 Min Error Head Distance 和 Min Error Head Diff Angle 控制GroundPlane 归中时候的允许误差。当用户归中前的头部位置距离目标位置小于 `Min Error Head Distance`并且头部朝向的Yaw角度和目标方位的Yaw角度小于 `Min Error Head Diff Angle` 的时候， 不进行归中操作。

!> 如果这两个数值太小， GroundPlane 会频繁归中ARCamera造成用户视觉上的瞬移感。   
如果这两个数值太大， GroundPlane就会失去归中的功能。   
我们建议用户保留默认的数值设置 :  
MinTracked Distance = 0;   
Max Tracked Distance = 2;    
Head Error Distance = 0.12;   
Head Error Diff Angle = 6;    


- 当 GroundPlane.recenterMode == Scripting 的时候
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/GroundPlane_Scripting.jpg ':size=670X172')


 GroundPlane 不会自动更新ARCamera 的方位。 开发者主动调用 `GroundPlane.ForceRecenter()`方法控制GroundPlane主动归中。


### 使用多个 GroundPlane

开发者可以在场景中放置多个 GroundPlane。一般有以下几种方式:

- 把多个Ground Plane 对象放置在同一个位置。
这样的好处是，应用内容不必局限于某个 Beacon， 使用任意一个Beacon都可以做为世界中心定位。

- 预先测量您的空间区域，在对应的角点位置，放置多个GroundPlane，并且在你的scene中把GroundPlane之间的位置按照实际测量的结果来放置。
>只要测量正确，上述方式能极大的延展单个Beacon的工作空间。

!> 当场景中存在有多个 Ground Plane 组件的时候， 距离用户最近的GroundPlane会被用于定位。   
通过静态成员 `GroundPlane.CurrentGroundPlane` 可以获取当前被用于定位的GroundPlane实例。 


### 静态成员

#### CurrentGroundPlane
 `public static GroundPlane CurrentGroundPlane { get; };`

当场景中有多于一个GroundPlane的时候，此字段返回最新的被用于归中操作的GroundPlane实例。 如果场景中只有一个GroundPlane，则只返回唯一的实例。

### 静态方法
#### ForceRecenter
  `public static void ForceRecenter()`

对第一个被跟踪到的GroundPlane对象，强制一次归中操作。 当RecenterMode = Automate的时候，这项操作会忽略最小和最大跟踪范围的条件限制。
  
```bash
using UnityEngine;
using Ximmerse.RhinoX;

///Example Code: 自定义归中操作
public class CustomRecenter : MonoBehaviour
{
    public GroundPlane groundPlane;
    public float MaxTrackedDistance = 0.9f;
    private void Start()
    {
        groundPlane.recenterMode = GroundPlane.RecenterMode.Scripting;
    }

    void ScriptCallGroundPlaneRecenter()
    {
        TrackableIdentity trackableIdentity = GetComponent<TrackableIdentity>();
        Vector3 Position = default(Vector3);
        Quaternion Rotation = default(Quaternion);
        ulong timestamp = 0;
        if(ObjectTracking.GetTrackableRawData(trackableIdentity.TrackableID, ref Position, ref Rotation, ref timestamp))
        {
            float trackedDistance = Position.magnitude;
            if(trackedDistance <= MaxTrackedDistance)
            {
                GroundPlane.ForceRecenter();
            }
        }
    }

}

````