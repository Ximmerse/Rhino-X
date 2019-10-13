#if UNITY_EDITOR || UNITY_ANDROID
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Ximmerse.RhinoX
{
    /// <summary>
    /// Grabable script : attach this script to gameObject to make the game object able to be grabbed by controller.
    /// The RXController must turn on the raycaster to grab.
    /// </summary>
    public class Grabable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public class OnGrabEvent : UnityEngine.Events.UnityEvent<Transform>
        {

        }

        Vector3 diffPoint;

        Quaternion diffQ;

        UnityEngine.Pose awakePose;

        Coroutine dragCoroutine;

        Transform dragAnchor;

        bool isDragging = false;

        /// <summary>
        /// On grab event : begin , update, end. 
        /// The event parameter is the grab anchor transform.
        /// </summary>
        public OnGrabEvent OnGrabBegin, OnGrabUpdate, OnGrabEnd;

        void Awake()
        {
            awakePose = new UnityEngine.Pose(transform.position, transform.rotation);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            var raycaster = eventData.pointerPressRaycast.module;
            var world2local = Matrix4x4.TRS(raycaster.transform.position, raycaster.transform.rotation, raycaster.transform.lossyScale).inverse;
            diffPoint = world2local.MultiplyPoint(transform.position);
            diffQ = world2local.rotation * transform.rotation;
            dragAnchor = raycaster.transform;
            isDragging = true;

            dragCoroutine = StartCoroutine(OnDrag());

            OnGrabBegin?.Invoke(dragAnchor);
        }

        IEnumerator OnDrag()
        {
            while (isDragging)
            {
                transform.position = dragAnchor.TransformPoint(diffPoint);
                transform.rotation = dragAnchor.rotation * diffQ;
                OnGrabUpdate?.Invoke(dragAnchor);
                yield return null;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (dragCoroutine != null)
            {
                StopCoroutine(dragCoroutine);
            }

            OnGrabEnd?.Invoke(dragAnchor);

            dragAnchor = null;
        }
    }
}
#endif