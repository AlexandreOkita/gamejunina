using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private AttackBase weapon;

    private List<Transform> players;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameManager.Instance;
        this.players = gm.Players.Select(e => e.transform).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        Transform nearestPlayer = getNearestPlayer();

        if (nearestPlayer != null)
        {
            float distance = Vector3.Distance(transform.position, nearestPlayer.position);

            if (distance <= attackRange)
            {
                // Atacar o jogador mais próximo se dentro do alcance
                Attack(nearestPlayer);
            }
            else
            {
                // Mover-se em direção ao jogador mais próximo se fora do alcance
                MoveTowards(nearestPlayer);
            }
        }
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

    private void MoveTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.right = direction;
    }

    private void Attack(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.right = direction;
        weapon.TryAttack();
    }
}