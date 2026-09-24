using UnityEngine;

public class Inimigo2 : Inimigos
{
    protected override void Start()
    {
        pointsValue = 30;
        speed = 1f;
        base.Start();
        GetComponent<Renderer>().material.color = Color.blue;
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}

