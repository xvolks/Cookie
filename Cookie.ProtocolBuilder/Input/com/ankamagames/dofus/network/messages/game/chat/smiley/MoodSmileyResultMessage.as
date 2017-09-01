package com.ankamagames.dofus.network.messages.game.chat.smiley
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MoodSmileyResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6196;
       
      
      private var _isInitialized:Boolean = false;
      
      public var resultCode:uint = 1;
      
      public var smileyId:uint = 0;
      
      public function MoodSmileyResultMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6196;
      }
      
      public function initMoodSmileyResultMessage(param1:uint = 1, param2:uint = 0) : MoodSmileyResultMessage
      {
         this.resultCode = param1;
         this.smileyId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.resultCode = 1;
         this.smileyId = 0;
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
         this.serializeAs_MoodSmileyResultMessage(param1);
      }
      
      public function serializeAs_MoodSmileyResultMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.resultCode);
         if(this.smileyId < 0)
         {
            throw new Error("Forbidden value (" + this.smileyId + ") on element smileyId.");
         }
         param1.writeVarShort(this.smileyId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MoodSmileyResultMessage(param1);
      }
      
      public function deserializeAs_MoodSmileyResultMessage(param1:ICustomDataInput) : void
      {
         this._resultCodeFunc(param1);
         this._smileyIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MoodSmileyResultMessage(param1);
      }
      
      public function deserializeAsyncAs_MoodSmileyResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this._resultCodeFunc);
         param1.addChild(this._smileyIdFunc);
      }
      
      private function _resultCodeFunc(param1:ICustomDataInput) : void
      {
         this.resultCode = param1.readByte();
         if(this.resultCode < 0)
         {
            throw new Error("Forbidden value (" + this.resultCode + ") on element of MoodSmileyResultMessage.resultCode.");
         }
      }
      
      private function _smileyIdFunc(param1:ICustomDataInput) : void
      {
         this.smileyId = param1.readVarUhShort();
         if(this.smileyId < 0)
         {
            throw new Error("Forbidden value (" + this.smileyId + ") on element of MoodSmileyResultMessage.smileyId.");
         }
      }
   }
}
