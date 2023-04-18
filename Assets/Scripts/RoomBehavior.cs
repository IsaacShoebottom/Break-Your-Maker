using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavior : MonoBehaviour
{
    public GameObject[] walls; //0=up 1=down 2=right 3=left
    public GameObject[] doors; //0=none 1=1 2=2 3=3 4=4 5=5
    public GameObject[] layouts;
    
    public void UpdateRoom(bool[] status){
        for(int i=0; i<status.Length; i++) {
            doors[i].SetActive(status[i]);
        }
    }

    public void GenerateLayout(bool treasureRoom){
        int selection = Random.Range(0,6);

        switch(selection){

            case 1:
                layouts[0].SetActive(true);
                layouts[1].SetActive(false);
                layouts[2].SetActive(false);
                layouts[3].SetActive(false);
                layouts[4].SetActive(false);
                layouts[5].SetActive(false);
                break;

            case 2:
                layouts[1].SetActive(true);
                layouts[0].SetActive(false);
                layouts[2].SetActive(false);
                layouts[3].SetActive(false);
                layouts[4].SetActive(false);
                layouts[5].SetActive(false);
                break;

            case 3:
                layouts[2].SetActive(true);
                layouts[0].SetActive(false);
                layouts[1].SetActive(false);
                layouts[3].SetActive(false);
                layouts[4].SetActive(false);
                layouts[5].SetActive(false);
                break;

            case 4:
                layouts[3].SetActive(true);
                layouts[0].SetActive(false);
                layouts[1].SetActive(false);
                layouts[2].SetActive(false);
                layouts[4].SetActive(false);
                layouts[5].SetActive(false);
                break;

            case 5:
                layouts[4].SetActive(true);
                layouts[0].SetActive(false);
                layouts[1].SetActive(false);
                layouts[2].SetActive(false);
                layouts[3].SetActive(false);
                layouts[5].SetActive(false);
                break;

            default: 
                layouts[0].SetActive(false);
                layouts[1].SetActive(false);
                layouts[2].SetActive(false);
                layouts[3].SetActive(false);
                layouts[4].SetActive(false);
                layouts[5].SetActive(false);
                break;      
        }

        if(treasureRoom){
            layouts[0].SetActive(false);
            layouts[1].SetActive(false);
            layouts[2].SetActive(false);
            layouts[3].SetActive(false);
            layouts[4].SetActive(false);
            layouts[5].SetActive(true);
        }
    }
}
