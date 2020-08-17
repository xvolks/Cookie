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
   public class GameRolePlayArenaRegisterMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6280;
       
      
      private var _isInitialized:Boolean = false;
      
      public var battleMode:uint = 3;
      
      public function GameRolePlayArenaRegisterMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6280;
      }
      
      public function initGameRolePlayArenaRegisterMessage(param1:uint = 3) : GameRolePlayArenaRegisterMessage
      {
         this.battleMode = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
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
         this.serializeAs_GameRolePlayArenaRegisterMessage(param1);
      }
      
      public function serializeAs_GameRolePlayArenaRegisterMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.battleMode);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayArenaRegisterMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayArenaRegisterMessage(param1:ICustomDataInput) : void
      {
         this._battleModeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayArenaRegisterMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayArenaRegisterMessage(param1:FuncTree) : void
      {
         param1.addChild(this._battleModeFunc);
      }
      
      private function _battleModeFunc(param1:ICustomDataInput) : void
      {
         this.battleMode = param1.readInt();
         if(this.battleMode < 0)
         {
            throw new Error("Forbidden value (" + this.battleMode + ") on element of GameRolePlayArenaRegisterMessage.battleMode.");
         }
      }
   }
}
