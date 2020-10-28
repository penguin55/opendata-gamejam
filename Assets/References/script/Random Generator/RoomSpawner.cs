using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomSpawner : MonoBehaviour {

	public AddRoom roomParent;
	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private int rand;
	public bool spawned = false;

    public LayerMask layer;

    public float waitTime = 4f;

    public bool check;

    public GameObject thisRoom;

    float time = 1f;

	void Start(){
        layer = LayerMask.GetMask("Obstacle");
		//Destroy(gameObject, waitTime);
        if (RoomTemplates.Instance.rooms.Count <= 10) Invoke("Spawn", .1f);
    }

    private void Update()
    {
        if (time < 0)
        {
            if (RoomTemplates.Instance.rooms.Count > 10)
            {
                if (!spawned && !check)
                {
                    Instantiate(RoomTemplates.Instance.closedRoom, transform.position, Quaternion.identity);
                    check = true;
                }
            }
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    IEnumerator SpawnClosedRoom()
    {
        yield return new WaitForSeconds(8f);
    }


	void Spawn(){
		if(spawned == false){
            spawned = true;
			if(openingDirection == 1){
				// Need to spawn a room with a BOTTOM door.

				bool up = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX && e.StatesY == roomParent.statesY + 2);
				bool right = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX + 1 && e.StatesY == roomParent.statesY + 1);
				bool bottom = false;
				bool left = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX - 1 && e.StatesY == roomParent.statesY + 1);

				AddRoom room = RoomTemplates.Instance.GetBottomRoomWithConstraint(up, right, bottom, left);
				room.SetNode(roomParent.statesX, roomParent.statesY + 1);

				Instantiate(room.gameObject, transform.position, room.transform.rotation);
			} else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.

				bool up = false;
				bool right = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX + 1 && e.StatesY == roomParent.statesY - 1);
				bool bottom = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX && e.StatesY == roomParent.statesY - 2 );
				bool left = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX - 1 && e.StatesY == roomParent.statesY - 1);

				AddRoom room = RoomTemplates.Instance.GetTopRoomWithConstraint(up, right, bottom, left);
				room.SetNode(roomParent.statesX, roomParent.statesY - 1);
				Instantiate(room.gameObject, transform.position, room.transform.rotation);
			} else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.

				bool up = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX + 1 && e.StatesY == roomParent.statesY + 1);
				bool right = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX + 2 && e.StatesY == roomParent.statesY);
				bool bottom = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX + 1 && e.StatesY == roomParent.statesY - 1);
				bool left = false;

				AddRoom room = RoomTemplates.Instance.GetLeftRoomWithConstraint(up, right, bottom, left);
				room.SetNode(roomParent.statesX + 1, roomParent.statesY);
				Instantiate(room.gameObject, transform.position, room.transform.rotation);
			} else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.

				bool up = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX - 1 && e.StatesY == roomParent.statesY + 1);
				bool right = false;
				bool bottom = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX - 1 && e.StatesY == roomParent.statesY - 1);
				bool left = NodeRoomHelper.RoomNode.Any(e => e.StatesX == roomParent.statesX - 2 && e.StatesY == roomParent.statesY);

				AddRoom room = RoomTemplates.Instance.GetRightRoomWithConstraint(up, right, bottom, left);
				room.SetNode(roomParent.statesX - 1, roomParent.statesY);
				Instantiate(room.gameObject, transform.position, room.transform.rotation);
			}

            // This holds all graph data
            AstarData data = AstarPath.active.data;

            // This creates a Grid Graph
            GridGraph gg = data.AddGraph(typeof(GridGraph)) as GridGraph;

            // Setup a grid graph with some values
            int width = 26;
            int depth = 18;
            float nodeSize = 1;

            gg.center = this.transform.position;

            gg.rotation = new Vector3(90, 0, 0);

            gg.collision.heightCheck = false;

            gg.collision.mask = layer;
            // Updates internal size from the above values
            gg.SetDimensions(width, depth, nodeSize);
            gg.collision.use2D = true;
            gg.collision.collisionCheck = true;
            gg.collision.type = ColliderType.Ray;

            // Scans all graphs
            AstarPath.active.Scan();
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(RoomTemplates.Instance.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }

        if (other.CompareTag("Room") || other.CompareTag("Closed"))
        {
            spawned = true;
            thisRoom = other.gameObject;
            Destroy(this.gameObject);
        }
    }
}
