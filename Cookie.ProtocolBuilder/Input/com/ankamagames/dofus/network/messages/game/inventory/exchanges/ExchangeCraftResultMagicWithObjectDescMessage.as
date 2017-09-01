package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItemNotInContainer;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeCraftResultMagicWithObjectDescMessage extends ExchangeCraftResultWithObjectDescMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6188;
       
      
      private var _isInitialized:Boolean = false;
      
      public var magicPoolStatus:int = 0;
      
      public function ExchangeCraftResultMagicWithObjectDescMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6188;
      }
      
      public function initExchangeCraftResultMagicWithObjectDescMessage(param1:uint = 0, param2:ObjectItemNotInContainer = null, param3:int = 0) : ExchangeCraftResultMagicWithObjectDescMessage
      {
         super.initExchangeCraftResultWithObjectDescMessage(param1,param2);
         this.magicPoolStatus = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.magicPoolStatus = 0;
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
         this.serializeAs_ExchangeCraftResultMagicWithObjectDescMessage(param1);
      }
      
      public function serializeAs_ExchangeCraftResultMagicWithObjectDescMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ExchangeCraftResultWithObjectDescMessage(param1);
         param1.writeByte(this.magicPoolStatus);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeCraftResultMagicWithObjectDescMessage(param1);
      }
      
      public function deserializeAs_ExchangeCraftResultMagicWithObjectDescMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._magicPoolStatusFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeCraftResultMagicWithObjectDescMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeCraftResultMagicWithObjectDescMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._magicPoolStatusFunc);
      }
      
      private function _magicPoolStatusFunc(param1:ICustomDataInput) : void
      {
         this.magicPoolStatus = param1.readByte();
      }
   }
}
