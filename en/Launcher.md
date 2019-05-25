

Launcher app is used to configurate the system and connected devices. There are 2 interaction mode in launcher app, gaze aiming mode and controller aiming mode. 

When there is no controller device connected, user will be able to interact the launcher UI with gaze aiming and buttons on the HMD.

When there is a controller connected, user can activate controller aiming mode by pushing trigger button. The gaze aiming mode is disabled when controller aiming mode is activated. 

Here is a list of frequently used features for development:

1. Application Opening and Uninstallation:	
In Launcher main UI, there is an application list. Users can click on the application in the list to launch the application, or long hold on the icon to un-install the application.

2.	WiFi, Bluetooth Configuration:	
User can launch the Wifi and Bluetooth config panel in the launcher app main menu.
Wifi connecting and Bluetooth pairing process are very similar to that on smart phones. 

3.	Device Manager and Configurations:	
Launcher device manager manages device paring, connectivity, and disconnection. RhinoX includes a wide range of input devices, such as tag controller, cube controller and touchpad controllers. 
The device manager will automatically pair the devices depending on the configuration.
Go to pairing menu, click on the devices you would like to pair, such as left or right controller, or a cube controller.
Once pairing button is clicked, the system will search for target devices; user will be required to push 2 buttons on controllers in order to have the controllers paired. 
Once controller is connected, user can activate the controler aiming mode in launcher by push trigger button.
If users need to have RhinoX to forget paired controllers, they can click on paired devices, and then click "Forget" button to unpair the controller.
			
4. System Update:	
The system update typically updates the VPU and system rom. When system rom or VPU update is available, a system dialog will pop up. Click "Yes" to update the system.

5. Application:		
When application is deployed on the device, users may need to setup application permissions. We recommend using a PC software, Visor, to config the application permissions.
