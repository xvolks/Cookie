package com.ankamagames.dofus.network.types.game.context.roleplay.quest
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class QuestActiveInformations implements INetworkType
   {
      
      public static const protocolId:uint = 381;
       
      
      public var questId:uint = 0;
      
      public function QuestActiveInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 381;
      }
      
      public function initQuestActiveInformations(param1:uint = 0) : QuestActiveInformations
      {
         this.questId = param1;
         return this;
      }
      
      public function reset() : void
      {
         this.questId = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_QuestActiveInformations(param1);
      }
      
      public function serializeAs_QuestActiveInformations(param1:ICustomDataOutput) : void
      {
         if(this.questId < 0)
         {
            throw new Error("Forbidden value (" + this.questId + ") on element questId.");
         }
         param1.writeVarShort(this.questId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_QuestActiveInformations(param1);
      }
      
      public function deserializeAs_QuestActiveInformations(param1:ICustomDataInput) : void
      {
         this._questIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_QuestActiveInformations(param1);
      }
      
      public function deserializeAsyncAs_QuestActiveInformations(param1:FuncTree) : void
      {
         param1.addChild(this._questIdFunc);
      }
      
      private function _questIdFunc(param1:ICustomDataInput) : void
      {
         this.questId = param1.readVarUhShort();
         if(this.questId < 0)
         {
            throw new Error("Forbidden value (" + this.questId + ") on element of QuestActiveInformations.questId.");
         }
      }
   }
}
