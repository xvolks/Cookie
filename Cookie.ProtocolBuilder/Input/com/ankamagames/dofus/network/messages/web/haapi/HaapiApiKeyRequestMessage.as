package com.ankamagames.dofus.network.messages.web.haapi
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HaapiApiKeyRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6648;
       
      
      private var _isInitialized:Boolean = false;
      
      public var keyType:uint = 0;
      
      public function HaapiApiKeyRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6648;
      }
      
      public function initHaapiApiKeyRequestMessage(param1:uint = 0) : HaapiApiKeyRequestMessage
      {
         this.keyType = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.keyType = 0;
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
         this.serializeAs_HaapiApiKeyRequestMessage(param1);
      }
      
      public function serializeAs_HaapiApiKeyRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.keyType);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HaapiApiKeyRequestMessage(param1);
      }
      
      public function deserializeAs_HaapiApiKeyRequestMessage(param1:ICustomDataInput) : void
      {
         this._keyTypeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HaapiApiKeyRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_HaapiApiKeyRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._keyTypeFunc);
      }
      
      private function _keyTypeFunc(param1:ICustomDataInput) : void
      {
         this.keyType = param1.readByte();
         if(this.keyType < 0)
         {
            throw new Error("Forbidden value (" + this.keyType + ") on element of HaapiApiKeyRequestMessage.keyType.");
         }
      }
   }
}
