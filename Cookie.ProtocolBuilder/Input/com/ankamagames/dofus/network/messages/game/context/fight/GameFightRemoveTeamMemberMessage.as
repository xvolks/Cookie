package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightRemoveTeamMemberMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 711;
       
      
      private var _isInitialized:Boolean = false;
      
      public var fightId:uint = 0;
      
      public var teamId:uint = 2;
      
      public var charId:Number = 0;
      
      public function GameFightRemoveTeamMemberMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 711;
      }
      
      public function initGameFightRemoveTeamMemberMessage(param1:uint = 0, param2:uint = 2, param3:Number = 0) : GameFightRemoveTeamMemberMessage
      {
         this.fightId = param1;
         this.teamId = param2;
         this.charId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.fightId = 0;
         this.teamId = 2;
         this.charId = 0;
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
         this.serializeAs_GameFightRemoveTeamMemberMessage(param1);
      }
      
      public function serializeAs_GameFightRemoveTeamMemberMessage(param1:ICustomDataOutput) : void
      {
         if(this.fightId < 0)
         {
            throw new Error("Forbidden value (" + this.fightId + ") on element fightId.");
         }
         param1.writeShort(this.fightId);
         param1.writeByte(this.teamId);
         if(this.charId < -9007199254740990 || this.charId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.charId + ") on element charId.");
         }
         param1.writeDouble(this.charId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightRemoveTeamMemberMessage(param1);
      }
      
      public function deserializeAs_GameFightRemoveTeamMemberMessage(param1:ICustomDataInput) : void
      {
         this._fightIdFunc(param1);
         this._teamIdFunc(param1);
         this._charIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightRemoveTeamMemberMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightRemoveTeamMemberMessage(param1:FuncTree) : void
      {
         param1.addChild(this._fightIdFunc);
         param1.addChild(this._teamIdFunc);
         param1.addChild(this._charIdFunc);
      }
      
      private function _fightIdFunc(param1:ICustomDataInput) : void
      {
         this.fightId = param1.readShort();
         if(this.fightId < 0)
         {
            throw new Error("Forbidden value (" + this.fightId + ") on element of GameFightRemoveTeamMemberMessage.fightId.");
         }
      }
      
      private function _teamIdFunc(param1:ICustomDataInput) : void
      {
         this.teamId = param1.readByte();
         if(this.teamId < 0)
         {
            throw new Error("Forbidden value (" + this.teamId + ") on element of GameFightRemoveTeamMemberMessage.teamId.");
         }
      }
      
      private function _charIdFunc(param1:ICustomDataInput) : void
      {
         this.charId = param1.readDouble();
         if(this.charId < -9007199254740990 || this.charId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.charId + ") on element of GameFightRemoveTeamMemberMessage.charId.");
         }
      }
   }
}
