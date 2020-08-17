package com.ankamagames.dofus.network.messages.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.context.fight.FightStartingPositions;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MapFightStartPositionsUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6716;
       
      
      private var _isInitialized:Boolean = false;
      
      public var mapId:uint = 0;
      
      public var fightStartPositions:FightStartingPositions;
      
      private var _fightStartPositionstree:FuncTree;
      
      public function MapFightStartPositionsUpdateMessage()
      {
         this.fightStartPositions = new FightStartingPositions();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6716;
      }
      
      public function initMapFightStartPositionsUpdateMessage(param1:uint = 0, param2:FightStartingPositions = null) : MapFightStartPositionsUpdateMessage
      {
         this.mapId = param1;
         this.fightStartPositions = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.mapId = 0;
         this.fightStartPositions = new FightStartingPositions();
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
         this.serializeAs_MapFightStartPositionsUpdateMessage(param1);
      }
      
      public function serializeAs_MapFightStartPositionsUpdateMessage(param1:ICustomDataOutput) : void
      {
         if(this.mapId < 0)
         {
            throw new Error("Forbidden value (" + this.mapId + ") on element mapId.");
         }
         param1.writeInt(this.mapId);
         this.fightStartPositions.serializeAs_FightStartingPositions(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MapFightStartPositionsUpdateMessage(param1);
      }
      
      public function deserializeAs_MapFightStartPositionsUpdateMessage(param1:ICustomDataInput) : void
      {
         this._mapIdFunc(param1);
         this.fightStartPositions = new FightStartingPositions();
         this.fightStartPositions.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MapFightStartPositionsUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_MapFightStartPositionsUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._mapIdFunc);
         this._fightStartPositionstree = param1.addChild(this._fightStartPositionstreeFunc);
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
         if(this.mapId < 0)
         {
            throw new Error("Forbidden value (" + this.mapId + ") on element of MapFightStartPositionsUpdateMessage.mapId.");
         }
      }
      
      private function _fightStartPositionstreeFunc(param1:ICustomDataInput) : void
      {
         this.fightStartPositions = new FightStartingPositions();
         this.fightStartPositions.deserializeAsync(this._fightStartPositionstree);
      }
   }
}
