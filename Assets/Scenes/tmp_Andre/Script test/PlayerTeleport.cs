using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Vector3 mariam1Position; // Titik tujuan untuk Mariam 1
    public Vector3 mariam2Position; // Titik tujuan untuk Mariam 2

    public void MoveToMariam1()
    {
        transform.position = mariam1Position;
    }

    public void MoveToMariam2()
    {
        transform.position = mariam2Position;
    }
}
