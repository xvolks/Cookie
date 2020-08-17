package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameFightTurnResumeMessage extends GameFightTurnStartMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6307;
       
      
      private var _isInitialized:Boolean = false;
      
      public var remainingTime:uint = 0;
      
      public function GameFightTurnResumeMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6307;
      }
      
      public function initGameFightTurnResumeMessage(param1:Number = 0, param2:uint = 0, param3:uint = 0) : GameFightTurnResumeMessage
      {
         super.initGameFightTurnStartMessage(param1,param2);
         this.remainingTime = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.remainingTime = 0;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightTurnResumeMessage(param1);
      }
      
      public function serializeAs_GameFightTurnResumeMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightTurnStartMessage(param1);
         if(this.remainingTime < 0)
         {
            throw new Error("Forbidden value (" + this.remainingTime + ") on element remainingTime.");
         }
         param1.writeVarInt(this.remainingTime);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightTurnResumeMessage(param1);
      }
      
      public function deserializeAs_GameFightTurnResumeMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._remainingTimeFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightTurnResumeMessage(param1);
      }
      
      public function deserializeAsyncAs_GameFightTurnResumeMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._remainingTimeFunc);
      }
      
      private function _remainingTimeFunc(param1:ICustomDataInput) : void
      {
         this.remainingTime = param1.readVarUhInt();
         if(this.remainingTime < 0)
         {
            throw new Error("Forbidden value (" + this.remainingTime + ") on element of GameFightTurnResumeMessage.remainingTime.");
         }
      }
   }
}
