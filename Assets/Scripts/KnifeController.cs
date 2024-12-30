using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeController : MonoBehaviour
{
    private KnifeManager knifeManager;
    private Rigidbody2D KnifeRigidBody;
    [SerializeField] private float MoveSpeed;
    private bool CanShoot;
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
        if (Input.GetMouseButtonDown(0)) // 0 : Left --- 1 : Right ---  2: middle
        {
            CanShoot = true;
        }
    }
    private void Shoot()
    {
        if (CanShoot)
        {
            KnifeRigidBody.AddForce(Vector2.up * MoveSpeed * Time.fixedDeltaTime);
            knifeManager.setDisableKnifeIconColor();

        }
    }
    private void GetComponentValues()
    {
        KnifeRigidBody = GetComponent<Rigidbody2D>();
        knifeManager= GameObject.FindObjectOfType<KnifeManager>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            CanShoot = false;
            KnifeRigidBody.isKinematic = true;
            transform.SetParent(other.gameObject.transform);
            knifeManager.SetActiveKnife();
        }
        if (other.gameObject.CompareTag("Knife"))
        {
            SceneManager.LoadScene(0);
        }

    }
}
