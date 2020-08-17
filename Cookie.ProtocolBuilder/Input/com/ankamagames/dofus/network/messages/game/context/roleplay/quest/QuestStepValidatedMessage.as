package com.ankamagames.dofus.network.messages.game.context.roleplay.quest
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class QuestStepValidatedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6099;
       
      
      private var _isInitialized:Boolean = false;
      
      public var questId:uint = 0;
      
      public var stepId:uint = 0;
      
      public function QuestStepValidatedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6099;
      }
      
      public function initQuestStepValidatedMessage(param1:uint = 0, param2:uint = 0) : QuestStepValidatedMessage
      {
         this.questId = param1;
         this.stepId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.questId = 0;
         this.stepId = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_QuestStepValidatedMessage(param1);
      }
      
      public function serializeAs_QuestStepValidatedMessage(param1:ICustomDataOutput) : void
      {
         if(this.questId < 0)
         {
            throw new Error("Forbidden value (" + this.questId + ") on element questId.");
         }
         param1.writeVarShort(this.questId);
         if(this.stepId < 0)
         {
            throw new Error("Forbidden value (" + this.stepId + ") on element stepId.");
         }
         param1.writeVarShort(this.stepId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_QuestStepValidatedMessage(param1);
      }
      
      public function deserializeAs_QuestStepValidatedMessage(param1:ICustomDataInput) : void
      {
         this._questIdFunc(param1);
         this._stepIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_QuestStepValidatedMessage(param1);
      }
      
      public function deserializeAsyncAs_QuestStepValidatedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._questIdFunc);
         param1.addChild(this._stepIdFunc);
      }
      
      private function _questIdFunc(param1:ICustomDataInput) : void
      {
         this.questId = param1.readVarUhShort();
         if(this.questId < 0)
         {
            throw new Error("Forbidden value (" + this.questId + ") on element of QuestStepValidatedMessage.questId.");
         }
      }
      
      private function _stepIdFunc(param1:ICustomDataInput) : void
      {
         this.stepId = param1.readVarUhShort();
         if(this.stepId < 0)
         {
            throw new Error("Forbidden value (" + this.stepId + ") on element of QuestStepValidatedMessage.stepId.");
         }
      }
   }
}
