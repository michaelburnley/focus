using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float rotationMax;
    [SerializeField]
    private float subjectMaxPos;
    [SerializeField]
    private float rotationRate;
    [SerializeField]
    private float zoomReturnRate;
    [SerializeField]
    private float zoomReturnTime;
    [SerializeField]
    private float zoomSpeed;
    [SerializeField]
    private Vector3 zoomInDist;
    [SerializeField]
    private Vector3 camOffset;

    private Vector3 mainCamPos;
    private Vector3 zoomCamPos;
    private float subjectStartPos;
    private float startRot;
    private float verticalRotLerp;
    private float timeLapsed;

    private Transform transform;
    private float shakeDuration = 0f;
    [SerializeField]
    private float shakeMagnitude = 0.2f;
    [SerializeField]
    private float dampingSpeed = 1.0f;
    
    // The initial position of the GameObject
    Vector3 initialPosition;

    
    private bool zoom = false;
    private GameObject subject;



    private static Camera _instance;    
    public static Camera Instance { get { return _instance; } }

    public bool Zoom {
        get {
            return zoom;
        }

        set {
            zoom = value;
        }
    }
    public GameObject Subject {
        get {
            return subject;
        }

        set {
            subject = value;
        }
    }

    private void OnEnable() {
        initialPosition = transform.localPosition;
    }

    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        if (transform == null) transform = GetComponent(typeof(Transform)) as Transform;
    }

    void Start()
    {
        subjectStartPos = subject.transform.position.y;
        mainCamPos = new Vector3(subject.transform.position.x, subject.transform.position.y + camOffset.y, subject.transform.position.z + camOffset.z);

        transform.position = mainCamPos;
        startRot = transform.rotation.x;
        subjectMaxPos += subjectStartPos;

        timeLapsed = zoomReturnRate;
    }


    void Update()
    {
        if (CheckTiming()) {
            ZoomIn();
        } else {
            ZoomOut();
        }

        initialPosition = transform.localPosition;
        

        if (shakeDuration > 0) {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    private void ZoomOut() {

        verticalRotLerp = Mathf.Lerp(startRot, rotationMax, (subject.transform.position.y - subjectStartPos) / subjectMaxPos * 1.5f);
        transform.rotation = Quaternion.Euler(verticalRotLerp, 0, 0);

        mainCamPos = new Vector3(subject.transform.position.x, subject.transform.position.y + camOffset.y, subject.transform.position.z + camOffset.z);

        if (transform.position != mainCamPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, mainCamPos, zoomSpeed);
        }
    }

    private void ZoomIn() {

        verticalRotLerp = Mathf.Lerp(transform.rotation.x, 0, rotationRate * Time.deltaTime);
        transform.rotation = Quaternion.Euler(verticalRotLerp, 0, 0);

        zoomCamPos = new Vector3(subject.transform.position.x, subject.transform.position.y + camOffset.y + zoomInDist.y, subject.transform.position.z + camOffset.z + zoomInDist.z);

        if (transform.position != zoomCamPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, zoomCamPos, zoomSpeed);
        }
    }

    public void Shake(float time) {
        shakeDuration = time;
        initialPosition = transform.localPosition;
    }
    
    private bool CheckTiming()
    {
        if (zoom) timeLapsed = 0;

        timeLapsed += Time.deltaTime;

        if (timeLapsed >= zoomReturnTime)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}