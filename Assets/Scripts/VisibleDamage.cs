using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleDamage : MonoBehaviour
{
    GameObject player;
    SpriteRenderer spriterend;
    private DamageHandlerPlayer playerDamage;

    public Sprite[] damageSprites1;
    public Sprite[] damageSprites2;
    public Sprite[] damageSprites3;

    public SaveScriptableObject saveScriptableObject;

    // Start is called before the first frame update
    void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
        player = gameObject;
        playerDamage = player.GetComponentInParent<DamageHandlerPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDamage.health == 1)
        {
            switch (saveScriptableObject.skinIndex)
            {
                case 0:

                    spriterend.sprite = damageSprites1[2];

                    break;

                case 1:

                    spriterend.sprite = damageSprites1[2];

                    break;

                case 2:

                    spriterend.sprite = damageSprites1[2];

                    break;

                case 3:

                    spriterend.sprite = damageSprites2[2];

                    break;

                case 4:

                    spriterend.sprite = damageSprites2[2];

                    break;

                case 5:

                    spriterend.sprite = damageSprites2[2];

                    break;

                case 6:

                    spriterend.sprite = damageSprites3[2];

                    break;

                case 7:

                    spriterend.sprite = damageSprites3[2];

                    break;

                case 8:

                    spriterend.sprite = damageSprites3[2];

                    break;

                default:

                    spriterend.sprite = null;

                    break;
            }
            //spriterend.sprite = damageSprites[2];

        } else if(playerDamage.health == 2)
        {
            switch (saveScriptableObject.skinIndex)
            {
                case 0:

                    spriterend.sprite = damageSprites1[1];

                    break;

                case 1:

                    spriterend.sprite = damageSprites1[1];

                    break;

                case 2:

                    spriterend.sprite = damageSprites1[1];

                    break;

                case 3:

                    spriterend.sprite = damageSprites2[1];

                    break;

                case 4:

                    spriterend.sprite = damageSprites2[1];

                    break;

                case 5:

                    spriterend.sprite = damageSprites2[1];

                    break;

                case 6:

                    spriterend.sprite = damageSprites3[1];

                    break;

                case 7:

                    spriterend.sprite = damageSprites3[1];

                    break;

                case 8:

                    spriterend.sprite = damageSprites3[1];

                    break;

                default:

                    spriterend.sprite = null;

                    break;
            }

            //spriterend.sprite = damageSprites[1];
        }
        else if(playerDamage.health == 3)
        {
            switch (saveScriptableObject.skinIndex)
            {
                case 0:

                    spriterend.sprite = damageSprites1[0];

                    break;

                case 1:

                    spriterend.sprite = damageSprites1[0];

                    break;

                case 2:

                    spriterend.sprite = damageSprites1[0];

                    break;

                case 3:

                    spriterend.sprite = damageSprites2[0];

                    break;

                case 4:

                    spriterend.sprite = damageSprites2[0];

                    break;

                case 5:

                    spriterend.sprite = damageSprites2[0];

                    break;

                case 6:

                    spriterend.sprite = damageSprites3[0];

                    break;

                case 7:

                    spriterend.sprite = damageSprites3[0];

                    break;

                case 8:

                    spriterend.sprite = damageSprites3[0];

                    break;

                default:

                    spriterend.sprite = null;

                    break;
            }

            //spriterend.sprite = damageSprites[0];
        }
        else
        {
            spriterend.sprite = null;
        }
    }
}
