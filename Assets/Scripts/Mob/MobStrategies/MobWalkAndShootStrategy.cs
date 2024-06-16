using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    static int SPEED_PARAMETER_HASH = Animator.StringToHash("Speed");

    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private AttackBase weapon;
    [SerializeField] Animator _animator;

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

        foreach (PlayerController player in GameManager.Instance.Players)
        {
            if (!player.Health.IsAlive) continue;

            float distance = Vector3.Distance(player.transform.position, currentPos);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPlayer = player.transform;
            }
        }
        return nearestPlayer;
    }

    private void MoveTowards(Transform target)
    {
        Vector3 delta = (target.position - transform.position);
        Vector3 direction = delta.normalized;
        transform.position += direction * speed * Time.deltaTime;
        weapon.transform.right = direction;

        _animator.SetFloat(SPEED_PARAMETER_HASH, delta.magnitude);

        if (delta.magnitude > 0.05f)
        {
            _animator.gameObject.transform.right = Vector2.Dot(delta, Vector2.right) * Vector2.right;
        }
    }

    private void Attack(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        weapon.transform.right = direction;
        weapon.TryAttack(1, 1);
    }
}
