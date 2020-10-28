using System.Collections.Generic;

public class NodeRoomHelper
{
    public static List<NodeData> RoomNode = new List<NodeData>();
}

[System.Serializable]
public class NodeData
{
    private int statesX, statesY;
    private AddRoom room;

    public AddRoom Room
    {
        get
        {
            return room;
        }

        set
        {
            room = value;
        }
    }

    public int StatesX
    {
        get
        {
            return statesX;
        }

        set
        {
            statesX = value;
        }
    }

    public int StatesY
    {
        get
        {
            return statesY;
        }

        set
        {
            statesY = value;
        }
    }
}