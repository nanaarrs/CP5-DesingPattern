using UnityEngine;

public class Inimigo1 : Inimigos
{
    protected override void Start()
    {
        pointsValue = 15;
        speed = 5f;
        base.Start();
        GetComponent<Renderer>().material.color = Color.red;
    }
}
