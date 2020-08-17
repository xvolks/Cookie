package com.ankamagames.dofus.network.messages.game.context.roleplay.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayPlayerFightRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5731;
       
      
      private var _isInitialized:Boolean = false;
      
      public var targetId:Number = 0;
      
      public var targetCellId:int = 0;
      
      public var friendly:Boolean = false;
      
      public function GameRolePlayPlayerFightRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5731;
      }
      
      public function initGameRolePlayPlayerFightRequestMessage(param1:Number = 0, param2:int = 0, param3:Boolean = false) : GameRolePlayPlayerFightRequestMessage
      {
         this.targetId = param1;
         this.targetCellId = param2;
         this.friendly = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.targetId = 0;
         this.targetCellId = 0;
         this.friendly = false;
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
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayPlayerFightRequestMessage(param1);
      }
      
      public function serializeAs_GameRolePlayPlayerFightRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.targetId < 0 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeVarLong(this.targetId);
         if(this.targetCellId < -1 || this.targetCellId > 559)
         {
            throw new Error("Forbidden value (" + this.targetCellId + ") on element targetCellId.");
         }
         param1.writeShort(this.targetCellId);
         param1.writeBoolean(this.friendly);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayPlayerFightRequestMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayPlayerFightRequestMessage(param1:ICustomDataInput) : void
      {
         this._targetIdFunc(param1);
         this._targetCellIdFunc(param1);
         this._friendlyFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayPlayerFightRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayPlayerFightRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._targetCellIdFunc);
         param1.addChild(this._friendlyFunc);
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readVarUhLong();
         if(this.targetId < 0 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of GameRolePlayPlayerFightRequestMessage.targetId.");
         }
      }
      
      private function _targetCellIdFunc(param1:ICustomDataInput) : void
      {
         this.targetCellId = param1.readShort();
         if(this.targetCellId < -1 || this.targetCellId > 559)
         {
            throw new Error("Forbidden value (" + this.targetCellId + ") on element of GameRolePlayPlayerFightRequestMessage.targetCellId.");
         }
      }
      
      private function _friendlyFunc(param1:ICustomDataInput) : void
      {
         this.friendly = param1.readBoolean();
      }
   }
}
