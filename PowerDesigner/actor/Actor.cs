// File:    Actor.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class Actor

using System;

public class Actor
{
   
   private int actorId;
   
   public int ActorId{
      get { return actorId; }
      set { actorId = value; }
   }
   
   private int rotation;
   
   public int Rotation{
      get { return rotation; }
      set { rotation = value; }
   }
   
   private int teamType;
   
   public int TeamType{
      get { return teamType; }
      set { teamType = value; }
   }
   
   private int scale;
   
   public int Scale{
      get { return scale; }
      set { scale = value; }
   }
   
   private string position;
   
   public string Position{
      get { return position; }
      set { position = value; }
   }
   
   private bool enable;
   
   public bool Enable{
      get { return enable; }
      set { enable = value; }
   }
   
   public System.Collections.Generic.List<Controller> controller;
   
   /// <summary>
   /// Property for collection of Controller
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Controller> Controller
   {
      get
      {
         if (controller == null)
            controller = new System.Collections.Generic.List<Controller>();
         return controller;
      }
      set
      {
         RemoveAllController();
         if (value != null)
         {
            foreach (Controller oController in value)
               AddController(oController);
         }
      }
   }
   
   /// <summary>
   /// Add a new Controller in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddController(Controller newController)
   {
      if (newController == null)
         return;
      if (this.controller == null)
         this.controller = new System.Collections.Generic.List<Controller>();
      if (!this.controller.Contains(newController))
         this.controller.Add(newController);
   }
   
   /// <summary>
   /// Remove an existing Controller from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveController(Controller oldController)
   {
      if (oldController == null)
         return;
      if (this.controller != null)
         if (this.controller.Contains(oldController))
            this.controller.Remove(oldController);
   }
   
   /// <summary>
   /// Remove all instances of Controller from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllController()
   {
      if (controller != null)
         controller.Clear();
   }

}