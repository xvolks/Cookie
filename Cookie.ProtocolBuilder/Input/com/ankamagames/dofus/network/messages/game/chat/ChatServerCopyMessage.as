package com.ankamagames.dofus.network.messages.game.chat
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChatServerCopyMessage extends ChatAbstractServerMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 882;
       
      
      private var _isInitialized:Boolean = false;
      
      public var receiverId:Number = 0;
      
      [Transient]
      public var receiverName:String = "";
      
      public function ChatServerCopyMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 882;
      }
      
      public function initChatServerCopyMessage(param1:uint = 0, param2:String = "", param3:uint = 0, param4:String = "", param5:Number = 0, param6:String = "") : ChatServerCopyMessage
      {
         super.initChatAbstractServerMessage(param1,param2,param3,param4);
         this.receiverId = param5;
         this.receiverName = param6;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.receiverId = 0;
         this.receiverName = "";
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ChatServerCopyMessage(param1);
      }
      
      public function serializeAs_ChatServerCopyMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ChatAbstractServerMessage(param1);
         if(this.receiverId < 0 || this.receiverId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.receiverId + ") on element receiverId.");
         }
         param1.writeVarLong(this.receiverId);
         param1.writeUTF(this.receiverName);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChatServerCopyMessage(param1);
      }
      
      public function deserializeAs_ChatServerCopyMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._receiverIdFunc(param1);
         this._receiverNameFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChatServerCopyMessage(param1);
      }
      
      public function deserializeAsyncAs_ChatServerCopyMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._receiverIdFunc);
         param1.addChild(this._receiverNameFunc);
      }
      
      private function _receiverIdFunc(param1:ICustomDataInput) : void
      {
         this.receiverId = param1.readVarUhLong();
         if(this.receiverId < 0 || this.receiverId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.receiverId + ") on element of ChatServerCopyMessage.receiverId.");
         }
      }
      
      private function _receiverNameFunc(param1:ICustomDataInput) : void
      {
         this.receiverName = param1.readUTF();
      }
   }
}
