using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillCaster : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    private ISkill skill1;
    private ISkill skill2;
    private ISkill skill3;

    public void Setup(ISkill skill, int slot)
    {
        switch(slot)
        {
            case 1:
                skill1 = skill;
                break;
            case 2:
                skill2 = skill;
                break;
            case 3:
                skill3 = skill;
                break;
        }
    }

    void OnSkill1(InputValue value)
    {
        Debug.Log("Casting skill 1");
        skill1?.Cast();
    }

    void OnSkill2(InputValue value)
    {
        Debug.Log("Casting skill 2");
        skill2?.Cast();
    }

    void OnSkill3(InputValue value)
    {
        Debug.Log("Casting skill 3");
        skill3?.Cast();
    }
}
