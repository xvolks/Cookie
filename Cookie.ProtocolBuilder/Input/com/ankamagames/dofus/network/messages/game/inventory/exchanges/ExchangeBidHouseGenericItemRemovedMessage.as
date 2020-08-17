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
   public class ExchangeBidHouseGenericItemRemovedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5948;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objGenericId:uint = 0;
      
      public function ExchangeBidHouseGenericItemRemovedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5948;
      }
      
      public function initExchangeBidHouseGenericItemRemovedMessage(param1:uint = 0) : ExchangeBidHouseGenericItemRemovedMessage
      {
         this.objGenericId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objGenericId = 0;
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
         this.serializeAs_ExchangeBidHouseGenericItemRemovedMessage(param1);
      }
      
      public function serializeAs_ExchangeBidHouseGenericItemRemovedMessage(param1:ICustomDataOutput) : void
      {
         if(this.objGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.objGenericId + ") on element objGenericId.");
         }
         param1.writeVarShort(this.objGenericId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeBidHouseGenericItemRemovedMessage(param1);
      }
      
      public function deserializeAs_ExchangeBidHouseGenericItemRemovedMessage(param1:ICustomDataInput) : void
      {
         this._objGenericIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeBidHouseGenericItemRemovedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeBidHouseGenericItemRemovedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._objGenericIdFunc);
      }
      
      private function _objGenericIdFunc(param1:ICustomDataInput) : void
      {
         this.objGenericId = param1.readVarUhShort();
         if(this.objGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.objGenericId + ") on element of ExchangeBidHouseGenericItemRemovedMessage.objGenericId.");
         }
      }
   }
}
