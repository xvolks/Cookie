package com.ankamagames.dofus.network.messages.game.chat
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChatClientMultiMessage extends ChatAbstractClientMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 861;
       
      
      private var _isInitialized:Boolean = false;
      
      public var channel:uint = 0;
      
      public function ChatClientMultiMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 861;
      }
      
      public function initChatClientMultiMessage(param1:String = "", param2:uint = 0) : ChatClientMultiMessage
      {
         super.initChatAbstractClientMessage(param1);
         this.channel = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.channel = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         if(HASH_FUNCTION != null)
         {
            HASH_FUNCTION(_loc2_);
         }
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
         this.serializeAs_ChatClientMultiMessage(param1);
      }
      
      public function serializeAs_ChatClientMultiMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ChatAbstractClientMessage(param1);
         param1.writeByte(this.channel);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChatClientMultiMessage(param1);
      }
      
      public function deserializeAs_ChatClientMultiMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._channelFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChatClientMultiMessage(param1);
      }
      
      public function deserializeAsyncAs_ChatClientMultiMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._channelFunc);
      }
      
      private function _channelFunc(param1:ICustomDataInput) : void
      {
         this.channel = param1.readByte();
         if(this.channel < 0)
         {
            throw new Error("Forbidden value (" + this.channel + ") on element of ChatClientMultiMessage.channel.");
         }
      }
   }
}
