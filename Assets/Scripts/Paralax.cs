using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float scrollSpeedX = 0.5f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        var offsetX = Time.time * scrollSpeedX;
        Vector2 newOffset = new Vector2(offsetX, 0);
        rend.material.mainTextureOffset = newOffset;
    }


}
