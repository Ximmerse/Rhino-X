//-----------------------------------------------------------------------
// <copyright file="RxControllerView.cs" company="GuangDong Virtual Reality Technology Limited">
//     Copyright (c) 2018 Ximmerse. All rights reserved.
// </copyright>
// <auther>YYQ</auther>
// <contact>yuanqing.yin@ximmerse.com</contact>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main menu script.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the demo : dynamic beacon tracking.
    /// </summary>
    public void LoadDemo_DynamicBeaconTracking ()
    {
        SceneManager.LoadScene("Beacon-Tracking", LoadSceneMode.Single);
    }

    /// <summary>
    /// Loads the demo : deer island with a ground plane.
    /// </summary>
    public void LoadDemo_GroundPlane_DeerIsland ()
    {
        SceneManager.LoadScene("Deer-Island", LoadSceneMode.Single);
    }

    public void BackToMainMenu ()
    {
        SceneManager.LoadScene("Controller UI", LoadSceneMode.Single);
    }
}
