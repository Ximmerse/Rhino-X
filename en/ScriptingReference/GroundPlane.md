# Ground Plane

> Namespace: Ximmerse.RhinoX      
> public sealed class DynamicTarget : TrackableBehaviour

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/GroundPlane.jpg ':size=450X400')

GroundPlane can be used as a world origin in the virtual world. This allows to map the virtual scene to a specific point in the physical space.
> GroundPlane is typically placed on ground, but it can be in any surface.  
> Ground Plane and Dynamic Target works in opposite ways:
> Dynamic Target's transform is updated based on where the marker is tracked relative to the users head.
> Ground Plane is considered a world origin, so from the user's perspective, Ground Plane is stationary. ARCamera's transform is updated based on the relative position and rotation to the Ground Plane object.

!> In theory, any trackable tag can be used as a Ground Plane.
In real application development, world origin needs to be as stable as possible, so the Beacon marker is better suited as a Ground Plane because it has larger trackable area compared to smaller tags.

### Ground Plane 2 Modes

- When GroundPlane.recenterMode == Automate,

 Min Tracked Distance and Max Tracked Distance controls the distance range in meters (between the HMD and the assigned GroundPlane marker) where GroundPlane will update the ARCamera transform.

!> The further the user is away from Beacon, the less stable the tracking becomes, so it is necessary to define an ideal tracking range for Ground Plane.
By default, when Beacon is 2 meters away from the user, Ground Plane will stop updating ARCamera transform, unless [GroundPlane.ForceRecenter()](en/ScriptingReference/GroundPlane.md?id=ForceRecenter) method is used.

`Min Error Head Distance` and `Min Error Head Diff Angle` controls Ground Plane recentering triggering threshold. If the difference between the current ARCamera transform and the one calculated by GroundPlane is below these values, it will not update the transform.

!> If `Min Error Head Distance` and `Min Error Head Diff Angle` are set too low, users may experience jumping images, because of frequent rencentering. In meters.

If `Min Error Head Distance` and `Min Error Head Diff Angle` are set too high, then recenter will probably no be triggered.

We recommend the following settings when using beacons as the GroundPlane markers:  
Min Tracked Distance = 0;   
Max Tracked Distance = 2;    
Head Error Distance = 0.12;   
Head Error Diff Angle = 6;    


- When GroundPlane.recenterMode == Scripting,
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/GroundPlane_Scripting.jpg ':size=670X172')


 GroundPlane will not recenter ARCamera. Developers need to use [GroundPlane.ForceRecenter()](en/ScriptingReference/GroundPlane.md?id=ForceRecenter) to recenter ARCamera manually based on custom conditions.


### Using Multiple Ground Planes

Developers can use multiple Ground Planes in a scene. There are a few ways to do it:

- Place multiple Ground Plane GameObjects at the same location in the scene. By doing this, content is not limited to a specific beacon, and any of them can be used as a world origin for your application.

- Pre-define interaction area, place Ground Plane markers at corners, and then measure the physical distance between each Ground Plane marker. Place the virtual Ground Plane GameObjects in the scene based on physical Ground Plane placement. This will allow to expand the physical area where the mapping will remain accurate.

>Multiple GroundPlanes will largely increase world origin tracking distance.


!> When there are multiple Ground Planes within trackable distance, the closest Ground Plane will be used to update the user's position.  
[GroundPlane.CurrentGroundPlane](en/ScriptingReference/GroundPlane.md?id=CurrentGroundPlane) can be used to access current tracked Ground Plane.


### Static Members

#### CurrentGroundPlane
`public static GroundPlane CurrentGroundPlane { get; };`

When there are multiple Ground Planes being tracked, this member returns the one that was used to perform the recenter (effectively, the closest one to the user). If there is only one Ground Plane in the scene, this will return that specific Ground Plane.

### Static Methods
#### ForceRecenter
`public static void ForceRecenter()`

Force recenter based on last tracked Ground Plane. When RecenterMode == Automate, this method ignores min error parameters.

```bash
using UnityEngine;
using Ximmerse.RhinoX;

///Example Code: Custom Recentering Sample
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
        TrackableIdentity trackableIdentity = groundPlane.GetComponent<TrackableIdentity>();
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
