using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    public ParticleSystem TouchParticle; // Assign your explosion particle effect in the Inspector
    public ScoreManager scoreManager; // Add this line
    public AudioClip explosionSound; // Add this line
    private AudioSource audioSource; // Add this line

    void Start() // Add this method
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        audioSource = GetComponent<AudioSource>(); // Add this line
        if (audioSource == null) // Add this block
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Play the explosion particle effect if it's assigned
            if (TouchParticle != null)
            {
                TouchParticle.Play(); // Play the explosion particle effect
                audioSource.PlayOneShot(explosionSound); // Add this line
            }

            Destroy(other.gameObject); // Destroy the enemy

            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                StartCoroutine(DeactivateAfterDelay());
            }
            else
            {
                StartCoroutine(GetHurt());
            }

            // scoreManager.DecreaseScore(); // Comment out or remove this line
        }
    }

    IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(TouchParticle.main.duration);
        gameObject.SetActive(false);
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}
