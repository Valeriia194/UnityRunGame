using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Assets.Scripts.Audio;
using Assets.Scripts.Project;
using AudioSettings = Assets.Scripts.Audio.AudioSettings;

public class SphereCollector : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int count = 0;

    private bool isCollecting = false;

    [SerializeField] GameObject particlePrefab;

    private IAudioService audioService;
    //private AudioSource audioSource;
    //public AudioClip pickupSound;


    void Start()
    {
        audioService = ProjectContext.Instance.AudioService;

        UpdateCounterUI();
        //audioSource = GetComponent<AudioSource>();

        //pickupSound = Resources.Load<AudioClip>("DM28");

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            CollectSphere();
            isCollecting = true;


            //GameObject particleInstance = Instantiate(particlePrefab, other.transform.position, Quaternion.identity);



            //StartCoroutine(DestroyParticleWithDelay(particleInstance));
            Destroy(other.gameObject);

            int damage = 50;
            var health = other.GetComponent<HealthController>();
            if (health != null)
            {
                health.Damage(damage);
            }

            audioService.PlayeSfx(new AudioSettings("DM28"));

            //audioSource.PlayOneShot(pickupSound);
        }
    }

    public void CollectSphere()
    {
        count++;
        UpdateCounterUI();
       
    }

    void UpdateCounterUI()
    {
        counterText.text = "Spheres: " + count.ToString();
    }



    IEnumerator DestroyParticleWithDelay(GameObject particle)
    {
        yield return new WaitForSeconds(1f);
        Destroy(particle);
        isCollecting = false;
    }
}

