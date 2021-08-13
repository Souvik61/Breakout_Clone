using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        var tilemap = collision.gameObject.GetComponent<Tilemap>();
        //If it has a tile map.
        if (tilemap != null)
        {
            ContactPoint2D hit = collision.contacts[0];
            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;

            TileBase tileToRem = tilemap.GetTile(tilemap.WorldToCell(hitPosition));
            //Remove tile
            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);

            //Invoke a event to notify when a tile is removed.
            AllEventsScript.OnCollisionWTile?.Invoke(tileToRem);
            
        }
    }
}

