// File:    DecorateStateGroup.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class DecorateStateGroup

using System;

public class DecorateStateGroup
{
   
   private int attribute35;
   
   public int Attribute35{
      get { return attribute35; }
      set { attribute35 = value; }
   }
   
   public System.Collections.Generic.List<ActorState> actorState;
   
   /// <summary>
   /// Property for collection of ActorState
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<ActorState> ActorState
   {
      get
      {
         if (actorState == null)
            actorState = new System.Collections.Generic.List<ActorState>();
         return actorState;
      }
      set
      {
         RemoveAllActorState();
         if (value != null)
         {
            foreach (ActorState oActorState in value)
               AddActorState(oActorState);
         }
      }
   }
   
   /// <summary>
   /// Add a new ActorState in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddActorState(ActorState newActorState)
   {
      if (newActorState == null)
         return;
      if (this.actorState == null)
         this.actorState = new System.Collections.Generic.List<ActorState>();
      if (!this.actorState.Contains(newActorState))
         this.actorState.Add(newActorState);
   }
   
   /// <summary>
   /// Remove an existing ActorState from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveActorState(ActorState oldActorState)
   {
      if (oldActorState == null)
         return;
      if (this.actorState != null)
         if (this.actorState.Contains(oldActorState))
            this.actorState.Remove(oldActorState);
   }
   
   /// <summary>
   /// Remove all instances of ActorState from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllActorState()
   {
      if (actorState != null)
         actorState.Clear();
   }

}