package com.ankamagames.dofus.network.messages.game.actions.sequence
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SequenceStartMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 955;
       
      
      private var _isInitialized:Boolean = false;
      
      public var sequenceType:int = 0;
      
      public var authorId:Number = 0;
      
      public function SequenceStartMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 955;
      }
      
      public function initSequenceStartMessage(param1:int = 0, param2:Number = 0) : SequenceStartMessage
      {
         this.sequenceType = param1;
         this.authorId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.sequenceType = 0;
         this.authorId = 0;
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
         this.serializeAs_SequenceStartMessage(param1);
      }
      
      public function serializeAs_SequenceStartMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.sequenceType);
         if(this.authorId < -9007199254740990 || this.authorId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.authorId + ") on element authorId.");
         }
         param1.writeDouble(this.authorId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SequenceStartMessage(param1);
      }
      
      public function deserializeAs_SequenceStartMessage(param1:ICustomDataInput) : void
      {
         this._sequenceTypeFunc(param1);
         this._authorIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SequenceStartMessage(param1);
      }
      
      public function deserializeAsyncAs_SequenceStartMessage(param1:FuncTree) : void
      {
         param1.addChild(this._sequenceTypeFunc);
         param1.addChild(this._authorIdFunc);
      }
      
      private function _sequenceTypeFunc(param1:ICustomDataInput) : void
      {
         this.sequenceType = param1.readByte();
      }
      
      private function _authorIdFunc(param1:ICustomDataInput) : void
      {
         this.authorId = param1.readDouble();
         if(this.authorId < -9007199254740990 || this.authorId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.authorId + ") on element of SequenceStartMessage.authorId.");
         }
      }
   }
}
