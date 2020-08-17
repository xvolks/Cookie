package com.ankamagames.dofus.network.messages.game.friend
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.friend.FriendInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class FriendAddedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5599;
       
      
      private var _isInitialized:Boolean = false;
      
      public var friendAdded:FriendInformations;
      
      private var _friendAddedtree:FuncTree;
      
      public function FriendAddedMessage()
      {
         this.friendAdded = new FriendInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5599;
      }
      
      public function initFriendAddedMessage(param1:FriendInformations = null) : FriendAddedMessage
      {
         this.friendAdded = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.friendAdded = new FriendInformations();
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
         this.serializeAs_FriendAddedMessage(param1);
      }
      
      public function serializeAs_FriendAddedMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.friendAdded.getTypeId());
         this.friendAdded.serialize(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FriendAddedMessage(param1);
      }
      
      public function deserializeAs_FriendAddedMessage(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.friendAdded = ProtocolTypeManager.getInstance(FriendInformations,_loc2_);
         this.friendAdded.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FriendAddedMessage(param1);
      }
      
      public function deserializeAsyncAs_FriendAddedMessage(param1:FuncTree) : void
      {
         this._friendAddedtree = param1.addChild(this._friendAddedtreeFunc);
      }
      
      private function _friendAddedtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.friendAdded = ProtocolTypeManager.getInstance(FriendInformations,_loc2_);
         this.friendAdded.deserializeAsync(this._friendAddedtree);
      }
   }
}
