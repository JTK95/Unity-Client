using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class SphereMovement : MonoBehaviour
    {
        public void SphereMove(float xpos, float zpos)
        {
            gameObject.transform.position = new Vector3(xpos, 65.718f, zpos);
        }
    }
}