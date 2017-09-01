package com.ankamagames.dofus.network.messages.game.basic
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SequenceNumberMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6317;
       
      
      private var _isInitialized:Boolean = false;
      
      public var number:uint = 0;
      
      public function SequenceNumberMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6317;
      }
      
      public function initSequenceNumberMessage(param1:uint = 0) : SequenceNumberMessage
      {
         this.number = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.number = 0;
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
         this.serializeAs_SequenceNumberMessage(param1);
      }
      
      public function serializeAs_SequenceNumberMessage(param1:ICustomDataOutput) : void
      {
         if(this.number < 0 || this.number > 65535)
         {
            throw new Error("Forbidden value (" + this.number + ") on element number.");
         }
         param1.writeShort(this.number);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SequenceNumberMessage(param1);
      }
      
      public function deserializeAs_SequenceNumberMessage(param1:ICustomDataInput) : void
      {
         this._numberFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SequenceNumberMessage(param1);
      }
      
      public function deserializeAsyncAs_SequenceNumberMessage(param1:FuncTree) : void
      {
         param1.addChild(this._numberFunc);
      }
      
      private function _numberFunc(param1:ICustomDataInput) : void
      {
         this.number = param1.readUnsignedShort();
         if(this.number < 0 || this.number > 65535)
         {
            throw new Error("Forbidden value (" + this.number + ") on element of SequenceNumberMessage.number.");
         }
      }
   }
}
