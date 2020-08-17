package com.ankamagames.dofus.network.messages.game.character.stats
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class LifePointsRegenEndMessage extends UpdateLifePointsMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5686;
       
      
      private var _isInitialized:Boolean = false;
      
      public var lifePointsGained:uint = 0;
      
      public function LifePointsRegenEndMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5686;
      }
      
      public function initLifePointsRegenEndMessage(param1:uint = 0, param2:uint = 0, param3:uint = 0) : LifePointsRegenEndMessage
      {
         super.initUpdateLifePointsMessage(param1,param2);
         this.lifePointsGained = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.lifePointsGained = 0;
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
         this.serializeAs_LifePointsRegenEndMessage(param1);
      }
      
      public function serializeAs_LifePointsRegenEndMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_UpdateLifePointsMessage(param1);
         if(this.lifePointsGained < 0)
         {
            throw new Error("Forbidden value (" + this.lifePointsGained + ") on element lifePointsGained.");
         }
         param1.writeVarInt(this.lifePointsGained);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_LifePointsRegenEndMessage(param1);
      }
      
      public function deserializeAs_LifePointsRegenEndMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._lifePointsGainedFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_LifePointsRegenEndMessage(param1);
      }
      
      public function deserializeAsyncAs_LifePointsRegenEndMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._lifePointsGainedFunc);
      }
      
      private function _lifePointsGainedFunc(param1:ICustomDataInput) : void
      {
         this.lifePointsGained = param1.readVarUhInt();
         if(this.lifePointsGained < 0)
         {
            throw new Error("Forbidden value (" + this.lifePointsGained + ") on element of LifePointsRegenEndMessage.lifePointsGained.");
         }
      }
   }
}
