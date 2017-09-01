package com.ankamagames.dofus.network.messages.game.chat
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChatServerMessage extends ChatAbstractServerMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 881;
       
      
      private var _isInitialized:Boolean = false;
      
      public var senderId:Number = 0;
      
      [Transient]
      public var senderName:String = "";
      
      public var senderAccountId:uint = 0;
      
      public function ChatServerMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 881;
      }
      
      public function initChatServerMessage(param1:uint = 0, param2:String = "", param3:uint = 0, param4:String = "", param5:Number = 0, param6:String = "", param7:uint = 0) : ChatServerMessage
      {
         super.initChatAbstractServerMessage(param1,param2,param3,param4);
         this.senderId = param5;
         this.senderName = param6;
         this.senderAccountId = param7;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.senderId = 0;
         this.senderName = "";
         this.senderAccountId = 0;
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
         this.serializeAs_ChatServerMessage(param1);
      }
      
      public function serializeAs_ChatServerMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ChatAbstractServerMessage(param1);
         if(this.senderId < -9007199254740990 || this.senderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.senderId + ") on element senderId.");
         }
         param1.writeDouble(this.senderId);
         param1.writeUTF(this.senderName);
         if(this.senderAccountId < 0)
         {
            throw new Error("Forbidden value (" + this.senderAccountId + ") on element senderAccountId.");
         }
         param1.writeInt(this.senderAccountId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChatServerMessage(param1);
      }
      
      public function deserializeAs_ChatServerMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._senderIdFunc(param1);
         this._senderNameFunc(param1);
         this._senderAccountIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChatServerMessage(param1);
      }
      
      public function deserializeAsyncAs_ChatServerMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._senderIdFunc);
         param1.addChild(this._senderNameFunc);
         param1.addChild(this._senderAccountIdFunc);
      }
      
      private function _senderIdFunc(param1:ICustomDataInput) : void
      {
         this.senderId = param1.readDouble();
         if(this.senderId < -9007199254740990 || this.senderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.senderId + ") on element of ChatServerMessage.senderId.");
         }
      }
      
      private function _senderNameFunc(param1:ICustomDataInput) : void
      {
         this.senderName = param1.readUTF();
      }
      
      private function _senderAccountIdFunc(param1:ICustomDataInput) : void
      {
         this.senderAccountId = param1.readInt();
         if(this.senderAccountId < 0)
         {
            throw new Error("Forbidden value (" + this.senderAccountId + ") on element of ChatServerMessage.senderAccountId.");
         }
      }
   }
}
