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
   public class ExchangeOnHumanVendorRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5772;
       
      
      private var _isInitialized:Boolean = false;
      
      public var humanVendorId:Number = 0;
      
      public var humanVendorCell:uint = 0;
      
      public function ExchangeOnHumanVendorRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5772;
      }
      
      public function initExchangeOnHumanVendorRequestMessage(param1:Number = 0, param2:uint = 0) : ExchangeOnHumanVendorRequestMessage
      {
         this.humanVendorId = param1;
         this.humanVendorCell = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.humanVendorId = 0;
         this.humanVendorCell = 0;
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
         this.serializeAs_ExchangeOnHumanVendorRequestMessage(param1);
      }
      
      public function serializeAs_ExchangeOnHumanVendorRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.humanVendorId < 0 || this.humanVendorId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.humanVendorId + ") on element humanVendorId.");
         }
         param1.writeVarLong(this.humanVendorId);
         if(this.humanVendorCell < 0 || this.humanVendorCell > 559)
         {
            throw new Error("Forbidden value (" + this.humanVendorCell + ") on element humanVendorCell.");
         }
         param1.writeVarShort(this.humanVendorCell);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeOnHumanVendorRequestMessage(param1);
      }
      
      public function deserializeAs_ExchangeOnHumanVendorRequestMessage(param1:ICustomDataInput) : void
      {
         this._humanVendorIdFunc(param1);
         this._humanVendorCellFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeOnHumanVendorRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeOnHumanVendorRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._humanVendorIdFunc);
         param1.addChild(this._humanVendorCellFunc);
      }
      
      private function _humanVendorIdFunc(param1:ICustomDataInput) : void
      {
         this.humanVendorId = param1.readVarUhLong();
         if(this.humanVendorId < 0 || this.humanVendorId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.humanVendorId + ") on element of ExchangeOnHumanVendorRequestMessage.humanVendorId.");
         }
      }
      
      private function _humanVendorCellFunc(param1:ICustomDataInput) : void
      {
         this.humanVendorCell = param1.readVarUhShort();
         if(this.humanVendorCell < 0 || this.humanVendorCell > 559)
         {
            throw new Error("Forbidden value (" + this.humanVendorCell + ") on element of ExchangeOnHumanVendorRequestMessage.humanVendorCell.");
         }
      }
   }
}
