# Trackable Identity

> Namespace: Ximmerse.RhinoX     
> public sealed class TrackableIdentity : MonoBehaviour

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/TrackableIdentity.png ':size=450X400')

Trackable Identity component can track an object via Trackable ID.
- Set ID in Trackable Identity inspector, defining which tag this component is associated to.
- Trackable Identity can be modified during runtime.
- Events will be triggered when the tracked object is tracked or out of sight.

### Public Members

#### TrackableID
- `public int TrackableID { get; set; };`

Set or get tracked object ID.

Pre-defined Beacon ID:

 Beacon 01 = 65;

 Beacon 02 = 66;

 Beacon 03 = 67;

 Controller = 81;

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Inspector/TrackableIdentity-Target-Dropdown.jpg ':size=450X400')

> About Custom ID: Besides beacons and controllers, RhinoX also supports Cube Controller, tablets, and tables. When using these additional controllers, custom ID will be needed. To get more information about additional input devices, please contact [Ximmerse Support](https://www.ximmerse.com/contact).

#### ActivateGameObject
- `public bool ActivateGameObject { get; set; } `

Set GameObject active status.

#### IsVisible
- `public bool IsVisible { get; }`

Is the tracked object visible to tracking camera or not. This Boolean can also be acquired through [ObjectTracking](en/ScriptingReference/ObjectTracking) interface.

#### OnVisibilityChange
- `public VisiblityChangeEvent OnVisibilityChange;`

This event is triggered right before an object is tracked and right after an object moves out of line of sight of the tracking camera.

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

If this is set to true, the SDK will output detailed logs every frame. Developer needs to use ADB tools to access the log output.
