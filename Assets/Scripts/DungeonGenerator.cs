using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{

    public class Cell{

        public bool visited = false;
        public bool treasureRoom = false;
        public bool[] status = new bool[4];

    }

    public Vector2 size;
    public int floorDepth = 1;
    public int startPos = 0;
    public GameObject room;
    public GameObject startRoom;
    public GameObject BossRoom;
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

    //Instantiates rooms in layout goten from Maze Generator
    void generateDungeon(){

        var bossRoom = Instantiate (BossRoom, new Vector3(0, (float)1.5*offset.y, 0), Quaternion.identity, transform);

        for(int i=0; i<size.x; i++){

            //instantiates visited rooms.
            for(int j=0; j<size.y; j++){

                if(i==0 && j==0){//setting start room
                    var newRoom = Instantiate (startRoom, new Vector3(i*offset.x, -j*offset.y, 0), Quaternion.identity, transform).GetComponent<RoomBehavior>();
                    newRoom.UpdateRoom(board[Mathf.FloorToInt(i+j*size.x)].status);
                }

                else if(board[Mathf.FloorToInt(i+j*size.x)].visited){//retreiving room layout and making room
                    
                    var newRoom = Instantiate (room, new Vector3(i*offset.x, -j*offset.y, 0), Quaternion.identity, transform).GetComponent<RoomBehavior>();
                    newRoom.UpdateRoom(board[Mathf.FloorToInt(i+j*size.x)].status);
                    newRoom.GenerateLayout(board[Mathf.FloorToInt(i+j*size.x)].treasureRoom);
                }
            }
        }

    }

    //generates the layout of the dungeon
    void MazeGenerator(){

        board = new List<Cell>(); //creating board of rooms

        for(int i=0; i<size.x; i++){

            for(int j=0; j<size.y; j++){ // adding cells to the board
                board.Add(new Cell());
            }

        }

        int currentCell = startPos; //set the starting room position in the grid

        Stack<int> path = new Stack<int>(); //making stack to trace the path

        int numberOfRooms = 3*floorDepth + Random.Range(5,7); //setting maximum number of rooms.
        if(numberOfRooms > 20){
            numberOfRooms = 20;
        }

        int generatedRooms = 0;

        while (generatedRooms<=numberOfRooms){

            //determining if room is a treasure room
            int chance = Random.Range(0,100);
            if(generatedRooms == numberOfRooms || chance <= 5){
                board[currentCell].treasureRoom = true;
            }
            
            board[currentCell].visited = true;

            //check neighbors
            List<int> neighbors = CheckNeighbors(currentCell);

            if(neighbors.Count == 0){//returning on path

                if(path.Count == 0){
                    break;
                }
                else{
                    currentCell = path.Pop();
                }
            }
            else{//adding doorways to path

                path.Push(currentCell);
                int newCell = neighbors[Random.Range(0,neighbors.Count)];

                if(generatedRooms!=numberOfRooms){

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

                }

                generatedRooms++;
            }
        }
        generateDungeon();
        AstarPath.active.Scan(); //adds pathfinding component to level
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
