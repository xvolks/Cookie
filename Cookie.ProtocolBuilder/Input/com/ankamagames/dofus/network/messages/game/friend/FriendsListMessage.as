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
   public class FriendsListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 4002;
       
      
      private var _isInitialized:Boolean = false;
      
      public var friendsList:Vector.<FriendInformations>;
      
      private var _friendsListtree:FuncTree;
      
      public function FriendsListMessage()
      {
         this.friendsList = new Vector.<FriendInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 4002;
      }
      
      public function initFriendsListMessage(param1:Vector.<FriendInformations> = null) : FriendsListMessage
      {
         this.friendsList = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.friendsList = new Vector.<FriendInformations>();
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
         this.serializeAs_FriendsListMessage(param1);
      }
      
      public function serializeAs_FriendsListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.friendsList.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.friendsList.length)
         {
            param1.writeShort((this.friendsList[_loc2_] as FriendInformations).getTypeId());
            (this.friendsList[_loc2_] as FriendInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FriendsListMessage(param1);
      }
      
      public function deserializeAs_FriendsListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:FriendInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(FriendInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.friendsList.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FriendsListMessage(param1);
      }
      
      public function deserializeAsyncAs_FriendsListMessage(param1:FuncTree) : void
      {
         this._friendsListtree = param1.addChild(this._friendsListtreeFunc);
      }
      
      private function _friendsListtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._friendsListtree.addChild(this._friendsListFunc);
            _loc3_++;
         }
      }
      
      private function _friendsListFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:FriendInformations = ProtocolTypeManager.getInstance(FriendInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.friendsList.push(_loc3_);
      }
   }
}
