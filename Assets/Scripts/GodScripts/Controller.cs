using UnityEngine;
using System.Collections;

public class Controller
{
    public Action action;
    static int globalPissOff = 0;
    public static bool moveAllowed;

    public Controller()
    {
        this.action = new Action(ActionType.idle, Vector3.zero);
        moveAllowed = true;
    }


    public Controller(Action action)
    {
        this.action = action;
    }


    void setAction(Action action)
    {
        this.action = action;
    }


    public Action ApplyModifier(God god, Action action)
    {
        return god.punish(action);
    }


    public void ApplyAction(Rigidbody player)
    {
        System.Random random = new System.Random();
        int num = random.Next(1, 10);
        if (GameManager.Instance.natureGod.howPissed() < 2)
        {
            if (num > 2) action = ApplyModifier(GameManager.Instance.natureGod, action);
        }
        else
        {
            if (num < 6) ApplyModifier(GameManager.Instance.natureGod, action);
        }

        if (GameManager.Instance.deathGod.howPissed() < 2)
        {
            if (num > 2) action = ApplyModifier(GameManager.Instance.deathGod, action);
        }
        else
        {
            if (num < 6) ApplyModifier(GameManager.Instance.deathGod, action);
        }

        switch (action.getType())
        {
            case ActionType.moveLeft:
                if (isMoveAllowed())
                {
                    Action.move(player, action.getForce());
                }
                return;
            case ActionType.moveRight:
                if (isMoveAllowed())
                {
                    Action.move(player, action.getForce());
                }
                return;
            case ActionType.jump:
                if (isMoveAllowed())
                {
                    Action.jump(player, action.getForce());
                }
                return;
            case ActionType.sacrifice:
                Action.sacrifice();
                enableMove();
                return;
            case ActionType.save:
                Action.save();
                enableMove();
                return;
        }
    }


    public static void disableMove()
    {
        Debug.Log("disabledMove");
        moveAllowed = false;
    }


    public static void enableMove()
    {
        moveAllowed = true;
    }


    public bool isMoveAllowed()
    {
        return moveAllowed;
    }
}
