package com.ankamagames.dofus.network.messages.game.context.roleplay.fight.arena
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayArenaRegistrationStatusMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6284;
       
      
      private var _isInitialized:Boolean = false;
      
      public var registered:Boolean = false;
      
      public var step:uint = 0;
      
      public var battleMode:uint = 3;
      
      public function GameRolePlayArenaRegistrationStatusMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6284;
      }
      
      public function initGameRolePlayArenaRegistrationStatusMessage(param1:Boolean = false, param2:uint = 0, param3:uint = 3) : GameRolePlayArenaRegistrationStatusMessage
      {
         this.registered = param1;
         this.step = param2;
         this.battleMode = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.registered = false;
         this.step = 0;
         this.battleMode = 3;
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
         this.serializeAs_GameRolePlayArenaRegistrationStatusMessage(param1);
      }
      
      public function serializeAs_GameRolePlayArenaRegistrationStatusMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.registered);
         param1.writeByte(this.step);
         param1.writeInt(this.battleMode);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayArenaRegistrationStatusMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayArenaRegistrationStatusMessage(param1:ICustomDataInput) : void
      {
         this._registeredFunc(param1);
         this._stepFunc(param1);
         this._battleModeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayArenaRegistrationStatusMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayArenaRegistrationStatusMessage(param1:FuncTree) : void
      {
         param1.addChild(this._registeredFunc);
         param1.addChild(this._stepFunc);
         param1.addChild(this._battleModeFunc);
      }
      
      private function _registeredFunc(param1:ICustomDataInput) : void
      {
         this.registered = param1.readBoolean();
      }
      
      private function _stepFunc(param1:ICustomDataInput) : void
      {
         this.step = param1.readByte();
         if(this.step < 0)
         {
            throw new Error("Forbidden value (" + this.step + ") on element of GameRolePlayArenaRegistrationStatusMessage.step.");
         }
      }
      
      private function _battleModeFunc(param1:ICustomDataInput) : void
      {
         this.battleMode = param1.readInt();
         if(this.battleMode < 0)
         {
            throw new Error("Forbidden value (" + this.battleMode + ") on element of GameRolePlayArenaRegistrationStatusMessage.battleMode.");
         }
      }
   }
}
