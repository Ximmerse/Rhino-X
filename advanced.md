# 进阶指南

本章节将会在快速开始的基础上，进一步的解释详细的概念以及SDK的进阶用途。



## 概念与组件

这里我们将会介绍一下实际开发中的会遇到的一些概念与约定名称。

### AR摄像机

AR摄像机是作用于在Unity场景中模拟人眼看到的信息。为了Marker的追踪以及视觉呈现的效果，场景中必须有一个附有Camera组件的GameObject，同时该GameObject上需要附有`ARCamera`以及`Tag Tracker`两个组件。可以以Demo场景中的Camera设置作为参考。

### Marker Target

Marker Target 是硬件Marker在Unity虚拟场景中的载体容器。

在场景中新建一个空白的GameObject，为其添加`Marker Identity`以及`Dynamic Marker`或者`Bench Marker`（二选一），就完成了Marker Target的创建了。

!> 不管Marker类型是`Bench Marker`亦或是`Dynamic Marker` ，他们都可以使用scatter cards (单Marker)或者marker group (组合Marker) 的marker类型。



## 从头开始

如果需要从头开始搭建一个真实开发场景，开发者可以遵循以下步骤：

1. 根据应用场景选择开所需的硬件设备，再这个示例中我们选择使用Cube

   ![Cube](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/cube-1.png)

   观察硬件的id 标签。

   !> 每个marker 硬件都会对应唯一个id

   ​![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/cube-id-sample.png)



2. 打开Unity新建工程，按照[上文](quickstart.md)中的指南导入SDK并且完成项目设置。



3. 制作Tracking Profiles

   在project 栏中任意目录下点击右键，在弹出的上下文窗口中选择`Create/Ximmerse/SlideInSDK/Tracking Profile` 新建一个Tracking Profile。

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-create-tracking-profile.png)

   你可以自定义`Tracking Profile` 文件的名字以及使用描述。在此示例中我们命名Demo Tracking Profile。

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-tracking-profile-description-inspector.png)

   接下来我们添加标定文件到Tracking Profile 中。由于我们所使用的硬件是Cube，而Cube是一个组合型追踪目标，所以我们的标定文件是添加Marker Group 类型。Config 一栏我们则使用与硬件id一致 为cube-410-01-007 的json配置文件。

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-tracking-profile-json-inspector.png)

   至此，我们就完成Tracking Profile 的创建。

   

4. 新建场景，在场景中搭设所需要的组件。

   - AR Camera

     在Main Camera上增加`AR Camera` 以及`Tag Tracker` 两个组件。Tag Tracker 的Tracking Profile 使用我们刚刚创建的Profile。

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-arcamera-tag-tracker-inspector.png)

   

   - Dynamic Marker

     建立完AR Camera 后，我们需要添加Marker Target 以确保Marker 能追踪并且使用其位置信息。

     创建一个GameObject，将其命名为Cube Dynamic Marker Target。为其添加`Marker Identity` 和`Dynamic Marker` 两个组件。

     ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-cube-dynamic-marker-inspector.png)

     此时我们需要查找Cube 所对应的Marker Id， 然后将其填入`Marker Identity` 对应的字段中。

     我们可以从配置的Tracking Profile 中的`Json Config` 中找到。

     ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-cube-tracking-json-marker-id.png)

     所以我们将Marker id，这里是`GroupID` **80** 填入`Marker Identity` 的`Marker Id` 字段中。

     至此基础的Marker追踪以及摄像机渲染设置完成。

     

5. 根据应用需求，构建虚拟视图。

   在这个实例当中，我们会建立一个简单的球型视图作为虚拟视图。但用户透过头显观察Cube 的时候，会看到一个红色的球体取替了Cube的位置。

   首先我们在Marker Target 下建立新的空白子物体，命名为View Root，由于Cube 的物理尺寸在半径0.11m左右， 我们将View Root 的缩放调整成0.11。

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-view-root-inspector.png)

   然后我们在View Root 下建立新的Sphere 子物体，新建一个红色材质球赋予给这个sphere即可。

   ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-sphere-view-inspector.png)

   至此，虚拟视图的设置完成。

   

6. 添加测试、调试工具。（可选）

   为了能更加方便的调试，我们建议加入一下工具方便调试。

   - PE Network Sync Transform / Properties

     请参考[此处](notdoneyet.md)查阅详细用法

     

   - [LunarConsole](https://assetstore.unity.com/packages/tools/gui/lunar-mobile-console-free-82881)

     在Project 一栏搜索Lunar Console 这个Prefab，并且将其置入场景中。

     ![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-lunar-console.png)

   

7. 打包测试。

   将这个场景保存到资源中，并在Build Settings中添加此场景。

   按照流程打包成sdk即可进行测试。



## 自定义Build Preset

Build Preset 是PE Plugins 中的Build Manager 所使用的快速设置Build Settings 配置文件。

我们开始新建一个自定义的Build Preset，首先进入`Tools/PolyEngine/Build Manager` 打开Build Manager的窗界面。

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-new-preset-build-manager-window.png)



点击New Preset 按钮并且为新的Preset 输入一个名称，在这里我们设置为Demo Preset。

![](https://ximmerse-1253940012.cos.ap-guangzhou.myqcloud.com/slide-in-sdk/sample-new-preset-button.png)

选择并加载我们建立的Preset，这个时候我们可以设置对应Player Settings 中的内容，这里我们举例几个常用项进行说明：

- Build Name

  最终apk安装后显示的应用名称。

- Package ID

  apk的唯一id，一般是com.开头。

- Default Orientation

  设备的默认旋转方向。

  !> 在Slide-In 的应用场景中中，我们的必须直接选择**Landscape Right**这个选项。

- Scenes

  对应在Build Settings 中会打包进apk 的场景。

设置完成Preset 后，我们需要点击Save Preset 按钮进行保存。

至此，自定义Build Preset的设置全部完成，之后我们就可以快速切换打包设置了。

