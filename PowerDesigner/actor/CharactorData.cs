// File:    CharactorData.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class CharactorData

using System;

public class CharactorData
{
   
   private string actorName;
   
   public string ActorName{
      get { return actorName; }
      set { actorName = value; }
   }
   
   private int actorType;
   
   public int ActorType{
      get { return actorType; }
      set { actorType = value; }
   }

}