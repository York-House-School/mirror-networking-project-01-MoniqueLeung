using UnityEngine;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE
public class CompassElement : NetworkBehaviour
{
    [Tooltip("The marker on the compass for this element")]
    public CompassMarker compassMarkerPrefab;
    [Tooltip("Text override for the marker, if it's a direction")]
    public string textDirection;

    Compass m_Compass;

    void Awake()
    {
        m_Compass = FindObjectOfType<Compass>();
        DebugUtility.HandleErrorIfNullFindObject<Compass, CompassElement>(m_Compass, this);

        var markerInstance = Instantiate(compassMarkerPrefab);

        markerInstance.Initialize(this, textDirection);
        m_Compass.RegisterCompassElement(transform, markerInstance);
    }

    void OnDestroy()
    {
        m_Compass.UnregisterCompassElement(transform);
    }
}
