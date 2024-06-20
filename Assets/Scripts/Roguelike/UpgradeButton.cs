using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike
{
    [RequireComponent(typeof(AudioSource))]
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] TMP_Text title;
        [SerializeField] TMP_Text description;
        [SerializeField] Image image;
        [SerializeField] Button button;

        private AudioSource source;

        // Start is called before the first frame update
        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        public void Setup(AttributeUpgrade upgrade, PlayerController player, Action selected)
        {
            title.text = upgrade.title;
            description.text = upgrade.description;
            image.sprite = upgrade.sprite;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                source.clip = upgrade.sound;
                source.Play();
                upgrade.Apply(player);
                selected?.Invoke();
            });
        }
    }
}
