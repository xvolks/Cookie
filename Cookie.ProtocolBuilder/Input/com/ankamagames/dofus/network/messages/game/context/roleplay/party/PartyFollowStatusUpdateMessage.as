package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyFollowStatusUpdateMessage extends AbstractPartyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5581;
       
      
      private var _isInitialized:Boolean = false;
      
      public var success:Boolean = false;
      
      public var isFollowed:Boolean = false;
      
      public var followedId:Number = 0;
      
      public function PartyFollowStatusUpdateMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5581;
      }
      
      public function initPartyFollowStatusUpdateMessage(param1:uint = 0, param2:Boolean = false, param3:Boolean = false, param4:Number = 0) : PartyFollowStatusUpdateMessage
      {
         super.initAbstractPartyMessage(param1);
         this.success = param2;
         this.isFollowed = param3;
         this.followedId = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.success = false;
         this.isFollowed = false;
         this.followedId = 0;
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
         this.serializeAs_PartyFollowStatusUpdateMessage(param1);
      }
      
      public function serializeAs_PartyFollowStatusUpdateMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyMessage(param1);
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.success);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.isFollowed);
         param1.writeByte(_loc2_);
         if(this.followedId < 0 || this.followedId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.followedId + ") on element followedId.");
         }
         param1.writeVarLong(this.followedId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyFollowStatusUpdateMessage(param1);
      }
      
      public function deserializeAs_PartyFollowStatusUpdateMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.deserializeByteBoxes(param1);
         this._followedIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyFollowStatusUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyFollowStatusUpdateMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._followedIdFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.success = BooleanByteWrapper.getFlag(_loc2_,0);
         this.isFollowed = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _followedIdFunc(param1:ICustomDataInput) : void
      {
         this.followedId = param1.readVarUhLong();
         if(this.followedId < 0 || this.followedId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.followedId + ") on element of PartyFollowStatusUpdateMessage.followedId.");
         }
      }
   }
}
