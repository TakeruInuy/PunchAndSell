using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [SerializeField] private TextMeshProUGUI resourceUI;
    public int resource;
    [SerializeField] private int maxResource  = 999999;

    public UnityEvent onValueChange = new UnityEvent();


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        resourceUI.text = "0";
        onValueChange.AddListener(LimitResource);
    }

    public void AddResource(int amount)
    { 
        resource += amount;
        onValueChange.Invoke();
    }

    public void RemoveResource(int amount) 
    {  
        resource -= amount;
        onValueChange.Invoke();
    }

    public void LimitResource()
    {
        resource = Mathf.Clamp(resource, 0, maxResource);
        resourceUI.text = resource.ToString();
        Debug.Log("Resource: " + resource);
    }

}
