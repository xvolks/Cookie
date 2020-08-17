package com.ankamagames.dofus.network.messages.game.context.roleplay.houses.guild
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HouseGuildShareRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5704;
       
      
      private var _isInitialized:Boolean = false;
      
      public var houseId:uint = 0;
      
      public var instanceId:uint = 0;
      
      public var enable:Boolean = false;
      
      public var rights:uint = 0;
      
      public function HouseGuildShareRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5704;
      }
      
      public function initHouseGuildShareRequestMessage(param1:uint = 0, param2:uint = 0, param3:Boolean = false, param4:uint = 0) : HouseGuildShareRequestMessage
      {
         this.houseId = param1;
         this.instanceId = param2;
         this.enable = param3;
         this.rights = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.houseId = 0;
         this.instanceId = 0;
         this.enable = false;
         this.rights = 0;
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
         this.serializeAs_HouseGuildShareRequestMessage(param1);
      }
      
      public function serializeAs_HouseGuildShareRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element houseId.");
         }
         param1.writeVarInt(this.houseId);
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element instanceId.");
         }
         param1.writeInt(this.instanceId);
         param1.writeBoolean(this.enable);
         if(this.rights < 0)
         {
            throw new Error("Forbidden value (" + this.rights + ") on element rights.");
         }
         param1.writeVarInt(this.rights);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseGuildShareRequestMessage(param1);
      }
      
      public function deserializeAs_HouseGuildShareRequestMessage(param1:ICustomDataInput) : void
      {
         this._houseIdFunc(param1);
         this._instanceIdFunc(param1);
         this._enableFunc(param1);
         this._rightsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseGuildShareRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_HouseGuildShareRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._houseIdFunc);
         param1.addChild(this._instanceIdFunc);
         param1.addChild(this._enableFunc);
         param1.addChild(this._rightsFunc);
      }
      
      private function _houseIdFunc(param1:ICustomDataInput) : void
      {
         this.houseId = param1.readVarUhInt();
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element of HouseGuildShareRequestMessage.houseId.");
         }
      }
      
      private function _instanceIdFunc(param1:ICustomDataInput) : void
      {
         this.instanceId = param1.readInt();
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element of HouseGuildShareRequestMessage.instanceId.");
         }
      }
      
      private function _enableFunc(param1:ICustomDataInput) : void
      {
         this.enable = param1.readBoolean();
      }
      
      private function _rightsFunc(param1:ICustomDataInput) : void
      {
         this.rights = param1.readVarUhInt();
         if(this.rights < 0)
         {
            throw new Error("Forbidden value (" + this.rights + ") on element of HouseGuildShareRequestMessage.rights.");
         }
      }
   }
}
