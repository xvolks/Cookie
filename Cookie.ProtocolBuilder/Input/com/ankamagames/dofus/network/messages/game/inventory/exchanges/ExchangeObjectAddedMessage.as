package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItem;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeObjectAddedMessage extends ExchangeObjectMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5516;
       
      
      private var _isInitialized:Boolean = false;
      
      public var object:ObjectItem;
      
      private var _objecttree:FuncTree;
      
      public function ExchangeObjectAddedMessage()
      {
         this.object = new ObjectItem();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5516;
      }
      
      public function initExchangeObjectAddedMessage(param1:Boolean = false, param2:ObjectItem = null) : ExchangeObjectAddedMessage
      {
         super.initExchangeObjectMessage(param1);
         this.object = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.object = new ObjectItem();
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
         this.serializeAs_ExchangeObjectAddedMessage(param1);
      }
      
      public function serializeAs_ExchangeObjectAddedMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ExchangeObjectMessage(param1);
         this.object.serializeAs_ObjectItem(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeObjectAddedMessage(param1);
      }
      
      public function deserializeAs_ExchangeObjectAddedMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.object = new ObjectItem();
         this.object.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeObjectAddedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeObjectAddedMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._objecttree = param1.addChild(this._objecttreeFunc);
      }
      
      private function _objecttreeFunc(param1:ICustomDataInput) : void
      {
         this.object = new ObjectItem();
         this.object.deserializeAsync(this._objecttree);
      }
   }
}
