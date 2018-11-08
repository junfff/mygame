// File:    DecorateDataGroup.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class DecorateDataGroup

using System;

public class DecorateDataGroup
{
   
   private int attribute34;
   
   public int Attribute34{
      get { return attribute34; }
      set { attribute34 = value; }
   }
   
   public System.Collections.Generic.List<DynamicData> dynamicData;
   
   /// <summary>
   /// Property for collection of DynamicData
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<DynamicData> DynamicData
   {
      get
      {
         if (dynamicData == null)
            dynamicData = new System.Collections.Generic.List<DynamicData>();
         return dynamicData;
      }
      set
      {
         RemoveAllDynamicData();
         if (value != null)
         {
            foreach (DynamicData oDynamicData in value)
               AddDynamicData(oDynamicData);
         }
      }
   }
   
   /// <summary>
   /// Add a new DynamicData in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddDynamicData(DynamicData newDynamicData)
   {
      if (newDynamicData == null)
         return;
      if (this.dynamicData == null)
         this.dynamicData = new System.Collections.Generic.List<DynamicData>();
      if (!this.dynamicData.Contains(newDynamicData))
         this.dynamicData.Add(newDynamicData);
   }
   
   /// <summary>
   /// Remove an existing DynamicData from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveDynamicData(DynamicData oldDynamicData)
   {
      if (oldDynamicData == null)
         return;
      if (this.dynamicData != null)
         if (this.dynamicData.Contains(oldDynamicData))
            this.dynamicData.Remove(oldDynamicData);
   }
   
   /// <summary>
   /// Remove all instances of DynamicData from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllDynamicData()
   {
      if (dynamicData != null)
         dynamicData.Clear();
   }

}