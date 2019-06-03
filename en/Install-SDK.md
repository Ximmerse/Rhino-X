# SDK Installation

Download here [https://github.com/Ximmerse/Rhino-X/](https://github.com/Ximmerse/Rhino-X/)

# SDK Structure

The SDK supports Unity version 2018.3.0 or above. You should be able to observe the following folder structure:

![Asset Folder:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Project-Hierarchy.png)

## Plugins/Android Directory

![Plugins/Android Folder:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Plugins-Android-Folder.png)


* AndroidManifest.xml - This file contains all the permissions required by RihonX. Developers are not supposed to modify this file.

* Plugins/Android/assets ：Contains all the calibration files(json and dat).
`Plugins/Android/assets actual contents may look different from the picture` 

* Plugins/Android/res ： USB permission file.


## Plugins/RhinoX Directory

![Plugins/RhinoX Folder:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Plugins-RhinoX-Folder.png)

This directory contains all the required library. Developers must not modify any content in this directory. These files are critical computer vision algorithems libaries.


## Ximmerse-Assets Directory

This directory contains frequently-used Ximmerse devices 3D models.


!> Developers can use these models in their own projects.

# Initialization
Click RhinoX SDK/Initialize shown Below: 
 
![Initialize:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Unity-ToolMenu-Initialized.png)

This will finish initialization process for RhinoX SDK.

Initialization Internal Processes:

* Config script execution order
* Config PlayerSetting / MultiThread Rendering = False
* Config QualitySetting / VysncCount = Don't Sync
* Config Default Orientation = Landscape Left