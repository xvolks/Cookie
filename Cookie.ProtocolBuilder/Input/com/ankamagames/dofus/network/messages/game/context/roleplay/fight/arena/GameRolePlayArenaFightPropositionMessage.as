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
   public class GameRolePlayArenaFightPropositionMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6276;
       
      
      private var _isInitialized:Boolean = false;
      
      public var fightId:uint = 0;
      
      public var alliesId:Vector.<Number>;
      
      public var duration:uint = 0;
      
      private var _alliesIdtree:FuncTree;
      
      public function GameRolePlayArenaFightPropositionMessage()
      {
         this.alliesId = new Vector.<Number>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6276;
      }
      
      public function initGameRolePlayArenaFightPropositionMessage(param1:uint = 0, param2:Vector.<Number> = null, param3:uint = 0) : GameRolePlayArenaFightPropositionMessage
      {
         this.fightId = param1;
         this.alliesId = param2;
         this.duration = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.fightId = 0;
         this.alliesId = new Vector.<Number>();
         this.duration = 0;
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
         this.serializeAs_GameRolePlayArenaFightPropositionMessage(param1);
      }
      
      public function serializeAs_GameRolePlayArenaFightPropositionMessage(param1:ICustomDataOutput) : void
      {
         if(this.fightId < 0)
         {
            throw new Error("Forbidden value (" + this.fightId + ") on element fightId.");
         }
         param1.writeInt(this.fightId);
         param1.writeShort(this.alliesId.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.alliesId.length)
         {
            if(this.alliesId[_loc2_] < -9007199254740990 || this.alliesId[_loc2_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.alliesId[_loc2_] + ") on element 2 (starting at 1) of alliesId.");
            }
            param1.writeDouble(this.alliesId[_loc2_]);
            _loc2_++;
         }
         if(this.duration < 0)
         {
            throw new Error("Forbidden value (" + this.duration + ") on element duration.");
         }
         param1.writeVarShort(this.duration);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayArenaFightPropositionMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayArenaFightPropositionMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:Number = NaN;
         this._fightIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readDouble();
            if(_loc4_ < -9007199254740990 || _loc4_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of alliesId.");
            }
            this.alliesId.push(_loc4_);
            _loc3_++;
         }
         this._durationFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayArenaFightPropositionMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayArenaFightPropositionMessage(param1:FuncTree) : void
      {
         param1.addChild(this._fightIdFunc);
         this._alliesIdtree = param1.addChild(this._alliesIdtreeFunc);
         param1.addChild(this._durationFunc);
      }
      
      private function _fightIdFunc(param1:ICustomDataInput) : void
      {
         this.fightId = param1.readInt();
         if(this.fightId < 0)
         {
            throw new Error("Forbidden value (" + this.fightId + ") on element of GameRolePlayArenaFightPropositionMessage.fightId.");
         }
      }
      
      private function _alliesIdtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._alliesIdtree.addChild(this._alliesIdFunc);
            _loc3_++;
         }
      }
      
      private function _alliesIdFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readDouble();
         if(_loc2_ < -9007199254740990 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of alliesId.");
         }
         this.alliesId.push(_loc2_);
      }
      
      private function _durationFunc(param1:ICustomDataInput) : void
      {
         this.duration = param1.readVarUhShort();
         if(this.duration < 0)
         {
            throw new Error("Forbidden value (" + this.duration + ") on element of GameRolePlayArenaFightPropositionMessage.duration.");
         }
      }
   }
}
