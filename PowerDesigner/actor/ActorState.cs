// File:    ActorState.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class ActorState

using System;

public class ActorState
{
   
   private int stateType;
   
   public int StateType{
      get { return stateType; }
      set { stateType = value; }
   }
   
   private bool stateValue;
   
   public bool StateValue{
      get { return stateValue; }
      set { stateValue = value; }
   }

}