package com.ankamagames.dofus.network.messages.game.chat.smiley
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChatSmileyMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 801;
       
      
      private var _isInitialized:Boolean = false;
      
      public var entityId:Number = 0;
      
      public var smileyId:uint = 0;
      
      public var accountId:uint = 0;
      
      public function ChatSmileyMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 801;
      }
      
      public function initChatSmileyMessage(param1:Number = 0, param2:uint = 0, param3:uint = 0) : ChatSmileyMessage
      {
         this.entityId = param1;
         this.smileyId = param2;
         this.accountId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.entityId = 0;
         this.smileyId = 0;
         this.accountId = 0;
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
         this.serializeAs_ChatSmileyMessage(param1);
      }
      
      public function serializeAs_ChatSmileyMessage(param1:ICustomDataOutput) : void
      {
         if(this.entityId < -9007199254740990 || this.entityId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.entityId + ") on element entityId.");
         }
         param1.writeDouble(this.entityId);
         if(this.smileyId < 0)
         {
            throw new Error("Forbidden value (" + this.smileyId + ") on element smileyId.");
         }
         param1.writeVarShort(this.smileyId);
         if(this.accountId < 0)
         {
            throw new Error("Forbidden value (" + this.accountId + ") on element accountId.");
         }
         param1.writeInt(this.accountId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChatSmileyMessage(param1);
      }
      
      public function deserializeAs_ChatSmileyMessage(param1:ICustomDataInput) : void
      {
         this._entityIdFunc(param1);
         this._smileyIdFunc(param1);
         this._accountIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChatSmileyMessage(param1);
      }
      
      public function deserializeAsyncAs_ChatSmileyMessage(param1:FuncTree) : void
      {
         param1.addChild(this._entityIdFunc);
         param1.addChild(this._smileyIdFunc);
         param1.addChild(this._accountIdFunc);
      }
      
      private function _entityIdFunc(param1:ICustomDataInput) : void
      {
         this.entityId = param1.readDouble();
         if(this.entityId < -9007199254740990 || this.entityId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.entityId + ") on element of ChatSmileyMessage.entityId.");
         }
      }
      
      private function _smileyIdFunc(param1:ICustomDataInput) : void
      {
         this.smileyId = param1.readVarUhShort();
         if(this.smileyId < 0)
         {
            throw new Error("Forbidden value (" + this.smileyId + ") on element of ChatSmileyMessage.smileyId.");
         }
      }
      
      private function _accountIdFunc(param1:ICustomDataInput) : void
      {
         this.accountId = param1.readInt();
         if(this.accountId < 0)
         {
            throw new Error("Forbidden value (" + this.accountId + ") on element of ChatSmileyMessage.accountId.");
         }
      }
   }
}
