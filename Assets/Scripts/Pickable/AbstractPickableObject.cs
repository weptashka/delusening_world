using UnityEngine;

public abstract class AbstractPickableObject : MonoBehaviour
{
    protected void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovementController playerMovementController))
        {
            Collect();
        }
    }

    protected abstract void Collect();
}
