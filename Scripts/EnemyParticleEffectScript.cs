using UnityEngine;

public class EnemyParticleEffectScript : MonoBehaviour
{
    public ParticleSystem particleEffect; // Assign your particle effect in the Inspector
    public GameObject Enemy; // Assign your enemy game object in the Inspector

    void Start()
    {
        // If the particle effect is not playing on start, play it
        if (!particleEffect.isPlaying)
        {
            particleEffect.Play();
        }
    }

    void Update()
    {
        // Always emit particles from the back of the enemy
        Vector3 particlePosition = Enemy.transform.position - Enemy.transform.forward;
        particleEffect.transform.position = particlePosition;
    }
}
