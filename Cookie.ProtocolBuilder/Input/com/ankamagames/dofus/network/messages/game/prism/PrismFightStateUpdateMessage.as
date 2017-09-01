package com.ankamagames.dofus.network.messages.game.prism
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PrismFightStateUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6040;
       
      
      private var _isInitialized:Boolean = false;
      
      public var state:uint = 0;
      
      public function PrismFightStateUpdateMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6040;
      }
      
      public function initPrismFightStateUpdateMessage(param1:uint = 0) : PrismFightStateUpdateMessage
      {
         this.state = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.state = 0;
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
         this.serializeAs_PrismFightStateUpdateMessage(param1);
      }
      
      public function serializeAs_PrismFightStateUpdateMessage(param1:ICustomDataOutput) : void
      {
         if(this.state < 0)
         {
            throw new Error("Forbidden value (" + this.state + ") on element state.");
         }
         param1.writeByte(this.state);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PrismFightStateUpdateMessage(param1);
      }
      
      public function deserializeAs_PrismFightStateUpdateMessage(param1:ICustomDataInput) : void
      {
         this._stateFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PrismFightStateUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_PrismFightStateUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._stateFunc);
      }
      
      private function _stateFunc(param1:ICustomDataInput) : void
      {
         this.state = param1.readByte();
         if(this.state < 0)
         {
            throw new Error("Forbidden value (" + this.state + ") on element of PrismFightStateUpdateMessage.state.");
         }
      }
   }
}
