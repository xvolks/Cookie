package com.ankamagames.dofus.network.messages.game.dare
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DareSubscribeRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6666;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dareId:Number = 0;
      
      public var subscribe:Boolean = false;
      
      public function DareSubscribeRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6666;
      }
      
      public function initDareSubscribeRequestMessage(param1:Number = 0, param2:Boolean = false) : DareSubscribeRequestMessage
      {
         this.dareId = param1;
         this.subscribe = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dareId = 0;
         this.subscribe = false;
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
         this.serializeAs_DareSubscribeRequestMessage(param1);
      }
      
      public function serializeAs_DareSubscribeRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element dareId.");
         }
         param1.writeDouble(this.dareId);
         param1.writeBoolean(this.subscribe);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareSubscribeRequestMessage(param1);
      }
      
      public function deserializeAs_DareSubscribeRequestMessage(param1:ICustomDataInput) : void
      {
         this._dareIdFunc(param1);
         this._subscribeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareSubscribeRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_DareSubscribeRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._dareIdFunc);
         param1.addChild(this._subscribeFunc);
      }
      
      private function _dareIdFunc(param1:ICustomDataInput) : void
      {
         this.dareId = param1.readDouble();
         if(this.dareId < 0 || this.dareId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.dareId + ") on element of DareSubscribeRequestMessage.dareId.");
         }
      }
      
      private function _subscribeFunc(param1:ICustomDataInput) : void
      {
         this.subscribe = param1.readBoolean();
      }
   }
}
