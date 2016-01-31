using UnityEngine;
using System.Collections;
using System;

public class NatureGod : God{
	// Use this for initialization
	public NatureGod () : base() { }


    public override Action LevelOneAction(Action action)
    {
        GodUtils.removeObject(GodUtils.getNearbyTile());
        return action;
    }


    public override Action LevelTwoAction(Action action)
    {
        return action;
    }


    public override Action LevelThreeAction(Action action)
    {
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
