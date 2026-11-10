using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PushScript : MonoBehaviour
{
    private InputSystem_Actions inputAction;
    [SerializeField] TextMeshProUGUI UItext;
    [SerializeField] Material material;
    [SerializeField] Renderer renderer;
    
    private int count;
    private bool play;
    private float timer;
    private float runTime = 0.2f; //1周の時間

    private void Awake()
    {
        count = 0;
        timer = 0;
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        inputAction = new InputSystem_Actions();

        inputAction.Player.Attack.performed += OnTrigger;

        inputAction.Enable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //デバッグ用のテキスト
        UItext.text = count.ToString();

        if (play)
        {
            timer += Time.deltaTime;
            float addTime = timer / runTime;
            material.SetFloat("_MyTimer", addTime);

            if (addTime >= 1f)
            {
                play = false;
                timer = 0f;
            }
        }
    }

    void OnTrigger(InputAction.CallbackContext context)
    {
        count++;
        play = true;
    }
}
