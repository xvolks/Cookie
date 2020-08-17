package com.ankamagames.dofus.network.messages.game.context.roleplay.stats
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class StatsUpgradeRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5610;
       
      
      private var _isInitialized:Boolean = false;
      
      public var useAdditionnal:Boolean = false;
      
      public var statId:uint = 11;
      
      public var boostPoint:uint = 0;
      
      public function StatsUpgradeRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5610;
      }
      
      public function initStatsUpgradeRequestMessage(param1:Boolean = false, param2:uint = 11, param3:uint = 0) : StatsUpgradeRequestMessage
      {
         this.useAdditionnal = param1;
         this.statId = param2;
         this.boostPoint = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.useAdditionnal = false;
         this.statId = 11;
         this.boostPoint = 0;
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
         this.serializeAs_StatsUpgradeRequestMessage(param1);
      }
      
      public function serializeAs_StatsUpgradeRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.useAdditionnal);
         param1.writeByte(this.statId);
         if(this.boostPoint < 0)
         {
            throw new Error("Forbidden value (" + this.boostPoint + ") on element boostPoint.");
         }
         param1.writeVarShort(this.boostPoint);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_StatsUpgradeRequestMessage(param1);
      }
      
      public function deserializeAs_StatsUpgradeRequestMessage(param1:ICustomDataInput) : void
      {
         this._useAdditionnalFunc(param1);
         this._statIdFunc(param1);
         this._boostPointFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_StatsUpgradeRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_StatsUpgradeRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._useAdditionnalFunc);
         param1.addChild(this._statIdFunc);
         param1.addChild(this._boostPointFunc);
      }
      
      private function _useAdditionnalFunc(param1:ICustomDataInput) : void
      {
         this.useAdditionnal = param1.readBoolean();
      }
      
      private function _statIdFunc(param1:ICustomDataInput) : void
      {
         this.statId = param1.readByte();
         if(this.statId < 0)
         {
            throw new Error("Forbidden value (" + this.statId + ") on element of StatsUpgradeRequestMessage.statId.");
         }
      }
      
      private function _boostPointFunc(param1:ICustomDataInput) : void
      {
         this.boostPoint = param1.readVarUhShort();
         if(this.boostPoint < 0)
         {
            throw new Error("Forbidden value (" + this.boostPoint + ") on element of StatsUpgradeRequestMessage.boostPoint.");
         }
      }
   }
}
