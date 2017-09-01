package com.ankamagames.dofus.network.messages.game.actions.fight
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameActionFightLifeAndShieldPointsLostMessage extends GameActionFightLifePointsLostMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6310;
       
      
      private var _isInitialized:Boolean = false;
      
      public var shieldLoss:uint = 0;
      
      public function GameActionFightLifeAndShieldPointsLostMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6310;
      }
      
      public function initGameActionFightLifeAndShieldPointsLostMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0, param4:uint = 0, param5:uint = 0, param6:uint = 0) : GameActionFightLifeAndShieldPointsLostMessage
      {
         super.initGameActionFightLifePointsLostMessage(param1,param2,param3,param4,param5);
         this.shieldLoss = param6;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.shieldLoss = 0;
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
         this.serializeAs_GameActionFightLifeAndShieldPointsLostMessage(param1);
      }
      
      public function serializeAs_GameActionFightLifeAndShieldPointsLostMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameActionFightLifePointsLostMessage(param1);
         if(this.shieldLoss < 0)
         {
            throw new Error("Forbidden value (" + this.shieldLoss + ") on element shieldLoss.");
         }
         param1.writeVarShort(this.shieldLoss);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionFightLifeAndShieldPointsLostMessage(param1);
      }
      
      public function deserializeAs_GameActionFightLifeAndShieldPointsLostMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._shieldLossFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionFightLifeAndShieldPointsLostMessage(param1);
      }
      
      public function deserializeAsyncAs_GameActionFightLifeAndShieldPointsLostMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._shieldLossFunc);
      }
      
      private function _shieldLossFunc(param1:ICustomDataInput) : void
      {
         this.shieldLoss = param1.readVarUhShort();
         if(this.shieldLoss < 0)
         {
            throw new Error("Forbidden value (" + this.shieldLoss + ") on element of GameActionFightLifeAndShieldPointsLostMessage.shieldLoss.");
         }
      }
   }
}
