using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantController : MonoBehaviour
{
    
    public GameObject acid;

    private ArrayList acids;

	private GameObject player;
	private Animator anim;
	private AudioSource audioSource;
	
	// 0 = Bite
	// 1 = Acid
	public AudioClip[] sounds;
    
	private float timer;
	private float lastShot;

	private int health = 100;

	private bool enemySpotted = false;

    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
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
                    audioSource.clip = sounds[0];
                    audioSource.Play();
                    anim.Play("Bite");
                    player.GetComponent<PlayerLogic>().Damage();
                }else{
                    lastShot = timer;
                    AcidAttack();
                    anim.Play("Idle");
                }
            }
        }
        if (health <= 0) {
	        player.GetComponent<PlayerLogic>().Win();
	        Destroy(gameObject);
        }
    }

    void AcidAttack(){
	    audioSource.clip = sounds[1];
	    audioSource.Play();
        Instantiate(acid, new Vector2(player.transform.position.x, player.transform.position.y), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
	    if (other.gameObject.CompareTag("Bullet")) {
			Destroy(other.gameObject);
			health--;
		}
    }


}
