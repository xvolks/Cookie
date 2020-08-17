package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ObjectUseMultipleMessage extends ObjectUseMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6234;
       
      
      private var _isInitialized:Boolean = false;
      
      public var quantity:uint = 0;
      
      public function ObjectUseMultipleMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6234;
      }
      
      public function initObjectUseMultipleMessage(param1:uint = 0, param2:uint = 0) : ObjectUseMultipleMessage
      {
         super.initObjectUseMessage(param1);
         this.quantity = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.quantity = 0;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectUseMultipleMessage(param1);
      }
      
      public function serializeAs_ObjectUseMultipleMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectUseMessage(param1);
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element quantity.");
         }
         param1.writeVarInt(this.quantity);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectUseMultipleMessage(param1);
      }
      
      public function deserializeAs_ObjectUseMultipleMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._quantityFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectUseMultipleMessage(param1);
      }
      
      public function deserializeAsyncAs_ObjectUseMultipleMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._quantityFunc);
      }
      
      private function _quantityFunc(param1:ICustomDataInput) : void
      {
         this.quantity = param1.readVarUhInt();
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element of ObjectUseMultipleMessage.quantity.");
         }
      }
   }
}
