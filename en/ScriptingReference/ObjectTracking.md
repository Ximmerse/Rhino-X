# ObjectTracking

> Namespace: Ximmerse.RhinoX    
> public static class ObjectTracking

- ObjectTracking static class provides helper methods to interact with tracked objects.

### Static Methods

#### GetTrackableRawData
- `public static bool GetTrackableRawData (int TrackableID, ref Vector3 Position, ref Quaternion Rotation, ref ulong timestamp)`

Populates the Position, Rotation and the timestamp of when the data was generated, for the specific ID indicated in TrackableID. Position and Rotation is in tracker space, not World coordinates.

!> These data are generated based on the assumption that RhinoX's IR camera is the origin of the coordination system. If world position and rotation is needed, please use [GetTrackableWorldSpaceData()](en/ScriptingReference/ObjectTracking.md?id=GetTrackableWorldSpaceData).


#### GetTrackableWorldSpaceData
- `public static bool GetTrackableWorldSpaceData (int TrackableID, ref Vector3 WorldPosition, ref Quaternion WorldRotation)`

> Pass in a Trackable Object ID to get raw world tracking data.

!> Opposite to `GetTrackableRawData()`, this method returns to world position and rotation. User transform also affects this value.
