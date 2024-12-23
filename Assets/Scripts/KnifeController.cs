using UnityEngine;

public class KnifeController : MonoBehaviour
{
    private Rigidbody2D KnifeRigidBody;
    [SerializeField] private float MoveSpeed;
    private bool AllowShoot;
    private void Start()
    {
        GetComponentValues();
    }

    private void Update()
    {
        HandleShootInput();
    }
    private void FixedUpdate()
    {
        Shoot();
    }
    private void HandleShootInput()
    {
        if(Input.GetMouseButtonDown(0)) // 0 : Left --- 1 : Right ---  2: middle
        {
            AllowShoot = true;
        }
    }
    private void Shoot()
    {
        if (AllowShoot)
        {
            KnifeRigidBody.AddForce(Vector2.up * MoveSpeed * Time.fixedDeltaTime );
        }
    }
    private void GetComponentValues()
    {
        KnifeRigidBody = GetComponent<Rigidbody2D>();
    }
}
