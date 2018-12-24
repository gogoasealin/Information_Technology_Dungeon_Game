using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance;
    public LayerMask mask;
    public LineRenderer line;
    public float step = 1f;
    public bool once;
    private Touch touch;
    private GameObject gameController;
    private GameController gameControllerScript;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (joint.distance > 0.1f)
        {
            joint.distance -= step * Time.deltaTime;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>())
            {
                once = true;
                joint.enabled = true;
                Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
                joint.connectedAnchor = connectPoint;

                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                //joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;

                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);

                line.GetComponent<Rope>().grabPos = hit.point;
            }
        }
        if (once)
        {
            line.SetPosition(1, joint.connectedBody.transform.TransformPoint(joint.connectedAnchor));
        }

        line.SetPosition(0, transform.position);

        if (Input.touchCount == 0)
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        gameControllerScript.GameOver();
    }

}
