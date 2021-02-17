using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

    public Sprite swordSprite;
    public Sprite sword2Sprite;
    public Sprite sword3Sprite;
    public Sprite armorSprite;
    public Sprite armor2Sprite;
    public Sprite armor3Sprite;
    public Sprite helmetSprite;
    public Sprite helmet2Sprite;
    public Sprite helmet3Sprite;
    public Sprite shoesSprite;
    public Sprite shoes2Sprite;
    public Sprite point;
    public Sprite healthPotionSprite;
    public Sprite staminaPotionSprite;

    public static ItemAssets Instance {
        get;
        private set;
    }

    private void Awake() {
        Instance = this;
    }


}
