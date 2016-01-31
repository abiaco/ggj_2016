using UnityEngine;
using System.Collections;

public abstract class God {
    protected int pissOffLevel;

    public God()
    {
        this.pissOffLevel = 0;
    }

    public Action punish(Action action)
    {
        switch (pissOffLevel)
        {
            case 0:
                return action;
            case 1:
                return LevelOneAction(action);
            case 2:
                return LevelTwoAction(action);
            case 3:
                return LevelThreeAction(action);
            case 4:
                return LevelFourAction(action);
            case 5:
                return LevelFiveAction(action);
            case 6:
                return LevelSixAction(action);
            case 7:
                return LevelSevenAction(action);
            case 8:
                return LevelEightAction(action);
            case 9:
                return LevelNineAction(action);
            case 10:
                return LevelTenAction(action);
        }
        return action;
    }

    public void pissOff()
    {
        this.pissOffLevel++;
    }

    public int howPissed()
    {
        return this.pissOffLevel;
    }
    public abstract Action LevelOneAction(Action action);
    public abstract Action LevelTwoAction(Action action);
    public abstract Action LevelThreeAction(Action action);
    public abstract Action LevelFourAction(Action action);
    public abstract Action LevelFiveAction(Action action);
    public abstract Action LevelSixAction(Action action);
    public abstract Action LevelSevenAction(Action action);
    public abstract Action LevelEightAction(Action action);
    public abstract Action LevelNineAction(Action action);
    public abstract Action LevelTenAction(Action action);
}
