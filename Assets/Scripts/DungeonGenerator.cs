using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{

    public class Cell{

        public bool visited = false;
        public bool[] status = new bool[4];

    }

    public Vector2 size;
    public int floorDepth = 1;
    public int startPos = 0;
    public GameObject room;
    public Vector2 offset;

    List<Cell> board;

    // Start is called before the first frame update
    void Start(){

        MazeGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateDungeon(){

        for(int i=0; i<size.x; i++){

            for(int j=0; j<size.y; j++){
                var newRoom = Instantiate (room, new Vector3(i*offset.x, 0, -j*offset.y), Quaternion.identity, transform).GetComponent<RoomBehavior>();
                newRoom.UpdateRoom(board[Mathf.FloorToInt(i+j*size.x)].status);
            }
        }

    }

    void MazeGenerator(){

        board = new List<Cell>();

        for(int i=0; i<size.x; i++){

            for(int j=0; j<size.y; j++){
                board.Add(new Cell());
            }

        }

        int currentCell = startPos;

        Stack<int> path = new Stack<int>();

        int numberOfRooms = 3*floorDepth + Random.Range(5,7);
        if(numberOfRooms > 20){
            numberOfRooms = 20;
        }

        int generatedRooms = 0;

        while (generatedRooms<=numberOfRooms){
            
            board[currentCell].visited = true;

            //check neighbors
            List<int> neighbors = CheckNeighbors(currentCell);

            if(neighbors.Count == 0){

                if(path.Count == 0){
                    break;
                }
                else{
                    currentCell = path.Pop();
                }
            }
            else{

                path.Push(currentCell);
                int newCell = neighbors[Random.Range(0,neighbors.Count)];

                if(newCell > currentCell){//down or right

                    if(newCell - 1 == currentCell){ //right
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
                    }
                    else{ //down
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;
                    }

                }
                else{//up or left

                    if(newCell + 1 == currentCell){ //left
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else{ //up
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;
                    }

                }

                generatedRooms++;
            }
        }
        generateDungeon();
    }

     List<int> CheckNeighbors(int cell){

        List<int> neighbors = new List<int>();

        //check up neighbor
        if(cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].visited){
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
        }

        //check down neighbor
        if(cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].visited){
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }

        //check right neighbor
        if((cell+ 1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].visited){
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        //check left neighbor
        if(cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited){
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }


        return neighbors;
    }
}
