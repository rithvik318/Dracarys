using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public float frameRate = 12f; // Frames per second

    private SpriteRenderer spriteRenderer;
    private int frame;
    private float timeSinceLastFrame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(Animate());
    }

    private void OnDisable()
    {
        StopCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            if (sprites != null && sprites.Length > 0)
            {
                timeSinceLastFrame += Time.deltaTime;

                if (timeSinceLastFrame >= 1f / frameRate)
                {
                    timeSinceLastFrame -= 1f / frameRate;
                    frame = (frame + 1) % sprites.Length;
                    spriteRenderer.sprite = sprites[frame];
                }
            }

            yield return null;
        }
    }

    
}
