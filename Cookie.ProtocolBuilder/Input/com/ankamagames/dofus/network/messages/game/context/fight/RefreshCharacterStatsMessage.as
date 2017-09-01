package com.ankamagames.dofus.network.messages.game.context.fight
{
   import com.ankamagames.dofus.network.types.game.context.fight.GameFightMinimalStats;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class RefreshCharacterStatsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6699;
       
      
      private var _isInitialized:Boolean = false;
      
      public var fighterId:Number = 0;
      
      public var stats:GameFightMinimalStats;
      
      private var _statstree:FuncTree;
      
      public function RefreshCharacterStatsMessage()
      {
         this.stats = new GameFightMinimalStats();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6699;
      }
      
      public function initRefreshCharacterStatsMessage(param1:Number = 0, param2:GameFightMinimalStats = null) : RefreshCharacterStatsMessage
      {
         this.fighterId = param1;
         this.stats = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.fighterId = 0;
         this.stats = new GameFightMinimalStats();
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
         this.serializeAs_RefreshCharacterStatsMessage(param1);
      }
      
      public function serializeAs_RefreshCharacterStatsMessage(param1:ICustomDataOutput) : void
      {
         if(this.fighterId < -9007199254740990 || this.fighterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.fighterId + ") on element fighterId.");
         }
         param1.writeDouble(this.fighterId);
         this.stats.serializeAs_GameFightMinimalStats(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_RefreshCharacterStatsMessage(param1);
      }
      
      public function deserializeAs_RefreshCharacterStatsMessage(param1:ICustomDataInput) : void
      {
         this._fighterIdFunc(param1);
         this.stats = new GameFightMinimalStats();
         this.stats.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_RefreshCharacterStatsMessage(param1);
      }
      
      public function deserializeAsyncAs_RefreshCharacterStatsMessage(param1:FuncTree) : void
      {
         param1.addChild(this._fighterIdFunc);
         this._statstree = param1.addChild(this._statstreeFunc);
      }
      
      private function _fighterIdFunc(param1:ICustomDataInput) : void
      {
         this.fighterId = param1.readDouble();
         if(this.fighterId < -9007199254740990 || this.fighterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.fighterId + ") on element of RefreshCharacterStatsMessage.fighterId.");
         }
      }
      
      private function _statstreeFunc(param1:ICustomDataInput) : void
      {
         this.stats = new GameFightMinimalStats();
         this.stats.deserializeAsync(this._statstree);
      }
   }
}
