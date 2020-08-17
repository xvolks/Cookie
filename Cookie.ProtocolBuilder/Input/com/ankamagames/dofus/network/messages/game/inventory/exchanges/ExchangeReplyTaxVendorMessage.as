package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeReplyTaxVendorMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5787;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectValue:Number = 0;
      
      public var totalTaxValue:Number = 0;
      
      public function ExchangeReplyTaxVendorMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5787;
      }
      
      public function initExchangeReplyTaxVendorMessage(param1:Number = 0, param2:Number = 0) : ExchangeReplyTaxVendorMessage
      {
         this.objectValue = param1;
         this.totalTaxValue = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectValue = 0;
         this.totalTaxValue = 0;
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
         this.serializeAs_ExchangeReplyTaxVendorMessage(param1);
      }
      
      public function serializeAs_ExchangeReplyTaxVendorMessage(param1:ICustomDataOutput) : void
      {
         if(this.objectValue < 0 || this.objectValue > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.objectValue + ") on element objectValue.");
         }
         param1.writeVarLong(this.objectValue);
         if(this.totalTaxValue < 0 || this.totalTaxValue > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.totalTaxValue + ") on element totalTaxValue.");
         }
         param1.writeVarLong(this.totalTaxValue);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeReplyTaxVendorMessage(param1);
      }
      
      public function deserializeAs_ExchangeReplyTaxVendorMessage(param1:ICustomDataInput) : void
      {
         this._objectValueFunc(param1);
         this._totalTaxValueFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeReplyTaxVendorMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeReplyTaxVendorMessage(param1:FuncTree) : void
      {
         param1.addChild(this._objectValueFunc);
         param1.addChild(this._totalTaxValueFunc);
      }
      
      private function _objectValueFunc(param1:ICustomDataInput) : void
      {
         this.objectValue = param1.readVarUhLong();
         if(this.objectValue < 0 || this.objectValue > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.objectValue + ") on element of ExchangeReplyTaxVendorMessage.objectValue.");
         }
      }
      
      private function _totalTaxValueFunc(param1:ICustomDataInput) : void
      {
         this.totalTaxValue = param1.readVarUhLong();
         if(this.totalTaxValue < 0 || this.totalTaxValue > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.totalTaxValue + ") on element of ExchangeReplyTaxVendorMessage.totalTaxValue.");
         }
      }
   }
}
