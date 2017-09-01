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
   public class GameFightStartingMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 700;
       
      
      private var _isInitialized:Boolean = false;
      
      public var fightType:uint = 0;
      
      public var attackerId:Number = 0;
      
      public var defenderId:Number = 0;
      
      public function GameFightStartingMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 700;
      }
      
      public function initGameFightStartingMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0) : GameFightStartingMessage
      {
         this.fightType = param1;
         this.attackerId = param2;
         this.defenderId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.fightType = 0;
         this.attackerId = 0;
         this.defenderId = 0;
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
         this.serializeAs_GameFightStartingMessage(param1);
      }
      
      public function serializeAs_GameFightStartingMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.fightType);
         if(this.attackerId < -9007199254740990 || this.attackerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.attackerId + ") on element attackerId.");
         }
         param1.writeDouble(this.attackerId);
         if(this.defenderId < -9007199254740990 || this.defenderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.defenderId + ") on element defenderId.");
         }
         param1.writeDouble(this.defenderId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightStartingMessage(param1);
      }
      
      public function deserializeAs_GameFightStartingMessage(param1:ICustomDataInput) : void
      {
         this._fightTypeFunc(param1);
         this._attackerIdFunc(param1);
         this._defenderIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightStartingMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightStartingMessage(param1:FuncTree) : void
      {
         param1.addChild(this._fightTypeFunc);
         param1.addChild(this._attackerIdFunc);
         param1.addChild(this._defenderIdFunc);
      }
      
      private function _fightTypeFunc(param1:ICustomDataInput) : void
      {
         this.fightType = param1.readByte();
         if(this.fightType < 0)
         {
            throw new Error("Forbidden value (" + this.fightType + ") on element of GameFightStartingMessage.fightType.");
         }
      }
      
      private function _attackerIdFunc(param1:ICustomDataInput) : void
      {
         this.attackerId = param1.readDouble();
         if(this.attackerId < -9007199254740990 || this.attackerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.attackerId + ") on element of GameFightStartingMessage.attackerId.");
         }
      }
      
      private function _defenderIdFunc(param1:ICustomDataInput) : void
      {
         this.defenderId = param1.readDouble();
         if(this.defenderId < -9007199254740990 || this.defenderId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.defenderId + ") on element of GameFightStartingMessage.defenderId.");
         }
      }
   }
}
