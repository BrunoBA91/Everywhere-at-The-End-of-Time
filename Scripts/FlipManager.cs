using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipManager : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;
    public AudioSource flipSound;

    public void OnMouseDown()
    {
        if (matched == false)
        {
            GameControl controlScript = gameControl.GetComponent<GameControl>();
            if (spriteRenderer.sprite == back)
            {
                //if (gameControl.GetComponent<GameControl>().TwoCardsUp() == false)
                if (controlScript.TokenUp(this))
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    controlScript.CheckTokens();
                    //gameControl.GetComponent<GameControl>().AddVisibleFace(faceIndex);
                    //matched = gameControl.GetComponent<GameControl>().CheckMatch();
                }
            }
            else
            {
                spriteRenderer.sprite = back;
                controlScript.TokenDown(this);
                //gameControl.GetComponent<GameControl>().RemoveVisibleFace(faceIndex);
            }
        } 
    }

    private void Awake()
    {
        gameControl = GameObject.Find("GameControl");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
