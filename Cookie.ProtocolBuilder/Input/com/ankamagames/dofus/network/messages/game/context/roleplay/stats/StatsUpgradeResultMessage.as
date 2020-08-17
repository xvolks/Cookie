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
   public class StatsUpgradeResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5609;
       
      
      private var _isInitialized:Boolean = false;
      
      public var result:int = 0;
      
      public var nbCharacBoost:uint = 0;
      
      public function StatsUpgradeResultMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5609;
      }
      
      public function initStatsUpgradeResultMessage(param1:int = 0, param2:uint = 0) : StatsUpgradeResultMessage
      {
         this.result = param1;
         this.nbCharacBoost = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.result = 0;
         this.nbCharacBoost = 0;
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
         this.serializeAs_StatsUpgradeResultMessage(param1);
      }
      
      public function serializeAs_StatsUpgradeResultMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.result);
         if(this.nbCharacBoost < 0)
         {
            throw new Error("Forbidden value (" + this.nbCharacBoost + ") on element nbCharacBoost.");
         }
         param1.writeVarShort(this.nbCharacBoost);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_StatsUpgradeResultMessage(param1);
      }
      
      public function deserializeAs_StatsUpgradeResultMessage(param1:ICustomDataInput) : void
      {
         this._resultFunc(param1);
         this._nbCharacBoostFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_StatsUpgradeResultMessage(param1);
      }
      
      public function deserializeAsyncAs_StatsUpgradeResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this._resultFunc);
         param1.addChild(this._nbCharacBoostFunc);
      }
      
      private function _resultFunc(param1:ICustomDataInput) : void
      {
         this.result = param1.readByte();
      }
      
      private function _nbCharacBoostFunc(param1:ICustomDataInput) : void
      {
         this.nbCharacBoost = param1.readVarUhShort();
         if(this.nbCharacBoost < 0)
         {
            throw new Error("Forbidden value (" + this.nbCharacBoost + ") on element of StatsUpgradeResultMessage.nbCharacBoost.");
         }
      }
   }
}
