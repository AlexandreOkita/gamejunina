using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillCaster : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    private ISkill _slot1;
    private ISkill _slot2;
    private ISkill _slot3;
    private int _lastAddedSkill = 0;

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
        _slot1?.Cast();
    }

    void OnSkill2(InputValue value)
    {
        Debug.Log("Casting skill 2");
        _slot2?.Cast();
    }

    void OnSkill3(InputValue value)
    {
        Debug.Log("Casting skill 3");
        _slot3?.Cast();
    }
}
