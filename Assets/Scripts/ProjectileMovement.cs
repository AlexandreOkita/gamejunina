using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    public float velocidade = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
    }
}
