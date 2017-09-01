package com.ankamagames.dofus.network.messages.game.context.roleplay.quest
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.roleplay.quest.QuestActiveInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class QuestStepInfoMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5625;
       
      
      private var _isInitialized:Boolean = false;
      
      public var infos:QuestActiveInformations;
      
      private var _infostree:FuncTree;
      
      public function QuestStepInfoMessage()
      {
         this.infos = new QuestActiveInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5625;
      }
      
      public function initQuestStepInfoMessage(param1:QuestActiveInformations = null) : QuestStepInfoMessage
      {
         this.infos = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.infos = new QuestActiveInformations();
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
         this.serializeAs_QuestStepInfoMessage(param1);
      }
      
      public function serializeAs_QuestStepInfoMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.infos.getTypeId());
         this.infos.serialize(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_QuestStepInfoMessage(param1);
      }
      
      public function deserializeAs_QuestStepInfoMessage(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.infos = ProtocolTypeManager.getInstance(QuestActiveInformations,_loc2_);
         this.infos.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_QuestStepInfoMessage(param1);
      }
      
      public function deserializeAsyncAs_QuestStepInfoMessage(param1:FuncTree) : void
      {
         this._infostree = param1.addChild(this._infostreeFunc);
      }
      
      private function _infostreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.infos = ProtocolTypeManager.getInstance(QuestActiveInformations,_loc2_);
         this.infos.deserializeAsync(this._infostree);
      }
   }
}
