using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class TimedSelfDestruct : NetworkBehaviour
{
    public float lifeTime = 1f;

    float m_spawnTime;

    void Awake()
    {
        m_spawnTime = Time.time;
    }

    private void Update()
    {
        if(Time.time > m_spawnTime + lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
