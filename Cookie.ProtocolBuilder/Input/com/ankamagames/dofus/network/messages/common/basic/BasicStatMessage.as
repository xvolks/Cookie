package com.ankamagames.dofus.network.messages.common.basic
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class BasicStatMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6530;
       
      
      private var _isInitialized:Boolean = false;
      
      public var timeSpent:Number = 0;
      
      public var statId:uint = 0;
      
      public function BasicStatMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6530;
      }
      
      public function initBasicStatMessage(param1:Number = 0, param2:uint = 0) : BasicStatMessage
      {
         this.timeSpent = param1;
         this.statId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.timeSpent = 0;
         this.statId = 0;
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
         this.serializeAs_BasicStatMessage(param1);
      }
      
      public function serializeAs_BasicStatMessage(param1:ICustomDataOutput) : void
      {
         if(this.timeSpent < 0 || this.timeSpent > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.timeSpent + ") on element timeSpent.");
         }
         param1.writeDouble(this.timeSpent);
         param1.writeVarShort(this.statId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_BasicStatMessage(param1);
      }
      
      public function deserializeAs_BasicStatMessage(param1:ICustomDataInput) : void
      {
         this._timeSpentFunc(param1);
         this._statIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_BasicStatMessage(param1);
      }
      
      public function deserializeAsyncAs_BasicStatMessage(param1:FuncTree) : void
      {
         param1.addChild(this._timeSpentFunc);
         param1.addChild(this._statIdFunc);
      }
      
      private function _timeSpentFunc(param1:ICustomDataInput) : void
      {
         this.timeSpent = param1.readDouble();
         if(this.timeSpent < 0 || this.timeSpent > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.timeSpent + ") on element of BasicStatMessage.timeSpent.");
         }
      }
      
      private function _statIdFunc(param1:ICustomDataInput) : void
      {
         this.statId = param1.readVarUhShort();
         if(this.statId < 0)
         {
            throw new Error("Forbidden value (" + this.statId + ") on element of BasicStatMessage.statId.");
         }
      }
   }
}
