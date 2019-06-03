# SDK 安装

下载:  [https://github.com/Ximmerse/Rhino-X/](https://github.com/Ximmerse/Rhino-X/)

# SDK 文件结构介绍

下载后，使用 2018.3.0 或以上的版本打开项目，文件路径结构如下:

![Asset Folder:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Project-Hierarchy.png)

## Plugins/Android 文件夹

![Plugins/Android Folder:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Plugins-Android-Folder.png)


* AndroidManifest.xml - 此文件定义RhinoX所必须的所有权限请求，开发者不可修改此权限需求。

* Plugins/Android/assets 目录： 所有可追踪物体的标定文件(json 和 dat文件) 必须被存放在此路径中。
`Plugins/Android/assets 内的实际内容可能和此图有不同。` 

* Plugins/Android/res 目录： 存放usb权限请求文件。


## Plugins/RhinoX 文件夹

![Plugins/RhinoX Folder:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Plugins-RhinoX-Folder.png)

此文件夹封装所有必须的代码库，用户不应该去修改和移动此文件夹内的所有文件。这些代码库是视觉算法的核心文件，缺一不可。



## Ximmerse-Assets 文件夹

此文件夹包含有 Ximmerse 的设备3D模型。这些模型是RhinoX常用交互设备的3D模型。


!> 开发者可以直接把上述文件直接拷贝到自己的项目中。

# 初始化
最后，点击 RhinoX SDK/Initialize 按钮: 
 
![Initialize:](https://raw.githubusercontent.com/yinyuanqings/AIOSDK/gh-pages/img/Unity-ToolMenu-Initialized.png)

点击此按键将初始化 RhinoX SDK 所需要的设置。

初始化内部工作流程:

* 设置关键类的 execution order
* 设置 PlayerSetting / MultiThread Rendering = False
* 设置 QualitySetting / VysncCount = Don't Sync
* 设置 Default Orientation = Landscape Left