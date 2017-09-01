package com.ankamagames.dofus.network.messages.subscription
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SubscriptionUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6616;
       
      
      private var _isInitialized:Boolean = false;
      
      public var timestamp:Number = 0;
      
      public function SubscriptionUpdateMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6616;
      }
      
      public function initSubscriptionUpdateMessage(param1:Number = 0) : SubscriptionUpdateMessage
      {
         this.timestamp = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.timestamp = 0;
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
         this.serializeAs_SubscriptionUpdateMessage(param1);
      }
      
      public function serializeAs_SubscriptionUpdateMessage(param1:ICustomDataOutput) : void
      {
         if(this.timestamp < -9007199254740990 || this.timestamp > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.timestamp + ") on element timestamp.");
         }
         param1.writeDouble(this.timestamp);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SubscriptionUpdateMessage(param1);
      }
      
      public function deserializeAs_SubscriptionUpdateMessage(param1:ICustomDataInput) : void
      {
         this._timestampFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SubscriptionUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_SubscriptionUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._timestampFunc);
      }
      
      private function _timestampFunc(param1:ICustomDataInput) : void
      {
         this.timestamp = param1.readDouble();
         if(this.timestamp < -9007199254740990 || this.timestamp > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.timestamp + ") on element of SubscriptionUpdateMessage.timestamp.");
         }
      }
   }
}
