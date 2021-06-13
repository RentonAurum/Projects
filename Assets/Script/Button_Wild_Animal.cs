using UnityEngine;
using UnityEngine.UI;

public class Button_Wild_Animal : MonoBehaviour
{
    [SerializeField]
    private GameObject map;

    private SpriteRenderer mapSpawn;

    private int mapState;

    void Start()
    {
        mapSpawn = map.GetComponent<SpriteRenderer>();
        mapState = 0;

        gameObject.GetComponent<Button>().onClick.AddListener(TurnOnAndOff);
    }

private void TurnOnAndOff()
    {
        mapState = 1 - mapState; //switch between 0 and 1
        if (mapState == 1)
        {
            map.SetActive(true);
        }
        else
        {
            map.SetActive(false);
        }
    }
}
