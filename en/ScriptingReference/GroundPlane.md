# Ground Plane

> Namespace: Ximmerse.RhinoX      
> public sealed class DynamicTarget : TrackableBehaviour

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/GroundPlane.jpg ':size=450X400')

> GroundPlane can be used as a world orgin in virtual world.   
> GroundPlane is typicall placed on groud.  
> Ground Plane and Dynamic Target works in opposite way: 
> Dynamic Target's transform is updated based on user's head movement.
> Ground Plane is considered a world origin, so from the user's perspective, Groud Plane is stationary. ARCamera's transform is updated based on relative position and rotation to the Groun Plane.


!> In theory, any trackable tag can be used as a Ground Plane.
In real application development, world origin needs to be as stable as possible, so Beacon marker is better suited as a Ground Plane because it has larger trackable area compared small tag controllers.

### Ground Plane 2 Modes

- When GroundPlane.recenterMode == Automate,

 Min Tracked Distance and Max Tracked Distance controls how close/far GroundPlane can be used as a world origin.

!> The further the user is away from Beacon, the less stable the tracking becomes, so it is necessary to define an ideal tracking range for Ground Plane.
By default, when Beacon is 2 meters away from the user, Ground Plane will stop updating ARCamera transform, unless `ForceRecenter()` method is used.

`Min Error Head Distance` and `Min Error Head Diff Angle` controls Ground Plane recentering triggering threshold. 

!> If `Min Error Head Distance` and `Min Error Head Diff Angle` are set too low, users may experience jumping images, because of frequent rencentering.

If `Min Error Head Distance` and `Min Error Head Diff Angle` are set too high, then recenter will probably never gets triggered.

There, we recommend the following settings:  
MinTracked Distance = 0;   
Max Tracked Distance = 2;    
Head Error Distance = 0.12;   
Head Error Diff Angle = 6;    


- When GroundPlane.recenterMode == Scripting,
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/GroundPlane_Scripting.jpg ':size=670X172')


 GroundPlane will not recenter ARCamera. Developers need to use `GroundPlane.ForceRecenter()` to recenter ARCamera manually based on custom conditions.


### Using Multiple Ground Plane

Developers can use mutiple Ground Planes in a scene. There are a few ways to do it:

- Place multiple Ground Plane at same location. By doing this, content is not limited by a specific beacon, and any beacon can be used as a world origin as long as it is tracked.

- Pre-define interaction area, place Ground Plane markers at corners, and then measure the physical distance between each Ground Plane marker. The next step is to place the virtual Ground Plane in the scene based on physical Ground Plane placement. 

>Doing so will largely increase world origin tracking distance.


!> When there are multiple Ground Planes in trackable distance, the closest Ground Plane will be used to update user's position.  
`GroundPlane.CurrentGroundPlane` can be used to access current tracked Ground Plane.


### Static Members

#### CurrentGroundPlane
`public static GroundPlane CurrentGroundPlane { get; };`

When there are multiple Ground Planes in the scene, this member returns the one that is currently being tracked. If there is only one Ground Plane in the scene, this will return that specific Ground Plane.

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