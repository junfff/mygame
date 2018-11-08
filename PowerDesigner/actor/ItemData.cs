// File:    ItemData.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class ItemData

using System;

public class ItemData
{
   
   private int itemSkillId;
   
   public int ItemSkillId{
      get { return itemSkillId; }
      set { itemSkillId = value; }
   }
   
   private int price;
   
   public int Price{
      get { return price; }
      set { price = value; }
   }
   
   private string des;
   
   public string Des{
      get { return des; }
      set { des = value; }
   }

}