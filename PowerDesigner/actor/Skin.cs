// File:    Skin.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class Skin

using System;

public class Skin
{
   
   private int skinID;
   
   public int SkinID{
      get { return skinID; }
      set { skinID = value; }
   }
   
   public System.Collections.Generic.List<Model> model;
   
   /// <summary>
   /// Property for collection of Model
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Model> Model
   {
      get
      {
         if (model == null)
            model = new System.Collections.Generic.List<Model>();
         return model;
      }
      set
      {
         RemoveAllModel();
         if (value != null)
         {
            foreach (Model oModel in value)
               AddModel(oModel);
         }
      }
   }
   
   /// <summary>
   /// Add a new Model in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddModel(Model newModel)
   {
      if (newModel == null)
         return;
      if (this.model == null)
         this.model = new System.Collections.Generic.List<Model>();
      if (!this.model.Contains(newModel))
         this.model.Add(newModel);
   }
   
   /// <summary>
   /// Remove an existing Model from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveModel(Model oldModel)
   {
      if (oldModel == null)
         return;
      if (this.model != null)
         if (this.model.Contains(oldModel))
            this.model.Remove(oldModel);
   }
   
   /// <summary>
   /// Remove all instances of Model from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllModel()
   {
      if (model != null)
         model.Clear();
   }

}