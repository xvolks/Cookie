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
   public class GameFightPlacementPossiblePositionsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 703;
       
      
      private var _isInitialized:Boolean = false;
      
      public var positionsForChallengers:Vector.<uint>;
      
      public var positionsForDefenders:Vector.<uint>;
      
      public var teamNumber:uint = 2;
      
      private var _positionsForChallengerstree:FuncTree;
      
      private var _positionsForDefenderstree:FuncTree;
      
      public function GameFightPlacementPossiblePositionsMessage()
      {
         this.positionsForChallengers = new Vector.<uint>();
         this.positionsForDefenders = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 703;
      }
      
      public function initGameFightPlacementPossiblePositionsMessage(param1:Vector.<uint> = null, param2:Vector.<uint> = null, param3:uint = 2) : GameFightPlacementPossiblePositionsMessage
      {
         this.positionsForChallengers = param1;
         this.positionsForDefenders = param2;
         this.teamNumber = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.positionsForChallengers = new Vector.<uint>();
         this.positionsForDefenders = new Vector.<uint>();
         this.teamNumber = 2;
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
         this.serializeAs_GameFightPlacementPossiblePositionsMessage(param1);
      }
      
      public function serializeAs_GameFightPlacementPossiblePositionsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.positionsForChallengers.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.positionsForChallengers.length)
         {
            if(this.positionsForChallengers[_loc2_] < 0 || this.positionsForChallengers[_loc2_] > 559)
            {
               throw new Error("Forbidden value (" + this.positionsForChallengers[_loc2_] + ") on element 1 (starting at 1) of positionsForChallengers.");
            }
            param1.writeVarShort(this.positionsForChallengers[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.positionsForDefenders.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.positionsForDefenders.length)
         {
            if(this.positionsForDefenders[_loc3_] < 0 || this.positionsForDefenders[_loc3_] > 559)
            {
               throw new Error("Forbidden value (" + this.positionsForDefenders[_loc3_] + ") on element 2 (starting at 1) of positionsForDefenders.");
            }
            param1.writeVarShort(this.positionsForDefenders[_loc3_]);
            _loc3_++;
         }
         param1.writeByte(this.teamNumber);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightPlacementPossiblePositionsMessage(param1);
      }
      
      public function deserializeAs_GameFightPlacementPossiblePositionsMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readVarUhShort();
            if(_loc6_ < 0 || _loc6_ > 559)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of positionsForChallengers.");
            }
            this.positionsForChallengers.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readVarUhShort();
            if(_loc7_ < 0 || _loc7_ > 559)
            {
               throw new Error("Forbidden value (" + _loc7_ + ") on elements of positionsForDefenders.");
            }
            this.positionsForDefenders.push(_loc7_);
            _loc5_++;
         }
         this._teamNumberFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightPlacementPossiblePositionsMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightPlacementPossiblePositionsMessage(param1:FuncTree) : void
      {
         this._positionsForChallengerstree = param1.addChild(this._positionsForChallengerstreeFunc);
         this._positionsForDefenderstree = param1.addChild(this._positionsForDefenderstreeFunc);
         param1.addChild(this._teamNumberFunc);
      }
      
      private function _positionsForChallengerstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._positionsForChallengerstree.addChild(this._positionsForChallengersFunc);
            _loc3_++;
         }
      }
      
      private function _positionsForChallengersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0 || _loc2_ > 559)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of positionsForChallengers.");
         }
         this.positionsForChallengers.push(_loc2_);
      }
      
      private function _positionsForDefenderstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._positionsForDefenderstree.addChild(this._positionsForDefendersFunc);
            _loc3_++;
         }
      }
      
      private function _positionsForDefendersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0 || _loc2_ > 559)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of positionsForDefenders.");
         }
         this.positionsForDefenders.push(_loc2_);
      }
      
      private function _teamNumberFunc(param1:ICustomDataInput) : void
      {
         this.teamNumber = param1.readByte();
         if(this.teamNumber < 0)
         {
            throw new Error("Forbidden value (" + this.teamNumber + ") on element of GameFightPlacementPossiblePositionsMessage.teamNumber.");
         }
      }
   }
}
