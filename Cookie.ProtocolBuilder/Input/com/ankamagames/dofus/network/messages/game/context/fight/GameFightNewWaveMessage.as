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
   public class GameFightNewWaveMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6490;
       
      
      private var _isInitialized:Boolean = false;
      
      public var id:uint = 0;
      
      public var teamId:uint = 2;
      
      public var nbTurnBeforeNextWave:int = 0;
      
      public function GameFightNewWaveMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6490;
      }
      
      public function initGameFightNewWaveMessage(param1:uint = 0, param2:uint = 2, param3:int = 0) : GameFightNewWaveMessage
      {
         this.id = param1;
         this.teamId = param2;
         this.nbTurnBeforeNextWave = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.id = 0;
         this.teamId = 2;
         this.nbTurnBeforeNextWave = 0;
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
         this.serializeAs_GameFightNewWaveMessage(param1);
      }
      
      public function serializeAs_GameFightNewWaveMessage(param1:ICustomDataOutput) : void
      {
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeByte(this.id);
         param1.writeByte(this.teamId);
         param1.writeShort(this.nbTurnBeforeNextWave);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightNewWaveMessage(param1);
      }
      
      public function deserializeAs_GameFightNewWaveMessage(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
         this._teamIdFunc(param1);
         this._nbTurnBeforeNextWaveFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightNewWaveMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightNewWaveMessage(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
         param1.addChild(this._teamIdFunc);
         param1.addChild(this._nbTurnBeforeNextWaveFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readByte();
         if(this.id < 0)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of GameFightNewWaveMessage.id.");
         }
      }
      
      private function _teamIdFunc(param1:ICustomDataInput) : void
      {
         this.teamId = param1.readByte();
         if(this.teamId < 0)
         {
            throw new Error("Forbidden value (" + this.teamId + ") on element of GameFightNewWaveMessage.teamId.");
         }
      }
      
      private function _nbTurnBeforeNextWaveFunc(param1:ICustomDataInput) : void
      {
         this.nbTurnBeforeNextWave = param1.readShort();
      }
   }
}
