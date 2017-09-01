package com.ankamagames.dofus.network.messages.game.context.mount
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PaddockBuyResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6516;
       
      
      private var _isInitialized:Boolean = false;
      
      public var paddockId:int = 0;
      
      public var bought:Boolean = false;
      
      public var realPrice:Number = 0;
      
      public function PaddockBuyResultMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6516;
      }
      
      public function initPaddockBuyResultMessage(param1:int = 0, param2:Boolean = false, param3:Number = 0) : PaddockBuyResultMessage
      {
         this.paddockId = param1;
         this.bought = param2;
         this.realPrice = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.paddockId = 0;
         this.bought = false;
         this.realPrice = 0;
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
         this.serializeAs_PaddockBuyResultMessage(param1);
      }
      
      public function serializeAs_PaddockBuyResultMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.paddockId);
         param1.writeBoolean(this.bought);
         if(this.realPrice < 0 || this.realPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.realPrice + ") on element realPrice.");
         }
         param1.writeVarLong(this.realPrice);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockBuyResultMessage(param1);
      }
      
      public function deserializeAs_PaddockBuyResultMessage(param1:ICustomDataInput) : void
      {
         this._paddockIdFunc(param1);
         this._boughtFunc(param1);
         this._realPriceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockBuyResultMessage(param1);
      }
      
      public function deserializeAsyncAs_PaddockBuyResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this._paddockIdFunc);
         param1.addChild(this._boughtFunc);
         param1.addChild(this._realPriceFunc);
      }
      
      private function _paddockIdFunc(param1:ICustomDataInput) : void
      {
         this.paddockId = param1.readInt();
      }
      
      private function _boughtFunc(param1:ICustomDataInput) : void
      {
         this.bought = param1.readBoolean();
      }
      
      private function _realPriceFunc(param1:ICustomDataInput) : void
      {
         this.realPrice = param1.readVarUhLong();
         if(this.realPrice < 0 || this.realPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.realPrice + ") on element of PaddockBuyResultMessage.realPrice.");
         }
      }
   }
}
