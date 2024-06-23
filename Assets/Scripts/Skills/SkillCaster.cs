using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillCaster : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] PlayerController _player;
    private ISkill _slot1;
    private ISkill _slot2;
    private ISkill _slot3;
    private int _lastAddedSkill = 0;

    private bool _slot1Loading = false;
    private bool _slot2Loading = false;
    private bool _slot3Loading = false;

    public void AddSkill(ISkill skill)
    {
        var slot = _lastAddedSkill % 3;
        switch(slot)
        {
            case 0:
                _slot1 = skill;
                break;
            case 1:
                _slot2 = skill;
                break;
            case 2:
                _slot3 = skill;
                break;
        };
        _lastAddedSkill++;
    }

    void OnSkill1(InputValue value)
    {
        Debug.Log("Casting skill 1");
        CastSkill(_slot1, _slot1Loading, 1);
    }

    void OnSkill2(InputValue value)
    {
        Debug.Log("Casting skill 2");
        CastSkill(_slot2, _slot2Loading, 2);
    }

    void OnSkill3(InputValue value)
    {
        Debug.Log("Casting skill 3");
        CastSkill(_slot3, _slot3Loading, 3);
    }

    private void CastSkill(ISkill skill, bool loading, int slotNumber)
    {
        if (!loading)
        {
            skill?.Cast(_player);
            StartCoroutine(LoadSkill(slotNumber, skill.Cooldown));
        }
    }

    private IEnumerator LoadSkill(int slot, float cooldown)
    {

        switch (slot)
        {
            case 1:
                _slot1Loading = true;
                break;
            case 2:
                _slot2Loading = true;
                break;
            case 3:
                _slot3Loading = true;
                break;
        }

        yield return new WaitForSeconds(cooldown);

        switch (slot)
        {
            case 1:
                _slot1Loading = false;
                break;
            case 2:
                _slot2Loading = false;
                break;
            case 3:
                _slot3Loading = false;
                break;
        }
    }
}
