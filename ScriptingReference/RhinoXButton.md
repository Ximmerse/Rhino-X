# RhinoXButton 

> 命名空间: Ximmerse.RhinoX     
> public enum RhinoXButton

- 定义所有RhinoX支持的按键类型的枚举。

```bash
    /// <summary>
    /// Enumeration defines all RhinoX buttons. Includes side-bar button on RhinoX and standard bluetooth controller.
    /// </summary>
    public enum RhinoXButton
    {
        /// <summary>
        /// The confirm button on RhinoX side bar.
        /// 侧边栏确认键。
        /// </summary>
        ConfirmButton = KeyCode.Return,

        /// <summary>
        /// The trigger button on RhinoX standard controller.
        /// This enumeration item is equated to ControllerButtonCode.Trigger
        /// 控制器上的Trigger按键
        /// </summary>
        ControllerTrigger = 0x40000,

        /// <summary>
        /// The touchpad button on RhinoX standard controller.
        /// This enumeration item is equated to ControllerButtonCode.TouchPad
        /// 控制器上的 TouchPad 按键
        /// </summary>
        ControllerTouchPadButton = 0x0004,

        /// <summary>
        /// The app button on RhinoX standard controller.
        /// This enumeration item is equated to ControllerButtonCode.App
        /// 控制器上的App按键
        /// </summary>
        App = 0x0010,

        /// <summary>
        /// The home button on RhinoX standard controller.
        /// This enumeration item is equated to ControllerButtonCode.Home
        /// 控制器上的Home按键。
        /// </summary>
        Home = 0x08,

    }
````