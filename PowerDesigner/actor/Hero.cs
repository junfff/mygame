// File:    Hero.cs
// Author:  Administrator
// Created: 2018年11月1日 13:46:24
// Purpose: Definition of Class Hero

using System;

public class Hero : Actor
{
   
   private string playerName;
   
   public string PlayerName{
      get { return playerName; }
      set { playerName = value; }
   }
   
   private int ambientState;
   
   public int AmbientState{
      get { return ambientState; }
      set { ambientState = value; }
   }
   
   private int currentTarget;
   
   public int CurrentTarget{
      get { return currentTarget; }
      set { currentTarget = value; }
   }
   
   private int lastTarget;
   
   public int LastTarget{
      get { return lastTarget; }
      set { lastTarget = value; }
   }
   
   private int preSelectTarget;
   
   public int PreSelectTarget{
      get { return preSelectTarget; }
      set { preSelectTarget = value; }
   }
   
   private int heroType;
   
   public int HeroType{
      get { return heroType; }
      set { heroType = value; }
   }
   
   public System.Collections.Generic.List<Skin> skin;
   
   /// <summary>
   /// Property for collection of Skin
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Skin> Skin
   {
      get
      {
         if (skin == null)
            skin = new System.Collections.Generic.List<Skin>();
         return skin;
      }
      set
      {
         RemoveAllSkin();
         if (value != null)
         {
            foreach (Skin oSkin in value)
               AddSkin(oSkin);
         }
      }
   }
   
   /// <summary>
   /// Add a new Skin in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddSkin(Skin newSkin)
   {
      if (newSkin == null)
         return;
      if (this.skin == null)
         this.skin = new System.Collections.Generic.List<Skin>();
      if (!this.skin.Contains(newSkin))
         this.skin.Add(newSkin);
   }
   
   /// <summary>
   /// Remove an existing Skin from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveSkin(Skin oldSkin)
   {
      if (oldSkin == null)
         return;
      if (this.skin != null)
         if (this.skin.Contains(oldSkin))
            this.skin.Remove(oldSkin);
   }
   
   /// <summary>
   /// Remove all instances of Skin from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllSkin()
   {
      if (skin != null)
         skin.Clear();
   }
   public System.Collections.Generic.List<Skill> skill;
   
   /// <summary>
   /// Property for collection of Skill
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<Skill> Skill
   {
      get
      {
         if (skill == null)
            skill = new System.Collections.Generic.List<Skill>();
         return skill;
      }
      set
      {
         RemoveAllSkill();
         if (value != null)
         {
            foreach (Skill oSkill in value)
               AddSkill(oSkill);
         }
      }
   }
   
   /// <summary>
   /// Add a new Skill in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddSkill(Skill newSkill)
   {
      if (newSkill == null)
         return;
      if (this.skill == null)
         this.skill = new System.Collections.Generic.List<Skill>();
      if (!this.skill.Contains(newSkill))
         this.skill.Add(newSkill);
   }
   
   /// <summary>
   /// Remove an existing Skill from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveSkill(Skill oldSkill)
   {
      if (oldSkill == null)
         return;
      if (this.skill != null)
         if (this.skill.Contains(oldSkill))
            this.skill.Remove(oldSkill);
   }
   
   /// <summary>
   /// Remove all instances of Skill from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllSkill()
   {
      if (skill != null)
         skill.Clear();
   }
   public System.Collections.Generic.List<RecommendSkillPoint> recommendSkillPoint;
   
   /// <summary>
   /// Property for collection of RecommendSkillPoint
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<RecommendSkillPoint> RecommendSkillPoint
   {
      get
      {
         if (recommendSkillPoint == null)
            recommendSkillPoint = new System.Collections.Generic.List<RecommendSkillPoint>();
         return recommendSkillPoint;
      }
      set
      {
         RemoveAllRecommendSkillPoint();
         if (value != null)
         {
            foreach (RecommendSkillPoint oRecommendSkillPoint in value)
               AddRecommendSkillPoint(oRecommendSkillPoint);
         }
      }
   }
   
   /// <summary>
   /// Add a new RecommendSkillPoint in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddRecommendSkillPoint(RecommendSkillPoint newRecommendSkillPoint)
   {
      if (newRecommendSkillPoint == null)
         return;
      if (this.recommendSkillPoint == null)
         this.recommendSkillPoint = new System.Collections.Generic.List<RecommendSkillPoint>();
      if (!this.recommendSkillPoint.Contains(newRecommendSkillPoint))
         this.recommendSkillPoint.Add(newRecommendSkillPoint);
   }
   
   /// <summary>
   /// Remove an existing RecommendSkillPoint from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveRecommendSkillPoint(RecommendSkillPoint oldRecommendSkillPoint)
   {
      if (oldRecommendSkillPoint == null)
         return;
      if (this.recommendSkillPoint != null)
         if (this.recommendSkillPoint.Contains(oldRecommendSkillPoint))
            this.recommendSkillPoint.Remove(oldRecommendSkillPoint);
   }
   
   /// <summary>
   /// Remove all instances of RecommendSkillPoint from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllRecommendSkillPoint()
   {
      if (recommendSkillPoint != null)
         recommendSkillPoint.Clear();
   }
   public System.Collections.Generic.List<IitemSkill> iitemSkill;
   
   /// <summary>
   /// Property for collection of IitemSkill
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<IitemSkill> IitemSkill
   {
      get
      {
         if (iitemSkill == null)
            iitemSkill = new System.Collections.Generic.List<IitemSkill>();
         return iitemSkill;
      }
      set
      {
         RemoveAllIitemSkill();
         if (value != null)
         {
            foreach (IitemSkill oIitemSkill in value)
               AddIitemSkill(oIitemSkill);
         }
      }
   }
   
   /// <summary>
   /// Add a new IitemSkill in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddIitemSkill(IitemSkill newIitemSkill)
   {
      if (newIitemSkill == null)
         return;
      if (this.iitemSkill == null)
         this.iitemSkill = new System.Collections.Generic.List<IitemSkill>();
      if (!this.iitemSkill.Contains(newIitemSkill))
         this.iitemSkill.Add(newIitemSkill);
   }
   
   /// <summary>
   /// Remove an existing IitemSkill from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveIitemSkill(IitemSkill oldIitemSkill)
   {
      if (oldIitemSkill == null)
         return;
      if (this.iitemSkill != null)
         if (this.iitemSkill.Contains(oldIitemSkill))
            this.iitemSkill.Remove(oldIitemSkill);
   }
   
   /// <summary>
   /// Remove all instances of IitemSkill from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllIitemSkill()
   {
      if (iitemSkill != null)
         iitemSkill.Clear();
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