using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidController : MonoBehaviour
{
	private Animator anim;
    
	private GameObject player;
    
	private float timer;
	private float lastHit;

    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
        anim.Play("Idle");
        timer = 0;
        lastHit = 0;
		player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;

        if(timer > 2 && !active){
            active = true;
            anim.Play("Active");
        }

        if(Vector3.Distance(player.transform.position, transform.position) < 5 && timer - lastHit > 2){
            player.GetComponent<PlayerLogic>().Damage();
            lastHit = timer;
        }

        if(timer > 20){
			Destroy(gameObject);            
        }
    }
}
