package com.ankamagames.dofus.network.messages.game.house
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HouseTeleportRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6726;
       
      
      private var _isInitialized:Boolean = false;
      
      public var houseId:uint = 0;
      
      public var houseInstanceId:int = 0;
      
      public function HouseTeleportRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6726;
      }
      
      public function initHouseTeleportRequestMessage(param1:uint = 0, param2:int = 0) : HouseTeleportRequestMessage
      {
         this.houseId = param1;
         this.houseInstanceId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.houseId = 0;
         this.houseInstanceId = 0;
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
         this.serializeAs_HouseTeleportRequestMessage(param1);
      }
      
      public function serializeAs_HouseTeleportRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element houseId.");
         }
         param1.writeVarInt(this.houseId);
         param1.writeInt(this.houseInstanceId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseTeleportRequestMessage(param1);
      }
      
      public function deserializeAs_HouseTeleportRequestMessage(param1:ICustomDataInput) : void
      {
         this._houseIdFunc(param1);
         this._houseInstanceIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseTeleportRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_HouseTeleportRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._houseIdFunc);
         param1.addChild(this._houseInstanceIdFunc);
      }
      
      private function _houseIdFunc(param1:ICustomDataInput) : void
      {
         this.houseId = param1.readVarUhInt();
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element of HouseTeleportRequestMessage.houseId.");
         }
      }
      
      private function _houseInstanceIdFunc(param1:ICustomDataInput) : void
      {
         this.houseInstanceId = param1.readInt();
      }
   }
}
