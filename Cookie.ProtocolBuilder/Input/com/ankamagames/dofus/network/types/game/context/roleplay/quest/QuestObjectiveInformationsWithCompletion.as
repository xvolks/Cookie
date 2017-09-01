package com.ankamagames.dofus.network.types.game.context.roleplay.quest
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class QuestObjectiveInformationsWithCompletion extends QuestObjectiveInformations implements INetworkType
   {
      
      public static const protocolId:uint = 386;
       
      
      public var curCompletion:uint = 0;
      
      public var maxCompletion:uint = 0;
      
      public function QuestObjectiveInformationsWithCompletion()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 386;
      }
      
      public function initQuestObjectiveInformationsWithCompletion(param1:uint = 0, param2:Boolean = false, param3:Vector.<String> = null, param4:uint = 0, param5:uint = 0) : QuestObjectiveInformationsWithCompletion
      {
         super.initQuestObjectiveInformations(param1,param2,param3);
         this.curCompletion = param4;
         this.maxCompletion = param5;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.curCompletion = 0;
         this.maxCompletion = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_QuestObjectiveInformationsWithCompletion(param1);
      }
      
      public function serializeAs_QuestObjectiveInformationsWithCompletion(param1:ICustomDataOutput) : void
      {
         super.serializeAs_QuestObjectiveInformations(param1);
         if(this.curCompletion < 0)
         {
            throw new Error("Forbidden value (" + this.curCompletion + ") on element curCompletion.");
         }
         param1.writeVarShort(this.curCompletion);
         if(this.maxCompletion < 0)
         {
            throw new Error("Forbidden value (" + this.maxCompletion + ") on element maxCompletion.");
         }
         param1.writeVarShort(this.maxCompletion);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_QuestObjectiveInformationsWithCompletion(param1);
      }
      
      public function deserializeAs_QuestObjectiveInformationsWithCompletion(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._curCompletionFunc(param1);
         this._maxCompletionFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_QuestObjectiveInformationsWithCompletion(param1);
      }
      
      public function deserializeAsyncAs_QuestObjectiveInformationsWithCompletion(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._curCompletionFunc);
         param1.addChild(this._maxCompletionFunc);
      }
      
      private function _curCompletionFunc(param1:ICustomDataInput) : void
      {
         this.curCompletion = param1.readVarUhShort();
         if(this.curCompletion < 0)
         {
            throw new Error("Forbidden value (" + this.curCompletion + ") on element of QuestObjectiveInformationsWithCompletion.curCompletion.");
         }
      }
      
      private function _maxCompletionFunc(param1:ICustomDataInput) : void
      {
         this.maxCompletion = param1.readVarUhShort();
         if(this.maxCompletion < 0)
         {
            throw new Error("Forbidden value (" + this.maxCompletion + ") on element of QuestObjectiveInformationsWithCompletion.maxCompletion.");
         }
      }
   }
}
