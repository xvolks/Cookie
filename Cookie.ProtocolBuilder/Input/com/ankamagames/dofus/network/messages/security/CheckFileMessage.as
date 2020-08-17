package com.ankamagames.dofus.network.messages.security
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CheckFileMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6156;
       
      
      private var _isInitialized:Boolean = false;
      
      public var filenameHash:String = "";
      
      public var type:uint = 0;
      
      public var value:String = "";
      
      public function CheckFileMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6156;
      }
      
      public function initCheckFileMessage(param1:String = "", param2:uint = 0, param3:String = "") : CheckFileMessage
      {
         this.filenameHash = param1;
         this.type = param2;
         this.value = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.filenameHash = "";
         this.type = 0;
         this.value = "";
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
         this.serializeAs_CheckFileMessage(param1);
      }
      
      public function serializeAs_CheckFileMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.filenameHash);
         param1.writeByte(this.type);
         param1.writeUTF(this.value);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CheckFileMessage(param1);
      }
      
      public function deserializeAs_CheckFileMessage(param1:ICustomDataInput) : void
      {
         this._filenameHashFunc(param1);
         this._typeFunc(param1);
         this._valueFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CheckFileMessage(param1);
      }
      
      public function deserializeAsyncAs_CheckFileMessage(param1:FuncTree) : void
      {
         param1.addChild(this._filenameHashFunc);
         param1.addChild(this._typeFunc);
         param1.addChild(this._valueFunc);
      }
      
      private function _filenameHashFunc(param1:ICustomDataInput) : void
      {
         this.filenameHash = param1.readUTF();
      }
      
      private function _typeFunc(param1:ICustomDataInput) : void
      {
         this.type = param1.readByte();
         if(this.type < 0)
         {
            throw new Error("Forbidden value (" + this.type + ") on element of CheckFileMessage.type.");
         }
      }
      
      private function _valueFunc(param1:ICustomDataInput) : void
      {
         this.value = param1.readUTF();
      }
   }
}
