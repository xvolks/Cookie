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
   public class HaapiApiKeyMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6649;
       
      
      private var _isInitialized:Boolean = false;
      
      public var returnType:uint = 0;
      
      public var keyType:uint = 0;
      
      public var token:String = "";
      
      public function HaapiApiKeyMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6649;
      }
      
      public function initHaapiApiKeyMessage(param1:uint = 0, param2:uint = 0, param3:String = "") : HaapiApiKeyMessage
      {
         this.returnType = param1;
         this.keyType = param2;
         this.token = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.returnType = 0;
         this.keyType = 0;
         this.token = "";
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
         this.serializeAs_HaapiApiKeyMessage(param1);
      }
      
      public function serializeAs_HaapiApiKeyMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.returnType);
         param1.writeByte(this.keyType);
         param1.writeUTF(this.token);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HaapiApiKeyMessage(param1);
      }
      
      public function deserializeAs_HaapiApiKeyMessage(param1:ICustomDataInput) : void
      {
         this._returnTypeFunc(param1);
         this._keyTypeFunc(param1);
         this._tokenFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HaapiApiKeyMessage(param1);
      }
      
      public function deserializeAsyncAs_HaapiApiKeyMessage(param1:FuncTree) : void
      {
         param1.addChild(this._returnTypeFunc);
         param1.addChild(this._keyTypeFunc);
         param1.addChild(this._tokenFunc);
      }
      
      private function _returnTypeFunc(param1:ICustomDataInput) : void
      {
         this.returnType = param1.readByte();
         if(this.returnType < 0)
         {
            throw new Error("Forbidden value (" + this.returnType + ") on element of HaapiApiKeyMessage.returnType.");
         }
      }
      
      private function _keyTypeFunc(param1:ICustomDataInput) : void
      {
         this.keyType = param1.readByte();
         if(this.keyType < 0)
         {
            throw new Error("Forbidden value (" + this.keyType + ") on element of HaapiApiKeyMessage.keyType.");
         }
      }
      
      private function _tokenFunc(param1:ICustomDataInput) : void
      {
         this.token = param1.readUTF();
      }
   }
}
