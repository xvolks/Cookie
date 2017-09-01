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
   public class GameRolePlayFightRequestCanceledMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5822;
       
      
      private var _isInitialized:Boolean = false;
      
      public var fightId:int = 0;
      
      public var sourceId:Number = 0;
      
      public var targetId:Number = 0;
      
      public function GameRolePlayFightRequestCanceledMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5822;
      }
      
      public function initGameRolePlayFightRequestCanceledMessage(param1:int = 0, param2:Number = 0, param3:Number = 0) : GameRolePlayFightRequestCanceledMessage
      {
         this.fightId = param1;
         this.sourceId = param2;
         this.targetId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.fightId = 0;
         this.sourceId = 0;
         this.targetId = 0;
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
         this.serializeAs_GameRolePlayFightRequestCanceledMessage(param1);
      }
      
      public function serializeAs_GameRolePlayFightRequestCanceledMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.fightId);
         if(this.sourceId < -9007199254740990 || this.sourceId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sourceId + ") on element sourceId.");
         }
         param1.writeDouble(this.sourceId);
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeDouble(this.targetId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayFightRequestCanceledMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayFightRequestCanceledMessage(param1:ICustomDataInput) : void
      {
         this._fightIdFunc(param1);
         this._sourceIdFunc(param1);
         this._targetIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayFightRequestCanceledMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayFightRequestCanceledMessage(param1:FuncTree) : void
      {
         param1.addChild(this._fightIdFunc);
         param1.addChild(this._sourceIdFunc);
         param1.addChild(this._targetIdFunc);
      }
      
      private function _fightIdFunc(param1:ICustomDataInput) : void
      {
         this.fightId = param1.readInt();
      }
      
      private function _sourceIdFunc(param1:ICustomDataInput) : void
      {
         this.sourceId = param1.readDouble();
         if(this.sourceId < -9007199254740990 || this.sourceId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.sourceId + ") on element of GameRolePlayFightRequestCanceledMessage.sourceId.");
         }
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readDouble();
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of GameRolePlayFightRequestCanceledMessage.targetId.");
         }
      }
   }
}
