# Advanced Tutorial

This guide builds on top of Getting Started tutorial, futher explaining the concepts and advanced SDK usages.



## Concept and Component

Frequely used concepts and conponents will be explained below.

### AR Camera

AR Camera acts like a regular Unity Camera, caputring the view that player sees. The SDK requires a Camera object in the scene, and this camera object must have `ARCamera` and `Tag Tracker` components. For detailed setup, please reference the camera setup in demo scene in SDK.

### Marker Target

Marker Target is a virtual representation of physical marker in Unity.

In order to create a market target, please create an empty GameObject in the scene, and then attach `MarkerIdentity`. The last step is attching `DynamicMarker` or `BenchMarker` component.

!> both `Bench Marker` and `Dynamic Marker` work with scatter cards (single marker) and marker groups.


## Starting From Scratch

如果需要从头开始搭建一个真实开发场景，开发者可以遵循以下步骤：

1. Please select the hardware based on the application experience. In this tutorial, we are using Cube to setup the scene.

   ![Cube](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/cube-1.png)

   Observe the Marker ID.

   !> Each marker has an unique identifier.

   ​![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/cube-id-sample.png)



2. Open Unity project, follow the steps in [Getting Started](quickstart.md) to setup initial SDK configurations.



3. Config Tracking Profiles

   Create a trackig profile by clicking on "Create" button located at `Create/Ximmerse/SlideInSDK/Tracking Profile`.

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-create-tracking-profile.png)

   You can name the `Tracking Profile` based on your preference. We are using "Demo Tracking Profile" in this tutorial.

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-tracking-profile-description-inspector.png)
   
   The next step is adding marker config file to Tracking Profile. Because we are using the cube in this tutorial, we are essentially dealing with a marker group. Therefore, we will chose Marker Group as the Tracking Type. Please also make sure that hardware ID is matching the JSON Config field.

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-tracking-profile-json-inspector.png)

   Now we have finished the setup for a Tracking Profile.

   

4. Create a new scene and setup the following objects.

   - AR Camera

     Add `ARCamera` and `TagTracker` components to the Main Camera. Fill the Tracking Profile field in TagTracker with the tracking profile we just created.

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-arcamera-tag-tracker-inspector.png)

   

   - Dynamic Marker

     After creating AR Camera，we need to add a Marker Target to ensure that the physical marker can be tracked.

     Create a GameObject，naming it Cube Dynamic Marker Target. Then, add `Marker Identity` and `Dynamic Marker` components.

     ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-cube-dynamic-marker-inspector.png)

     Notice that Marker Id under `Marker Identity` component needs to be filed with the ID number found in Tracking Profile's `Json Config`.

     ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-cube-tracking-json-marker-id.png)

     Once we find the Marker ID, which is called `GroupID` in this example, **80** to `Marker ID` under `Marker Identify` component.

     Now we have finished setting up marker trackers and AR Camera.

     

5. Create Virtual Representation

   In this tutorial, we are using a sphere to represent the physical cube, so that when user wears the AR headset, he or she will see the sphere's position and rotation matching the physical cube.

   First of all, let's create an empty GameObject under Marker Target, naming it View Root. The physical cube's radius is around 0.11 meter, so we change the scale of View Root to 0.11 to match the real physics.

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-view-root-inspector.png)

   Then, adding a Sphere object as a child of View Root. We are adding a red material here to the sphere.

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-sphere-view-inspector.png)

   Now we have a virtual representation of the physical cube.

   

6. Debug and Development（Optional）

   To make the development and debugging easier, we recommend following the next steps to setup the debug tools.

   - PE Network Sync Transform / Properties

     Please read [this doc](notdoneyet.md) for details.

     

   - [LunarConsole](https://assetstore.unity.com/packages/tools/gui/lunar-mobile-console-free-82881)

     Under Project panel, please search "Lunar Console" and drag it to the game scene.

     ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-lunar-console.png)

   

7. Deployment

   Save the entire scene, and add the scene to Build Settings.

   Follow the standard Unity deployment steps.



## Build Preset

Build Preset is a config file in PolyEngine Plugins' Build Manager.

To create a Build Preset, we will click on Build Manager button under `Tools/PolyEngine/Build Manager`.

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-new-preset-build-manager-window.png)



Click New Preset and give it a name. In this tutorial, we name it "Demo Preset".

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-new-preset-button.png)

Load the Build Preset we just created. Here are the typical settings of a preset configuration:

- Build Name

  The name of the application that shows on the phone screen.

- Package ID

  Application bundle identifier.

- Default Orientation

  We must use **Landscape Right** for this option.

- Scenes

  The scenes to include in the application.

After setting up the Preset, we can now save it by clicking on "Save Preset" button.

From now, we could quickly switch between presets to quickly deploy the applications.
