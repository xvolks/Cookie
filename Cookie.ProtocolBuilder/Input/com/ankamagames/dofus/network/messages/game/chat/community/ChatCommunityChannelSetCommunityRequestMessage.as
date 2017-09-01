package com.ankamagames.dofus.network.messages.game.chat.community
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChatCommunityChannelSetCommunityRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6729;
       
      
      private var _isInitialized:Boolean = false;
      
      public var communityId:int = 0;
      
      public function ChatCommunityChannelSetCommunityRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6729;
      }
      
      public function initChatCommunityChannelSetCommunityRequestMessage(param1:int = 0) : ChatCommunityChannelSetCommunityRequestMessage
      {
         this.communityId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.communityId = 0;
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
         this.serializeAs_ChatCommunityChannelSetCommunityRequestMessage(param1);
      }
      
      public function serializeAs_ChatCommunityChannelSetCommunityRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.communityId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChatCommunityChannelSetCommunityRequestMessage(param1);
      }
      
      public function deserializeAs_ChatCommunityChannelSetCommunityRequestMessage(param1:ICustomDataInput) : void
      {
         this._communityIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChatCommunityChannelSetCommunityRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_ChatCommunityChannelSetCommunityRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._communityIdFunc);
      }
      
      private function _communityIdFunc(param1:ICustomDataInput) : void
      {
         this.communityId = param1.readShort();
      }
   }
}
