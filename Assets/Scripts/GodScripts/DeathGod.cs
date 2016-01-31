using UnityEngine;
using System.Collections;
using System;

public class DeathGod : God {
    public DeathGod() : base() { }


    public override Action LevelOneAction(Action action)
    {
        return new Action(GodUtils.getRandomActionType(), action.getForce());
    }


    public override Action LevelTwoAction(Action action)
    {
        action.setForce(action.getForce() * -this.pissOffLevel);
        return action;
    }


    public override Action LevelThreeAction(Action action)
    {
        action = new Action(GodUtils.getRandomActionType(), action.getForce());
        action.setForce(action.getForce() * this.pissOffLevel);
        return action;
    }


    public override Action LevelFourAction(Action action)
    {
        return action;
    }


    public override Action LevelFiveAction(Action action)
    {
        return action;
    }


    public override Action LevelSixAction(Action action)
    {
        return action;
    }


    public override Action LevelSevenAction(Action action)
    {
        return action;
    }


    public override Action LevelEightAction(Action action)
    {
        return action;
    }


    public override Action LevelNineAction(Action action)
    {
        return action;
    }


    public override Action LevelTenAction(Action action)
    {
        return action;
    }

}
