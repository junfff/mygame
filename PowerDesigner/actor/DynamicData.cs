// File:    DynamicData.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class DynamicData

using System;

public class DynamicData
{
   
   private int dataType;
   
   public int DataType{
      get { return dataType; }
      set { dataType = value; }
   }
   
   private int dataValue;
   
   public int DataValue{
      get { return dataValue; }
      set { dataValue = value; }
   }

}