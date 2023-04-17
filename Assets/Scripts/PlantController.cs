using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    
	public GameObject player;
	private Animator anim;
    
	private float timer;
	private float lastShot;

	private int health = 30;

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
        }
    }
}
