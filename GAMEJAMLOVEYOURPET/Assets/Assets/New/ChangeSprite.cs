using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite[] textures; // Array of 2D textures to choose from
    public SpriteRenderer spriteRenderer; // Reference to the sprite renderer component

    void Start()
    {
        int index = Random.Range(0, textures.Length); // Generate a random index from 0 to textures.Length - 1
        spriteRenderer.sprite = textures[index]; // Set the sprite renderer's sprite to the randomly selected texture
    }
}
