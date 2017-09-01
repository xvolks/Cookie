package com.ankamagames.dofus.network.messages.queues
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class QueueStatusMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6100;
       
      
      private var _isInitialized:Boolean = false;
      
      public var position:uint = 0;
      
      public var total:uint = 0;
      
      public function QueueStatusMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6100;
      }
      
      public function initQueueStatusMessage(param1:uint = 0, param2:uint = 0) : QueueStatusMessage
      {
         this.position = param1;
         this.total = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.position = 0;
         this.total = 0;
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
         this.serializeAs_QueueStatusMessage(param1);
      }
      
      public function serializeAs_QueueStatusMessage(param1:ICustomDataOutput) : void
      {
         if(this.position < 0 || this.position > 65535)
         {
            throw new Error("Forbidden value (" + this.position + ") on element position.");
         }
         param1.writeShort(this.position);
         if(this.total < 0 || this.total > 65535)
         {
            throw new Error("Forbidden value (" + this.total + ") on element total.");
         }
         param1.writeShort(this.total);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_QueueStatusMessage(param1);
      }
      
      public function deserializeAs_QueueStatusMessage(param1:ICustomDataInput) : void
      {
         this._positionFunc(param1);
         this._totalFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_QueueStatusMessage(param1);
      }
      
      public function deserializeAsyncAs_QueueStatusMessage(param1:FuncTree) : void
      {
         param1.addChild(this._positionFunc);
         param1.addChild(this._totalFunc);
      }
      
      private function _positionFunc(param1:ICustomDataInput) : void
      {
         this.position = param1.readUnsignedShort();
         if(this.position < 0 || this.position > 65535)
         {
            throw new Error("Forbidden value (" + this.position + ") on element of QueueStatusMessage.position.");
         }
      }
      
      private function _totalFunc(param1:ICustomDataInput) : void
      {
         this.total = param1.readUnsignedShort();
         if(this.total < 0 || this.total > 65535)
         {
            throw new Error("Forbidden value (" + this.total + ") on element of QueueStatusMessage.total.");
         }
      }
   }
}
