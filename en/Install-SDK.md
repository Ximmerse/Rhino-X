# SDK Installation

Download here [https://github.com/Ximmerse/Rhino-X/](https://github.com/Ximmerse/Rhino-X/)

# SDK Structure

The SDK supports Unity version 2018.3.0 or above. You should be able to observe the following folder structure:

![Asset Folder:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Project-Hierarchy.png)

## Plugins/Android Directory

![Plugins/Android Folder:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Plugins-Android-Folder.png)


* AndroidManifest.xml - This file contains all the permissions required by RhinoX applications. Developers are not supposed to modify this file.

* Plugins/Android/assets ：Contains all the tracker calibration files (json and dat).

`Plugins/Android/assets actual contents may look different from those shown in the picture above`

* Plugins/Android/res ： USB permission file.


## Plugins/RhinoX Directory

![Plugins/RhinoX Folder:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Plugins-RhinoX-Folder.png)

This directory contains all the required libraries for the SDK to operate. Developers must not modify any content in this directory. These files are critical computer vision libraries.

## Ximmerse-Assets Directory

This directory contains frequently-used Ximmerse devices 3D models.

> NOTE: Developers can use these models in their own projects.

# Initialization
Click RhinoX SDK/Initialize shown Below:

![Initialize:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Unity-ToolMenu-Initialized.png)

This will initialize the Unity project to properly utilize the RhinoX SDK.

>Initialization Processes:
- Set script execution order
- Disable Multithreaded Rendering
- Set Vertical Sync (VSync) to 'Don't Sync'
- Set the default orientation to 'Landscape Left'
