using UnityEngine;

public class EnemyManager : MonoBehaviour{

    public GameObject spitter;
    public GameObject cactus;
    public GameObject crawler;
    public GameObject bug;
    public GameObject scutter;
    public GameObject jumper;
    public GameObject yeti;
    public GameObject snow;


    void Start() {
        Instantiate(spitter, new Vector3(11.3f, 4.16f, 0f), new Quaternion());
        Instantiate(spitter, new Vector3(11.45f, 2.2f, 0f), new Quaternion());
        Instantiate(spitter, new Vector3(15.34f, 2.2f, 0f), new Quaternion());

        Instantiate(cactus, new Vector3(31.8f, 4.32f, 0f), new Quaternion());
        Instantiate(cactus, new Vector3(29.26f, 2.89f, 0f), new Quaternion());

        Instantiate(crawler, new Vector3(32f, 2.1f, 0f), new Quaternion());
        Instantiate(crawler, new Vector3(35.4f, 2.1f, 0f), new Quaternion());

        Instantiate(bug, new Vector3(35f, 6.2f, 0f), new Quaternion());
        Instantiate(bug, new Vector3(30f, 6.2f, 0f), new Quaternion());

        Instantiate(scutter, new Vector3(48f, 2.5f, 0f), new Quaternion());
        Instantiate(scutter, new Vector3(44f, 0.71f, 0f), new Quaternion());

        Instantiate(jumper, new Vector3(50f, 3.97f, 0f), new Quaternion());
        Instantiate(jumper, new Vector3(76f, 4f, 0f), new Quaternion());

        Instantiate(yeti, new Vector3(73f, 4.2f, 0f), new Quaternion());
        Instantiate(yeti, new Vector3(70f, 2.2f, 0f), new Quaternion());

        Instantiate(snow, new Vector3(78f, 4.2f, 0f), new Quaternion());
        Instantiate(snow, new Vector3(65f, 4.2f, 0f), new Quaternion());
    }
}
