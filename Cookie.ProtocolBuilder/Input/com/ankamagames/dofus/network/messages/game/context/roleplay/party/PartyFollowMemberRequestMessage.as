package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyFollowMemberRequestMessage extends AbstractPartyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5577;
       
      
      private var _isInitialized:Boolean = false;
      
      public var playerId:Number = 0;
      
      public function PartyFollowMemberRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5577;
      }
      
      public function initPartyFollowMemberRequestMessage(param1:uint = 0, param2:Number = 0) : PartyFollowMemberRequestMessage
      {
         super.initAbstractPartyMessage(param1);
         this.playerId = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.playerId = 0;
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
         this.serializeAs_PartyFollowMemberRequestMessage(param1);
      }
      
      public function serializeAs_PartyFollowMemberRequestMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyMessage(param1);
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyFollowMemberRequestMessage(param1);
      }
      
      public function deserializeAs_PartyFollowMemberRequestMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._playerIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyFollowMemberRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyFollowMemberRequestMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._playerIdFunc);
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of PartyFollowMemberRequestMessage.playerId.");
         }
      }
   }
}
