using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test : MonoBehaviour
    {
        static Plane plane;

        void Start()
        {
            plane = new Plane(transform.forward, transform.position);
            Debug.Log(CalcPosition(new Vector2(0f, 0f)));
            Debug.Log(CalcPosition(new Vector2(Screen.width, 0f)));
            Debug.Log(CalcPosition(new Vector2(0f, Screen.height)));
            Debug.Log(CalcPosition(new Vector2(Screen.width, Screen.height)));
        }

        public Vector3 CalcPosition(Vector2 screenPos)
        {
            //Ray ray = UICamera.currentCamera.ScreenPointToRay(screenPos);    // для NGUI
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            float dist = 0f;
            Vector3 pos = Vector3.zero;

            if (plane.Raycast(ray, out dist))
                pos = ray.GetPoint(dist);

            return pos;
        }
    }

}