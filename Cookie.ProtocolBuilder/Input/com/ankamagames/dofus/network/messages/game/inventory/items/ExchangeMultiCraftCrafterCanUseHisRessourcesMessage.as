package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6020;
       
      
      private var _isInitialized:Boolean = false;
      
      public var allowed:Boolean = false;
      
      public function ExchangeMultiCraftCrafterCanUseHisRessourcesMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6020;
      }
      
      public function initExchangeMultiCraftCrafterCanUseHisRessourcesMessage(param1:Boolean = false) : ExchangeMultiCraftCrafterCanUseHisRessourcesMessage
      {
         this.allowed = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.allowed = false;
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
         this.serializeAs_ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(param1);
      }
      
      public function serializeAs_ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.allowed);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(param1);
      }
      
      public function deserializeAs_ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(param1:ICustomDataInput) : void
      {
         this._allowedFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(param1:FuncTree) : void
      {
         param1.addChild(this._allowedFunc);
      }
      
      private function _allowedFunc(param1:ICustomDataInput) : void
      {
         this.allowed = param1.readBoolean();
      }
   }
}
