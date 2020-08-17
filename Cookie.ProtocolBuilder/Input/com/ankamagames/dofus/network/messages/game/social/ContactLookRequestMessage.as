package com.ankamagames.dofus.network.messages.game.social
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ContactLookRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5932;
       
      
      private var _isInitialized:Boolean = false;
      
      public var requestId:uint = 0;
      
      public var contactType:uint = 0;
      
      public function ContactLookRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5932;
      }
      
      public function initContactLookRequestMessage(param1:uint = 0, param2:uint = 0) : ContactLookRequestMessage
      {
         this.requestId = param1;
         this.contactType = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.requestId = 0;
         this.contactType = 0;
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
         this.serializeAs_ContactLookRequestMessage(param1);
      }
      
      public function serializeAs_ContactLookRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.requestId < 0 || this.requestId > 255)
         {
            throw new Error("Forbidden value (" + this.requestId + ") on element requestId.");
         }
         param1.writeByte(this.requestId);
         param1.writeByte(this.contactType);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ContactLookRequestMessage(param1);
      }
      
      public function deserializeAs_ContactLookRequestMessage(param1:ICustomDataInput) : void
      {
         this._requestIdFunc(param1);
         this._contactTypeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ContactLookRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_ContactLookRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._requestIdFunc);
         param1.addChild(this._contactTypeFunc);
      }
      
      private function _requestIdFunc(param1:ICustomDataInput) : void
      {
         this.requestId = param1.readUnsignedByte();
         if(this.requestId < 0 || this.requestId > 255)
         {
            throw new Error("Forbidden value (" + this.requestId + ") on element of ContactLookRequestMessage.requestId.");
         }
      }
      
      private function _contactTypeFunc(param1:ICustomDataInput) : void
      {
         this.contactType = param1.readByte();
         if(this.contactType < 0)
         {
            throw new Error("Forbidden value (" + this.contactType + ") on element of ContactLookRequestMessage.contactType.");
         }
      }
   }
}
