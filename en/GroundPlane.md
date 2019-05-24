## Ground Plane Component

After RhoniX SDK is initlaized, AR Camera will be updated based on user head rotation and positon. However, this is not enough in some cases. 

!> Developers often need a ground refference, and then place the head transformation information into the ground based coordination system.

We will talk about how to use GroudPlane component to define ground surface in this tutorial.


- Open Assets/Demo/Scenes/DeerIsland scene.

- Select GroundPlane GameObject.

![Logo](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/GroundPlane-Inspector.png ':size=450X400')

> In this tutorial, we will use beacon #1 to define the ground surface.

> In GroundPlane configuration fields， Tilt Euler is used to rotate Marker 90 degree agound Y-axis, building the coordination system that has y axis pointing up.
> Min and Max Tracked Distance is defining the ideal tracking range when GroundPlane is tracked. This number is depending on physical marker size.

> Min head error distance and Head diff angle defines the difference tolerance. When the error distance and diff angle falls within these threshold, GroundPlan will not calibrate head position and orientation.

> DebugView is used to see GroundPlane virtual position.

- The scene is now ready to deployed. You can observe how GroundPlane corrects head position and rotation based on ground refference.
