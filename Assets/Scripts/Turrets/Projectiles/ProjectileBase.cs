using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    protected float powerValue;
    protected float speed;
    protected float remainingLifetime = float.PositiveInfinity;

    public void SetRange(float range)
    {
        remainingLifetime = range / speed;
    }

    virtual protected void Update()
    {
        Move();

        remainingLifetime -= Time.deltaTime;
        if (remainingLifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void Move();
}