using UnityEngine;
using UnityEngine.Tilemaps;


// Class to contain all event functions
public class AllEventsScript : MonoBehaviour
{
    public delegate void BlankFunc();

    //On Ball go out of screen
    public static BlankFunc OnBallGoOut;

    //Tile Collision
    public delegate void TileCollision(TileBase tile);
    public static TileCollision OnCollisionWTile;

    //On All Tiles Destroyed
    public static BlankFunc OnAllTilesDestroyed;
}
