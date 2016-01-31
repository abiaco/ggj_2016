using UnityEngine;
using System.Collections;

public static class GodUtils{

    public static ActionType getRandomActionType()
    {
        System.Random rand = new System.Random();
        int r = rand.Next(0, sizeof(ActionType));
        switch (r)
        {
            case 0:
                return ActionType.idle;
            case 1:
                return ActionType.moveLeft;
            case 2:
                return ActionType.moveRight;
            case 3:
                return ActionType.jump;
            case 4:
                return ActionType.sacrifice;
            case 5:
                return ActionType.save;

        }
        return ActionType.idle;
    }

    public static GameObject getNearbyTile()
    {
        Rigidbody player = GameManager.Instance.ThePlayer.GetComponent<Rigidbody>();
        int xpos = 0;
        if (GameManager.Instance.ThePlayer.GetComponent<Controller>().action.getType() == ActionType.moveLeft) xpos = -2;
        else if (GameManager.Instance.ThePlayer.GetComponent<Controller>().action.getType() == ActionType.moveRight) xpos = 2;
        
        Vector3 newpos = player.position + new Vector3(GameManager.Instance.GetComponent<PlayerInput>().speed * xpos, 0, 0);
        player.transform.Translate(newpos);

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Environment"))
        {
            if (player.GetComponent<Bounds>().Intersects(obj.GetComponent<Bounds>()))
            {
                player.transform.Translate(-newpos);
                return obj;
            }
        }
        player.transform.Translate(-newpos);
    
        return null;
    }
    
    public static void removeObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
