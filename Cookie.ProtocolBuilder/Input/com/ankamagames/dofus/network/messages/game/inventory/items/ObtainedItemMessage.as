package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ObtainedItemMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6519;
       
      
      private var _isInitialized:Boolean = false;
      
      public var genericId:uint = 0;
      
      public var baseQuantity:uint = 0;
      
      public function ObtainedItemMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6519;
      }
      
      public function initObtainedItemMessage(param1:uint = 0, param2:uint = 0) : ObtainedItemMessage
      {
         this.genericId = param1;
         this.baseQuantity = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.genericId = 0;
         this.baseQuantity = 0;
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
         this.serializeAs_ObtainedItemMessage(param1);
      }
      
      public function serializeAs_ObtainedItemMessage(param1:ICustomDataOutput) : void
      {
         if(this.genericId < 0)
         {
            throw new Error("Forbidden value (" + this.genericId + ") on element genericId.");
         }
         param1.writeVarShort(this.genericId);
         if(this.baseQuantity < 0)
         {
            throw new Error("Forbidden value (" + this.baseQuantity + ") on element baseQuantity.");
         }
         param1.writeVarInt(this.baseQuantity);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObtainedItemMessage(param1);
      }
      
      public function deserializeAs_ObtainedItemMessage(param1:ICustomDataInput) : void
      {
         this._genericIdFunc(param1);
         this._baseQuantityFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObtainedItemMessage(param1);
      }
      
      public function deserializeAsyncAs_ObtainedItemMessage(param1:FuncTree) : void
      {
         param1.addChild(this._genericIdFunc);
         param1.addChild(this._baseQuantityFunc);
      }
      
      private function _genericIdFunc(param1:ICustomDataInput) : void
      {
         this.genericId = param1.readVarUhShort();
         if(this.genericId < 0)
         {
            throw new Error("Forbidden value (" + this.genericId + ") on element of ObtainedItemMessage.genericId.");
         }
      }
      
      private function _baseQuantityFunc(param1:ICustomDataInput) : void
      {
         this.baseQuantity = param1.readVarUhInt();
         if(this.baseQuantity < 0)
         {
            throw new Error("Forbidden value (" + this.baseQuantity + ") on element of ObtainedItemMessage.baseQuantity.");
         }
      }
   }
}
