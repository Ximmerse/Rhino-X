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

namespace Ximmerse.RhinoX
{
    /// <summary>
    /// RhinoX controller view script.
    /// </summary>
    #if UNITY_ANDROID
    [RequireComponent(typeof(RXController))]
    #endif
    public class RxControllerView : MonoBehaviour
    {
#if UNITY_ANDROID
#pragma warning disable CS0649
        RXController m_rxController;

        internal RXController RxController
        {
            get
            {
                if(!m_rxController)
                {
                    m_rxController = GetComponent<RXController>();
                }
                return m_rxController;
            }
        }
        [Header("--- Touch Pad Buttons ---")]
        [SerializeField]
        Transform m_TouchPadPointer;
        /// <summary>
        /// Gets or sets the touch pad pointer.
        /// </summary>
        /// <value>The touch pad pointer.</value>
        public Transform TouchPadPointer
        {
            get
            {
                return m_TouchPadPointer;
            }
            set
            {
                m_TouchPadPointer = value;
            }
        }

      
        [SerializeField]
        GameObject m_TP_Up; 
        [SerializeField]
        GameObject m_TP_Right, m_TP_Left, m_TP_Bottom, m_TP_Center;

        [Header("--- App and Home ---")]
        [SerializeField]
        GameObject m_AppButton;
        [SerializeField]
        GameObject m_HomeButton;

        [SerializeField]
        TextMesh m_BatteryUI;

        void Update()
        {
            Vector2 touchPosition;
            if(RxController.GetTouchPadPoint(out touchPosition))
            {
                m_TouchPadPointer.localPosition = new Vector3(touchPosition.x, touchPosition.y, 0);
            }
            else
            {
                m_TouchPadPointer.localPosition = Vector3.zero;
            }

            m_TP_Up.SetActive(CheckTouchPadButton(TouchPadButtonDirection.Up));
            m_TP_Bottom.SetActive(CheckTouchPadButton(TouchPadButtonDirection.Bottom));
            m_TP_Left.SetActive(CheckTouchPadButton(TouchPadButtonDirection.Left));
            m_TP_Right.SetActive(CheckTouchPadButton(TouchPadButtonDirection.Right));
            m_TP_Center.SetActive(CheckTouchPadButton(TouchPadButtonDirection.Center));

            m_AppButton.SetActive(RxController.IsButton(ControllerButtonCode.App));
            m_HomeButton.SetActive(RxController.IsButton(ControllerButtonCode.Home));


            if(m_BatteryUI)
            {
                m_BatteryUI.text = string.Format("Battery:{0}\r\nVoltage:{1}", this.RxController.Battery, RxController.BatteryVoltage);
            }
        }
        IEnumerator delayDeactive(GameObject go)
        {
            yield return new WaitForSeconds(0.2f);
            go.SetActive(false);
        }

        private bool CheckTouchPadButton(TouchPadButtonDirection direction)
        {
            TouchPadButtonDirection _direction = default(TouchPadButtonDirection);
            if (RxController.IsButton(ControllerButtonCode.TouchPadButton) && RxController.GetTouchPadPoint(out _direction))
            {
                return direction == _direction;
            }
            else return false;
        }
#pragma warning restore CS1634 
#endif
    }

}