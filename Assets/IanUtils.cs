using UnityEngine;
using System.Collections;

public static class IanUtils
{
    public static Bounds bounds;

    public static Bounds CameraOrthographicBounds(this Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }

    //terrible by working by side effects but whatever it's a game jam with no battery left
    public static void MoveToScreenEdge(this Transform transform, Vector3 tryMoveToHere)
    {
        if (bounds != null)
        {
            bounds = CameraOrthographicBounds(Camera.main);
        }

        if (tryMoveToHere.x < bounds.extents.x && tryMoveToHere.x > -bounds.extents.x)
        {
            transform.position = tryMoveToHere;
        }
        
    }

}
