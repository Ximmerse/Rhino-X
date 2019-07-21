using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeerMotionManger : MonoBehaviour
{
    public static DeerMotionManger _instance;
    public Transform originPositon;

    public int isDeerAnger = 0;
    public bool isDeerScared = false;
    public int deerAngerCount = 5;
    public GameObject sphere;

    [HideInInspector]
    public Vector3 globleDesnation;

    [Header("------DeerSencor------\n")]
    [SerializeField] SphereCollider deerHead;
    [SerializeField] SphereCollider deerTail;
    [SerializeField] SphereCollider deerAround;

    [Header("------MoveSpeed------\n")]
    [SerializeField] float moveSpeed = 2.2f;
    [SerializeField] float runSpeed = 30f;

    [Header("------Sounds------\n")]
    [SerializeField] List<AudioClip> footSounds;
    [SerializeField] AudioClip moveSounds;

    [SerializeField]
    AudioSource likeSound;

    [Header("------Effect------\n")]
    [SerializeField] ParticleSystem like;

    private Animator deerAnimator;
    private NavMeshAgent deerAgent;
    private AudioSource audioSource;

    private void Awake()
    {
        _instance = this;

        audioSource = GetComponent<AudioSource>();

        deerAnimator = GetComponent<Animator>();

        deerAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float angle;
    float deerMoveSpeed = 0;
    float deerTrunSpeed = 0;

    float remainStopTimer = 0;
    float resetRemainStopTime = 10f;

    public bool updateDesnation = false;

    float trailTimer = 0;
    float trailStopTime = 1f;

    void LateUpdate()
    {
        if (deerAnimator.GetCurrentAnimatorStateInfo(0).IsName("DEat"))
        {
            deerHead.enabled = false;
            deerTail.enabled = false;

            deerAgent.isStopped = true;
        }
        else
        {
            deerHead.enabled = true;
            deerTail.enabled = true;
            deerAround.enabled = true;

            deerAgent.isStopped = false;
        }

        //Debug.Log(deerAgent.velocity.magnitude);
        Debug.DrawRay(transform.position, deerAgent.velocity, Color.blue, 0.01f);

        sphere.transform.position = deerAgent.destination;

        if (isDeerScared)
        {
            deerAround.enabled = false;

            deerAgent.speed = runSpeed;
            deerAgent.acceleration = 6;

            if (updateDesnation)
            {
                Vector3 randomPos = RandmPos();

                deerAgent.SetDestination(randomPos);

                updateDesnation = false;
            }

            deerMoveSpeed = deerAgent.velocity.magnitude;
            deerTrunSpeed = Vector3.Cross(transform.forward, deerAgent.velocity).y;

            if (Vector3.Distance(transform.position,deerAgent.destination)<1f)
            {
                remainStopTimer += Time.deltaTime;

                deerMoveSpeed = Mathf.Lerp(4, 0, remainStopTimer*1.5f);

                deerAnimator.SetFloat("Vertical", deerMoveSpeed);

                if (deerMoveSpeed<0.01f)
                {
                    isDeerScared = false;
                    remainStopTimer = 0f;
                }
            }

        }
        else
        {
            deerAround.enabled = true;

            deerAgent.speed = moveSpeed;
            deerAgent.acceleration = 3;

            deerMoveSpeed = deerAgent.velocity.magnitude;
            deerTrunSpeed = Vector3.Cross(transform.forward, deerAgent.velocity).y;
        }

        deerAnimator.SetFloat("Horizontal", deerTrunSpeed);
        deerAnimator.SetFloat("Vertical", deerMoveSpeed);

        if (deerAnimator.GetFloat("Vertical")>0)
        {
            audioSource.priority = 200;
            audioSource.volume = 0.1f;
            audioSource.PlayOneShot(moveSounds);
        }
        else
        {
            trailTimer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, trailTimer);
            if (audioSource.volume<=0.01f)
            {
                audioSource.Stop();
                trailTimer = 0f;
            }

        }
    }

    bool m_IsBusy = false;

    public void Eat()
    {
        if(!m_IsBusy)
        {
            deerAnimator.SetTrigger("eat");
            m_IsBusy = true;
            Invoke("FreeDear", 3);
        }
    }

    public void SetDeerDestnation(Vector3 destnation)
    {
        deerAgent.SetDestination(destnation);
    }

    public void DeerBackKick()
    {
        if (!m_IsBusy)
        {
            deerAgent.isStopped = true;
            deerAnimator.SetTrigger("attack");
            isDeerAnger = 0;
            m_IsBusy = true;
            Invoke("FreeDear", 3);
        }
    }

    void FreeDear ()
    {
        m_IsBusy = false;
    }

    float runArea =2;
    private Vector3 RandmPos()
    {
        float x = Random.Range(-runArea, runArea);
        float z = Random.Range(-runArea, runArea);
        return new Vector3(x, 0, z);
    }
    public void OnTrotWalk()
    {
        var audioSource = GetComponent<AudioSource>();
        //int randomIndex = Random.Range(0, footSounds.Count);
        var adudioClip = footSounds[0];
        audioSource.PlayOneShot(adudioClip);
    }
    public void OnTrotWalk2()
    {
        var audioSource = GetComponent<AudioSource>();
        //int randomIndex = Random.Range(0, footSounds.Count);
        var adudioClip = footSounds[1];
        audioSource.PlayOneShot(adudioClip);
    }
    public void OnTrotWalk3()
    {
        var audioSource = GetComponent<AudioSource>();
        //int randomIndex = Random.Range(0, footSounds.Count);
        var adudioClip = footSounds[2];
        audioSource.PlayOneShot(adudioClip);
    }
    public void LikePalyer()
    {
        like.Play();
        likeSound.Play();
    }
}
