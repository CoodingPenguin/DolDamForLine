using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    public bool loop;
    public float frameSeconds;
    //The file location of the sprites within the resources folder
    public string locationExposed;
    public string locationCovered;
    private SpriteRenderer spr;
    private Sprite[] sprites;
    private int frame = 0;
    private float deltaTime = 0;

    public float coveredScale;

    public GameManager gameManager;

    private bool isSetCovered; //ball size에 따라 스프라이트 변경 유무
    private bool isSetExposed; //ball size에 따라 스프라이트 변경 유무

    // Use this for initialization
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>(locationExposed);
        gameManager = GameManager.instance;
        isSetExposed = false;
        isSetCovered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameState == GameManager.GameState.PLAYING)
        {
            //Keep track of the time that has passed
            deltaTime += Time.deltaTime;
            frameSeconds = Mathf.PI * sprites[0].rect.width / gameManager.GetScrollSpeed() / sprites.Length / 9.6f / 2.5f;

            /*Loop to allow for multiple sprite frame 
             jumps in a single update call if needed
             Useful if frameSeconds is very small*/
            while (deltaTime >= frameSeconds)
            {
                deltaTime -= frameSeconds;
                frame++;
                if (loop)
                    frame %= sprites.Length;
                //Max limit
                else if (frame >= sprites.Length)
                    frame = sprites.Length - 1;
            }
            //Animate sprite with selected frame
            spr.sprite = sprites[frame];

            
            if(PlayerMove.instance.ballScale > coveredScale && !isSetCovered)
            {
                Debug.Log("스프라이트 변경");
                sprites = null;
                sprites = Resources.LoadAll<Sprite>(locationCovered);
                isSetCovered = true;
                isSetExposed = false;
            }else if(PlayerMove.instance.ballScale < coveredScale && !isSetExposed)
            {
                Debug.Log("스프라이트 변경");
                sprites = null;
                sprites = Resources.LoadAll<Sprite>(locationExposed);
                isSetCovered = false;
                isSetExposed = true;
            }
            
        }
    }


}
