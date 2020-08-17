package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightJoinMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 702;
       
      
      private var _isInitialized:Boolean = false;
      
      public var isTeamPhase:Boolean = false;
      
      public var canBeCancelled:Boolean = false;
      
      public var canSayReady:Boolean = false;
      
      public var isFightStarted:Boolean = false;
      
      public var timeMaxBeforeFightStart:uint = 0;
      
      public var fightType:uint = 0;
      
      public function GameFightJoinMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 702;
      }
      
      public function initGameFightJoinMessage(param1:Boolean = false, param2:Boolean = false, param3:Boolean = false, param4:Boolean = false, param5:uint = 0, param6:uint = 0) : GameFightJoinMessage
      {
         this.isTeamPhase = param1;
         this.canBeCancelled = param2;
         this.canSayReady = param3;
         this.isFightStarted = param4;
         this.timeMaxBeforeFightStart = param5;
         this.fightType = param6;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.isTeamPhase = false;
         this.canBeCancelled = false;
         this.canSayReady = false;
         this.isFightStarted = false;
         this.timeMaxBeforeFightStart = 0;
         this.fightType = 0;
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
         this.serializeAs_GameFightJoinMessage(param1);
      }
      
      public function serializeAs_GameFightJoinMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.isTeamPhase);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.canBeCancelled);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,2,this.canSayReady);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,3,this.isFightStarted);
         param1.writeByte(_loc2_);
         if(this.timeMaxBeforeFightStart < 0)
         {
            throw new Error("Forbidden value (" + this.timeMaxBeforeFightStart + ") on element timeMaxBeforeFightStart.");
         }
         param1.writeShort(this.timeMaxBeforeFightStart);
         param1.writeByte(this.fightType);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightJoinMessage(param1);
      }
      
      public function deserializeAs_GameFightJoinMessage(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
         this._timeMaxBeforeFightStartFunc(param1);
         this._fightTypeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightJoinMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightJoinMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._timeMaxBeforeFightStartFunc);
         param1.addChild(this._fightTypeFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.isTeamPhase = BooleanByteWrapper.getFlag(_loc2_,0);
         this.canBeCancelled = BooleanByteWrapper.getFlag(_loc2_,1);
         this.canSayReady = BooleanByteWrapper.getFlag(_loc2_,2);
         this.isFightStarted = BooleanByteWrapper.getFlag(_loc2_,3);
      }
      
      private function _timeMaxBeforeFightStartFunc(param1:ICustomDataInput) : void
      {
         this.timeMaxBeforeFightStart = param1.readShort();
         if(this.timeMaxBeforeFightStart < 0)
         {
            throw new Error("Forbidden value (" + this.timeMaxBeforeFightStart + ") on element of GameFightJoinMessage.timeMaxBeforeFightStart.");
         }
      }
      
      private function _fightTypeFunc(param1:ICustomDataInput) : void
      {
         this.fightType = param1.readByte();
         if(this.fightType < 0)
         {
            throw new Error("Forbidden value (" + this.fightType + ") on element of GameFightJoinMessage.fightType.");
         }
      }
   }
}
