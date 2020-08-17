package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.DungeonPartyFinderPlayer;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DungeonPartyFinderRoomContentUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6250;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dungeonId:uint = 0;
      
      public var addedPlayers:Vector.<DungeonPartyFinderPlayer>;
      
      public var removedPlayersIds:Vector.<Number>;
      
      private var _addedPlayerstree:FuncTree;
      
      private var _removedPlayersIdstree:FuncTree;
      
      public function DungeonPartyFinderRoomContentUpdateMessage()
      {
         this.addedPlayers = new Vector.<DungeonPartyFinderPlayer>();
         this.removedPlayersIds = new Vector.<Number>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6250;
      }
      
      public function initDungeonPartyFinderRoomContentUpdateMessage(param1:uint = 0, param2:Vector.<DungeonPartyFinderPlayer> = null, param3:Vector.<Number> = null) : DungeonPartyFinderRoomContentUpdateMessage
      {
         this.dungeonId = param1;
         this.addedPlayers = param2;
         this.removedPlayersIds = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dungeonId = 0;
         this.addedPlayers = new Vector.<DungeonPartyFinderPlayer>();
         this.removedPlayersIds = new Vector.<Number>();
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
         this.serializeAs_DungeonPartyFinderRoomContentUpdateMessage(param1);
      }
      
      public function serializeAs_DungeonPartyFinderRoomContentUpdateMessage(param1:ICustomDataOutput) : void
      {
         if(this.dungeonId < 0)
         {
            throw new Error("Forbidden value (" + this.dungeonId + ") on element dungeonId.");
         }
         param1.writeVarShort(this.dungeonId);
         param1.writeShort(this.addedPlayers.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.addedPlayers.length)
         {
            (this.addedPlayers[_loc2_] as DungeonPartyFinderPlayer).serializeAs_DungeonPartyFinderPlayer(param1);
            _loc2_++;
         }
         param1.writeShort(this.removedPlayersIds.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.removedPlayersIds.length)
         {
            if(this.removedPlayersIds[_loc3_] < 0 || this.removedPlayersIds[_loc3_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.removedPlayersIds[_loc3_] + ") on element 3 (starting at 1) of removedPlayersIds.");
            }
            param1.writeVarLong(this.removedPlayersIds[_loc3_]);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DungeonPartyFinderRoomContentUpdateMessage(param1);
      }
      
      public function deserializeAs_DungeonPartyFinderRoomContentUpdateMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:DungeonPartyFinderPlayer = null;
         var _loc7_:Number = NaN;
         this._dungeonIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = new DungeonPartyFinderPlayer();
            _loc6_.deserialize(param1);
            this.addedPlayers.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readVarUhLong();
            if(_loc7_ < 0 || _loc7_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc7_ + ") on elements of removedPlayersIds.");
            }
            this.removedPlayersIds.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DungeonPartyFinderRoomContentUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_DungeonPartyFinderRoomContentUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._dungeonIdFunc);
         this._addedPlayerstree = param1.addChild(this._addedPlayerstreeFunc);
         this._removedPlayersIdstree = param1.addChild(this._removedPlayersIdstreeFunc);
      }
      
      private function _dungeonIdFunc(param1:ICustomDataInput) : void
      {
         this.dungeonId = param1.readVarUhShort();
         if(this.dungeonId < 0)
         {
            throw new Error("Forbidden value (" + this.dungeonId + ") on element of DungeonPartyFinderRoomContentUpdateMessage.dungeonId.");
         }
      }
      
      private function _addedPlayerstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._addedPlayerstree.addChild(this._addedPlayersFunc);
            _loc3_++;
         }
      }
      
      private function _addedPlayersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:DungeonPartyFinderPlayer = new DungeonPartyFinderPlayer();
         _loc2_.deserialize(param1);
         this.addedPlayers.push(_loc2_);
      }
      
      private function _removedPlayersIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._removedPlayersIdstree.addChild(this._removedPlayersIdsFunc);
            _loc3_++;
         }
      }
      
      private function _removedPlayersIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readVarUhLong();
         if(_loc2_ < 0 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of removedPlayersIds.");
         }
         this.removedPlayersIds.push(_loc2_);
      }
   }
}
