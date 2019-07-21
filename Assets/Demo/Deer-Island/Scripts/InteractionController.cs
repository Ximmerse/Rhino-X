using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ximmerse.RhinoX;
public class InteractionController : MonoBehaviour
{
    public static InteractionController _instance;

    [SerializeField] float deerAngerThreshold = 0.3f;
    SphereCollider collier;

    [Header("------OriginConmand------\n")]
    [SerializeField] AudioClip whistle;
    [SerializeField] ParticleSystem particle;


    float timer =2;
    [SerializeField]float resetTimeSize = 1;

    bool hasCollisionObject = false;

    private void Awake()
    {
        _instance = this;

        collier = GetComponent<SphereCollider>();

        timer = resetTimeSize;
    }

    [SerializeField]
    Ximmerse.RhinoX.RXController controller;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        //controller.OnTap.AddListener(HandleUnityAction);
    }

    private void OnDestroy()
    {
        //controller.OnTap.RemoveListener(HandleUnityAction);
    }

    //void HandleUnityAction(Ximmerse.RhinoX.ControllerButtonCode buttonCode)
    //{
    //    if(buttonCode == Ximmerse.RhinoX.ControllerButtonCode.Trigger)
    //    {
    //        this.OnPlayerAct();
    //    }
    //}


    float playerScaredMotion = 0f;

    Vector3 lastPosition;

    // Update is called once per frame.
    void Update()
    {
        if (hasCollisionObject)
        {
            collier.enabled = false;
            timer -= Time.deltaTime;

            if (timer<=0)
            {
                timer = 2;
                collier.enabled = true;
                hasCollisionObject = false;
            }
        }
        else
        {
            timer = 2;
            collier.enabled = true;
        }

        if (hasScardDeer)
        {
            DeerMotionManger._instance.isDeerScared = true;
            hasScardDeer = false;
        }

        playerScaredMotion = (lastPosition - transform.position).magnitude;

        lastPosition = transform.position;

        if(RXInput.IsButtonTap(RhinoXButton.ControllerTrigger))
        {
            this.OnPlayerAct();
        }
    }


    [SerializeField] float moveRange = 1;

    bool hasScardDeer = false;

    bool canTriggerEat, canTriggerBKick;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "HeadCollider")
        {
            hasCollisionObject = true;


            canTriggerEat = true;
        }

        if (other.name == "TailCollider")
        {
            hasCollisionObject = true;

            //Vector3 randomPos = new Vector3(Random.RandomRange(-moveRange, moveRange), 0, Random.RandomRange(-moveRange, moveRange));

            //DeerMotionManger._instance.SetDeerDestnation(randomPos);
            //DeerMotionManger._instance.DeerBackKick();
            canTriggerBKick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "HeadCollider")
        {
            hasCollisionObject = false;
            canTriggerEat = false;
        }

        if (other.name == "TailCollider")
        {
            hasCollisionObject = false;
            canTriggerBKick = false;
        }
    }


    public void OnPlayerAct ()
    {
        if(canTriggerEat)
        {
            DeerMotionManger._instance.Eat();
            DeerMotionManger._instance.LikePalyer();
        }
        else if(canTriggerBKick)
        {
            DeerMotionManger._instance.DeerBackKick();
        }

        particle.Play();
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.name== "ScaredCollider")
    //    {
    //        if (playerScaredMotion > deerAngerThreshold && !hasScardDeer)
    //        {
    //            hasScardDeer = true;

    //            hasCollisionObject = true;

    //            DeerMotionManger._instance.updateDesnation = true;
    //        }
    //    }
    //}

    public void MoveToPlayer()
    {
        DeerMotionManger._instance.Eat();
        particle.Play();

        //var audio = GetComponent<AudioSource>();
        //audio.clip = whistle;
        //if (!audio.isPlaying)
        //{
        //    audio.Play();
        //}
        //DeerMotionManger._instance.SetDeerDestnation(this.transform.position + LittleRandmPos());
    }

    private Vector3 LittleRandmPos()
    {
        float x = Random.Range(-1, 1);
        float z = Random.Range(-1, 1);
        return new Vector3(x, 0, z);
    }
}
