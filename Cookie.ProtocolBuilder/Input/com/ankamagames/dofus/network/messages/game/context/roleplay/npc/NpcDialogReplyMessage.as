package com.ankamagames.dofus.network.messages.game.context.roleplay.npc
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class NpcDialogReplyMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5616;
       
      
      private var _isInitialized:Boolean = false;
      
      public var replyId:uint = 0;
      
      public function NpcDialogReplyMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5616;
      }
      
      public function initNpcDialogReplyMessage(param1:uint = 0) : NpcDialogReplyMessage
      {
         this.replyId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.replyId = 0;
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
         this.serializeAs_NpcDialogReplyMessage(param1);
      }
      
      public function serializeAs_NpcDialogReplyMessage(param1:ICustomDataOutput) : void
      {
         if(this.replyId < 0)
         {
            throw new Error("Forbidden value (" + this.replyId + ") on element replyId.");
         }
         param1.writeVarInt(this.replyId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_NpcDialogReplyMessage(param1);
      }
      
      public function deserializeAs_NpcDialogReplyMessage(param1:ICustomDataInput) : void
      {
         this._replyIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_NpcDialogReplyMessage(param1);
      }
      
      public function deserializeAsyncAs_NpcDialogReplyMessage(param1:FuncTree) : void
      {
         param1.addChild(this._replyIdFunc);
      }
      
      private function _replyIdFunc(param1:ICustomDataInput) : void
      {
         this.replyId = param1.readVarUhInt();
         if(this.replyId < 0)
         {
            throw new Error("Forbidden value (" + this.replyId + ") on element of NpcDialogReplyMessage.replyId.");
         }
      }
   }
}
