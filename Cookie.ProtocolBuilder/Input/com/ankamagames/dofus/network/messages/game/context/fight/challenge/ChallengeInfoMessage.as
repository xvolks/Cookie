package com.ankamagames.dofus.network.messages.game.context.fight.challenge
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ChallengeInfoMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6022;
       
      
      private var _isInitialized:Boolean = false;
      
      public var challengeId:uint = 0;
      
      public var targetId:Number = 0;
      
      public var xpBonus:uint = 0;
      
      public var dropBonus:uint = 0;
      
      public function ChallengeInfoMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6022;
      }
      
      public function initChallengeInfoMessage(param1:uint = 0, param2:Number = 0, param3:uint = 0, param4:uint = 0) : ChallengeInfoMessage
      {
         this.challengeId = param1;
         this.targetId = param2;
         this.xpBonus = param3;
         this.dropBonus = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.challengeId = 0;
         this.targetId = 0;
         this.xpBonus = 0;
         this.dropBonus = 0;
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
         this.serializeAs_ChallengeInfoMessage(param1);
      }
      
      public function serializeAs_ChallengeInfoMessage(param1:ICustomDataOutput) : void
      {
         if(this.challengeId < 0)
         {
            throw new Error("Forbidden value (" + this.challengeId + ") on element challengeId.");
         }
         param1.writeVarShort(this.challengeId);
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeDouble(this.targetId);
         if(this.xpBonus < 0)
         {
            throw new Error("Forbidden value (" + this.xpBonus + ") on element xpBonus.");
         }
         param1.writeVarInt(this.xpBonus);
         if(this.dropBonus < 0)
         {
            throw new Error("Forbidden value (" + this.dropBonus + ") on element dropBonus.");
         }
         param1.writeVarInt(this.dropBonus);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChallengeInfoMessage(param1);
      }
      
      public function deserializeAs_ChallengeInfoMessage(param1:ICustomDataInput) : void
      {
         this._challengeIdFunc(param1);
         this._targetIdFunc(param1);
         this._xpBonusFunc(param1);
         this._dropBonusFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChallengeInfoMessage(param1);
      }
      
      public function deserializeAsyncAs_ChallengeInfoMessage(param1:FuncTree) : void
      {
         param1.addChild(this._challengeIdFunc);
         param1.addChild(this._targetIdFunc);
         param1.addChild(this._xpBonusFunc);
         param1.addChild(this._dropBonusFunc);
      }
      
      private function _challengeIdFunc(param1:ICustomDataInput) : void
      {
         this.challengeId = param1.readVarUhShort();
         if(this.challengeId < 0)
         {
            throw new Error("Forbidden value (" + this.challengeId + ") on element of ChallengeInfoMessage.challengeId.");
         }
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readDouble();
         if(this.targetId < -9007199254740990 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of ChallengeInfoMessage.targetId.");
         }
      }
      
      private function _xpBonusFunc(param1:ICustomDataInput) : void
      {
         this.xpBonus = param1.readVarUhInt();
         if(this.xpBonus < 0)
         {
            throw new Error("Forbidden value (" + this.xpBonus + ") on element of ChallengeInfoMessage.xpBonus.");
         }
      }
      
      private function _dropBonusFunc(param1:ICustomDataInput) : void
      {
         this.dropBonus = param1.readVarUhInt();
         if(this.dropBonus < 0)
         {
            throw new Error("Forbidden value (" + this.dropBonus + ") on element of ChallengeInfoMessage.dropBonus.");
         }
      }
   }
}
