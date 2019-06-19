# RhinoXButton 

> Namespace: Ximmerse.RhinoX     
> public enum RhinoXButton

- This class defines all RhinoX supported device button enums.

```bash
    /// <summary>
    /// Enumeration defines all RhinoX buttons. Includes side-bar button on RhinoX and standard bluetooth controller.
    /// </summary>
    public enum RhinoXButton
    {
        /// <summary>
        /// The confirm button on RhinoX side bar.
        ///
        /// </summary>
        ConfirmButton = KeyCode.Return,

        /// <summary>
        /// The trigger button on RhinoX standard controller.
        /// This enumeration item is equated to ControllerButtonCode.Trigger
        ///
        /// </summary>
        ControllerTrigger = 0x40000,

        /// <summary>
        /// The touchpad button on RhinoX standard controller.
        /// This enumeration item is equated to ControllerButtonCode.TouchPad
        ///
        /// </summary>
        ControllerTouchPadButton = 0x0004,

        /// <summary>
        /// The app button on RhinoX standard controller.
        /// This enumeration item is equated to ControllerButtonCode.App
        ///
        /// </summary>
        App = 0x0010,

        /// <summary>
        /// The home button on RhinoX standard controller.
        /// This enumeration item is equated to ControllerButtonCode.Home
        ///
        /// </summary>
        Home = 0x08,

    }
````
