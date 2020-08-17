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
   public class BasicDateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 177;
       
      
      private var _isInitialized:Boolean = false;
      
      public var day:uint = 0;
      
      public var month:uint = 0;
      
      public var year:uint = 0;
      
      public function BasicDateMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 177;
      }
      
      public function initBasicDateMessage(param1:uint = 0, param2:uint = 0, param3:uint = 0) : BasicDateMessage
      {
         this.day = param1;
         this.month = param2;
         this.year = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.day = 0;
         this.month = 0;
         this.year = 0;
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
         this.serializeAs_BasicDateMessage(param1);
      }
      
      public function serializeAs_BasicDateMessage(param1:ICustomDataOutput) : void
      {
         if(this.day < 0)
         {
            throw new Error("Forbidden value (" + this.day + ") on element day.");
         }
         param1.writeByte(this.day);
         if(this.month < 0)
         {
            throw new Error("Forbidden value (" + this.month + ") on element month.");
         }
         param1.writeByte(this.month);
         if(this.year < 0)
         {
            throw new Error("Forbidden value (" + this.year + ") on element year.");
         }
         param1.writeShort(this.year);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_BasicDateMessage(param1);
      }
      
      public function deserializeAs_BasicDateMessage(param1:ICustomDataInput) : void
      {
         this._dayFunc(param1);
         this._monthFunc(param1);
         this._yearFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_BasicDateMessage(param1);
      }
      
      public function deserializeAsyncAs_BasicDateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._dayFunc);
         param1.addChild(this._monthFunc);
         param1.addChild(this._yearFunc);
      }
      
      private function _dayFunc(param1:ICustomDataInput) : void
      {
         this.day = param1.readByte();
         if(this.day < 0)
         {
            throw new Error("Forbidden value (" + this.day + ") on element of BasicDateMessage.day.");
         }
      }
      
      private function _monthFunc(param1:ICustomDataInput) : void
      {
         this.month = param1.readByte();
         if(this.month < 0)
         {
            throw new Error("Forbidden value (" + this.month + ") on element of BasicDateMessage.month.");
         }
      }
      
      private function _yearFunc(param1:ICustomDataInput) : void
      {
         this.year = param1.readShort();
         if(this.year < 0)
         {
            throw new Error("Forbidden value (" + this.year + ") on element of BasicDateMessage.year.");
         }
      }
   }
}
