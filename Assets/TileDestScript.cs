using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestScript : MonoBehaviour
{
    
    private Vector2[] vecArr = { 
        new Vector2(-1.0f, 0), 
        new Vector2(1.0f, 0), 
        new Vector2(0, -1.0f),
        new Vector2(-1.0f, -1.0f) };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HitOneMethod(collision);
        //HitTwoMethod(collision);
    }

    private void HitOneMethod(Collision2D collision)
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

    private void HitTwoMethod(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        var tilemap = collision.gameObject.GetComponent<Tilemap>();

        //If it has a tile map.
        if (tilemap != null)
        {
            //Common hit point checking
            ContactPoint2D hit = collision.contacts[0];
            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
            
            var a = tilemap.WorldToCell(hitPosition);
            TileBase tileToRem = tilemap.GetTile(tilemap.WorldToCell(hitPosition));

            //If hit to tile map but no tile found
            if (tileToRem == null)
            {
                TileBase tileToRemove = null;
                Vector3Int tilePosToRem = Vector3Int.zero;
                int i = 0;
                
                while (i<4)
                {
                    Vector3 bHitPosition = hit.point + 0.01f * vecArr[i];

                    var c = tilemap.WorldToCell(bHitPosition);

                    tileToRemove = tilemap.GetTile(c);

                    if (tileToRemove != null)
                    {
                        tilePosToRem = c;
                        break;
                    }
                    i++;
                }
                //Remove tile only if tile is found
                if (tileToRemove != null)
                {
                    //tilemap.SwapTile(tileToRemove, null);
                    //Remove tile
                    tilemap.SetTile(tilePosToRem, null);

                    //Invoke a event to notify when a tile is removed.
                    AllEventsScript.OnCollisionWTile?.Invoke(tileToRemove);
                }
            }
            else
            {
                //Remove tile
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);

                //Invoke a event to notify when a tile is removed.
                AllEventsScript.OnCollisionWTile?.Invoke(tileToRem);
            }

        }

    }

    //World point to tile
    TileBase HitPointToTile(Tilemap tilemap, Vector2 hitPoint)
    {
        TileBase tileAtPos = tilemap.GetTile(tilemap.WorldToCell(hitPoint));
        return tileAtPos;
    }


    //Compares two float values whether they are greater than certain difference  
    private bool FloatAlmostEquals(float fvalue , float fvaluetocomp,float diff)
    {
        return (Mathf.Abs(fvalue - fvaluetocomp) <= diff);
    }
}

