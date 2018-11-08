// File:    Soldier.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class Soldier

using System;

public class Soldier : Actor
{
   
   private string name;
   
   public string Name{
      get { return name; }
      set { name = value; }
   }
   
   private int soldierType;
   
   public int SoldierType{
      get { return soldierType; }
      set { soldierType = value; }
   }

}