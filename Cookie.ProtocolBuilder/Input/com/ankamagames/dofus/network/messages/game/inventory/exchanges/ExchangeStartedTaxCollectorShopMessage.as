package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItem;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeStartedTaxCollectorShopMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6664;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objects:Vector.<ObjectItem>;
      
      public var kamas:Number = 0;
      
      private var _objectstree:FuncTree;
      
      public function ExchangeStartedTaxCollectorShopMessage()
      {
         this.objects = new Vector.<ObjectItem>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6664;
      }
      
      public function initExchangeStartedTaxCollectorShopMessage(param1:Vector.<ObjectItem> = null, param2:Number = 0) : ExchangeStartedTaxCollectorShopMessage
      {
         this.objects = param1;
         this.kamas = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objects = new Vector.<ObjectItem>();
         this.kamas = 0;
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
         this.serializeAs_ExchangeStartedTaxCollectorShopMessage(param1);
      }
      
      public function serializeAs_ExchangeStartedTaxCollectorShopMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.objects.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objects.length)
         {
            (this.objects[_loc2_] as ObjectItem).serializeAs_ObjectItem(param1);
            _loc2_++;
         }
         if(this.kamas < 0 || this.kamas > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kamas + ") on element kamas.");
         }
         param1.writeVarLong(this.kamas);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeStartedTaxCollectorShopMessage(param1);
      }
      
      public function deserializeAs_ExchangeStartedTaxCollectorShopMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItem = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItem();
            _loc4_.deserialize(param1);
            this.objects.push(_loc4_);
            _loc3_++;
         }
         this._kamasFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeStartedTaxCollectorShopMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeStartedTaxCollectorShopMessage(param1:FuncTree) : void
      {
         this._objectstree = param1.addChild(this._objectstreeFunc);
         param1.addChild(this._kamasFunc);
      }
      
      private function _objectstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectstree.addChild(this._objectsFunc);
            _loc3_++;
         }
      }
      
      private function _objectsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItem = new ObjectItem();
         _loc2_.deserialize(param1);
         this.objects.push(_loc2_);
      }
      
      private function _kamasFunc(param1:ICustomDataInput) : void
      {
         this.kamas = param1.readVarUhLong();
         if(this.kamas < 0 || this.kamas > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kamas + ") on element of ExchangeStartedTaxCollectorShopMessage.kamas.");
         }
      }
   }
}
