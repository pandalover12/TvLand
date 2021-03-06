﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour {

    [SerializeField]
    BoxCollider2D destoryhook;
    // the destination of the hookC:\Users\panda12\Desktop\fixedone\Codebase\WorkingTitle\Assets\Scripts\Managers\CoilManger.cs
    private Vector2 destiny;
    // the speed
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    float slowspeed;
    [SerializeField]
    private float zoominSpeed = 0.1f;
    [SerializeField]
    private float distance = 0.5f;
    [SerializeField]
    private float maxDistance = 10f;
    [SerializeField]
    GameObject nodePrefab;
    [HideInInspector]
    public GameObject player;
    [SerializeField]
    private GameObject secondNode;
    [SerializeField]
    // last node is the cloest rope 2 the player
    private GameObject lastNode;

    private GameObject grappleTarget;

    GameObject Poolme;

    // particles


    private LineRenderer lr;
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    AudioClip hitSound;



    // this changes based on the rope length 
    public int vertexCount = 1;
    [SerializeField]
    private List<GameObject> Nodes = new List<GameObject>();


    // is true and it never turns false
    [SerializeField]
    public bool done = false;
    private bool cooldown = false;
    [HideInInspector]
    public bool reelingIn = false;
    bool collision;
    [SerializeField]
    LayerMask mask;

    [SerializeField]
    Collider mainCollider;
    [SerializeField]
    FixedJoint2D connectedJoint = null;
    [SerializeField]
    Rigidbody2D connectedRigidbody = null;
    GameObject eye;
    bool swing;
    [SerializeField]
    bool slowrealin;
    bool hit;
    bool delete = true;
    float gravity;
    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        secondNode = null;
        lastNode = transform.gameObject;

        Nodes.Add(transform.gameObject);

        transform.LookAt(grappleTarget.transform.position);
        transform.Rotate(Vector2.up * -90);
        done = false;
        gravity = player.GetComponent<Rigidbody2D>().gravityScale;



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            slowrealin = !slowrealin;
        }
        if (done && swing == false && hit && reelingIn == false)
        {

            player.GetComponent<Rigidbody2D>().velocity += 1.6f * player.GetComponent<Rigidbody2D>().velocity;
            swing = true;

        }
        if (slowrealin && Poolme.tag == "pullAbleObject")
        {
            Poolme.transform.position = Vector2.MoveTowards(Poolme.transform.position, eye.transform.position, 0.1f);



            for (int i = 0; i < Nodes.Count; ++i)
            {
                if (Vector2.Distance(eye.transform.position, Nodes[i].transform.position) < 1.7f)
                {
                    --vertexCount;
                    Destroy(Nodes[i]);
                    Nodes.Remove(Nodes[i]);
                }
                else
                    Nodes[i].transform.position = Vector2.MoveTowards(Nodes[i].transform.position, eye.transform.position, 0.1f);
            }


        }
        else
        {
            player.GetComponent<Rigidbody2D>().gravityScale = gravity;
        }
        if (reelingIn)
        {

            done = true;

            rb2d.isKinematic = true;

            Destroy(connectedJoint);
            Destroy(connectedRigidbody);

            /*          if (mainCollider.enabled)
                        {
                            mainCollider.enabled = false;
                            return;
                        }*/

            transform.position = Vector2.MoveTowards(transform.position, eye.transform.position, speed * 2f);

            /*            if (secondNode != null)
                        {
                            secondNode.GetComponent<HingeJoint2D>().connectedAnchor = Vector2.zero;
                        }
                        else
                        {
                            GetComponent<HingeJoint2D>().connectedAnchor = Vector2.zero;
                        }

                        if ((secondNode.transform.position - lastNode.transform.position).sqrMagnitude < 0.025f)
                        {
                            DeleteSecond();
                        }*/

            if (Vector2.Distance(eye.transform.position, transform.position) < 1f)
            {

                player.GetComponent<GrappleScpt>().DestroyGrapple();
            }

            if (Nodes.Count != 1)
            {
                DeleteNodes();
            }
        }
        else if (!done)
        {
            transform.position = Vector2.MoveTowards(transform.position, destiny, speed);

            if (Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }
        }

        if (!done && Vector2.Distance(eye.transform.position, transform.position) > maxDistance)
        {
            reelingIn = true;
        float d=    Vector2.Distance(eye.transform.position, transform.position);
         //   Debug.Break();
        }
        if (collision == false && (Vector2)transform.position == destiny)
        {
            reelingIn = true;
        }
    }

    void Update()
    {
        RenderLine();

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            return;
        }

        if (coll.gameObject.tag == "Ground")
        {
            reelingIn = true;
        }
        /*if (tag == "Shocker")
          {
              reelingIn = true;
              return;
          }*/


        Debug.Log("HIT!");
        hit = true;
        collision = true;
        //   if (mask != (1 << coll.gameObject.layer | mask))
        //     reelingIn = true;

        if (!done)
        {
            Debug.Log("Done!");
            done = true;

            MakeRope();

            destiny = Vector2.zero;

            //rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            if (coll.gameObject.GetComponent<Rigidbody2D>() == null)
            {
                connectedRigidbody = coll.gameObject.AddComponent<Rigidbody2D>();
                connectedRigidbody.isKinematic = true;
                connectedRigidbody.freezeRotation = true;
                connectedRigidbody.useFullKinematicContacts = true;
            }
            connectedJoint = coll.gameObject.AddComponent<FixedJoint2D>();
            connectedJoint.connectedBody = rb2d;
            connectedJoint.autoConfigureConnectedAnchor = false;
            Poolme = coll.gameObject;

            // Spawn needed particles
            //if (grappleTarget.tag == "Wood")
            //{

            //}
            //else if (grappleTarget.tag == "Metal")
            //{
            //    Instantiate(grappleMetalParticle, grappleTarget.transform.position, grappleTarget.transform.rotation);
            //}
            //else if (grappleTarget.tag == "Stone")
            //{
            //    Instantiate(grappleStoneParticle, grappleTarget.transform.position, grappleTarget.transform.rotation);
            //}
        }
    }
    // Funct
    #region

    //  dsplays the lines
    void RenderLine()
    {
        lr.positionCount = vertexCount;

        int i;
        for (i = 0; i < vertexCount - 1; i++)
        {
            if (Nodes[i] == null)
                Nodes[i] = null;
            else lr.SetPosition(i, Nodes[i].transform.position);
        }

        lr.SetPosition(i, eye.transform.position);
    }
    // it replaces the last node with the newest node
    public void CreateNode()
    {
        // puting the rope in last node in front of the players
        Vector2 pos2Create = eye.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= ((eye.transform.position - lastNode.transform.position).magnitude < distance ? (eye.transform.position - lastNode.transform.position).magnitude : distance);
        pos2Create += (Vector2)lastNode.transform.position;
        Debug.Log(pos2Create);
        GameObject go = (GameObject)Instantiate(nodePrefab, pos2Create, Quaternion.identity);
        // sets the node 2 the transform of the parent
        go.transform.SetParent(transform);
        // replaces the hingje joint of the last node to the newsest last node
        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
        // the last node because the second node
        secondNode = lastNode;
        // the new node becomes the last node
        lastNode = go;
        // adde the newest last node 2 the list
        Nodes.Add(lastNode);
        // incracment the vertex counter
        vertexCount++;



    }

    public void CreateNode1()
    {
        // puting the rope in last node in front of the players
        Vector2 pos2Create = eye.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= ((eye.transform.position - lastNode.transform.position).magnitude < distance ? (eye.transform.position - lastNode.transform.position).magnitude : distance);
        pos2Create += (Vector2)lastNode.transform.position;
        pos2Create.y -= 0.1f;
        Debug.Log(pos2Create);
        GameObject go = (GameObject)Instantiate(nodePrefab, pos2Create, Quaternion.identity);
        // sets the node 2 the transform of the parent
        go.transform.SetParent(transform);
        // replaces the hingje joint of the last node to the newsest last node
        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
        // the last node because the second node
        secondNode = lastNode;
        // the new node becomes the last node
        lastNode = go;
        // adde the newest last node 2 the list
        Nodes.Add(lastNode);
        // incracment the vertex counter
        vertexCount++;
    }
    // bug fix = first guess
    public void MakeRope()
    {
        if (player == null) return;
        while (Vector2.Distance(eye.transform.position, lastNode.transform.position) > 0.1)//distance)
        {
            Debug.Log(Vector2.Distance(eye.transform.position, lastNode.transform.position));
            CreateNode();
        }
        // giving the last node refrence 2 the player
        lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
    }
    public void MakeRope1()
    {
        if (cooldown == false)
        {
            cooldown = true;
            StartCoroutine("RopeReelOut");
            CreateNode();
            CreateNode1();
            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
        }
    }
    IEnumerator RopeReelOut()
    {
        yield return new WaitForSeconds(0.1f);
        cooldown = false;
    }
    // deltes nodes
    public void DeleteNodes()
    {
        vertexCount = 2;
        foreach (GameObject obj in Nodes)
        {
            if (obj != transform.gameObject)
            {
                Destroy(obj);
            }
        }
        List<GameObject> tempNodes = new List<GameObject>();
        tempNodes.Add(transform.gameObject);
        lastNode = transform.gameObject;
        secondNode = null;
        Nodes = tempNodes;
        Destroy(connectedJoint);
        Destroy(connectedRigidbody);
        Destroy(this);
        Destroy(gameObject);

    }
    // deletes ropes
    public void DeleteSecond()
    {

        int i = Nodes.IndexOf(secondNode);
        --i;
        Destroy(secondNode);
        Nodes.Remove(secondNode);
        --vertexCount;
        secondNode = Nodes[i];
        secondNode.GetComponent<HingeJoint2D>().connectedBody = lastNode.GetComponent<Rigidbody2D>();

    }

    #endregion
    // accessors
    #region 
    public bool GetGrappleHookDone()
    {
        return done;
    }
    public float GetNodesCount()
    {
        return Nodes.Count;
    }
    public GameObject GetSecondNode()
    {
        return secondNode;
    }
    public GameObject GetLastNode()
    {
        return lastNode;
    }
    public bool Getslowrealin()
    {
        return slowrealin;
    }
    #endregion
    // Setters
    #region
    public void SetTarget(GameObject _target)
    {
        grappleTarget = _target;
    }
    public void SetEye(GameObject _eye)
    {
        eye = _eye;
    }
    public void SetDestination(Vector2 _destination)
    {
        destiny = _destination;
    }
    public void SetMaxDistance(float _maxDistance)
    {
      //  maxDistance = _maxDistance;
    }
    public void Setslowrealin(bool _slowrealin)
    {
        slowrealin = _slowrealin;
    }
    public GameObject GetObjecGrappled()
    {
        return Poolme;
    }
    #endregion
}
