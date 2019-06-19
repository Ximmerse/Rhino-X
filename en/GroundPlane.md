## Ground Plane

After RhinoX SDK is initialized during runtime, the AR Camera will be updated based on the user's head rotation and position using Visual Inertial Odometry (VIO). In some cases, applications require more information to map the virtual scene to a specific location in the physical space, like figuring out where the floor is.

!> GroundPlanes are especially useful to have when the application requires multiple users to share both physical and virtual worlds.

### Using the SDK
Similarly to the Object Tracking example shown earlier in this guide, we are using the RhinoX tracking capabilities to get the position and rotation of known markers. But this time, instead of moving a Unity object to where the marker is, we will move the user's head (the ARCamera) so the predefined scene object location matches that of our physical marker. We will talk about how to use the GroundPlane component to achieve this.

!> Developers often need a ground reference, and then place the head Transform information relative to the ground coordinate system.

- Open Assets/Demo/Scenes/DeerIsland scene.

- Select the GroundPlane GameObject. This will server as our reference or "anchor"

<!-- ![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/GroundPlane-Inspector.png ':size=450X400') -->
![Logo](images/groundPlane.png)

!> In this tutorial, we use Beacon #1 to define the ground surface. Make sure the target in the Trackable Identity matches the beacon you are using.

- Move the GroundPlane object to any position you want.

!> For educational purposes, we recommend adding a cube or set the debug options to have visual cues for the location of GroundPlane object.

- Build and deploy. Put the beacon anywhere in the floor (or any flat surface).

- Start the application, and look at the Beacon. Notice how the spot we chose earlier for the GroundPlane matches the location of the beacon.

- Walk around, and every so often look at the beacon to see how you will be recentered.

!> Important: The GroundPlane component only affects the user's head yaw rotation (i.e. the physical marker doesn't need to be laying perfectly flat in the ground).

### What do the parameters mean?

Recenter Mode allows to control when the GroundPlane will update the user head. Sometimes we only want to set the head transform every frame the marker is visible, some others we might want to do it only once after the marker becomes visible. Try the different settings to find what suits your application needs better.  

Min and Max Tracked Distance is defining the tracking distance range in which the GroundPlane will affect the HMD position. This is a useful way to control when the marker location data is trusted as reference point.

!>The size of the physical marker (in this case, Beacon #1) affects how far the RhinoX can track it. The larger the marker, the farther it can be to be tracked precisely.

Min head error distance and Head diff angle defines the difference tolerance. When the error distance and diff angle falls within these thresholds, GroundPlane will not recenter the head position and orientation.

DebugView is used to see GroundPlane virtual position.
