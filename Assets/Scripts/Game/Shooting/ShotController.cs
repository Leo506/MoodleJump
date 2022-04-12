using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    public class ShotController : MonoBehaviour
    {
        [SerializeField] ShotObj shotPrefab;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Instantiate(shotPrefab, transform.position, Quaternion.identity).Init(Vector2.up);
            }
        }
    }
}