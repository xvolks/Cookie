package com.ankamagames.dofus.network.messages.game.inventory.preset
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InventoryPresetItemUpdateRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6210;
       
      
      private var _isInitialized:Boolean = false;
      
      public var presetId:uint = 0;
      
      public var position:uint = 63;
      
      public var objUid:uint = 0;
      
      public function InventoryPresetItemUpdateRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6210;
      }
      
      public function initInventoryPresetItemUpdateRequestMessage(param1:uint = 0, param2:uint = 63, param3:uint = 0) : InventoryPresetItemUpdateRequestMessage
      {
         this.presetId = param1;
         this.position = param2;
         this.objUid = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.presetId = 0;
         this.position = 63;
         this.objUid = 0;
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
         this.serializeAs_InventoryPresetItemUpdateRequestMessage(param1);
      }
      
      public function serializeAs_InventoryPresetItemUpdateRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.presetId < 0)
         {
            throw new Error("Forbidden value (" + this.presetId + ") on element presetId.");
         }
         param1.writeByte(this.presetId);
         param1.writeByte(this.position);
         if(this.objUid < 0)
         {
            throw new Error("Forbidden value (" + this.objUid + ") on element objUid.");
         }
         param1.writeVarInt(this.objUid);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InventoryPresetItemUpdateRequestMessage(param1);
      }
      
      public function deserializeAs_InventoryPresetItemUpdateRequestMessage(param1:ICustomDataInput) : void
      {
         this._presetIdFunc(param1);
         this._positionFunc(param1);
         this._objUidFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InventoryPresetItemUpdateRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_InventoryPresetItemUpdateRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._presetIdFunc);
         param1.addChild(this._positionFunc);
         param1.addChild(this._objUidFunc);
      }
      
      private function _presetIdFunc(param1:ICustomDataInput) : void
      {
         this.presetId = param1.readByte();
         if(this.presetId < 0)
         {
            throw new Error("Forbidden value (" + this.presetId + ") on element of InventoryPresetItemUpdateRequestMessage.presetId.");
         }
      }
      
      private function _positionFunc(param1:ICustomDataInput) : void
      {
         this.position = param1.readUnsignedByte();
         if(this.position < 0 || this.position > 255)
         {
            throw new Error("Forbidden value (" + this.position + ") on element of InventoryPresetItemUpdateRequestMessage.position.");
         }
      }
      
      private function _objUidFunc(param1:ICustomDataInput) : void
      {
         this.objUid = param1.readVarUhInt();
         if(this.objUid < 0)
         {
            throw new Error("Forbidden value (" + this.objUid + ") on element of InventoryPresetItemUpdateRequestMessage.objUid.");
         }
      }
   }
}
