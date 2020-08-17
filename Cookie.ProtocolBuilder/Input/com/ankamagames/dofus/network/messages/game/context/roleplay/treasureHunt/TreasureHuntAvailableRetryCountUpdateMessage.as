package com.ankamagames.dofus.network.messages.game.context.roleplay.treasureHunt
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TreasureHuntAvailableRetryCountUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6491;
       
      
      private var _isInitialized:Boolean = false;
      
      public var questType:uint = 0;
      
      public var availableRetryCount:int = 0;
      
      public function TreasureHuntAvailableRetryCountUpdateMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6491;
      }
      
      public function initTreasureHuntAvailableRetryCountUpdateMessage(param1:uint = 0, param2:int = 0) : TreasureHuntAvailableRetryCountUpdateMessage
      {
         this.questType = param1;
         this.availableRetryCount = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.questType = 0;
         this.availableRetryCount = 0;
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
         this.serializeAs_TreasureHuntAvailableRetryCountUpdateMessage(param1);
      }
      
      public function serializeAs_TreasureHuntAvailableRetryCountUpdateMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.questType);
         param1.writeInt(this.availableRetryCount);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TreasureHuntAvailableRetryCountUpdateMessage(param1);
      }
      
      public function deserializeAs_TreasureHuntAvailableRetryCountUpdateMessage(param1:ICustomDataInput) : void
      {
         this._questTypeFunc(param1);
         this._availableRetryCountFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TreasureHuntAvailableRetryCountUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_TreasureHuntAvailableRetryCountUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._questTypeFunc);
         param1.addChild(this._availableRetryCountFunc);
      }
      
      private function _questTypeFunc(param1:ICustomDataInput) : void
      {
         this.questType = param1.readByte();
         if(this.questType < 0)
         {
            throw new Error("Forbidden value (" + this.questType + ") on element of TreasureHuntAvailableRetryCountUpdateMessage.questType.");
         }
      }
      
      private function _availableRetryCountFunc(param1:ICustomDataInput) : void
      {
         this.availableRetryCount = param1.readInt();
      }
   }
}
