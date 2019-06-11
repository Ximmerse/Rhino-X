# ObjectTracking

> Namespace: Ximmerse.RhinoX    
> public static class ObjectTracking

- ObjectTracking static class provides helper methods to interact tracked objects.

### Static Methods

#### GetTrackableRawData
- `public static bool GetTrackableRawData (int TrackableID, ref Vector3 Position, ref Quaternion Rotation, ref ulong timestamp)`

> Pass in a Trackable Object ID to get raw tracking data.

!> These data are generated based on the assumption that RhinoX's IR camera is the origin of the coordination system. If world position and rotation is needed, please use `GetTrackableWorldSpaceData()`.


#### GetTrackableWorldSpaceData
- `public static bool GetTrackableWorldSpaceData (int TrackableID, ref Vector3 WorldPosition, ref Quaternion WorldRotation)`

> Pass in a Trackable Object ID to get raw world tracking data.

!> Opposite to `GetTrackableRawData()`, this method returns to world position and rotation. User transform also affects this value.

