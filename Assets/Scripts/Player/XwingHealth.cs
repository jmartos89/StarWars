using UnityEngine;
using UnityEngine.UI;

public class XwingHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float damageBullet;
    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private ParticleSystem bigExplosion;
    [SerializeField]
    private ParticleSystem smallExplosion;


    void Awake()
    {
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
        bigExplosion.Stop();
        smallExplosion.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            smallExplosion.Play();
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth / maxHealth;   
            Destroy(other.gameObject);

            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        bigExplosion.Play();
        Camera.main.transform.SetParent(null);
        Destroy(gameObject, bigExplosion.main.duration);
    }
}
