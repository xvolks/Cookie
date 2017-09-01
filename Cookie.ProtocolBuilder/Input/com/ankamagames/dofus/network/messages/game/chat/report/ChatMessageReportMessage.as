package com.ankamagames.dofus.network.messages.game.chat.report
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChatMessageReportMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 821;
       
      
      private var _isInitialized:Boolean = false;
      
      public var senderName:String = "";
      
      public var content:String = "";
      
      public var timestamp:uint = 0;
      
      public var channel:uint = 0;
      
      public var fingerprint:String = "";
      
      public var reason:uint = 0;
      
      public function ChatMessageReportMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 821;
      }
      
      public function initChatMessageReportMessage(param1:String = "", param2:String = "", param3:uint = 0, param4:uint = 0, param5:String = "", param6:uint = 0) : ChatMessageReportMessage
      {
         this.senderName = param1;
         this.content = param2;
         this.timestamp = param3;
         this.channel = param4;
         this.fingerprint = param5;
         this.reason = param6;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.senderName = "";
         this.content = "";
         this.timestamp = 0;
         this.channel = 0;
         this.fingerprint = "";
         this.reason = 0;
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
         this.serializeAs_ChatMessageReportMessage(param1);
      }
      
      public function serializeAs_ChatMessageReportMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.senderName);
         param1.writeUTF(this.content);
         if(this.timestamp < 0)
         {
            throw new Error("Forbidden value (" + this.timestamp + ") on element timestamp.");
         }
         param1.writeInt(this.timestamp);
         param1.writeByte(this.channel);
         param1.writeUTF(this.fingerprint);
         if(this.reason < 0)
         {
            throw new Error("Forbidden value (" + this.reason + ") on element reason.");
         }
         param1.writeByte(this.reason);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChatMessageReportMessage(param1);
      }
      
      public function deserializeAs_ChatMessageReportMessage(param1:ICustomDataInput) : void
      {
         this._senderNameFunc(param1);
         this._contentFunc(param1);
         this._timestampFunc(param1);
         this._channelFunc(param1);
         this._fingerprintFunc(param1);
         this._reasonFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChatMessageReportMessage(param1);
      }
      
      public function deserializeAsyncAs_ChatMessageReportMessage(param1:FuncTree) : void
      {
         param1.addChild(this._senderNameFunc);
         param1.addChild(this._contentFunc);
         param1.addChild(this._timestampFunc);
         param1.addChild(this._channelFunc);
         param1.addChild(this._fingerprintFunc);
         param1.addChild(this._reasonFunc);
      }
      
      private function _senderNameFunc(param1:ICustomDataInput) : void
      {
         this.senderName = param1.readUTF();
      }
      
      private function _contentFunc(param1:ICustomDataInput) : void
      {
         this.content = param1.readUTF();
      }
      
      private function _timestampFunc(param1:ICustomDataInput) : void
      {
         this.timestamp = param1.readInt();
         if(this.timestamp < 0)
         {
            throw new Error("Forbidden value (" + this.timestamp + ") on element of ChatMessageReportMessage.timestamp.");
         }
      }
      
      private function _channelFunc(param1:ICustomDataInput) : void
      {
         this.channel = param1.readByte();
         if(this.channel < 0)
         {
            throw new Error("Forbidden value (" + this.channel + ") on element of ChatMessageReportMessage.channel.");
         }
      }
      
      private function _fingerprintFunc(param1:ICustomDataInput) : void
      {
         this.fingerprint = param1.readUTF();
      }
      
      private function _reasonFunc(param1:ICustomDataInput) : void
      {
         this.reason = param1.readByte();
         if(this.reason < 0)
         {
            throw new Error("Forbidden value (" + this.reason + ") on element of ChatMessageReportMessage.reason.");
         }
      }
   }
}
