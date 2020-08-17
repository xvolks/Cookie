package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItemToSellInNpcShop;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeStartOkNpcShopMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5761;
       
      
      private var _isInitialized:Boolean = false;
      
      public var npcSellerId:Number = 0;
      
      public var tokenId:uint = 0;
      
      public var objectsInfos:Vector.<ObjectItemToSellInNpcShop>;
      
      private var _objectsInfostree:FuncTree;
      
      public function ExchangeStartOkNpcShopMessage()
      {
         this.objectsInfos = new Vector.<ObjectItemToSellInNpcShop>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5761;
      }
      
      public function initExchangeStartOkNpcShopMessage(param1:Number = 0, param2:uint = 0, param3:Vector.<ObjectItemToSellInNpcShop> = null) : ExchangeStartOkNpcShopMessage
      {
         this.npcSellerId = param1;
         this.tokenId = param2;
         this.objectsInfos = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.npcSellerId = 0;
         this.tokenId = 0;
         this.objectsInfos = new Vector.<ObjectItemToSellInNpcShop>();
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
         this.serializeAs_ExchangeStartOkNpcShopMessage(param1);
      }
      
      public function serializeAs_ExchangeStartOkNpcShopMessage(param1:ICustomDataOutput) : void
      {
         if(this.npcSellerId < -9007199254740990 || this.npcSellerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.npcSellerId + ") on element npcSellerId.");
         }
         param1.writeDouble(this.npcSellerId);
         if(this.tokenId < 0)
         {
            throw new Error("Forbidden value (" + this.tokenId + ") on element tokenId.");
         }
         param1.writeVarShort(this.tokenId);
         param1.writeShort(this.objectsInfos.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objectsInfos.length)
         {
            (this.objectsInfos[_loc2_] as ObjectItemToSellInNpcShop).serializeAs_ObjectItemToSellInNpcShop(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeStartOkNpcShopMessage(param1);
      }
      
      public function deserializeAs_ExchangeStartOkNpcShopMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItemToSellInNpcShop = null;
         this._npcSellerIdFunc(param1);
         this._tokenIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItemToSellInNpcShop();
            _loc4_.deserialize(param1);
            this.objectsInfos.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeStartOkNpcShopMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeStartOkNpcShopMessage(param1:FuncTree) : void
      {
         param1.addChild(this._npcSellerIdFunc);
         param1.addChild(this._tokenIdFunc);
         this._objectsInfostree = param1.addChild(this._objectsInfostreeFunc);
      }
      
      private function _npcSellerIdFunc(param1:ICustomDataInput) : void
      {
         this.npcSellerId = param1.readDouble();
         if(this.npcSellerId < -9007199254740990 || this.npcSellerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.npcSellerId + ") on element of ExchangeStartOkNpcShopMessage.npcSellerId.");
         }
      }
      
      private function _tokenIdFunc(param1:ICustomDataInput) : void
      {
         this.tokenId = param1.readVarUhShort();
         if(this.tokenId < 0)
         {
            throw new Error("Forbidden value (" + this.tokenId + ") on element of ExchangeStartOkNpcShopMessage.tokenId.");
         }
      }
      
      private function _objectsInfostreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectsInfostree.addChild(this._objectsInfosFunc);
            _loc3_++;
         }
      }
      
      private function _objectsInfosFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItemToSellInNpcShop = new ObjectItemToSellInNpcShop();
         _loc2_.deserialize(param1);
         this.objectsInfos.push(_loc2_);
      }
   }
}
