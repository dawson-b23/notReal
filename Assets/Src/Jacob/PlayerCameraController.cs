using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField]
    private float maxDistance = 2.5f;
    private Transform tracker = null;

    private Vector2 offset = Vector2.zero;

    private void FixedUpdate()
    {
        if(tracker != null)
        {
            offset = this.transform.position - tracker.position;

            if (offset.magnitude > maxDistance)
            {
                //this.transform.position += new Vector3(-offset.normalized.x, -offset.normalized.y, 0.0f) * maxDistance;

                Vector3 foo = Vector3.Lerp(this.transform.position, tracker.position, 0.05f);
                foo = new Vector3(foo.x, foo.y, -10.0f);

                this.transform.position = foo;
            }
        }
    }

    public void SetTracker(Transform toTrack)
    {
        tracker = toTrack;
    }
}
