using UnityEngine;

public class Teleporter : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(out ITeleportable _)) return;

        Vector2 displacementToCenter = transform.position - other.transform.position;
        other.transform.position += 2 * (Vector3) displacementToCenter;
    }
}
