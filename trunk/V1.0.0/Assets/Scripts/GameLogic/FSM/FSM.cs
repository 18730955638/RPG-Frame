using UnityEngine;
using System.Collections;

using U3DEventFrame;
using System;

public abstract class FSMBase
{
    protected Animator animator;

    public FSMBase(Animator animator)
    {
        this.animator = animator;
    }

    public abstract void OnEnter();
    public abstract void Update();
    public abstract void OnLeave();
}

public class FSMManager
{
    FSMBase[] allStates;

    byte nowIndex;
    int nowState;
    public FSMManager(int count)
    {
        allStates = new FSMBase[count];

        nowIndex = 0;
        nowState = -1;
    }

    public void AddState(FSMBase newBase)
    {
        if (nowIndex < allStates.Length)
        {
            allStates[nowIndex++] = newBase;
        }
    }

    public void ChangeState(byte index)
    {
        if (nowIndex != index)
        {
            if (nowState != -1)
            {
                allStates[nowState].OnLeave();
            }
        }
        allStates[index].OnEnter();
        nowState = index;
    }

    public void Update()
    {
        if (nowState != -1)
        {
            allStates[nowState].Update();
        }
    }
}
