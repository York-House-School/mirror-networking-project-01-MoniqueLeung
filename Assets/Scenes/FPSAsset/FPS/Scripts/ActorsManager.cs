using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class ActorsManager : NetworkBehaviour
{

    public List<Actor> actors { get; private set; }

    private void Awake()
    {
        actors = new List<Actor>();
    }
}
