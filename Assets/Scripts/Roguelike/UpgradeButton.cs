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
        [SerializeField] AudioSource _audioSource;

        public void Setup(AttributeUpgrade upgrade, PlayerController player, Action selected)
        {
            title.text = upgrade.title;
            description.text = upgrade.description;
            image.sprite = upgrade.sprite;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() =>
            {
                _audioSource.clip = upgrade.sound;
                _audioSource.Play();
                upgrade.Apply(player);
                selected?.Invoke();
            });
        }
    }
}
