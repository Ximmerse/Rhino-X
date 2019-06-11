# ObjectTracking

> 命名空间: Ximmerse.RhinoX    
> public static class ObjectTracking

- ObjectTracking 静态类提供和对象跟踪有关的辅助方法。

### 静态方法

#### GetTrackableRawData
- `public static bool GetTrackableRawData (int TrackableID, ref Vector3 Position, ref Quaternion Rotation, ref ulong timestamp)`

>给出一个 Trackable Object ID，获取此对象的追踪数据的原始输出。 

!> 这些数据是以追踪相机(RhinoX中间的红外相机)为原始坐标点。 通过这些数据可以获取到被追踪物体的追踪距离，追踪角度。如果你使用到了自定义的追踪行为，则需要用到这些数据。
如果你需要的是全局位置和朝向，你需要调用 `GetTrackableWorldSpaceData()`。


#### GetTrackableWorldSpaceData
- `public static bool GetTrackableWorldSpaceData (int TrackableID, ref Vector3 WorldPosition, ref Quaternion WorldRotation)`

给出一个 Trackable Object ID, 获取此对象的全局位置和朝向。

!> 和 `GetTrackableRawData()` 相对应， 此方法输出的是全局坐标和朝向，这些值也取决于用户头部所在的位置。

