using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float backgroundVerticalScrollSpeed = .001f;
    [SerializeField] float backgroundHorizontalScrollSpeed = 0f;
    Material bgMaterial;
    Vector2 bgOffset;
    // Start is called before the first frame update
    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
        bgOffset = new Vector2(backgroundHorizontalScrollSpeed, backgroundVerticalScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerX();
        CheckPlayerY();
        bgOffset = new Vector2(backgroundHorizontalScrollSpeed, backgroundVerticalScrollSpeed);
        bgMaterial.mainTextureOffset -= bgOffset * Time.deltaTime;
    }

    void CheckPlayerY()
    {
        if (player.GetYPos() == 0)
        {
            backgroundVerticalScrollSpeed = 0f;
        }
        else if (player.GetYPos() < 0)
        {
            backgroundVerticalScrollSpeed = -.05f;
        }
        else if (player.GetYPos() > 0)
        {
            backgroundVerticalScrollSpeed = .05f;
        }
    }

    void CheckPlayerX()
    {
        if (player.GetXPos() == 0)
        {
            backgroundHorizontalScrollSpeed = 0f;
        }
        else if (player.GetXPos() < 0)
        {
            backgroundHorizontalScrollSpeed = -.025f;
        }
        else if (player.GetXPos() > 0)
        {
            backgroundHorizontalScrollSpeed = .025f;
        }
    }
}
