using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
namespace Ximmerse.RhinoX
{
    public class PointerEventChangeView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Material NormalMaterial, HighLightMaterial;
        public void OnPointerEnter(PointerEventData eventData)
        {
            GetComponent<Renderer>().sharedMaterial = HighLightMaterial;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GetComponent<Renderer>().sharedMaterial = NormalMaterial;
        }
    }
}