#pragma strict

public var speed : float = 150f;


function Update ()
{
    transform.Rotate(Vector3.up, speed * Time.deltaTime);
    transform.position.x = Mathf.PingPong(Time.time, 10.0) - 2.0;
}

