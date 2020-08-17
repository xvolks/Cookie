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
   public class ExchangeStartOkMulticraftCrafterMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5818;
       
      
      private var _isInitialized:Boolean = false;
      
      public var skillId:uint = 0;
      
      public function ExchangeStartOkMulticraftCrafterMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5818;
      }
      
      public function initExchangeStartOkMulticraftCrafterMessage(param1:uint = 0) : ExchangeStartOkMulticraftCrafterMessage
      {
         this.skillId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.skillId = 0;
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
         this.serializeAs_ExchangeStartOkMulticraftCrafterMessage(param1);
      }
      
      public function serializeAs_ExchangeStartOkMulticraftCrafterMessage(param1:ICustomDataOutput) : void
      {
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element skillId.");
         }
         param1.writeVarInt(this.skillId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeStartOkMulticraftCrafterMessage(param1);
      }
      
      public function deserializeAs_ExchangeStartOkMulticraftCrafterMessage(param1:ICustomDataInput) : void
      {
         this._skillIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeStartOkMulticraftCrafterMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeStartOkMulticraftCrafterMessage(param1:FuncTree) : void
      {
         param1.addChild(this._skillIdFunc);
      }
      
      private function _skillIdFunc(param1:ICustomDataInput) : void
      {
         this.skillId = param1.readVarUhInt();
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element of ExchangeStartOkMulticraftCrafterMessage.skillId.");
         }
      }
   }
}
