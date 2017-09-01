package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeBidPriceForSellerMessage extends ExchangeBidPriceMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6464;
       
      
      private var _isInitialized:Boolean = false;
      
      public var allIdentical:Boolean = false;
      
      public var minimalPrices:Vector.<Number>;
      
      private var _minimalPricestree:FuncTree;
      
      public function ExchangeBidPriceForSellerMessage()
      {
         this.minimalPrices = new Vector.<Number>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6464;
      }
      
      public function initExchangeBidPriceForSellerMessage(param1:uint = 0, param2:Number = 0, param3:Boolean = false, param4:Vector.<Number> = null) : ExchangeBidPriceForSellerMessage
      {
         super.initExchangeBidPriceMessage(param1,param2);
         this.allIdentical = param3;
         this.minimalPrices = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.allIdentical = false;
         this.minimalPrices = new Vector.<Number>();
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
         this.serializeAs_ExchangeBidPriceForSellerMessage(param1);
      }
      
      public function serializeAs_ExchangeBidPriceForSellerMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ExchangeBidPriceMessage(param1);
         param1.writeBoolean(this.allIdentical);
         param1.writeShort(this.minimalPrices.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.minimalPrices.length)
         {
            if(this.minimalPrices[_loc2_] < 0 || this.minimalPrices[_loc2_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.minimalPrices[_loc2_] + ") on element 2 (starting at 1) of minimalPrices.");
            }
            param1.writeVarLong(this.minimalPrices[_loc2_]);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeBidPriceForSellerMessage(param1);
      }
      
      public function deserializeAs_ExchangeBidPriceForSellerMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:Number = NaN;
         super.deserialize(param1);
         this._allIdenticalFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarUhLong();
            if(_loc4_ < 0 || _loc4_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of minimalPrices.");
            }
            this.minimalPrices.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeBidPriceForSellerMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeBidPriceForSellerMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._allIdenticalFunc);
         this._minimalPricestree = param1.addChild(this._minimalPricestreeFunc);
      }
      
      private function _allIdenticalFunc(param1:ICustomDataInput) : void
      {
         this.allIdentical = param1.readBoolean();
      }
      
      private function _minimalPricestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._minimalPricestree.addChild(this._minimalPricesFunc);
            _loc3_++;
         }
      }
      
      private function _minimalPricesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readVarUhLong();
         if(_loc2_ < 0 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of minimalPrices.");
         }
         this.minimalPrices.push(_loc2_);
      }
   }
}
