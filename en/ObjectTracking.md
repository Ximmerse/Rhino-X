## Object Tracking

This tutorial will guide you on how to track a physical object.
### Using the SDK 
- Create a new scene, naming it Beacon-Tracking. Delete the MainCamera GameObject.
We will use the beacon from the devkit as an example.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/IMG_BEACON_01.JPG ':size=450X400')

- Create a tracking profile by clicking on "Tracking Profile" under Create/Ximmerse/:
![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Create-Tracking-Profile.png)

- Check "Track Beacons" option.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Assign-Beacon-JSON.png)

!> TrackingProfile is database that contains the calibration data of the trackable tags.

- Next, create an ARCamera and drag the newly created TrackingProfile to Tracking Profile field in the ARCamera inspector.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/AssignTrackingProfile.png ':size=450X400')

!> In a typical development, developers may need to link more than one tracking object calibration file to the ARCamera.

- Lastly, create a Dynamic Target. Set Trackable Identify Target to `Beacon 01`. Attach a 3D cube or any other geometry as a child (don't forget to set it's local position and rotation to 0 so there is no offset).

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Create-GameObject-Shortcut.png ':size=450X400')

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/SetTrackableIdentity.png ':size=450X400')

!> If using #2 or #3 beacon, please set Target to `Beacon 02` or `Beacon 03`.

- Save the scene. At this point, everything is ready to be deployed.
- Start the application, hold the beacon on your hands, and see how our virtual cube follows it.

### What is happening?
In order to track objects the RhinoX utilizes the X-Tag system. The SDK provides easy to use tools and components to "tell" our application what tag information to track, and how to associate this data to a 3D Transform. To achieve this, we use TrackingProfiles, .JSON and .dat files. These describe what identities to track, associate trackable identities between the low level and high level libraries, and what a tag looks like (calibration).

The ARCamera sends all the tracking profile data to the low-level API upon initialization of the application. The Low-level algorithms will determine how to utilize these databases to track objects.  

Each physical beacon has a number on it, that corresponds with the Trackable Identity ID (as seen in the Trackable Identity target field). The tracking configuration for the beacons is in Plugins/Android/assets/BEACON-500.json and Plugins/Android/assets/BEACON-500.dat files.

BEACON-500.json contents:
```bash
{
    "CARD_SINGLE":
    {
        "CalibFile": "BEACON-500.dat", // Beacon calibration file
        "Markers": [65,66,67],  //ID 65, 66, 67 is associated to #1，#2，#3 beacon.
        "MarkersSize": [0.15,0.15,0.15] //Beacon physical size, in meters.
    }
}
```

When we created the TrackingProfile, we checked the "Track Beacons" option. This adds the associated .json and .dat files automatically without requiring any other configuration. Similarly, we could have added controllers by checking the "Track Controllers" options; or custom configurations (eg. the application uses a gun controller with markers, or individual markers on physical props spread around a room) by selecting "Additive Tracking" and manually drag-and-dropping the desired .json files.

> Remember, you can mix and match any of these options as desired.

Finally, the Trackable Identity component associates it's GameObject to specific marker data. In our example, the Dynamic Target Component knows that it should place it's virtual object where the tracking system senses the Beacon 1 marker, thanks to the Trackable Identity. No extra scripting required!
