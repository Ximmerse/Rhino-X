# Dynamic Target

> Namespace: Ximmerse.RhinoX      
> public sealed class DynamicTarget : TrackableBehaviour

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/DynamicTarget.png ':size=350X300')

Dynamic Target is a virtual representation of a tracked tag. Rotation and position is updated relative to the user's transform, and the
pose of the marker assigned as a target in the accompanying [TrackableIdentity](en/ScriptingReference/TrackableIdentity) 

- When Trackable Identity is set to Beacon, Dynamic Target will look like the one in the following image:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/photo/Beacon-Axis.jpg ':size=400X350')

- When Trackable Identity is set to Controller, Dynamic Target will be observed like this:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/photo/Controller-Axis.jpg ':size=400X350')

!> When YawOnly is checked, Dynamic Target will only update the rotation around Y-axis. This feature is useful when Pitch (rotation around X-axis) or Roll (rotation around Z-axis) is not needed.

### Public Members

#### YawOnly
- `public bool YawOnly { get; set; };`

If this is set to False，rotation around x,y,z will be updated. If this is set to true, only rotation around Y-axis will be updated.
