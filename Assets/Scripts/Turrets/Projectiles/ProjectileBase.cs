using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    protected float powerValue;
    protected float speed;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();

    // Hit detection (OnTriggerEnter2D vs OnTriggerStay2D) is implemented per subclass,
    // since Cannon/Shotgun/Aegis only need a single Enter per target, while Pylon's
    // beam needs Stay with its own internal cooldown to tick repeatedly.
}
