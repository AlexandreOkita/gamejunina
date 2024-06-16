using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text description;
    [SerializeField] Image image;
    // Start is called before the first frame update
    public void Setup(AttributeUpgrade upgrade)
    {
        title.text = upgrade.title;
        description.text = upgrade.description;
        image.sprite = upgrade.sprite;
    }
}
