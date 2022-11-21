using UnityEngine;

public class WaterScipt : MonoBehaviour
{
    [SerializeField]
    private GameObject Particle_1,
        Particle_2;

    private bool IsOnWater()
    {
        return col.IsTouching(cf2);
    }

    private float timer;
    private Collider2D col;
    private ContactFilter2D cf2;
    private LayerMask mask;

    private void Awake()
    {
        mask = LayerMask.GetMask("Bounce");
        col = transform.GetComponent<Collider2D>();
        cf2.useLayerMask = true;
        cf2.useTriggers = true;
        cf2.layerMask = mask;
    }

    //instanciate the Particle at point.
    private void Update()
    {
        if (IsOnWater())
        {
            timer += Time.deltaTime;
            if (timer > 1.3f)
            {
                Instantiate(
                    Particle_2,
                    Handlers.main.BounceMov.transform.position,
                    Quaternion.identity
                );
                timer = 0;
            }
            return;
        }
        timer = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 CollisionPoint = other.transform.position;
        Instantiate(Particle_1, CollisionPoint, Quaternion.identity);
    }
}
