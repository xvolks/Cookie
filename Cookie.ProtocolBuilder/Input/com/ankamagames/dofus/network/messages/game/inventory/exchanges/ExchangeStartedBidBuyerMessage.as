package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.data.items.SellerBuyerDescriptor;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeStartedBidBuyerMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5904;
       
      
      private var _isInitialized:Boolean = false;
      
      public var buyerDescriptor:SellerBuyerDescriptor;
      
      private var _buyerDescriptortree:FuncTree;
      
      public function ExchangeStartedBidBuyerMessage()
      {
         this.buyerDescriptor = new SellerBuyerDescriptor();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5904;
      }
      
      public function initExchangeStartedBidBuyerMessage(param1:SellerBuyerDescriptor = null) : ExchangeStartedBidBuyerMessage
      {
         this.buyerDescriptor = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.buyerDescriptor = new SellerBuyerDescriptor();
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
         this.serializeAs_ExchangeStartedBidBuyerMessage(param1);
      }
      
      public function serializeAs_ExchangeStartedBidBuyerMessage(param1:ICustomDataOutput) : void
      {
         this.buyerDescriptor.serializeAs_SellerBuyerDescriptor(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeStartedBidBuyerMessage(param1);
      }
      
      public function deserializeAs_ExchangeStartedBidBuyerMessage(param1:ICustomDataInput) : void
      {
         this.buyerDescriptor = new SellerBuyerDescriptor();
         this.buyerDescriptor.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeStartedBidBuyerMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeStartedBidBuyerMessage(param1:FuncTree) : void
      {
         this._buyerDescriptortree = param1.addChild(this._buyerDescriptortreeFunc);
      }
      
      private function _buyerDescriptortreeFunc(param1:ICustomDataInput) : void
      {
         this.buyerDescriptor = new SellerBuyerDescriptor();
         this.buyerDescriptor.deserializeAsync(this._buyerDescriptortree);
      }
   }
}
