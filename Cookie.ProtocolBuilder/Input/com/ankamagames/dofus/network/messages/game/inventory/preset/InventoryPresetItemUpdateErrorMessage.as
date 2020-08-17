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
   public class InventoryPresetItemUpdateErrorMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6211;
       
      
      private var _isInitialized:Boolean = false;
      
      public var code:uint = 1;
      
      public function InventoryPresetItemUpdateErrorMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6211;
      }
      
      public function initInventoryPresetItemUpdateErrorMessage(param1:uint = 1) : InventoryPresetItemUpdateErrorMessage
      {
         this.code = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.code = 1;
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
         this.serializeAs_InventoryPresetItemUpdateErrorMessage(param1);
      }
      
      public function serializeAs_InventoryPresetItemUpdateErrorMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.code);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InventoryPresetItemUpdateErrorMessage(param1);
      }
      
      public function deserializeAs_InventoryPresetItemUpdateErrorMessage(param1:ICustomDataInput) : void
      {
         this._codeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InventoryPresetItemUpdateErrorMessage(param1);
      }
      
      public function deserializeAsyncAs_InventoryPresetItemUpdateErrorMessage(param1:FuncTree) : void
      {
         param1.addChild(this._codeFunc);
      }
      
      private function _codeFunc(param1:ICustomDataInput) : void
      {
         this.code = param1.readByte();
         if(this.code < 0)
         {
            throw new Error("Forbidden value (" + this.code + ") on element of InventoryPresetItemUpdateErrorMessage.code.");
         }
      }
   }
}
