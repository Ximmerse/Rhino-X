## Object Tracking

This tutorial will guide you on how to track a physical object.

- Create a new scene, naming it Beacon-Tracking. Delete the MainCamera GameObject.
We will use the beacon from the devkit as an example. 
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/IMG_BEACON_01.JPG ':size=450X400')
!> Beacon has a number marked on it. Open the config file associated to the beacon: Plugins/Android/assets/BEACON-500.json:

```bash
BEACON-500.json is a beacon configuration file, which defines all the information required to track beacons.
In this section, we will review how to use these config files.

BEACON-500.json contents:

{
    "CARD_SINGLE":
    {
        "CalibFile": "BEACON-500.dat", // Beacon calibration file
        "Markers": [65,66,67],  //ID 65, 66, 67 is associated to #1，#2，#3 beacon.
        "MarkersSize": [0.15,0.15,0.15] //Beacon physical size, in meters.
    }
}
```

- Create a tracking profile by clicking on "Tracking Profile" under Create/Ximmerse/:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Create-Tracking-Profile.png)

- Check "Track Beacons" option.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Assign-Beacon-JSON.png)

!> TrackingProfile is database, storing calibration data for the trackable tags.

- Next, create ARCamera, drag the newly created TrackingProfile to Tracking Profile field under ARCamera inspector.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/TrackingProfile-Setup-Completely.png)

!> TrackingProfile is a database, storing tracking target's calibration file. In a typical development, developers may need to link more than one tracking object calibration file.

- Create an ARCamera, and then drag the TrackingProfile to ARCamera's Tracking Profile field.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/AssignTrackingProfile.png ':size=450X400')

!> ARCamera will send all the tracking profile data to low-level API upon SDK initialization. Low-level algorithm will determine how to utlize these databases.  

- Lastly, create a Dynamic Target. Set Trackable Identify Target to `Beacon 01`.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Create-GameObject-Shortcut.png ':size=450X400')

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/SetTrackableIdentity.png ':size=450X400')

!> If using #2 or #3 beacon, please set Target to `Beacon 02` or `Beacon 03`.

- Save the scene. At this point, everything is ready to be deployed.
