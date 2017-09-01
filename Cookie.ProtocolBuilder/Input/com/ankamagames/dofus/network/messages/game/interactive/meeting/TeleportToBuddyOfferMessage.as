package com.ankamagames.dofus.network.messages.game.interactive.meeting
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TeleportToBuddyOfferMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6287;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dungeonId:uint = 0;
      
      public var buddyId:Number = 0;
      
      public var timeLeft:uint = 0;
      
      public function TeleportToBuddyOfferMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6287;
      }
      
      public function initTeleportToBuddyOfferMessage(param1:uint = 0, param2:Number = 0, param3:uint = 0) : TeleportToBuddyOfferMessage
      {
         this.dungeonId = param1;
         this.buddyId = param2;
         this.timeLeft = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dungeonId = 0;
         this.buddyId = 0;
         this.timeLeft = 0;
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
         this.serializeAs_TeleportToBuddyOfferMessage(param1);
      }
      
      public function serializeAs_TeleportToBuddyOfferMessage(param1:ICustomDataOutput) : void
      {
         if(this.dungeonId < 0)
         {
            throw new Error("Forbidden value (" + this.dungeonId + ") on element dungeonId.");
         }
         param1.writeVarShort(this.dungeonId);
         if(this.buddyId < 0 || this.buddyId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.buddyId + ") on element buddyId.");
         }
         param1.writeVarLong(this.buddyId);
         if(this.timeLeft < 0)
         {
            throw new Error("Forbidden value (" + this.timeLeft + ") on element timeLeft.");
         }
         param1.writeVarInt(this.timeLeft);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TeleportToBuddyOfferMessage(param1);
      }
      
      public function deserializeAs_TeleportToBuddyOfferMessage(param1:ICustomDataInput) : void
      {
         this._dungeonIdFunc(param1);
         this._buddyIdFunc(param1);
         this._timeLeftFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TeleportToBuddyOfferMessage(param1);
      }
      
      public function deserializeAsyncAs_TeleportToBuddyOfferMessage(param1:FuncTree) : void
      {
         param1.addChild(this._dungeonIdFunc);
         param1.addChild(this._buddyIdFunc);
         param1.addChild(this._timeLeftFunc);
      }
      
      private function _dungeonIdFunc(param1:ICustomDataInput) : void
      {
         this.dungeonId = param1.readVarUhShort();
         if(this.dungeonId < 0)
         {
            throw new Error("Forbidden value (" + this.dungeonId + ") on element of TeleportToBuddyOfferMessage.dungeonId.");
         }
      }
      
      private function _buddyIdFunc(param1:ICustomDataInput) : void
      {
         this.buddyId = param1.readVarUhLong();
         if(this.buddyId < 0 || this.buddyId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.buddyId + ") on element of TeleportToBuddyOfferMessage.buddyId.");
         }
      }
      
      private function _timeLeftFunc(param1:ICustomDataInput) : void
      {
         this.timeLeft = param1.readVarUhInt();
         if(this.timeLeft < 0)
         {
            throw new Error("Forbidden value (" + this.timeLeft + ") on element of TeleportToBuddyOfferMessage.timeLeft.");
         }
      }
   }
}
