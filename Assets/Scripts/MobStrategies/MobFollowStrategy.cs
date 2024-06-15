using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class MobFollowStrategy : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    private List<Transform> players;

    private void Start()
    {
        GameManager gm = GameManager.Instance;
        this.players = gm.Players.Select(e => e.transform).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        Transform nearestPlayer = getNearestPlayer();
        
        Vector2 direction = (Vector2)(nearestPlayer.position - transform.position);
        direction.Normalize();

        transform.position += (Vector3)(direction * (speed * Time.deltaTime));
        transform.right = direction;
    }

    private Transform getNearestPlayer()
    {
        Transform nearestPlayer = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (Transform player in players)
        {
            float distance = Vector3.Distance(player.position, currentPos);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPlayer = player;
            }
        }
        return nearestPlayer;
    }
}
