using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public List<GameObject> items;
    public GameObject key;
    public float offset;
    
    void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    //spawns item
    public void SpawnItem(){

        ChangeSprite();
        var Item = Instantiate(items[Random.Range(0,items.Count - 1)], new Vector3(0, offset, 0), Quaternion.identity, transform);
    }

    //spawns key for player
    public void SpawnKey(){

        ChangeSprite();
        var Item = Instantiate(key, new Vector3(0, offset, 0), Quaternion.identity, transform);
    }

    //updates sprite
    void ChangeSprite(){
        spriteRenderer.sprite = newSprite;
    }
}
