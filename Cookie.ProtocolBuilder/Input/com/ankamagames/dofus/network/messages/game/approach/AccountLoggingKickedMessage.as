package com.ankamagames.dofus.network.messages.game.approach
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AccountLoggingKickedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6029;
       
      
      private var _isInitialized:Boolean = false;
      
      public var days:uint = 0;
      
      public var hours:uint = 0;
      
      public var minutes:uint = 0;
      
      public function AccountLoggingKickedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6029;
      }
      
      public function initAccountLoggingKickedMessage(param1:uint = 0, param2:uint = 0, param3:uint = 0) : AccountLoggingKickedMessage
      {
         this.days = param1;
         this.hours = param2;
         this.minutes = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.days = 0;
         this.hours = 0;
         this.minutes = 0;
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
         this.serializeAs_AccountLoggingKickedMessage(param1);
      }
      
      public function serializeAs_AccountLoggingKickedMessage(param1:ICustomDataOutput) : void
      {
         if(this.days < 0)
         {
            throw new Error("Forbidden value (" + this.days + ") on element days.");
         }
         param1.writeVarShort(this.days);
         if(this.hours < 0)
         {
            throw new Error("Forbidden value (" + this.hours + ") on element hours.");
         }
         param1.writeByte(this.hours);
         if(this.minutes < 0)
         {
            throw new Error("Forbidden value (" + this.minutes + ") on element minutes.");
         }
         param1.writeByte(this.minutes);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AccountLoggingKickedMessage(param1);
      }
      
      public function deserializeAs_AccountLoggingKickedMessage(param1:ICustomDataInput) : void
      {
         this._daysFunc(param1);
         this._hoursFunc(param1);
         this._minutesFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AccountLoggingKickedMessage(param1);
      }
      
      public function deserializeAsyncAs_AccountLoggingKickedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._daysFunc);
         param1.addChild(this._hoursFunc);
         param1.addChild(this._minutesFunc);
      }
      
      private function _daysFunc(param1:ICustomDataInput) : void
      {
         this.days = param1.readVarUhShort();
         if(this.days < 0)
         {
            throw new Error("Forbidden value (" + this.days + ") on element of AccountLoggingKickedMessage.days.");
         }
      }
      
      private function _hoursFunc(param1:ICustomDataInput) : void
      {
         this.hours = param1.readByte();
         if(this.hours < 0)
         {
            throw new Error("Forbidden value (" + this.hours + ") on element of AccountLoggingKickedMessage.hours.");
         }
      }
      
      private function _minutesFunc(param1:ICustomDataInput) : void
      {
         this.minutes = param1.readByte();
         if(this.minutes < 0)
         {
            throw new Error("Forbidden value (" + this.minutes + ") on element of AccountLoggingKickedMessage.minutes.");
         }
      }
   }
}
