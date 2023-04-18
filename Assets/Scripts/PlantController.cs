using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    
    public GameObject acid;

    private ArrayList acids;

	private GameObject player;
	private Animator anim;
    
	private float timer;
	private float lastShot;

	private int health = 100;

	private bool enemySpotted = false;

    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
		timer = 0;
		lastShot = 0;
		player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;

        if(Vector3.Distance(player.transform.position, transform.position) < 130 && !enemySpotted){
            enemySpotted = true;
            lastShot = timer;
        }

        if(enemySpotted){
            if( timer - lastShot > 2){
                if(Vector3.Distance(player.transform.position, transform.position) < 30){
                    lastShot = timer;
                    anim.Play("Bite");
                    player.GetComponent<PlayerLogic>().Damage();
                }else{
                    lastShot = timer;
                    AcidAttack();
                    anim.Play("Idle");
                }
            }
        }
    }

    void AcidAttack(){
        Instantiate(acid, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Bullet") {
			Destroy(other.gameObject);
			health--;
		}

		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
