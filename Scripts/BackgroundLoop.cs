using UnityEngine; // Imports Unity Engine namespace

public class LoopingBackground : MonoBehaviour // Class for looping background effect
{
    public float backgroundSpeed; // Controls background scroll speed

    public Renderer backgroundRenderer; // Reference to the Renderer component

    void Update() // Called once per frame
    {
        float offsetY = Time.time * backgroundSpeed; // Calculates offset for scrolling

        Vector2 offset = new Vector2(0, offsetY); // Creates a new 2D vector for offset

        backgroundRenderer.material.mainTextureOffset = offset; // Applies offset to background
    }
}
