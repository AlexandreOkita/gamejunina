using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] ParticleSystem _teleportParticle;
    [SerializeField] BoxCollider2D _bounds;

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(out ITeleportable _)) return;

        // Vector2 displacementToCenter = transform.position - other.transform.position;
        // other.transform.position += 2 * (Vector3) displacementToCenter;
        StartCoroutine(TeleportRoutine(other.transform));
    }

    IEnumerator TeleportRoutine(Transform objectToTeleport)
    {
        bool isXOutside = Mathf.Abs(objectToTeleport.position.x) >= _bounds.size.x / 2f;
        bool isYOutside = Mathf.Abs(objectToTeleport.position.y) >= _bounds.size.y / 2f;
        if (!isXOutside && !isYOutside) yield break;

        float xDestination = isXOutside
            ? -Mathf.Sign(objectToTeleport.position.x) * _bounds.size.x / 2f
            : objectToTeleport.position.x;
        float yDestination = isYOutside
            ? -Mathf.Sign(objectToTeleport.position.y) * _bounds.size.y / 2f
            : objectToTeleport.position.y;
        Vector2 destination = new Vector2(xDestination, yDestination);

        objectToTeleport.DOScale(Vector3.zero, 0.1f).OnComplete(() => objectToTeleport.gameObject.SetActive(false));
        var inTeleport = Instantiate(_teleportParticle, objectToTeleport.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.4f);

        var outTeleport = Instantiate(_teleportParticle, destination, Quaternion.identity);

        yield return new WaitForSeconds(0.4f);

        objectToTeleport.transform.position = destination;
        objectToTeleport.gameObject.SetActive(true);
        objectToTeleport.DOScale(Vector3.one, 0.1f);

        yield return new WaitForSeconds(0.4f);

        Destroy(inTeleport.gameObject);
        Destroy(outTeleport.gameObject);
    }
}
