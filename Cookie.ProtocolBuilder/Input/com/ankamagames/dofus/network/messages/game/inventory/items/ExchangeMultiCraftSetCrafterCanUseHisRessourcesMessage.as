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
   public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6021;
       
      
      private var _isInitialized:Boolean = false;
      
      public var allow:Boolean = false;
      
      public function ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6021;
      }
      
      public function initExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(param1:Boolean = false) : ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage
      {
         this.allow = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.allow = false;
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
         this.serializeAs_ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(param1);
      }
      
      public function serializeAs_ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.allow);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(param1);
      }
      
      public function deserializeAs_ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(param1:ICustomDataInput) : void
      {
         this._allowFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(param1:FuncTree) : void
      {
         param1.addChild(this._allowFunc);
      }
      
      private function _allowFunc(param1:ICustomDataInput) : void
      {
         this.allow = param1.readBoolean();
      }
   }
}
