using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputField nameField;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateName()
    {
        PersistentDataManager.Instance.CurrentPlayer = nameField.text;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
