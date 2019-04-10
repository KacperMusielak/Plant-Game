using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBounds : MonoBehaviour
{
    Collider m_Collider;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

}
