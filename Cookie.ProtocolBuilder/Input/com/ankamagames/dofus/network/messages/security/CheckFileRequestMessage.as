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
   public class CheckFileRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6154;
       
      
      private var _isInitialized:Boolean = false;
      
      public var filename:String = "";
      
      public var type:uint = 0;
      
      public function CheckFileRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6154;
      }
      
      public function initCheckFileRequestMessage(param1:String = "", param2:uint = 0) : CheckFileRequestMessage
      {
         this.filename = param1;
         this.type = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.filename = "";
         this.type = 0;
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
         this.serializeAs_CheckFileRequestMessage(param1);
      }
      
      public function serializeAs_CheckFileRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.filename);
         param1.writeByte(this.type);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CheckFileRequestMessage(param1);
      }
      
      public function deserializeAs_CheckFileRequestMessage(param1:ICustomDataInput) : void
      {
         this._filenameFunc(param1);
         this._typeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CheckFileRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_CheckFileRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._filenameFunc);
         param1.addChild(this._typeFunc);
      }
      
      private function _filenameFunc(param1:ICustomDataInput) : void
      {
         this.filename = param1.readUTF();
      }
      
      private function _typeFunc(param1:ICustomDataInput) : void
      {
         this.type = param1.readByte();
         if(this.type < 0)
         {
            throw new Error("Forbidden value (" + this.type + ") on element of CheckFileRequestMessage.type.");
         }
      }
   }
}
