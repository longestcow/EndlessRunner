using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menucode : MonoBehaviour
{
   public Sprite DefaultSprite;
    public Sprite HoverSprite;
    // Start is called before the first frame update
    public void startGame()
    {
        SceneManager.LoadScene(1); 
        
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        print("sdfsdfdsfdsfds");
    }

    void OnMouseExit() 
    {
        //transform.GetComponent<SpriteRenderer>().sprite = HoverSprite;
        print("sdfsdfdsfdsfds");
    }
}

