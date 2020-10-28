using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

    public bool up, down, left, right;

    public int statesX, statesY;

    public void SetNode(int x, int y)
    {
        NodeData node = new NodeData();
        node.Room = this;
        node.StatesX = x;
        node.StatesY = y;
        statesX = x;
        statesY = y;
        NodeRoomHelper.RoomNode.Add(node);
    }

    public bool CheckConstraint(bool up, bool right, bool down, bool left)
    {
        return this.up && up || this.right && right || this.down && down || this.left && left;
    }


	void Start(){

        RoomTemplates.Instance.rooms.Add(this.gameObject);		

        //// This holds all graph data
        //AstarData data = AstarPath.active.data;

        //// This creates a Grid Graph
        //GridGraph gg = data.AddGraph(typeof(GridGraph)) as GridGraph;

        //// Setup a grid graph with some values
        //int width = 27;
        //int depth = 19;
        //float nodeSize = 1;

        //gg.center = this.transform.position;

        //gg.rotation = new Vector3(90, 0, 0);

        //// Updates internal size from the above values
        //gg.SetDimensions(width, depth, nodeSize);

        //// Scans all graphs
        //AstarPath.active.Scan();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("player"))
        {
            FOVMesh.isPlayer = true;
            //CameraController.instance.room = this;
            //CameraController.instance.setBatas(transform.position, transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("player"))
        {
            FOVMesh.isPlayer = false;
            //CameraController.instance.room = this;
            //CameraController.instance.setBatas(transform.position, transform.position);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("player"))
        {
            //CameraController.instance.room = this;
            //CameraController.instance.setBatas(transform.position, transform.position);
        }
    }

}
