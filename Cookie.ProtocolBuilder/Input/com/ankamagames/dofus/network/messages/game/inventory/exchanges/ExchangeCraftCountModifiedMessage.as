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
   public class ExchangeCraftCountModifiedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6595;
       
      
      private var _isInitialized:Boolean = false;
      
      public var count:int = 0;
      
      public function ExchangeCraftCountModifiedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6595;
      }
      
      public function initExchangeCraftCountModifiedMessage(param1:int = 0) : ExchangeCraftCountModifiedMessage
      {
         this.count = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.count = 0;
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
         this.serializeAs_ExchangeCraftCountModifiedMessage(param1);
      }
      
      public function serializeAs_ExchangeCraftCountModifiedMessage(param1:ICustomDataOutput) : void
      {
         param1.writeVarInt(this.count);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeCraftCountModifiedMessage(param1);
      }
      
      public function deserializeAs_ExchangeCraftCountModifiedMessage(param1:ICustomDataInput) : void
      {
         this._countFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeCraftCountModifiedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeCraftCountModifiedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._countFunc);
      }
      
      private function _countFunc(param1:ICustomDataInput) : void
      {
         this.count = param1.readVarInt();
      }
   }
}
