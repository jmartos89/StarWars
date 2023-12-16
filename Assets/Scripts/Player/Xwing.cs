using UnityEngine;

public class Xwing : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private int speed;
    [SerializeField]
    private int turnSpeed;

    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullet;

    AudioSource shootAudio;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shootAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Turning();
        Attack();
    }

    // Movemos la nave en el eje X y Z
    private void Movement()
    {
        // Teclas a utilizar: a y d
        float horizontal = Input.GetAxis("Horizontal");

        //Teclas a utilizar: w y s
        float vertical = Input.GetAxis("Vertical");

        //Creamos la dirección hacía donde queremos ir
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        //Movemos la nave
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    //Movemos la nave en el ejeY
    private void Turning()
    {
        //Recoger el desplazamiento horizontal del ratón
        float xMouse = Input.GetAxis("Mouse X");

        //Recoget el desplazamiento vertical del ratón
        float yMouse = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-yMouse, xMouse, 0);

        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime);
    }

    //Atacamos
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootAudio.Play();
            
            for(int i = 0; i < posRotBullet.Length; ++i) {
                Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
            }
        }
    }
}
