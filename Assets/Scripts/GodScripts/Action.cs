using UnityEngine;
using System.Collections;

public enum ActionType
{
    idle,
    moveLeft,
    moveRight,
    jump,
    sacrifice,
    save
}

public class Action
{
    ActionType type;
    Vector3 force;
    public static float maxXVelocity = 1000f;
    public static float speed = 20.0f;
    public static float jumpSpeed = 8.0F;
    private Vector3 xForceToAdd = Vector3.zero;
    private float xPos = 0;

    public Action()
    {
        type = ActionType.idle;
        force = Vector3.zero;
    }

    public Action(ActionType type)
    {
        this.type = type;
        this.force = Vector3.zero;
    }

    public Action(ActionType type, Vector3 force)
    {
        this.type = type;
        this.force = force;
    }

    public ActionType getType()
    {
        return this.type;
    }

    public Vector3 getForce()
    {
        return this.force;
    }

    public void setType(ActionType newType)
    {
        this.type = newType;
    }

    public void setForce(Vector3 newForce)
    {
        this.force = newForce;
    }

    public static void move (Rigidbody player, Vector3 force)
    {
        player.AddForce(force);
        player.velocity = new Vector3(Mathf.Clamp(player.velocity.x, (-1 * maxXVelocity), maxXVelocity), player.velocity.y, 0f);
    }

    public static void jump(Rigidbody player, Vector3 force)
    {
        if (GameManager.Instance.ThePlayer.GetComponent<PlayerProperties>().CheckGroundDist())
        {
            player.AddForce(force);
        }
    }

    public static void sacrifice()
    {
        GameManager.Instance.natureGod.pissOff();
    }

    public static void save()
    {
        GameManager.Instance.deathGod.pissOff();
    }
}
