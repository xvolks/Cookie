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
   public class DungeonPartyFinderRoomContentMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6247;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dungeonId:uint = 0;
      
      public var players:Vector.<DungeonPartyFinderPlayer>;
      
      private var _playerstree:FuncTree;
      
      public function DungeonPartyFinderRoomContentMessage()
      {
         this.players = new Vector.<DungeonPartyFinderPlayer>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6247;
      }
      
      public function initDungeonPartyFinderRoomContentMessage(param1:uint = 0, param2:Vector.<DungeonPartyFinderPlayer> = null) : DungeonPartyFinderRoomContentMessage
      {
         this.dungeonId = param1;
         this.players = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dungeonId = 0;
         this.players = new Vector.<DungeonPartyFinderPlayer>();
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
         this.serializeAs_DungeonPartyFinderRoomContentMessage(param1);
      }
      
      public function serializeAs_DungeonPartyFinderRoomContentMessage(param1:ICustomDataOutput) : void
      {
         if(this.dungeonId < 0)
         {
            throw new Error("Forbidden value (" + this.dungeonId + ") on element dungeonId.");
         }
         param1.writeVarShort(this.dungeonId);
         param1.writeShort(this.players.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.players.length)
         {
            (this.players[_loc2_] as DungeonPartyFinderPlayer).serializeAs_DungeonPartyFinderPlayer(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DungeonPartyFinderRoomContentMessage(param1);
      }
      
      public function deserializeAs_DungeonPartyFinderRoomContentMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:DungeonPartyFinderPlayer = null;
         this._dungeonIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new DungeonPartyFinderPlayer();
            _loc4_.deserialize(param1);
            this.players.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DungeonPartyFinderRoomContentMessage(param1);
      }
      
      public function deserializeAsyncAs_DungeonPartyFinderRoomContentMessage(param1:FuncTree) : void
      {
         param1.addChild(this._dungeonIdFunc);
         this._playerstree = param1.addChild(this._playerstreeFunc);
      }
      
      private function _dungeonIdFunc(param1:ICustomDataInput) : void
      {
         this.dungeonId = param1.readVarUhShort();
         if(this.dungeonId < 0)
         {
            throw new Error("Forbidden value (" + this.dungeonId + ") on element of DungeonPartyFinderRoomContentMessage.dungeonId.");
         }
      }
      
      private function _playerstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._playerstree.addChild(this._playersFunc);
            _loc3_++;
         }
      }
      
      private function _playersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:DungeonPartyFinderPlayer = new DungeonPartyFinderPlayer();
         _loc2_.deserialize(param1);
         this.players.push(_loc2_);
      }
   }
}
