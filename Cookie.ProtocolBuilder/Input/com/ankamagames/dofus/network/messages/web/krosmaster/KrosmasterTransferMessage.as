package com.ankamagames.dofus.network.messages.web.krosmaster
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class KrosmasterTransferMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6348;
       
      
      private var _isInitialized:Boolean = false;
      
      public var uid:String = "";
      
      public var failure:uint = 0;
      
      public function KrosmasterTransferMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6348;
      }
      
      public function initKrosmasterTransferMessage(param1:String = "", param2:uint = 0) : KrosmasterTransferMessage
      {
         this.uid = param1;
         this.failure = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.uid = "";
         this.failure = 0;
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
         this.serializeAs_KrosmasterTransferMessage(param1);
      }
      
      public function serializeAs_KrosmasterTransferMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.uid);
         param1.writeByte(this.failure);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_KrosmasterTransferMessage(param1);
      }
      
      public function deserializeAs_KrosmasterTransferMessage(param1:ICustomDataInput) : void
      {
         this._uidFunc(param1);
         this._failureFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_KrosmasterTransferMessage(param1);
      }
      
      public function deserializeAsyncAs_KrosmasterTransferMessage(param1:FuncTree) : void
      {
         param1.addChild(this._uidFunc);
         param1.addChild(this._failureFunc);
      }
      
      private function _uidFunc(param1:ICustomDataInput) : void
      {
         this.uid = param1.readUTF();
      }
      
      private function _failureFunc(param1:ICustomDataInput) : void
      {
         this.failure = param1.readByte();
         if(this.failure < 0)
         {
            throw new Error("Forbidden value (" + this.failure + ") on element of KrosmasterTransferMessage.failure.");
         }
      }
   }
}
