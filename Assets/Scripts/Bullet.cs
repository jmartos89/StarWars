using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private int speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
