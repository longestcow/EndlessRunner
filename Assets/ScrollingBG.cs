using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField] private RawImage img;
    public float x;

    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x,0) * Time.deltaTime, img.uvRect.size);
    }
}
