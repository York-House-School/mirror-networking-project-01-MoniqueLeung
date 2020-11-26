using UnityEngine;
using UnityEngine.Events;
using Mirror;

//Script by Monique Leung November-December2020 for Computer Programming 12 G, Project Name = EXHILE

public class ProjectileBase : NetworkBehaviour
{
    public GameObject owner { get; private set; }
    public Vector3 initialPosition { get; private set; }
    public Vector3 initialDirection { get; private set; }
    public Vector3 inheritedMuzzleVelocity { get; private set; }
    public float initialCharge { get; private set; }

    public UnityAction onShoot;

    public void Shoot(WeaponController controller)
    {
        owner = controller.owner;
        initialPosition = transform.position;
        initialDirection = transform.forward;
        inheritedMuzzleVelocity = controller.muzzleWorldVelocity;
        initialCharge = controller.currentCharge;

        if (onShoot != null)
        {
            onShoot.Invoke();
        }
    }
}
