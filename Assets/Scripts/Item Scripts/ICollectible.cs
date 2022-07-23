using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICollectible : MonoBehaviour
{
    public abstract void Collect();



    public void TurnInvisble()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null) return;

        Color color = new Color();
        color.a = 0.0f;
        spriteRenderer.color = color;
    }
}
