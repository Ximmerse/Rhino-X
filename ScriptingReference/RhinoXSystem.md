# RhinoXSystem

> 命名空间: Ximmerse.RhinoX     
> public static class RhinoXSystem

RhinoXSystem 静态类提供和RhinoX SDK的系统信息。

### 公共成员

#### SdkVersion
- `public const string SDKVersion;`

获取 RhinoX 的 SDK 版本。


#### SubModuleVersion
- `public static SDKVersion SubModuleVersion { get; set; }; `

获取 RhinoX 的子模块引擎版本。


#### GetHeadTrackingSystemTimestamp
- `public static ulong GetHeadTrackingSystemTimestamp();`

获取头部跟踪系统的时间戳。


#### EnableVPUPowerSaving
- `public static bool EnableVPUPowerSaving { get; set; };`

开启/关闭VPU的节能模式。在节能模式下，物体追踪相机在没有检测到物体的时候，会进入节能模式以降低耗电。 
此开关默认值为True。

