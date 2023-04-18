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
    private bool opened;
    
    void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        opened =false;
    }

    //spawns item
    public void SpawnItem(){

        if(!opened){
            ChangeSprite();
            var Item = Instantiate(items[Random.Range(0,items.Count - 1)], (transform.position + new Vector3(0, offset, 0)), Quaternion.identity, transform);
        }
    }

    //spawns key for player
    public void SpawnKey(){

        if(!opened){
            ChangeSprite();
            var Item = Instantiate(key, (transform.position + new Vector3(0, offset, 0)), Quaternion.identity, transform);
        }

    }

    //updates sprite
    void ChangeSprite(){
        spriteRenderer.sprite = newSprite;
        opened = true;
    }
}
