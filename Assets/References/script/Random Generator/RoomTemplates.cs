using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomTemplates : MonoBehaviour {

    public static RoomTemplates Instance;
    public AddRoom[] bottomRooms;
    public AddRoom[] topRooms;
    public AddRoom[] leftRooms;
    public AddRoom[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    private void Awake()
    {
        Instance = this;
    }

    void Update(){

        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i == 8)
                {
                    LevelLoader.instance.LoadDone();
                    TransitionManager.Instance.FadeOut(null);
                    FindObjectOfType<AudioManager>().Play("InGame");
                    //Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

        
    }

    public AddRoom GetBottomRoomWithConstraint(bool up, bool right, bool bottom, bool left)
    {
        List<AddRoom> room = new List<AddRoom>();
        room.AddRange(bottomRooms.Where(e => e.CheckConstraint(up, right, bottom, left) != true));

        int rand = Random.Range(0, room.Count);

        return room[rand];
    }

    public AddRoom GetTopRoomWithConstraint(bool up, bool right, bool bottom, bool left)
    {
        List<AddRoom> room = new List<AddRoom>();
        room.AddRange(topRooms.Where(e => e.CheckConstraint(up, right, bottom, left) != true));

        int rand = Random.Range(0, room.Count);

        return room[rand];
    }

    public AddRoom GetLeftRoomWithConstraint(bool up, bool right, bool bottom, bool left)
    {
        List<AddRoom> room = new List<AddRoom>();
        room.AddRange(leftRooms.Where(e => e.CheckConstraint(up, right, bottom, left) != true));

        int rand = Random.Range(0, room.Count);

        return room[rand];
    }

    public AddRoom GetRightRoomWithConstraint(bool up, bool right, bool bottom, bool left)
    {
        List<AddRoom> room = new List<AddRoom>();
        room.AddRange(rightRooms.Where(e => e.CheckConstraint(up, right, bottom, left) != true));

        int rand = Random.Range(0, room.Count);

        return room[rand];
    }

}
