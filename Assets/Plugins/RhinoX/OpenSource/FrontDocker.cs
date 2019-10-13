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
    /// Attach this script to the object that you want to always dock at the front-side of the RX user.
    /// An example is to attach this script to the menu canvas.
    /// </summary>
    public class FrontDocker : MonoBehaviour
    {
#if UNITY_ANDROID
        [SerializeField]
        [Tooltip("Distance along Z-axis from head to dock position.")]
        float m_ZDepth = 4;

        /// <summary>
        /// Z-depth : canvas z-distance to head.
        /// </summary>
        /// <value>The z depth.</value>
        public float Z_Depth
        {
            get
            {
                return m_ZDepth;
            }
            set
            {
                m_ZDepth = value;
            }
        }

        [SerializeField, Tooltip ("Force docking every frame")]
        bool m_ForceEveryFrame;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Ximmerse.RhinoX.FrontDocker"/> force every frame.
        /// </summary>
        /// <value><c>true</c> if force every frame; otherwise, <c>false</c>.</value>
        public bool ForceEveryFrame
        {
            get
            {
                return m_ForceEveryFrame;
            }
            set
            {
                m_ForceEveryFrame = value;
            }
        }

        [SerializeField, Tooltip("Angular diff error to re-dock canvas, smaller values cause frequent re-docking.")]
        float m_AngleDiffError = 35;

        /// <summary>
        /// Angular diff error to re-dock canvas, smaller values cause frequent re-docking.
        /// </summary>
        /// <value>The diff error.</value>
        public float AngleDiffError
        {
            get
            {
                return m_AngleDiffError;
            }
            set
            {
                m_AngleDiffError = value;
            }
        }


        [SerializeField, Tooltip ("Delay time to start docking.")]
        float m_DockDelay = 0.5f;

        /// <summary>
        /// Gets or sets the dock delay.
        /// </summary>
        /// <value>The dock delay.</value>
        public float DockDelay
        {
            get
            {
                return m_DockDelay;
            }
            set
            {
                m_DockDelay = value;
            }
        }

        [SerializeField, Min(0.1f)]
        [Tooltip("The smaller damp time is , the faster the transform dock to eye's front.")]
        float m_DampTime = 0.3f;

        /// <summary>
        /// Gets or sets the damp time. The smaller damp time is , the faster the transform dock to eye's front.
        /// </summary>
        /// <value>The damp time.</value>
        public float DampTime
        {
            get
            {
                return m_DampTime;
            }
            set
            {
                m_DampTime = value;
            }
        }

        /// <summary>
        /// offset of docker position.
        /// modify by leaf.2019.08.30
        /// </summary>
        public Vector3 PositionOffset;

        bool m_Docking = false;

        float dampSpeed = 0;

        float dockEulerY;


        float? m_DockingStartTime;


        Transform m_HeadTransform;

        Transform headTransform
        {
            get
            {
                if (m_HeadTransform == null)
                {
                    m_HeadTransform = ARCamera.Instance.transform;
                }
                return m_HeadTransform;
            }
        }

        // Start is called before the first frame update
        IEnumerator Start()
        {
            while ((Application.platform == RuntimePlatform.Android) && (ARCamera.Instance == null || ARCamera.Instance.IsARBegan == false))
            {
                yield return null;
            }
            //calculate dock position and rotation:
            Quaternion fwdQ = Quaternion.Euler(0, headTransform.eulerAngles.y, 0);
            transform.position = headTransform.position + fwdQ * Vector3.forward * m_ZDepth;
            transform.rotation = fwdQ;
            m_Docking = false;
            dockEulerY = headTransform.eulerAngles.y;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            var headT = headTransform;
            float headEulerY = headT.eulerAngles.y;
            float eulerYDiff = Quaternion.Angle( Quaternion.Euler(0, headEulerY, 0) , Quaternion.Euler(0, dockEulerY, 0));
            if (m_ForceEveryFrame || Mathf.Abs(eulerYDiff) >= m_AngleDiffError)
            {
                m_Docking = true;
                if (m_DockingStartTime.HasValue == false)
                {
                    m_DockingStartTime = Time.time + m_DockDelay;
                }
            }

            if (m_Docking)
            {
                if (m_DockingStartTime.HasValue && Time.time < m_DockingStartTime.Value)
                {
                    //wait for delay time
                }
                else
                {
                    if(m_DampTime > 0)
                    {
                        dockEulerY = Mathf.SmoothDampAngle(dockEulerY, headEulerY, ref dampSpeed, m_DampTime);
                        float eulerYDiff2 = Quaternion.Angle(Quaternion.Euler(0, headEulerY, 0), Quaternion.Euler(0, dockEulerY, 0));
                        if (eulerYDiff2 <= 2.5f)
                        {
                            m_Docking = false;
                            m_DockingStartTime = null;//reset docking start time
                        }
                    }
                    else
                    {
                        dockEulerY = headEulerY;
                    }
                }

                transform.rotation = Quaternion.Euler(0, dockEulerY, 0);
            }

            //Update pos:
            // modify by leaf.2019.08.30
            transform.position = headTransform.position + Quaternion.Euler(0, dockEulerY, 0) * Vector3.forward * m_ZDepth + PositionOffset;
        }
#endif
    }
}