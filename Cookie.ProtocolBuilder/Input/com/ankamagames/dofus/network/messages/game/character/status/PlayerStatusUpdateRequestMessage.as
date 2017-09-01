package com.ankamagames.dofus.network.messages.game.character.status
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.character.status.PlayerStatus;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PlayerStatusUpdateRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6387;
       
      
      private var _isInitialized:Boolean = false;
      
      public var status:PlayerStatus;
      
      private var _statustree:FuncTree;
      
      public function PlayerStatusUpdateRequestMessage()
      {
         this.status = new PlayerStatus();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6387;
      }
      
      public function initPlayerStatusUpdateRequestMessage(param1:PlayerStatus = null) : PlayerStatusUpdateRequestMessage
      {
         this.status = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.status = new PlayerStatus();
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
         this.serializeAs_PlayerStatusUpdateRequestMessage(param1);
      }
      
      public function serializeAs_PlayerStatusUpdateRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.status.getTypeId());
         this.status.serialize(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PlayerStatusUpdateRequestMessage(param1);
      }
      
      public function deserializeAs_PlayerStatusUpdateRequestMessage(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.status = ProtocolTypeManager.getInstance(PlayerStatus,_loc2_);
         this.status.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PlayerStatusUpdateRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_PlayerStatusUpdateRequestMessage(param1:FuncTree) : void
      {
         this._statustree = param1.addChild(this._statustreeFunc);
      }
      
      private function _statustreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.status = ProtocolTypeManager.getInstance(PlayerStatus,_loc2_);
         this.status.deserializeAsync(this._statustree);
      }
   }
}
